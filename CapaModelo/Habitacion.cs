using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Habitacion
    {
        public int HabitacionID { get; set; }  // ID de la habitación (auto-generado por la base de datos)
        public string NumeroHabitacion { get; set; }  // Número de la habitación
        public int Piso { get; set; }  // Piso donde está ubicada la habitación
        public string Estado { get; set; }  // Estado de la habitación (Disponible, Ocupada, Mantenimiento)
        public int HotelID { get; set; }  // ID del hotel al que pertenece la habitación
        public int TipoHabitacionID { get; set; }  // ID del tipo de habitación (e.g., Individual, Doble, Suite)
    }
}
