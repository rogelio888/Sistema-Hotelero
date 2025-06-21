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
    public partial class Login : Form
    {
        bool claveVisible = false;
        public Login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            labelMostrarClave.Text = "Mostrar";
        }

        private void labelMostrarClave_Click_1(object sender, EventArgs e)
        {
            if (claveVisible)
            {
                textBox2.PasswordChar = '*';
                labelMostrarClave.Text = "Mostrar";
                claveVisible = false;
            }
            else
            {
                textBox2.PasswordChar = '\0';
                labelMostrarClave.Text = "Ocultar";
                claveVisible = true;
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;  // Correo del empleado
            string documento = textBox2.Text;  // Documento (carnet) del empleado

            EmpleadoDatos datos = new EmpleadoDatos();  // Instancia de la clase de datos

            // Llamar al método Login de la capa de datos para obtener el empleado
            Empleado empleado = datos.Login(email, documento);

            if (empleado != null)
            {
                // Guardamos al empleado en la clase SesionUsuario
                SesionUsuario.EmpleadoActual = empleado;

                // Mostrar un mensaje de bienvenida
                MessageBox.Show($"Bienvenido, {empleado.nombre} {empleado.apellido}!");

                // Abrir el formulario principal de la aplicación
                Inicio inicio = new Inicio();
                inicio.Show();
                this.Hide();  // Opcional: esconder login
            }
            else
            {
                // Si las credenciales son incorrectas
                MessageBox.Show("Credenciales incorrectas.");
            }
        }
    }
}
