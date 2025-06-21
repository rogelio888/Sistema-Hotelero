using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ReservaDatos
    {
        private Conexion conexion = new Conexion();  // Instancia de la clase Conexion

        public DataRow ObtenerDatosReservaPorId(int idReserva)
        {
            string query = @"
        SELECT 
            R.ReservaID,
            H.Nombre AS NombreHuesped,
            H.NumeroDocumento,
            R.FechaReserva,
            R.FechaEntrada,
            R.FechaSalida,
            R.CantidadPersonas,
            R.EstadoReserva,
            R.Observaciones,
            ISNULL(SUM(DR.Total), 0) AS TotalReserva,
            E.Nombre + ' ' + E.Apellido AS Responsable,
            MP.NombreMetodo
        FROM Reserva R
        INNER JOIN Huespedes H ON R.HuespedID = H.HuespedID
        INNER JOIN Empleado E ON R.EmpleadoID = E.EmpleadoID
        LEFT JOIN DetalleReserva DR ON R.ReservaID = DR.ReservaID
        LEFT JOIN MetodoPago MP ON R.MetodoPagoID = MP.MetodoPagoID
        WHERE R.ReservaID = @idReserva
        GROUP BY 
            R.ReservaID, H.Nombre, H.NumeroDocumento, R.FechaReserva, R.FechaEntrada, R.FechaSalida, 
            R.CantidadPersonas, R.EstadoReserva, R.Observaciones, E.Nombre, E.Apellido, MP.NombreMetodo";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idReserva", idReserva);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                else
                    return null;
            }
        }

        public DataTable ObtenerHabitacionesPorReserva(int idReserva)
        {
            string query = @"
        SELECT 
            H.NumeroHabitacion AS Habitacion,
            H.Piso,
            HT.Nombre AS Hotel,
            TH.Descripcion AS TipoHabitacion,
            DR.PrecioNoche AS Costo
        FROM DetalleReserva DR
        INNER JOIN Habitaciones H ON DR.HabitacionID = H.HabitacionID
        INNER JOIN Hoteles HT ON H.HotelID = HT.HotelID
        INNER JOIN TipoHabitacion TH ON H.TipoHabitacionID = TH.TipoHabitacionID
        WHERE DR.ReservaID = @idReserva AND DR.HabitacionID IS NOT NULL";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idReserva", idReserva);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ObtenerServiciosPorReserva(int idReserva)
        {
            string query = @"
        SELECT 
            S.NombreServicio AS NombreServicio,
            COUNT(*) AS Cantidad,
            DATEDIFF(DAY, R.FechaEntrada, R.FechaSalida) AS Estancia,
            SUM(DR.Total) AS Costo
        FROM DetalleReserva DR
        INNER JOIN Servicios S ON DR.ServicioID = S.ServicioID
        INNER JOIN Reserva R ON DR.ReservaID = R.ReservaID
        WHERE DR.ReservaID = @idReserva AND DR.ServicioID IS NOT NULL
        GROUP BY S.NombreServicio, R.FechaEntrada, R.FechaSalida";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idReserva", idReserva);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ObtenerResumenReservas()
        {
            string query = @"
            SELECT 
                R.ReservaID,
                H.Nombre AS NombreHuesped,
                H.NumeroDocumento,
                R.FechaReserva,
                R.FechaEntrada,
                R.FechaSalida,
                (SELECT COUNT(*) FROM DetalleReserva DR WHERE DR.ReservaID = R.ReservaID AND DR.HabitacionID IS NOT NULL) AS CantHabitaciones,
                (SELECT COUNT(*) FROM DetalleReserva DR WHERE DR.ReservaID = R.ReservaID AND DR.ServicioID IS NOT NULL) AS CantServicios,
                ISNULL(SUM(DR.Total), 0) AS MontoTotal,
                E.nombre + ' ' + E.apellido AS Responsable
            FROM Reserva R
            INNER JOIN Huespedes H ON R.HuespedID = H.HuespedID
            INNER JOIN Empleado E ON R.EmpleadoID = E.EmpleadoID
            LEFT JOIN DetalleReserva DR ON R.ReservaID = DR.ReservaID
            GROUP BY 
                R.ReservaID, H.Nombre, H.NumeroDocumento, R.FechaReserva, R.FechaEntrada, R.FechaSalida, E.nombre, E.apellido
            ORDER BY R.ReservaID DESC";
            DataTable dt = new DataTable();
            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable CargarMetodoPago()
        {
            string query = "SELECT MetodoPagoID, NombreMetodo FROM MetodoPago";
            DataTable dt = new DataTable();

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;  // Devolver el DataTable con los métodos de pago
        }

        public DataTable ObtenerUltimasReservas()
        {
            // Crear el DataTable donde se almacenarán los resultados
            DataTable dt = new DataTable();

            string query = @"
            SELECT 
                R.ReservaID,  -- Agregamos ReservaID
                H.Nombre AS HuespedNombre, 
                R.FechaEntrada, 
                R.EstadoReserva, 
                D.Total AS MontoTotal
            FROM 
                Reserva R
            JOIN 
                Huespedes H ON R.HuespedID = H.HuespedID
            JOIN 
                DetalleReserva D ON R.ReservaID = D.ReservaID
            ORDER BY 
                R.FechaReserva DESC
            OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";

            // Ejecutar la consulta y llenar el DataTable
            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;  // Devolver el DataTable con los resultados
        }


        public int GuardarReserva(int huespedID, int empleadoID, DateTime fechaReserva, DateTime fechaEntrada, DateTime fechaSalida, string estadoReserva, string observaciones, int metodoPagoID, int cantidadPersonas)
        {
            string query = @"
            INSERT INTO Reserva (HuespedID, EmpleadoID, FechaReserva, FechaEntrada, FechaSalida, EstadoReserva, Observaciones, MetodoPagoID, CantidadPersonas)
            VALUES (@HuespedID, @EmpleadoID, @FechaReserva, @FechaEntrada, @FechaSalida, @EstadoReserva, @Observaciones, @MetodoPagoID, @CantidadPersonas);
            SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HuespedID", huespedID);
                cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                cmd.Parameters.AddWithValue("@FechaReserva", fechaReserva);
                cmd.Parameters.AddWithValue("@FechaEntrada", fechaEntrada);
                cmd.Parameters.AddWithValue("@FechaSalida", fechaSalida);
                cmd.Parameters.AddWithValue("@EstadoReserva", estadoReserva);
                cmd.Parameters.AddWithValue("@Observaciones", observaciones);
                cmd.Parameters.AddWithValue("@MetodoPagoID", metodoPagoID);
                cmd.Parameters.AddWithValue("@CantidadPersonas", cantidadPersonas);

                conn.Open();
                // Ejecutar la consulta y obtener el ID generado
                int reservaID = Convert.ToInt32(cmd.ExecuteScalar());
                return reservaID;
            }
        }

        public void GuardarDetalleReserva(int reservaID, int habitacionID, decimal precioNoche, decimal total)
        {
            string query = @"
        INSERT INTO DetalleReserva (ReservaID, HabitacionID, PrecioNoche, Total)
        VALUES (@ReservaID, @HabitacionID, @PrecioNoche, @Total)";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReservaID", reservaID);
                cmd.Parameters.AddWithValue("@HabitacionID", habitacionID);
                cmd.Parameters.AddWithValue("@PrecioNoche", precioNoche);
                cmd.Parameters.AddWithValue("@Total", total);

                conn.Open();
                cmd.ExecuteNonQuery();  // Ejecutar la consulta de inserción
            }
        }

        public decimal ObtenerPrecioNochePorHabitacion(int habitacionID)
        {
            decimal precioNoche = 0;

            string query = @"
            SELECT T.CostoBase
            FROM Habitaciones H
            JOIN TipoHabitacion T ON H.TipoHabitacionID = T.TipoHabitacionID
            WHERE H.HabitacionID = @HabitacionID";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HabitacionID", habitacionID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    precioNoche = (decimal)reader["CostoBase"];
                }

                reader.Close();
            }

            return precioNoche;
        }

        // Método para actualizar el estado de una habitación
        public void ActualizarEstadoHabitacion(int habitacionID)
        {
            string query = "UPDATE Habitaciones SET Estado = 'Ocupada' WHERE HabitacionID = @HabitacionID";
            using (var connection = conexion.GetConnection()) // Corrección aquí
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HabitacionID", habitacionID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para guardar servicios en la reserva
        public void GuardarServicios(int reservaID, int servicioID, decimal precio, decimal totalServicio)
        {
            string query = @"
        INSERT INTO DetalleReserva (ReservaID, ServicioID, PrecioNoche, Total)
        VALUES (@ReservaID, @ServicioID, @Precio, @Total)";

            using (var connection = conexion.GetConnection())
            {
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregar los parámetros necesarios
                    command.Parameters.AddWithValue("@ReservaID", reservaID);
                    command.Parameters.AddWithValue("@ServicioID", servicioID);
                    command.Parameters.AddWithValue("@Precio", precio);  // Precio de cada servicio
                    command.Parameters.AddWithValue("@Total", totalServicio);  // Total de ese servicio

                    // Abrir la conexión y ejecutar la consulta
                    connection.Open();
                    command.ExecuteNonQuery();  // Ejecutar la consulta de inserción
                }
            }
        }


    }
}
