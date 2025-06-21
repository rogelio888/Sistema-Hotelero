using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;

namespace CapaDatos
{
    public class HabitacionesDatos
    {
        private Conexion conexion = new Conexion();  // Instancia de la clase Conexion



        public bool VerificarDisponibilidadHabitacion(int habitacionID, DateTime fechaEntrada, DateTime fechaSalida)
        {
            string query = @"
            SELECT COUNT(*)
            FROM Reserva R
            JOIN DetalleReserva DR ON R.ReservaID = DR.ReservaID
            WHERE DR.HabitacionID = @HabitacionID
            AND ((R.FechaEntrada BETWEEN @FechaEntrada AND @FechaSalida) 
            OR (R.FechaSalida BETWEEN @FechaEntrada AND @FechaSalida)
            OR (@FechaEntrada BETWEEN R.FechaEntrada AND R.FechaSalida))";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HabitacionID", habitacionID);
                cmd.Parameters.AddWithValue("@FechaEntrada", fechaEntrada);
                cmd.Parameters.AddWithValue("@FechaSalida", fechaSalida);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();  // Obtener el número de reservas solapadas

                return count == 0;  // Si count es 0, significa que la habitación está disponible
            }
        }

        public (int Piso, string NumeroHabitacion) ObtenerPisoYNumeroHabitacion(int habitacionID)
        {
            int piso = 0;
            string numeroHabitacion = string.Empty;

            string query = "SELECT Piso, NumeroHabitacion FROM Habitaciones WHERE HabitacionID = @HabitacionID";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HabitacionID", habitacionID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    piso = (int)reader["Piso"];  // Obtener el piso de la habitación
                    numeroHabitacion = reader["NumeroHabitacion"].ToString();  // Obtener el número de la habitación
                }

                reader.Close();
            }

            return (piso, numeroHabitacion);  // Retornar el piso y el número de la habitación
        }




        // Método para obtener el CostoBase de la habitación según el TipoHabitacionID
        public decimal ObtenerCostoPorTipoHabitacion(int tipoHabitacionID)
        {
            decimal costoBase = 0;

            string query = "SELECT CostoBase FROM TipoHabitacion WHERE TipoHabitacionID = @TipoHabitacionID";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TipoHabitacionID", tipoHabitacionID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    costoBase = (decimal)reader["CostoBase"];  // Obtener el CostoBase
                }

                reader.Close();
            }

            return costoBase;  // Retornar el CostoBase de la habitación
        }


        public (string, decimal) ObtenerTipoHabitacionYPrecioNoche(int habitacionID)
        {
            string tipoHabitacion = "";
            decimal precioNoche = 0;

            string query = @"
            SELECT T.Descripcion AS TipoHabitacion, T.CostoBase AS PrecioNoche
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
                    tipoHabitacion = reader["TipoHabitacion"].ToString();  // Obtener el tipo de habitación
                    precioNoche = (decimal)reader["PrecioNoche"];  // Obtener el precio por noche
                }

                reader.Close();
            }

            return (tipoHabitacion, precioNoche);  // Retorna el tipo de habitación y el precio por noche
        }


        // Método para obtener las habitaciones disponibles (Estado = 'Disponible')
        public DataTable ObtenerHabitacionesDisponibles_reserva()
        {
            DataTable dt = new DataTable();

            string query = @"
            SELECT Ho.Nombre AS HotelNombre, H.Piso, H.NumeroHabitacion, H.HabitacionID
            FROM Habitaciones H
            JOIN Hoteles Ho ON H.HotelID = Ho.HotelID
            WHERE H.Estado = 'Disponible'";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);  // Llenamos el DataTable con los datos de la base de datos
            }

            return dt;  // Retornamos el DataTable con los resultados
        }

        // Método para obtener las habitaciones con nombres de hotel y tipo de habitación
        public DataTable ObtenerHabitacionesConDetalles()
        {
            DataTable dt = new DataTable();

            string query = @"
            SELECT 
                H.NumeroHabitacion, 
                Ho.Nombre AS HotelNombre, 
                H.Piso, 
                H.Estado, 
                T.Descripcion AS TipoHabitacion
            FROM 
                Habitaciones H
            JOIN 
                Hoteles Ho ON H.HotelID = Ho.HotelID
            JOIN 
                TipoHabitacion T ON H.TipoHabitacionID = T.TipoHabitacionID";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);  // Llenamos el DataTable con los datos de la base de datos
            }

            return dt;  // Retornamos el DataTable con los resultados
        }

        // Método para agregar una nueva habitación
        public void AgregarHabitacion(Habitacion habitacion)
        {
            string query = @"
            INSERT INTO Habitaciones (NumeroHabitacion, Piso, Estado, HotelID, TipoHabitacionID)
            VALUES (@NumeroHabitacion, @Piso, @Estado, @HotelID, @TipoHabitacionID)";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NumeroHabitacion", habitacion.NumeroHabitacion);
                cmd.Parameters.AddWithValue("@Piso", habitacion.Piso);
                cmd.Parameters.AddWithValue("@Estado", habitacion.Estado);
                cmd.Parameters.AddWithValue("@HotelID", habitacion.HotelID);
                cmd.Parameters.AddWithValue("@TipoHabitacionID", habitacion.TipoHabitacionID);

                conn.Open();
                cmd.ExecuteNonQuery();  // Ejecutar la consulta para agregar la habitación
            }
        }

        // Método para agregar un nuevo tipo de habitación
        public void AgregarTipoHabitacion(string descripcion, decimal costoBase, int capacidad)
        {
            string query = @"
            INSERT INTO TipoHabitacion (Descripcion, CostoBase, Capacidad)
            VALUES (@Descripcion, @CostoBase, @Capacidad)";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@CostoBase", costoBase);
                cmd.Parameters.AddWithValue("@Capacidad", capacidad);

                conn.Open();
                cmd.ExecuteNonQuery();  // Ejecutar la consulta para agregar el tipo de habitación
            }
        }

        // Método para agregar un nuevo hotel
        public void AgregarHotel(string nombre, string direccion, string telefono, string email, string categoria)
        {
            string query = @"
            INSERT INTO Hoteles (Nombre, Direccion, Telefono, Email, Categoria)
            VALUES (@Nombre, @Direccion, @Telefono, @Email, @Categoria)";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Direccion", direccion);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Categoria", categoria);

                conn.Open();
                cmd.ExecuteNonQuery();  // Ejecutar la consulta para agregar el hotel
            }
        }

        // Método para obtener todos los tipos de habitación desde la base de datos
        public DataTable ObtenerTiposHabitacion()
        {
            DataTable dt = new DataTable();

            string query = "SELECT TipoHabitacionID, Descripcion FROM TipoHabitacion";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);  // Llenamos el DataTable con los datos de la base de datos
            }

            return dt;  // Retornamos el DataTable con los tipos de habitación
        }

        // Método para obtener todos los hoteles desde la base de datos
        public DataTable ObtenerHoteles()
        {
            DataTable dt = new DataTable();

            string query = "SELECT HotelID, Nombre FROM Hoteles";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);  // Llenamos el DataTable con los datos de la base de datos
            }

            return dt;  // Retornamos el DataTable con los hoteles
        }

        // Método para obtener la cantidad de habitaciones disponibles
        public int ObtenerHabitacionesDisponibles()
        {
            int disponibles = 0;
            string query = "SELECT COUNT(*) FROM Habitaciones WHERE Estado = 'Disponible'";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                disponibles = (int)cmd.ExecuteScalar();  // Ejecutar la consulta y obtener el resultado
            }

            return disponibles;
        }

        // Método para obtener la cantidad de habitaciones ocupadas
        public int ObtenerHabitacionesOcupadas()
        {
            int ocupadas = 0;
            string query = "SELECT COUNT(*) FROM Habitaciones WHERE Estado = 'Ocupada'";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                ocupadas = (int)cmd.ExecuteScalar();  // Ejecutar la consulta y obtener el resultado
            }

            return ocupadas;
        }

        // Método para obtener la cantidad de habitaciones en mantenimiento
        public int ObtenerHabitacionesMantenimiento()
        {
            int mantenimiento = 0;
            string query = "SELECT COUNT(*) FROM Habitaciones WHERE Estado = 'Mantenimiento'";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                mantenimiento = (int)cmd.ExecuteScalar();  // Ejecutar la consulta y obtener el resultado
            }

            return mantenimiento;
        }
    }

}
