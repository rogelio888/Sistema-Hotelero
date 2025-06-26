using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Empleado
    {
        public int id_empleado { get; set; }          // ID del empleado
        public string nombre { get; set; }            // Nombre del empleado
        public string apellido { get; set; }          // Apellido del empleado
        public string tipo_documento { get; set; }    // Tipo de documento (DNI, etc.)
        public string documento { get; set; }         // Número de documento (Carnet)
        public string telefono { get; set; }          // Teléfono del empleado
        public string email { get; set; }             // Correo electrónico del empleado
        public string direccion { get; set; }         // Dirección del empleado
        public DateTime fecha_contratacion { get; set; } // Fecha de contratación
        public string rol { get; set; }               // Rol del empleado (de la tabla Roles)
        public string estado_empleado { get; set; }   // Estado del empleado (Activo/Inactivo)
        public int id_rol { get; set; }                 // ID del rol (relacionado con la tabla Roles)
        public int EstadoEmpleado { get; set; }         
    }
}
