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
using CapaDatos;

namespace SistemaHotelero3._0
{
    public partial class Administracion : Form
    {
        public Administracion()
        {
            InitializeComponent();
        }

        private void iNICIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inicio form = new Inicio();
            form.Show();
            this.Close();
        }

        private void hABITACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Habitaciones form = new Habitaciones();
            form.Show();
            this.Close();
        }

        private void huéspedesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Huespedes form = new Huespedes();
            form.Show();
            this.Close();
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservas form = new Reservas();
            form.Show();
            this.Close();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear un formulario simple para pedir el ID de reserva
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "ID de Reserva",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Ingrese el ID de la reserva:", Width = 240 };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 240 };
            Button confirmation = new Button() { Text = "OK", Left = 180, Width = 80, Top = 80, DialogResult = DialogResult.OK };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                int idReserva;
                if (int.TryParse(inputBox.Text, out idReserva))
                {
                    Reporte form = new Reporte(idReserva);
                    form.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe ingresar un ID de reserva válido para generar el reporte.");
                }
            }
        }

        private void Administracion_Load(object sender, EventArgs e)
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

            // Tipo de documento
            comboBoxTipoDocumento.Items.Clear();
            comboBoxTipoDocumento.Items.AddRange(new string[] { "CI", "DNI", "Pasaporte" });

            // Estado
            comboBoxEstado.Items.Clear();
            comboBoxEstado.Items.AddRange(new string[] { "Activo", "Inactivo" });

            // Rol
            comboBoxRol.Items.Clear();
            comboBoxRol.Items.AddRange(new string[] { "Recepcionista", "Administrador", "Limpieza", "Camarero", "Mantenimiento" });

            // Jornada
            comboBoxJornada.Items.Clear();
            comboBoxJornada.Items.AddRange(new string[] { "Mañana", "Tarde", "Noche" });

            // Horario de inicio y fin (puedes personalizar según tu necesidad)
            comboBoxHoraInicio.Items.Clear();
            comboBoxHoraInicio.Items.AddRange(new string[] { "04:00:00", "12:00:00", "20:00:00" });

            comboBoxHoraFin.Items.Clear();
            comboBoxHoraFin.Items.AddRange(new string[] { "11:59:00", "19:59:00", "04:00:00" });

            // Opcional: seleccionar el primer elemento por defecto
            if (comboBoxTipoDocumento.Items.Count > 0) comboBoxTipoDocumento.SelectedIndex = 0;
            if (comboBoxEstado.Items.Count > 0) comboBoxEstado.SelectedIndex = 0;
            if (comboBoxRol.Items.Count > 0) comboBoxRol.SelectedIndex = 0;
            if (comboBoxJornada.Items.Count > 0) comboBoxJornada.SelectedIndex = 0;
            if (comboBoxHoraInicio.Items.Count > 0) comboBoxHoraInicio.SelectedIndex = 0;
            if (comboBoxHoraFin.Items.Count > 0) comboBoxHoraFin.SelectedIndex = 0;

            CargarEmpleados();

        }

        private void CargarEmpleados()
        {
            EmpleadoDatos datos = new EmpleadoDatos();
            dataGridView1.DataSource = datos.ObtenerEmpleadosConRol();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Cerrar sesión
            SesionUsuario.EmpleadoActual = null;

            // Volver al login
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            EmpleadoDatos datos = new EmpleadoDatos();
            if (datos.ExisteEmpleadoPorDocumento(textBoxNumDocumento.Text))
            {
                MessageBox.Show("Ya existe un empleado con ese número de documento.");
                return;
            }

            // Mapear el nombre del rol a su ID
            int rolID = 1;
            switch (comboBoxRol.SelectedItem.ToString())
            {
                case "Recepcionista": rolID = 1; break;
                case "Administrador": rolID = 2; break;
                case "Limpieza": rolID = 3; break;
                case "Camarero": rolID = 4; break;
                case "Mantenimiento": rolID = 5; break;
            }

            Empleado empleado = new Empleado
            {
                nombre = textBoxNombre.Text,
                apellido = textBoxApellido.Text,
                tipo_documento = comboBoxTipoDocumento.SelectedItem.ToString(),
                documento = textBoxNumDocumento.Text,
                telefono = textBoxTelefono.Text,
                email = textBoxEmail.Text,
                direccion = textBoxDireccion.Text,
                fecha_contratacion = dateTimePickerContratacion.Value,
                id_rol = rolID,
                estado_empleado = comboBoxEstado.SelectedItem.ToString()
            };

            int empleadoID = datos.AgregarEmpleadoYObtenerID(empleado);

            if (empleadoID > 0)
            {
                // Guardar jornada laboral
                string jornada = comboBoxJornada.SelectedItem.ToString();
                string horaInicio = comboBoxHoraInicio.SelectedItem.ToString();
                string horaFin = comboBoxHoraFin.SelectedItem.ToString();

                bool exitoJornada = datos.AgregarJornadaLaboral(empleadoID, jornada, horaInicio, horaFin);

                if (exitoJornada)
                {
                    MessageBox.Show("Empleado y jornada guardados correctamente.");
                    LimpiarCampos();
                    CargarEmpleados();
                }
                else
                {
                    MessageBox.Show("Empleado guardado, pero error al guardar la jornada.");
                }
            }
            else
            {
                MessageBox.Show("Error al guardar el empleado.");
            }
        }

        private void LimpiarCampos()
        {
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            comboBoxTipoDocumento.SelectedIndex = 0;
            textBoxNumDocumento.Clear();
            textBoxTelefono.Clear();
            textBoxEmail.Clear();
            textBoxDireccion.Clear();
            comboBoxRol.SelectedIndex = 0;
            comboBoxEstado.SelectedIndex = 0;
            comboBoxJornada.SelectedIndex = 0;
            comboBoxHoraInicio.SelectedIndex = 0;
            comboBoxHoraFin.SelectedIndex = 0;
            dateTimePickerContratacion.Value = DateTime.Now;
        }

        private int empleadoSeleccionadoID = -1;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                empleadoSeleccionadoID = Convert.ToInt32(row.Cells["EmpleadoID"].Value);

                textBoxNombre.Text = row.Cells["Nombre"].Value.ToString();
                textBoxApellido.Text = row.Cells["Apellido"].Value.ToString();
                comboBoxTipoDocumento.SelectedItem = row.Cells["TipoDocumento"].Value.ToString();
                textBoxNumDocumento.Text = row.Cells["NumeroDocumento"].Value.ToString();
                textBoxTelefono.Text = row.Cells["Telefono"].Value.ToString();
                textBoxEmail.Text = row.Cells["Email"].Value.ToString();
                textBoxDireccion.Text = row.Cells["Direccion"].Value.ToString();
                comboBoxRol.SelectedItem = row.Cells["Rol"].Value.ToString();
                dateTimePickerContratacion.Value = Convert.ToDateTime(row.Cells["FechaContratacion"].Value);
                comboBoxEstado.SelectedItem = row.Cells["EstadoEmpleado"].Value.ToString();

                // Cargar jornada laboral
                EmpleadoDatos datos = new EmpleadoDatos();
                var jornadaRow = datos.ObtenerJornadaLaboralPorEmpleado(empleadoSeleccionadoID);
                if (jornadaRow != null)
                {
                    comboBoxJornada.SelectedItem = jornadaRow["Jornada"].ToString();
                    comboBoxHoraInicio.SelectedItem = TimeSpan.Parse(jornadaRow["HoraInicio"].ToString()).ToString(@"hh\:mm\:ss");
                    comboBoxHoraFin.SelectedItem = TimeSpan.Parse(jornadaRow["HoraFin"].ToString()).ToString(@"hh\:mm\:ss");
                }
                else
                {
                    comboBoxJornada.SelectedIndex = 0;
                    comboBoxHoraInicio.SelectedIndex = 0;
                    comboBoxHoraFin.SelectedIndex = 0;
                }
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (empleadoSeleccionadoID == -1)
            {
                MessageBox.Show("Seleccione un empleado para modificar.");
                return;
            }

            int rolID = 1;
            switch (comboBoxRol.SelectedItem.ToString())
            {
                case "Recepcionista": rolID = 1; break;
                case "Administrador": rolID = 2; break;
                case "Limpieza": rolID = 3; break;
                case "Camarero": rolID = 4; break;
                case "Mantenimiento": rolID = 5; break;
            }

            Empleado empleado = new Empleado
            {
                id_empleado = empleadoSeleccionadoID,
                nombre = textBoxNombre.Text,
                apellido = textBoxApellido.Text,
                tipo_documento = comboBoxTipoDocumento.SelectedItem.ToString(),
                documento = textBoxNumDocumento.Text,
                telefono = textBoxTelefono.Text,
                email = textBoxEmail.Text,
                direccion = textBoxDireccion.Text,
                fecha_contratacion = dateTimePickerContratacion.Value,
                id_rol = rolID,
                estado_empleado = comboBoxEstado.SelectedItem.ToString()
            };

            EmpleadoDatos datos = new EmpleadoDatos();
            bool exito = datos.ModificarEmpleado(empleado);

            // Modificar jornada laboral
            string jornada = comboBoxJornada.SelectedItem.ToString();
            string horaInicio = comboBoxHoraInicio.SelectedItem.ToString();
            string horaFin = comboBoxHoraFin.SelectedItem.ToString();
            bool exitoJornada = datos.ModificarJornadaLaboral(empleadoSeleccionadoID, jornada, horaInicio, horaFin);

            if (exito && exitoJornada)
            {
                MessageBox.Show("Empleado y jornada modificados correctamente.");
                LimpiarCampos();
                CargarEmpleados();
                empleadoSeleccionadoID = -1;
            }
            else if (exito)
            {
                MessageBox.Show("Empleado modificado, pero error al modificar la jornada.");
            }
            else
            {
                MessageBox.Show("Error al modificar el empleado.");
            }
        }
    }
}
