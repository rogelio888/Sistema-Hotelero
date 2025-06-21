using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        // Cadena de conexión global (modifica con tu conexión real)
        private string connectionString = "Data Source=HINOJOSA;Initial Catalog=HotelDB;Integrated Security=True";

        // Método para obtener la conexión
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);  // Devuelve una nueva conexión a la base de datos
        }
    }
}
