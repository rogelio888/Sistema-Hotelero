using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Huesped
    {
        public string Nombre { get; set; }  // Nombre del huésped
        public string Apellido { get; set; }  // Apellido del huésped
        public string TipoDocumento { get; set; }  // Tipo de documento (DNI, Pasaporte, etc.)
        public string NumeroDocumento { get; set; }  // Número del documento
        public string Telefono { get; set; }  // Teléfono del huésped
        public string Email { get; set; }  // Email del huésped
        public string Direccion { get; set; }  // Dirección del huésped
        public DateTime FechaNacimiento { get; set; }  // Fecha de nacimiento
        public string Nacionalidad { get; set; }  // Nacionalidad del huésped
    }
}
