using CapaDatos;
using CapaModelo;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotelero3._0
{
    public partial class Reporte : Form
    {
        private int _idReserva;
        public Reporte(int idReserva)
        {
            InitializeComponent();
            _idReserva = idReserva;
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            // Verifica que el empleado haya iniciado sesión
            if (SesionUsuario.EmpleadoActual != null)
            {
                labelUsuario.Text = $"{SesionUsuario.EmpleadoActual.nombre} {SesionUsuario.EmpleadoActual.apellido}";
            }
            else
            {
                MessageBox.Show("No se ha iniciado sesión.");
                return;
            }

            // Cargar datos de la reserva
            CargarDatosReserva();
            // Cargar habitaciones asociadas
            CargarHabitaciones();
            // Cargar servicios asociados
            CargarServicios();
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

        private void administraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracion form = new Administracion();
            form.Show();
            this.Close();
        }

        private void CargarDatosReserva()
        {
            ReservaDatos datos = new ReservaDatos();
            // Debes crear un método que devuelva los datos de la reserva por ID
            DataRow reserva = datos.ObtenerDatosReservaPorId(_idReserva);
            if (reserva == null)
            {
                MessageBox.Show("No se encontró la reserva.");
                this.Close();
                return;
            }

            idreserva.Text = reserva["ReservaID"].ToString();
            responsable.Text = reserva["Responsable"].ToString();
            huesped.Text = reserva["NombreHuesped"].ToString();
            documento.Text = reserva["NumeroDocumento"].ToString();
            fechareserva.Text = Convert.ToDateTime(reserva["FechaReserva"]).ToShortDateString();
            entrada.Text = Convert.ToDateTime(reserva["FechaEntrada"]).ToShortDateString();
            salida.Text = Convert.ToDateTime(reserva["FechaSalida"]).ToShortDateString();
            cantidadpersonas.Text = reserva["CantidadPersonas"].ToString();
            estadoreserva.Text = reserva["EstadoReserva"].ToString();
            formapago.Text = reserva["NombreMetodo"].ToString();
            observaciones.Text = reserva["Observaciones"].ToString();
            totalreserva.Text = Convert.ToDecimal(reserva["TotalReserva"]).ToString("C");
        }

        private void CargarHabitaciones()
        {
            ReservaDatos datos = new ReservaDatos();
            // Debes crear un método que devuelva las habitaciones por ID de reserva
            DataTable dt = datos.ObtenerHabitacionesPorReserva(_idReserva);
            dataGridViewHabitaciones.DataSource = dt;
        }

        private void CargarServicios()
        {
            ReservaDatos datos = new ReservaDatos();
            // Debes crear un método que devuelva los servicios por ID de reserva
            DataTable dt = datos.ObtenerServiciosPorReserva(_idReserva);
            dataGridViewServicios.DataSource = dt;
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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Guardar reporte como PDF";
            saveFileDialog.FileName = $"ReporteReserva_{idreserva.Text}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // Título principal
                    var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22);
                    var subTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                    Paragraph title = new Paragraph("Hotel Necesidad", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);

                    // Fecha y responsable
                    PdfPTable headerTable = new PdfPTable(2);
                    headerTable.WidthPercentage = 100;
                    headerTable.SetWidths(new float[] { 1, 1 });
                    headerTable.AddCell(new PdfPCell(new Phrase($"ID Reserva : {idreserva.Text}\nResponsable : {responsable.Text}", normalFont)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    headerTable.AddCell(new PdfPCell(new Phrase($"Fecha Reserva : {fechareserva.Text}", normalFont)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    doc.Add(headerTable);

                    doc.Add(new Paragraph("\n"));

                    // Datos del huésped
                    Paragraph datosHuesped = new Paragraph("Datos del Huesped", subTitleFont);
                    datosHuesped.Alignment = Element.ALIGN_LEFT;
                    datosHuesped.SpacingAfter = 10f;
                    doc.Add(datosHuesped);

                    PdfPTable datosTable = new PdfPTable(2);
                    datosTable.WidthPercentage = 60;
                    datosTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    datosTable.AddCell("Huesped :");
                    datosTable.AddCell(huesped.Text);
                    datosTable.AddCell("Numero de Documento :");
                    datosTable.AddCell(documento.Text);
                    datosTable.AddCell("Fecha de Entrada :");
                    datosTable.AddCell(entrada.Text);
                    datosTable.AddCell("Fecha de Salida :");
                    datosTable.AddCell(salida.Text);
                    datosTable.AddCell("Cantidad de Personas :");
                    datosTable.AddCell(cantidadpersonas.Text);
                    datosTable.AddCell("Estado de la Reserva :");
                    datosTable.AddCell(estadoreserva.Text);
                    datosTable.AddCell("Método de Pago :");
                    datosTable.AddCell(formapago.Text);
                    datosTable.AddCell("Observaciones :");
                    datosTable.AddCell(observaciones.Text);
                    doc.Add(datosTable);

                    doc.Add(new Paragraph("\n"));

                    // Habitaciones
                    Paragraph habTitle = new Paragraph("Habitaciones", subTitleFont);
                    habTitle.Alignment = Element.ALIGN_LEFT;
                    doc.Add(habTitle);

                    PdfPTable habTable = new PdfPTable(dataGridViewHabitaciones.Columns.Count);
                    habTable.WidthPercentage = 100;
                    // Encabezados
                    foreach (DataGridViewColumn col in dataGridViewHabitaciones.Columns)
                        habTable.AddCell(new Phrase(col.HeaderText, normalFont));
                    // Filas
                    foreach (DataGridViewRow row in dataGridViewHabitaciones.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                                habTable.AddCell(new Phrase(cell.Value?.ToString() ?? "", normalFont));
                        }
                    }
                    doc.Add(habTable);

                    doc.Add(new Paragraph("\n"));

                    // Servicios
                    Paragraph servTitle = new Paragraph("Servicios", subTitleFont);
                    servTitle.Alignment = Element.ALIGN_LEFT;
                    doc.Add(servTitle);

                    PdfPTable servTable = new PdfPTable(dataGridViewServicios.Columns.Count);
                    servTable.WidthPercentage = 100;
                    // Encabezados
                    foreach (DataGridViewColumn col in dataGridViewServicios.Columns)
                        servTable.AddCell(new Phrase(col.HeaderText, normalFont));
                    // Filas
                    foreach (DataGridViewRow row in dataGridViewServicios.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                                servTable.AddCell(new Phrase(cell.Value?.ToString() ?? "", normalFont));
                        }
                    }
                    doc.Add(servTable);

                    doc.Add(new Paragraph("\n"));

                    // Total y usuario
                    PdfPTable footerTable = new PdfPTable(2);
                    footerTable.WidthPercentage = 100;
                    footerTable.SetWidths(new float[] { 1, 1 });
                    footerTable.AddCell(new PdfPCell(new Phrase(labelUsuario.Text, normalFont)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                    footerTable.AddCell(new PdfPCell(new Phrase($"Total Reserva : {totalreserva.Text}", normalFont)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    doc.Add(footerTable);

                    doc.Close();
                }

                MessageBox.Show("PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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
    }
}
