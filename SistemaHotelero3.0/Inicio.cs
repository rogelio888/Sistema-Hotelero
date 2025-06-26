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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            // Ajustar el tamaño del DataGridView
            dataGridView1.Width = 553;
            dataGridView1.Height = 170;

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

            // Obtener las últimas 5 reservas
            ReservaDatos reservaDatos = new ReservaDatos();
            DataTable dt = reservaDatos.ObtenerUltimasReservas();

            // Asignar el DataTable al DataGridView
            dataGridView1.DataSource = dt;

            // Ajustar automáticamente el tamaño de las columnas para que se adapten al contenido
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Ajustar las filas para que se adapten al contenido (si necesario)
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Establecer un ancho mínimo y máximo para cada columna (opcional)
            dataGridView1.Columns["HuespedNombre"].MinimumWidth = 100;  // Ancho mínimo de la columna "HuespedNombre"
            dataGridView1.Columns["HuespedNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns["FechaEntrada"].MinimumWidth = 120;   // Ancho mínimo de la columna "FechaEntrada"
            dataGridView1.Columns["FechaEntrada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns["EstadoReserva"].MinimumWidth = 120;  // Ancho mínimo de la columna "EstadoReserva"
            dataGridView1.Columns["EstadoReserva"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns["MontoTotal"].MinimumWidth = 120;     // Ancho mínimo de la columna "MontoTotal"
            dataGridView1.Columns["MontoTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Obtener el número de habitaciones disponibles, ocupadas y en mantenimiento
            HabitacionesDatos habitacionesDatos = new HabitacionesDatos();
            int disponibles = habitacionesDatos.ObtenerHabitacionesDisponibles();
            int ocupadas = habitacionesDatos.ObtenerHabitacionesOcupadas();
            int mantenimiento = habitacionesDatos.ObtenerHabitacionesMantenimiento();

            // Actualizar los labels con los resultados
            lblDisponibles.Text = $"{disponibles}";
            lblOcupadas.Text = $"{ocupadas}";
            lblMantenimiento.Text = $"{mantenimiento}";
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

        private void button4_Click(object sender, EventArgs e)
        {
            // Cerrar sesión
            SesionUsuario.EmpleadoActual = null;

            // Volver al login
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
