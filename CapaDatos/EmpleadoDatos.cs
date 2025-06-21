using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;

namespace CapaDatos
{
    public class EmpleadoDatos
    {
        private Conexion conexion = new Conexion();  // Instancia de la clase Conexion

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
