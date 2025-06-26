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
    public partial class Huespedes : Form
    {
        public Huespedes()
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

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservas form = new Reservas();
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

        private void Huespedes_Load(object sender, EventArgs e)
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

            // Llamar al método para cargar los datos de los huéspedes en el DataGridView
            CargarHuespedes();
        }

        private void CargarHuespedes()
        {
            HuespedesDatos datos = new HuespedesDatos();

            // Obtener los datos de los huéspedes sin el HuespedID
            DataTable dt = datos.ObtenerHuespedes();

            // Asignar el DataTable al DataGridView
            dataGridView1.DataSource = dt;
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

        private void button5Guardar_Click(object sender, EventArgs e)
        {
            // Crear un objeto de la clase Huesped con los datos del formulario
            Huesped huesped = new Huesped
            {
                Nombre = textBox2Nombre.Text,  // Nombre del huésped
                Apellido = textBox3Apellido.Text,  // Apellido del huésped
                TipoDocumento = comboBox3TipoDocumento.SelectedItem.ToString(),  // Tipo de documento (DNI, etc.)
                NumeroDocumento = textBox1NumDocumento.Text,  // Número de documento
                Telefono = textBox4Telefono.Text,  // Teléfono del huésped
                Email = textBox5email.Text,  // Email del huésped
                Direccion = textBox6Direccion.Text,  // Dirección del huésped
                FechaNacimiento = DateTime.Parse(textBox7FechaNacimiento.Text),  // Fecha de nacimiento
                Nacionalidad = textBox8Nacionalidad.Text  // Nacionalidad del huésped
            };

            // Crear una instancia de la clase HuespedesDatos para guardar el huésped
            HuespedesDatos datos = new HuespedesDatos();
            datos.AgregarHuesped(huesped);  // Llamar al método para agregar el huésped

            // Mostrar un mensaje de éxito
            MessageBox.Show("Huésped agregado correctamente.");

            // Opcional: Limpiar los campos del formulario
            LimpiarCampos();
            // Llamado al metodo para actualizar el datagrid
            ActualizarDataGridView();
        }

        // Metodo para actualizar el datagrid
        private void ActualizarDataGridView()
        {
            HuespedesDatos datos = new HuespedesDatos();

            // Obtener los datos actualizados de los huéspedes
            DataTable dt = datos.ObtenerHuespedes();

            // Asignar el DataTable al DataGridView
            dataGridView1.DataSource = dt;
        }

        // Método para limpiar los campos del formulario después de guardar
        private void LimpiarCampos()
        {
            textBox2Nombre.Clear();
            textBox3Apellido.Clear();
            comboBox3TipoDocumento.SelectedIndex = -1;
            textBox1NumDocumento.Clear();
            textBox4Telefono.Clear();
            textBox5email.Clear();
            textBox6Direccion.Clear();
            textBox7FechaNacimiento.Clear();
            textBox8Nacionalidad.Clear();
        }
    }
}
