using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotelero3._0
{
    public partial class Habitaciones : Form
    {
        public Habitaciones()
        {
            InitializeComponent();
        }

        private void Habitaciones_Load(object sender, EventArgs e)
        {
            // Verifica que el empleado haya iniciado sesión
            if (SesionUsuario.EmpleadoActual != null)
            {
                // Asigna el nombre del empleado al Label9
                labelUsuario.Text = $"{SesionUsuario.EmpleadoActual.nombre} {SesionUsuario.EmpleadoActual.apellido}";
            }
            else
            {
                // Si no hay un empleado autenticado, se puede mostrar un mensaje o redirigir al login
                MessageBox.Show("No se ha iniciado sesión.");
            }

            // Llamar al método para cargar los ComboBox
            CargarComboBoxes();
            // Llamar al método para cargar los datos de las habitaciones en el DataGridView
            CargarHabitaciones();
            // Deshabilitar los campos de hotel y tipo de habitación al iniciar
            DeshabilitarCamposHotelTipo();
        }

        private void iNICIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inicio form = new Inicio();
            form.Show();
            this.Close();
        }

        private void hABITACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void huéspedesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Huespedes form = new Huespedes();
            form.Show();
            this.Close();
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Huespedes form = new Huespedes();
            form.Show();
            this.Close();
        }

        private void administraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracion form = new Administracion();
            form.Show();
            this.Close();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar si hay una reserva seleccionada para pasar el ID
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idReserva = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ReservaID"].Value);
                Reporte form = new Reporte(idReserva);
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una reserva para generar el reporte.");
            }
        }

        // Método para deshabilitar los campos de hotel y tipo de habitación
        private void DeshabilitarCamposHotelTipo()
        {
            // Deshabilitar los TextBox y ComboBox relacionados con hotel y tipo de habitación
            textBoxNombre.Enabled = false;
            textBoxDireccion.Enabled = false;
            textBoxTelefono.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxCategoria.Enabled = false;
            buttonGuardarHotel.Enabled = false;

            textBoxNombreTipo.Enabled = false;
            textBoxCostoBase.Enabled = false;
            textBoxCapacidad.Enabled = false;
            buttonGuardarTipo.Enabled = false;
        }

        private void CargarHabitaciones()
        {
            HabitacionesDatos datos = new HabitacionesDatos();

            // Obtener los datos de las habitaciones con los nombres de hotel y tipo de habitación
            DataTable dt = datos.ObtenerHabitacionesConDetalles();

            // Asignar el DataTable al DataGridView
            dataGridView1.DataSource = dt;
        }

        private void CargarComboBoxes()
        {
            HabitacionesDatos datos = new HabitacionesDatos();

            // Obtener los tipos de habitación y cargarlos en el ComboBoxTipoHabitacion
            DataTable tiposHabitacion = datos.ObtenerTiposHabitacion();
            comboBoxTipoHabitacion.DataSource = tiposHabitacion;
            comboBoxTipoHabitacion.DisplayMember = "Descripcion";  // Columna a mostrar
            comboBoxTipoHabitacion.ValueMember = "TipoHabitacionID";  // Columna de valor

            // Obtener los hoteles y cargarlos en el ComboBoxHotel
            DataTable hoteles = datos.ObtenerHoteles();
            comboBoxHotel.DataSource = hoteles;
            comboBoxHotel.DisplayMember = "Nombre";  // Columna a mostrar
            comboBoxHotel.ValueMember = "HotelID";  // Columna de valor
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Cerrar sesión
            SesionUsuario.EmpleadoActual = null;

            // Volver al login
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void buttonAñadirHotel_Click(object sender, EventArgs e)
        {
            // Habilitar los campos del hotel para ser completados
            textBoxNombre.Enabled = true;
            textBoxDireccion.Enabled = true;
            textBoxTelefono.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxCategoria.Enabled = true;
            buttonGuardarHotel.Enabled = true;  // Habilitar el botón de guardar
        }

        private void buttonGuardarHotel_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los campos de texto
            string nombre = textBoxNombre.Text;
            string direccion = textBoxDireccion.Text;
            string telefono = textBoxTelefono.Text;
            string email = textBoxEmail.Text;
            string categoria = textBoxCategoria.Text;

            // Llamar a la capa de datos para guardar el hotel
            HabitacionesDatos datos = new HabitacionesDatos();
            datos.AgregarHotel(nombre, direccion, telefono, email, categoria);

            // Mostrar un mensaje de confirmación
            MessageBox.Show("Hotel agregado correctamente.");

            // Actualizar el ComboBoxHotel con el nuevo hotel
            CargarComboBoxes();

            // Opcional: Limpiar los campos del formulario
            LimpiarCamposHotel();
        }

        private void LimpiarCamposHotel()
        {
            textBoxNombre.Clear();
            textBoxDireccion.Clear();
            textBoxTelefono.Clear();
            textBoxEmail.Clear();
            textBoxCategoria.Clear();

            textBoxNombre.Enabled = false;
            textBoxDireccion.Enabled = false;
            textBoxTelefono.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxCategoria.Enabled = false;
            buttonGuardarHotel.Enabled = false;
        }

        private void buttonaddTipo_Click(object sender, EventArgs e)
        {
            // Habilitar los campos para añadir el tipo de habitación
            textBoxNombreTipo.Enabled = true;
            textBoxCostoBase.Enabled = true;
            textBoxCapacidad.Enabled = true;
            buttonGuardarTipo.Enabled = true;  // Habilitar el botón de guardar tipo
        }

        private void buttonGuardarTipo_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los campos de texto
            string descripcion = textBoxNombreTipo.Text;
            decimal costoBase = decimal.Parse(textBoxCostoBase.Text);
            int capacidad = int.Parse(textBoxCapacidad.Text);

            // Llamar a la capa de datos para guardar el tipo de habitación
            HabitacionesDatos datos = new HabitacionesDatos();
            datos.AgregarTipoHabitacion(descripcion, costoBase, capacidad);

            // Mostrar un mensaje de confirmación
            MessageBox.Show("Tipo de habitación agregado correctamente.");

            // Actualizar el ComboBoxTipoHabitacion con el nuevo tipo de habitación
            CargarComboBoxes();

            // Opcional: Limpiar los campos del formulario
            LimpiarCamposTipo();
        }

        private void LimpiarCamposTipo()
        {
            textBoxNombreTipo.Clear();
            textBoxCostoBase.Clear();
            textBoxCapacidad.Clear();

            textBoxNombreTipo.Enabled = false;
            textBoxCostoBase.Enabled = false;
            textBoxCapacidad.Enabled = false;
            buttonGuardarTipo.Enabled = false;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Crear un objeto de la clase Habitacion con los datos del formulario
            Habitacion habitacion = new Habitacion
            {
                NumeroHabitacion = textBoxNumHabitacion.Text,  // Número de la habitación
                Piso = int.Parse(comboBoxPiso.SelectedItem.ToString()),  // Piso de la habitación
                Estado = comboBoxEstado.SelectedItem.ToString(),  // Estado (Disponible, Ocupada, Mantenimiento)
                HotelID = int.Parse(comboBoxHotel.SelectedValue.ToString()),  // ID del hotel
                TipoHabitacionID = int.Parse(comboBoxTipoHabitacion.SelectedValue.ToString())  // ID del tipo de habitación
            };

            // Crear una instancia de la clase HabitacionesDatos para guardar la habitación
            HabitacionesDatos datos = new HabitacionesDatos();
            datos.AgregarHabitacion(habitacion);  // Llamar al método para agregar la habitación

            // Mostrar un mensaje de éxito
            MessageBox.Show("Habitación agregada correctamente.");

            // Opcional: Limpiar los campos del formulario
            LimpiarCampos();

            // Actualizar el DataGridView para mostrar la nueva habitación
            ActualizarDataGridView();
        }

        // Método para limpiar los campos del formulario después de guardar
        private void LimpiarCampos()
        {
            textBoxNumHabitacion.Clear();
            comboBoxPiso.SelectedIndex = -1;
            comboBoxEstado.SelectedIndex = -1;
            comboBoxHotel.SelectedIndex = -1;
            comboBoxTipoHabitacion.SelectedIndex = -1;
        }

        private void ActualizarDataGridView()
        {
            HabitacionesDatos datos = new HabitacionesDatos();

            // Obtener los datos actualizados de las habitaciones
            DataTable dt = datos.ObtenerHabitacionesConDetalles();

            // Asignar el DataTable al DataGridView
            dataGridView1.DataSource = dt;
        }
    }
}
