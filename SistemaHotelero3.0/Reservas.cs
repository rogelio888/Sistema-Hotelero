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
using Microsoft.VisualBasic;

namespace SistemaHotelero3._0
{
    public partial class Reservas : Form
    {
        public Reservas()
        {
            InitializeComponent();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void Reservas_Load(object sender, EventArgs e)
        {
            // Verifica que el empleado haya iniciado sesión
            if (SesionUsuario.EmpleadoActual != null)
            {
                // Asigna el nombre del empleado al Label9
                labelUsuario.Text = $"{SesionUsuario.EmpleadoActual.nombre} {SesionUsuario.EmpleadoActual.apellido}";
                // Asigna el nombre del empleado al label4Responsable
                label4Responsable.Text = $"{SesionUsuario.EmpleadoActual.nombre} {SesionUsuario.EmpleadoActual.apellido}";
            }
            else
            {
                // Si no hay un empleado autenticado, se puede mostrar un mensaje o redirigir al login
                MessageBox.Show("No se ha iniciado sesión.");
            }

            // Llamar al método para cargar los huéspedes en el ComboBox
            CargarHuespedesComboBox();
            // Llamar al método para cargar las habitaciones disponibles en el ComboBox
            CargarHabitacionesComboBox();

            // Inicializar el DataGridView con el DataTable
            InicializarDataGridView();

            // Cargar los métodos de pago en el ComboBox
            CargarMetodosPagoComboBox();

            // Cargar resumen de reservas
            CargarResumenReservas();
        }

        private void CargarResumenReservas()
        {
            ReservaDatos datos = new ReservaDatos();
            DataTable dt = datos.ObtenerResumenReservas();
            dataGridView1.DataSource = dt;
        }

        private void CalcularTotal()
        {
            decimal subtotalHabitaciones = 0;
            decimal subtotalServicios = 0;

            decimal.TryParse(label21SubTotalhabitaciones.Text,
                System.Globalization.NumberStyles.Currency,
                System.Globalization.CultureInfo.CurrentCulture,
                out subtotalHabitaciones);

            decimal.TryParse(label22SubtotalServicios.Text,
                System.Globalization.NumberStyles.Currency,
                System.Globalization.CultureInfo.CurrentCulture,
                out subtotalServicios);

            decimal total = subtotalHabitaciones + subtotalServicios;
            label23MontoTotal.Text = total.ToString("C");
        }

        private void CalcularSubtotalHabitaciones()
        {
            decimal subtotalHabitaciones = 0;

            // Recorremos las filas del DataTable de habitaciones seleccionadas
            foreach (DataRow row in dtHabitacionesSeleccionadas.Rows)
            {
                int habitacionID = (int)row["Habitaciones"];  // Obtener HabitacionID

                // Obtener el TipoHabitacionID de la habitación (por el HabitacionID)
                HabitacionesDatos datosHabitacion = new HabitacionesDatos();
                var tipoHabitacionYPrecio = datosHabitacion.ObtenerTipoHabitacionYPrecioNoche(habitacionID);

                decimal precioNoche = tipoHabitacionYPrecio.Item2; // PrecioNoche es el segundo valor devuelto

                // Sumar el precio de la habitación al subtotal
                subtotalHabitaciones += precioNoche;
            }

            // Actualizar el Label con el subtotal de habitaciones
            label21SubTotalhabitaciones.Text = subtotalHabitaciones.ToString("C");
        }


        private void CargarHabitacionesComboBox()
        {
            HabitacionesDatos datos = new HabitacionesDatos();

            // Obtener las habitaciones disponibles
            DataTable dt = datos.ObtenerHabitacionesDisponibles_reserva();

            // Configurar el ComboBox para mostrar el nombre del hotel, piso y número de habitación
            cmbx_habitacion.DisplayMember = "DisplayValue";  // Nombre que se verá en el ComboBox
            cmbx_habitacion.ValueMember = "HabitacionID";  // El valor que se usará internamente (ID de la habitación)

            // Crear una columna "DisplayValue" para concatenar HotelNombre, Piso y NumeroHabitacion
            dt.Columns.Add("DisplayValue", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                row["DisplayValue"] = row["HotelNombre"].ToString() + " - " + row["Piso"].ToString() + " - " + row["NumeroHabitacion"].ToString();
            }

            // Asignar el DataTable al ComboBox
            cmbx_habitacion.DataSource = dt;
        }

        private void CargarHuespedesComboBox()
        {
            HuespedesDatos datos = new HuespedesDatos();

            // Obtener los datos de los huéspedes
            DataTable dt = datos.ObtenerHuespedes_Reserva();

            // Configurar el ComboBox para mostrar el nombre y número de documento
            cmbx_huesped.DisplayMember = "DisplayValue";  // Nombre que se verá en el ComboBox
            cmbx_huesped.ValueMember = "NumeroDocumento";  // El valor que se usará internamente

            // Crear una columna "DisplayValue" para concatenar Nombre y NumeroDocumento
            dt.Columns.Add("DisplayValue", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                row["DisplayValue"] = row["Nombre"].ToString() + " - " + row["NumeroDocumento"].ToString();
            }

            // Asignar el DataTable al ComboBox
            cmbx_huesped.DataSource = dt;
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

        private void cmbx_habitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una habitación
            if (cmbx_habitacion.SelectedValue != null)
            {
                int habitacionID = (int)cmbx_habitacion.SelectedValue;

                // Llamar a la capa de datos para obtener el tipo de habitación y el precio por noche
                HabitacionesDatos datos = new HabitacionesDatos();
                var (tipoHabitacion, precioNoche) = datos.ObtenerTipoHabitacionYPrecioNoche(habitacionID);

                // Actualizar los labels con el tipo de habitación y el precio por noche
                label2TipoHabitacion.Text = tipoHabitacion;  // Tipo de habitación
                label3PrecioNoche.Text = precioNoche.ToString("C");  // Precio por noche (formato monetario)
            }
        }

        private DataTable dtHabitacionesSeleccionadas;

        private void InicializarDataGridView()
        {
            // Inicializar el DataTable con las columnas necesarias
            dtHabitacionesSeleccionadas = new DataTable();
            dtHabitacionesSeleccionadas.Columns.Add("NombreHuesped", typeof(string));  // Columna para el nombre del huésped
            dtHabitacionesSeleccionadas.Columns.Add("Habitaciones", typeof(int));  // Columna para el HabitacionID (tipo entero)
            dtHabitacionesSeleccionadas.Columns.Add("NombreHabitacion", typeof(string));  // Columna para el nombre de la habitación

            // Asignar el DataTable al DataGridView
            dataGridView3.DataSource = dtHabitacionesSeleccionadas;
        }

        private void botonañadir_Click(object sender, EventArgs e)
        {
            // Verificar que un huésped esté seleccionado
            if (cmbx_huesped.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un huésped.");
                return;
            }

            // Obtener el HuespedID del ComboBox (el valor seleccionado)
            var selectedItem = cmbx_huesped.SelectedItem as DataRowView;
            int huespedID = (int)selectedItem["HuespedID"];  // Extraemos el HuespedID
            string nombreHuesped = selectedItem["Nombre"].ToString();  // Extraemos el nombre del huésped

            // Verificar que se haya seleccionado una habitación
            if (cmbx_habitacion.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una habitación.");
                return;
            }

            // Obtener el HabitacionID de la habitación seleccionada (int)
            int habitacionID = (int)cmbx_habitacion.SelectedValue;

            // Validar que la habitación no esté ya seleccionada
            foreach (DataRow row in dtHabitacionesSeleccionadas.Rows)
            {
                if ((int)row["Habitaciones"] == habitacionID)
                {
                    MessageBox.Show("Esta habitación ya ha sido seleccionada.");
                    return;
                }
            }

            // Obtener el nombre del hotel, piso y el número de habitación
            HabitacionesDatos datosHabitacion = new HabitacionesDatos();
            var tipoHabitacionYPrecio = datosHabitacion.ObtenerTipoHabitacionYPrecioNoche(habitacionID);
            string hotelNombre = tipoHabitacionYPrecio.Item1;  // HotelNombre
            var habitacionInfo = datosHabitacion.ObtenerPisoYNumeroHabitacion(habitacionID);  // Obtener piso y numero de habitacion
            int piso = habitacionInfo.Piso;
            string numeroHabitacion = habitacionInfo.NumeroHabitacion;

            // Crear el texto para mostrar en el DataGridView (esto se muestra, pero no se guarda)
            string habitacion = $"{hotelNombre} - {piso} - {numeroHabitacion}";  // Mostrar algo como "Hotel Sol - 1 - 101"

            // Agregar los datos al DataTable
            DataRow nuevaFila = dtHabitacionesSeleccionadas.NewRow();
            nuevaFila["NombreHuesped"] = nombreHuesped;  // Nombre del huésped desde el ComboBox
            nuevaFila["Habitaciones"] = habitacionID;  // Guardar el HabitacionID en la columna Habitaciones
            nuevaFila["NombreHabitacion"] = habitacion;  // Guardar el nombre de la habitación en la nueva columna

            // Añadir la nueva fila al DataTable
            dtHabitacionesSeleccionadas.Rows.Add(nuevaFila);  // Añadir la nueva fila al DataGridView

            // Calcular el subtotal de habitaciones
            CalcularSubtotalHabitaciones();

            // Calcular el total (habitaciones + servicios)
            CalcularTotal();
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si el doble clic fue en la primera columna (la columna de selección)
            if (e.ColumnIndex == 0)  // Asumimos que la primera columna es la de selección
            {
                // Verificar si se hizo doble clic en una fila válida (no en la cabecera)
                if (e.RowIndex >= 0)
                {
                    // Eliminar la fila del DataTable
                    dtHabitacionesSeleccionadas.Rows.RemoveAt(e.RowIndex);

                    // Actualizar el DataGridView
                    dataGridView3.DataSource = dtHabitacionesSeleccionadas;
                }
            }
        }

        private void CalcularSubtotalServicios()
        {
            decimal subtotalServicios = 0;

            // Verificar si el CheckBox de Desayuno está seleccionado
            if (checkBoxdesayuno.Checked)
            {
                decimal precioDesayuno = 10.00m; // Precio fijo para Desayuno
                int cantidadDesayuno = (int)numericUpDown1Desayuno.Value; // Cantidad seleccionada
                subtotalServicios += precioDesayuno * cantidadDesayuno;  // Calcular subtotal de Desayuno
            }

            // Verificar si el CheckBox de SPA está seleccionado
            if (checkBoxspa.Checked)
            {
                decimal precioSPA = 25.00m; // Precio fijo para SPA
                int cantidadSPA = (int)numericUpDown3SPA.Value; // Cantidad seleccionada
                subtotalServicios += precioSPA * cantidadSPA;  // Calcular subtotal de SPA
            }

            // Verificar si el CheckBox de Limpieza Diaria está seleccionado
            if (checkBoxlimpieza.Checked)
            {
                decimal precioLimpieza = 15.00m; // Precio fijo para Limpieza Diaria
                int cantidadLimpieza = (int)numericUpDown2Limpieza.Value; // Cantidad seleccionada
                subtotalServicios += precioLimpieza * cantidadLimpieza;  // Calcular subtotal de Limpieza Diaria
            }

            // Verificar si el CheckBox de Minibar está seleccionado
            if (checkBoxminibar.Checked)
            {
                decimal precioMinibar = 7.00m; // Precio fijo para Minibar
                int cantidadMinibar = (int)numericUpDown4Bar.Value; // Cantidad seleccionada
                subtotalServicios += precioMinibar * cantidadMinibar;  // Calcular subtotal de Minibar
            }

            // Actualizar el Label con el subtotal de los servicios
            label22SubtotalServicios.Text = subtotalServicios.ToString("C");
        }

        private void checkBoxdesayuno_CheckedChanged(object sender, EventArgs e)
        {
            CalcularSubtotalServicios();  // Llamar al método para actualizar el subtotal de servicios
                                          
            // Calcular el total (habitaciones + servicios)
            CalcularTotal();
        }

        private void numericUpDown1Desayuno_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotalServicios();  // Llamar al método para actualizar el subtotal de servicios

            // Calcular el total (habitaciones + servicios)
            CalcularTotal();
        }

