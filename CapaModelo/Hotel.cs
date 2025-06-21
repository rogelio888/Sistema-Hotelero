using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Hotel
    {
        public int HotelID { get; set; }  // ID del hotel (auto-generado por la base de datos)
        public string Nombre { get; set; }  // Nombre del hotel
        public string Direccion { get; set; }  // Dirección del hotel
        public string Telefono { get; set; }  // Teléfono del hotel
        public string Email { get; set; }  // Email del hotel
        public string Categoria { get; set; }  // Categoría del hotel (e.g. 5 estrellas)
    }
}
