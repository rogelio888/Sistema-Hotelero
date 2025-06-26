using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class EmpleadoDatos
    {
        private Conexion conexion = new Conexion();  // Instancia de la clase Conexion

        public bool ExisteEmpleadoPorDocumento(string numeroDocumento)
        {
            string query = "SELECT COUNT(*) FROM Empleado WHERE NumeroDocumento = @NumeroDocumento";
            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public DataRow ObtenerJornadaLaboralPorEmpleado(int empleadoID)
        {
            string query = @"SELECT Jornada, HoraInicio, HoraFin FROM JornadaLaboral WHERE EmpleadoID = @EmpleadoID";
            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public bool ModificarJornadaLaboral(int empleadoID, string jornada, string horaInicio, string horaFin)
        {
            string query = @"UPDATE JornadaLaboral
                     SET Jornada = @Jornada, HoraInicio = @HoraInicio, HoraFin = @HoraFin
                     WHERE EmpleadoID = @EmpleadoID";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@EmpleadoID", empleadoID),
        new SqlParameter("@Jornada", jornada),
        new SqlParameter("@HoraInicio", horaInicio),
        new SqlParameter("@HoraFin", horaFin)
            };

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool AgregarJornadaLaboral(int empleadoID, string jornada, string horaInicio, string horaFin)
        {
            string query = @"INSERT INTO JornadaLaboral (EmpleadoID, Jornada, HoraInicio, HoraFin)
                     VALUES (@EmpleadoID, @Jornada, @HoraInicio, @HoraFin)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@EmpleadoID", empleadoID),
        new SqlParameter("@Jornada", jornada),
        new SqlParameter("@HoraInicio", horaInicio),
        new SqlParameter("@HoraFin", horaFin)
            };

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool ModificarEmpleado(Empleado empleado)
        {
            string query = @"UPDATE Empleado SET
        Nombre = @Nombre,
        Apellido = @Apellido,
        TipoDocumento = @TipoDocumento,
        NumeroDocumento = @NumeroDocumento,
        Telefono = @Telefono,
        Email = @Email,
        Direccion = @Direccion,
        RolID = @RolID,
        FechaContratacion = @FechaContratacion,
        EstadoEmpleado = @EstadoEmpleado
        WHERE EmpleadoID = @EmpleadoID";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Nombre", empleado.nombre),
        new SqlParameter("@Apellido", empleado.apellido),
        new SqlParameter("@TipoDocumento", empleado.tipo_documento),
        new SqlParameter("@NumeroDocumento", empleado.documento),
        new SqlParameter("@Telefono", empleado.telefono),
        new SqlParameter("@Email", empleado.email),
        new SqlParameter("@Direccion", empleado.direccion),
        new SqlParameter("@RolID", empleado.id_rol),
        new SqlParameter("@FechaContratacion", empleado.fecha_contratacion),
        new SqlParameter("@EstadoEmpleado", empleado.estado_empleado),
        new SqlParameter("@EmpleadoID", empleado.id_empleado)
            };

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public DataTable ObtenerEmpleadosConRol()
        {
            string query = @"
        SELECT 
            E.EmpleadoID,
            E.Nombre,
            E.Apellido,
            E.TipoDocumento,
            E.NumeroDocumento,
            E.Telefono,
            E.Email,
            E.Direccion,
            R.NombreRol AS Rol,
            E.FechaContratacion,
            E.EstadoEmpleado,
            J.Jornada,
            CONVERT(varchar(8), J.HoraInicio, 108) AS HoraInicio,
            CONVERT(varchar(8), J.HoraFin, 108) AS HoraFin
        FROM Empleado E
        INNER JOIN Roles R ON E.RolID = R.RolID
        LEFT JOIN JornadaLaboral J ON E.EmpleadoID = J.EmpleadoID";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int AgregarEmpleadoYObtenerID(Empleado empleado)
        {
            string query = @"INSERT INTO Empleado
        (Nombre, Apellido, TipoDocumento, NumeroDocumento, Telefono, Email, Direccion, RolID, FechaContratacion, EstadoEmpleado)
        OUTPUT INSERTED.EmpleadoID
        VALUES
        (@Nombre, @Apellido, @TipoDocumento, @NumeroDocumento, @Telefono, @Email, @Direccion, @RolID, @FechaContratacion, @EstadoEmpleado)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Nombre", empleado.nombre),
                new SqlParameter("@Apellido", empleado.apellido),
                new SqlParameter("@TipoDocumento", empleado.tipo_documento),
                new SqlParameter("@NumeroDocumento", empleado.documento),
                new SqlParameter("@Telefono", empleado.telefono),
                new SqlParameter("@Email", empleado.email),
                new SqlParameter("@Direccion", empleado.direccion),
                new SqlParameter("@RolID", empleado.id_rol),
                new SqlParameter("@FechaContratacion", empleado.fecha_contratacion),
                new SqlParameter("@EstadoEmpleado", empleado.estado_empleado)
            };

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        // Método para autenticar al empleado
        public Empleado Login(string email, string documento)
        {
            Empleado empleado = null;

            // Definir la consulta SQL ajustada a la estructura de tu base de datos
            string query = @"
            SELECT E.*, R.NombreRol AS rol
            FROM Empleado E
            JOIN Roles R ON E.RolID = R.RolID
            WHERE E.Email = @Email AND E.NumeroDocumento = @Documento";

            // Parámetros para la consulta
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Email", email),
            new SqlParameter("@Documento", documento)
            };

            // Usamos la clase Conexion para obtener la conexión y ejecutar la consulta
            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);

                conn.Open();  // Abre la conexión a la base de datos
                SqlDataReader reader = cmd.ExecuteReader();  // Ejecutar la consulta

                if (reader.Read())
                {
                    // Si el empleado es encontrado, asignamos los datos al objeto Empleado
                    empleado = new Empleado
                    {
                        id_empleado = (int)reader["EmpleadoID"],
                        nombre = reader["Nombre"].ToString(),
                        apellido = reader["Apellido"].ToString(),
                        tipo_documento = reader["TipoDocumento"].ToString(),
                        documento = reader["NumeroDocumento"].ToString(),
                        telefono = reader["Telefono"].ToString(),
                        email = reader["Email"].ToString(),
                        direccion = reader["Direccion"].ToString(),
                        fecha_contratacion = (DateTime)reader["FechaContratacion"],
                        rol = reader["rol"].ToString(),  // Nombre del rol obtenido de la tabla Roles
                        estado_empleado = reader["EstadoEmpleado"].ToString()  // Estado del empleado
                    };
                }

                reader.Close();  // Cerramos el reader
            }

            return empleado;  // Retorna el empleado encontrado o null si no existe
        }
    }
}