        private void checkBoxlimpieza_CheckedChanged(object sender, EventArgs e)
        {
            CalcularSubtotalServicios();  // Llamar al método para actualizar el subtotal de servicios

            // Calcular el total (habitaciones + servicios)
            CalcularTotal();
        }

        private void numericUpDown2Limpieza_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotalServicios();  // Llamar al método para actualizar el subtotal de servicios

            // Calcular el total (habitaciones + servicios)
            CalcularTotal();
        }

        private void checkBoxspa_CheckedChanged(object sender, EventArgs e)
        {
            CalcularSubtotalServicios();  // Llamar al método para actualizar el subtotal de servicios

            // Calcular el total (habitaciones + servicios)
            CalcularTotal();
        }

        private void numericUpDown3SPA_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotalServicios();  // Llamar al método para actualizar el subtotal de servicios

            // Calcular el total (habitaciones + servicios)
            CalcularTotal();
        }

        private void checkBoxminibar_CheckedChanged(object sender, EventArgs e)
        {
            CalcularSubtotalServicios();  // Llamar al método para actualizar el subtotal de servicios

            // Calcular el total (habitaciones + servicios)
            CalcularTotal();
        }

        private void numericUpDown4Bar_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotalServicios();  // Llamar al método para actualizar el subtotal de servicios

            // Calcular el total (habitaciones + servicios)
            CalcularTotal();
        }

        private void CargarMetodosPagoComboBox()
        {
            ReservaDatos datos = new ReservaDatos();
            DataTable dt = datos.CargarMetodoPago();

            cmbx_formaPago.DisplayMember = "NombreMetodo";   // Lo que se muestra
            cmbx_formaPago.ValueMember = "MetodoPagoID";     // El valor interno (ID)
            cmbx_formaPago.DataSource = dt;
        }

        private void LimpiarFormulario()
        {
            // Recargar datos de ComboBox
            CargarHuespedesComboBox();
            CargarHabitacionesComboBox();
            CargarMetodosPagoComboBox();

            // Limpiar ComboBox de huésped
            cmbx_huesped.SelectedIndex = -1;

            // Limpiar ComboBox de habitación
            cmbx_habitacion.SelectedIndex = -1;

            // Limpiar ComboBox de método de pago
            cmbx_formaPago.SelectedIndex = -1;

            // Limpiar ComboBox de estado de reserva
            cmbx_estadoReserva.SelectedIndex = -1;

            // Limpiar TextBox de observaciones y cantidad de personas
            txb_Observaciones.Text = string.Empty;
            txb_cantpersonas.Text = string.Empty;

            // Reiniciar DateTimePickers a la fecha actual
            dateTimePickerFechaReserva.Value = DateTime.Now;
            dtp_entrada.Value = DateTime.Now;
            dtp_salida.Value = DateTime.Now;

            // Desmarcar y reiniciar NumericUpDown de servicios
            checkBoxdesayuno.Checked = false;
            checkBoxspa.Checked = false;
            checkBoxlimpieza.Checked = false;
            checkBoxminibar.Checked = false;

            numericUpDown1Desayuno.Value = 0;
            numericUpDown3SPA.Value = 0;
            numericUpDown2Limpieza.Value = 0;
            numericUpDown4Bar.Value = 0;

            // Limpiar DataTable y refrescar DataGridView de habitaciones seleccionadas
            dtHabitacionesSeleccionadas.Clear();
            dataGridView3.DataSource = dtHabitacionesSeleccionadas;

            // Limpiar subtotales y total
            label21SubTotalhabitaciones.Text = "0";
            label22SubtotalServicios.Text = "0";
            label23MontoTotal.Text = "0";
        }

        private void button5Guardar_Click(object sender, EventArgs e)
        {
            var selectedHuesped = cmbx_huesped.SelectedItem as DataRowView;
            if (selectedHuesped == null)
            {
                MessageBox.Show("Seleccione un huésped.");
                return;
            }
            int huespedID = (int)selectedHuesped["HuespedID"];

            int empleadoID = SesionUsuario.EmpleadoActual.id_empleado;

            DateTime fechaReserva = dateTimePickerFechaReserva.Value;
            DateTime fechaEntrada = dtp_entrada.Value;
            DateTime fechaSalida = dtp_salida.Value;

            string estadoReserva = cmbx_estadoReserva.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(estadoReserva))
            {
                MessageBox.Show("Seleccione un estado de reserva.");
                return;
            }

            string observaciones = txb_Observaciones.Text;

            if (cmbx_formaPago.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un método de pago.");
                return;
            }
            int metodoPagoID = Convert.ToInt32(cmbx_formaPago.SelectedValue);

            if (!int.TryParse(txb_cantpersonas.Text, out int cantidadPersonas))
            {
                MessageBox.Show("Ingrese una cantidad válida de personas.");
                return;
            }

            // 1. Guardar la reserva y obtener el ID generado
            ReservaDatos reservaDatos = new ReservaDatos();
            int reservaID = reservaDatos.GuardarReserva(
                huespedID, empleadoID, fechaReserva, fechaEntrada, fechaSalida,
                estadoReserva, observaciones, metodoPagoID, cantidadPersonas);

            // 2. Guardar detalles de habitaciones
            int cantidadNoches = (fechaSalida - fechaEntrada).Days;
            foreach (DataRow row in dtHabitacionesSeleccionadas.Rows)
            {
                int habitacionID = (int)row["Habitaciones"];
                decimal precioNoche = reservaDatos.ObtenerPrecioNochePorHabitacion(habitacionID);
                decimal total = precioNoche * cantidadNoches;
                reservaDatos.GuardarDetalleReserva(reservaID, habitacionID, precioNoche, total);

                // Actualizar estado de la habitación a "Ocupada"
                reservaDatos.ActualizarEstadoHabitacion(habitacionID);
            }

            // 3. Guardar servicios seleccionados
            // Mapeo de IDs de servicios (ajusta según tu base de datos)
            var servicios = new[]
            {
                new { Check = checkBoxdesayuno, Cantidad = (int)numericUpDown1Desayuno.Value, ServicioID = 1, Precio = 10.00m },
                new { Check = checkBoxspa, Cantidad = (int)numericUpDown3SPA.Value, ServicioID = 6, Precio = 25.00m },
                new { Check = checkBoxlimpieza, Cantidad = (int)numericUpDown2Limpieza.Value, ServicioID = 7, Precio = 15.00m },
                new { Check = checkBoxminibar, Cantidad = (int)numericUpDown4Bar.Value, ServicioID = 8, Precio = 7.00m }
            };

            foreach (var servicio in servicios)
            {
                if (servicio.Check.Checked && servicio.Cantidad > 0)
                {
                    decimal totalServicio = servicio.Precio * servicio.Cantidad;
                    reservaDatos.GuardarServicios(reservaID, servicio.ServicioID, servicio.Precio, totalServicio);
                }
            }

            MessageBox.Show("Reserva guardada correctamente.");

            // Limpiar el formulario después de guardar
            LimpiarFormulario();

            // Recargar el resumen de reservas
            CargarResumenReservas();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén el idreserva de la fila seleccionada
                var idReservaSeleccionada = dataGridView1.Rows[e.RowIndex].Cells["ReservaID"].Value.ToString();

                // Muestra el InputBox con el id ya rellenado
                string input = Interaction.InputBox(
                    "Confirma o ingresa el ID de la reserva:",
                    "Verificar ID de Reserva",
                    idReservaSeleccionada);

                // Si el usuario cancela o deja vacío, no hace nada
                if (string.IsNullOrWhiteSpace(input))
                    return;

                // Aquí puedes validar el ID si lo deseas (por ejemplo, que sea numérico)
                if (!int.TryParse(input, out int idReservaValida))
                {
                    MessageBox.Show("El ID de reserva debe ser un número válido.");
                    return;
                }

                // Abre el formulario Reporte y pásale el ID de reserva
                var frmReporte = new Reporte(idReservaValida);
                frmReporte.ShowDialog(); // Modal

                // Cierra el formulario actual (Reservas)
                this.Close();
            }
        }
    }
}
