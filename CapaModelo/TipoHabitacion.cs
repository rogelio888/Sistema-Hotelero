using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class TipoHabitacion
    {
        public int TipoHabitacionID { get; set; }  // ID del tipo de habitación (auto-generado por la base de datos)
        public string Descripcion { get; set; }  // Descripción del tipo de habitación (e.g., "Individual", "Doble", "Suite")
        public decimal CostoBase { get; set; }  // Costo base de la habitación
        public int Capacidad { get; set; }  // Capacidad máxima de personas que puede alojar el tipo de habitación
    }
}
