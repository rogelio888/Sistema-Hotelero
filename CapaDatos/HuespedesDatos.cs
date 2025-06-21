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
    public class HuespedesDatos
    {
        private Conexion conexion = new Conexion();  // Instancia de la clase Conexion

        // Método para obtener el CI del huésped según HuespedID


        // Método para obtener los nombres y números de documentos de los huéspedes
        public DataTable ObtenerHuespedes_Reserva()
        {
            DataTable dt = new DataTable();

            string query = @"
            SELECT HuespedID, Nombre, NumeroDocumento
            FROM Huespedes";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        // Método para obtener los datos de los huéspedes (sin incluir HuespedID)
        public DataTable ObtenerHuespedes()
        {
            DataTable dt = new DataTable();

            string query = @"
            SELECT Nombre, Apellido, TipoDocumento, NumeroDocumento, Telefono, Email, Direccion, FechaNacimiento, Nacionalidad
            FROM Huespedes";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);  // Llenamos el DataTable con los datos de la base de datos
            }

            return dt;  // Retornamos el DataTable con los resultados
        }

        // Método para agregar un nuevo huésped
        public void AgregarHuesped(Huesped huesped)
        {
            string query = @"
            INSERT INTO Huespedes (Nombre, Apellido, TipoDocumento, NumeroDocumento, Telefono, Email, Direccion, FechaNacimiento, Nacionalidad)
            VALUES (@Nombre, @Apellido, @TipoDocumento, @NumeroDocumento, @Telefono, @Email, @Direccion, @FechaNacimiento, @Nacionalidad)";

            using (SqlConnection conn = conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", huesped.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", huesped.Apellido);
                cmd.Parameters.AddWithValue("@TipoDocumento", huesped.TipoDocumento);
                cmd.Parameters.AddWithValue("@NumeroDocumento", huesped.NumeroDocumento);
                cmd.Parameters.AddWithValue("@Telefono", huesped.Telefono);
                cmd.Parameters.AddWithValue("@Email", huesped.Email);
                cmd.Parameters.AddWithValue("@Direccion", huesped.Direccion);
                cmd.Parameters.AddWithValue("@FechaNacimiento", huesped.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Nacionalidad", huesped.Nacionalidad);

                conn.Open();
                cmd.ExecuteNonQuery();  // Ejecutar la consulta para agregar el huésped
            }
        }
    }

}
