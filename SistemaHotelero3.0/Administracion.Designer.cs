namespace SistemaHotelero3._0
{
    partial class Administracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administracion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxHoraFin = new System.Windows.Forms.ComboBox();
            this.comboBoxHoraInicio = new System.Windows.Forms.ComboBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxNumDocumento = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.comboBoxJornada = new System.Windows.Forms.ComboBox();
            this.comboBoxRol = new System.Windows.Forms.ComboBox();
            this.dateTimePickerContratacion = new System.Windows.Forms.DateTimePicker();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.comboBoxTipoDocumento = new System.Windows.Forms.ComboBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iNICIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hABITACIONESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.huéspedesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.labelUsuario);
            this.panel1.Location = new System.Drawing.Point(-8, 540);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 45);
            this.panel1.TabIndex = 170;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1071, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(77, 24);
            this.button5.TabIndex = 107;
            this.button5.Text = "Cerrar sesión";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(12, 16);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(51, 20);
            this.labelUsuario.TabIndex = 0;
            this.labelUsuario.Text = "label9";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(639, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(498, 309);
            this.dataGridView1.TabIndex = 169;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // comboBoxHoraFin
            // 
            this.comboBoxHoraFin.FormattingEnabled = true;
            this.comboBoxHoraFin.Items.AddRange(new object[] {
            "15:00",
            "17:00"});
            this.comboBoxHoraFin.Location = new System.Drawing.Point(485, 462);
            this.comboBoxHoraFin.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxHoraFin.Name = "comboBoxHoraFin";
            this.comboBoxHoraFin.Size = new System.Drawing.Size(76, 21);
            this.comboBoxHoraFin.TabIndex = 168;
            // 
            // comboBoxHoraInicio
            // 
            this.comboBoxHoraInicio.FormattingEnabled = true;
            this.comboBoxHoraInicio.Items.AddRange(new object[] {
            "07:00:00",
            "08:00:00",
            "09:00:00"});
            this.comboBoxHoraInicio.Location = new System.Drawing.Point(303, 463);
            this.comboBoxHoraInicio.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxHoraInicio.Name = "comboBoxHoraInicio";
            this.comboBoxHoraInicio.Size = new System.Drawing.Size(76, 21);
            this.comboBoxHoraInicio.TabIndex = 167;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEmail.Location = new System.Drawing.Point(485, 223);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(145, 20);
            this.textBoxEmail.TabIndex = 166;
            // 
            // textBoxNumDocumento
            // 
            this.textBoxNumDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNumDocumento.Location = new System.Drawing.Point(485, 178);
            this.textBoxNumDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNumDocumento.Name = "textBoxNumDocumento";
            this.textBoxNumDocumento.Size = new System.Drawing.Size(145, 20);
            this.textBoxNumDocumento.TabIndex = 165;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxApellido.Location = new System.Drawing.Point(485, 128);
            this.textBoxApellido.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(145, 20);
            this.textBoxApellido.TabIndex = 164;
            // 
            // comboBoxJornada
            // 
            this.comboBoxJornada.FormattingEnabled = true;
            this.comboBoxJornada.Items.AddRange(new object[] {
            "Mañana",
            "lunes-viernes",
            "Noche",
            "lunes-viernes",
            "lunes-viernes"});
            this.comboBoxJornada.Location = new System.Drawing.Point(100, 465);
            this.comboBoxJornada.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxJornada.Name = "comboBoxJornada";
            this.comboBoxJornada.Size = new System.Drawing.Size(76, 21);
            this.comboBoxJornada.TabIndex = 163;
            // 
            // comboBoxRol
            // 
            this.comboBoxRol.FormattingEnabled = true;
            this.comboBoxRol.Items.AddRange(new object[] {
            "Administrador",
            "Recepcionista",
            "Limpieza"});
            this.comboBoxRol.Location = new System.Drawing.Point(205, 362);
            this.comboBoxRol.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(174, 21);
            this.comboBoxRol.TabIndex = 162;
            // 
            // dateTimePickerContratacion
            // 
            this.dateTimePickerContratacion.Location = new System.Drawing.Point(205, 318);
            this.dateTimePickerContratacion.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerContratacion.Name = "dateTimePickerContratacion";
            this.dateTimePickerContratacion.Size = new System.Drawing.Size(174, 20);
            this.dateTimePickerContratacion.TabIndex = 161;
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDireccion.Location = new System.Drawing.Point(205, 272);
            this.textBoxDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(174, 20);
            this.textBoxDireccion.TabIndex = 160;
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTelefono.Location = new System.Drawing.Point(205, 223);
            this.textBoxTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(174, 20);
            this.textBoxTelefono.TabIndex = 159;
            // 
            // comboBoxTipoDocumento
            // 
            this.comboBoxTipoDocumento.FormattingEnabled = true;
            this.comboBoxTipoDocumento.Items.AddRange(new object[] {
            "CI",
            "NIT",
            "PASAPORTE"});
            this.comboBoxTipoDocumento.Location = new System.Drawing.Point(205, 178);
            this.comboBoxTipoDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTipoDocumento.Name = "comboBoxTipoDocumento";
            this.comboBoxTipoDocumento.Size = new System.Drawing.Size(174, 21);
            this.comboBoxTipoDocumento.TabIndex = 158;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNombre.Location = new System.Drawing.Point(205, 126);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(174, 20);
            this.textBoxNombre.TabIndex = 157;
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(992, 463);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(77, 24);
            this.buttonModificar.TabIndex = 156;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(852, 463);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(77, 24);
            this.buttonEliminar.TabIndex = 155;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(710, 462);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(77, 24);
            this.buttonGuardar.TabIndex = 154;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(446, 462);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 20);
            this.label14.TabIndex = 153;
            this.label14.Text = "Fin:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(251, 463);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 20);
            this.label13.TabIndex = 152;
            this.label13.Text = "Inicio:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(28, 464);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 20);
            this.label12.TabIndex = 151;
            this.label12.Text = "Jornada";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(27, 415);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 20);
            this.label11.TabIndex = 150;
            this.label11.Text = "Horario semanal:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(28, 363);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 20);
            this.label10.TabIndex = 149;
            this.label10.Text = "Rol del empleado:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 318);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 20);
            this.label9.TabIndex = 148;
            this.label9.Text = "Fecha de contratación:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 147;
            this.label8.Text = "Dirección:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(410, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 146;
            this.label7.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 145;
            this.label6.Text = "Teléfono:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(411, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 144;
            this.label5.Text = "Número:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 143;
            this.label4.Text = "Tipo de documento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(411, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 142;
            this.label3.Text = "Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 141;
            this.label2.Text = "Nombre:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iNICIOToolStripMenuItem,
            this.hABITACIONESToolStripMenuItem,
            this.huéspedesToolStripMenuItem,
            this.reservasToolStripMenuItem,
            this.administraciónToolStripMenuItem,
            this.reporteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1169, 67);
            this.menuStrip1.TabIndex = 183;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iNICIOToolStripMenuItem
            // 
            this.iNICIOToolStripMenuItem.AutoSize = false;
            this.iNICIOToolStripMenuItem.AutoToolTip = true;
            this.iNICIOToolStripMenuItem.Image = global::SistemaHotelero3._0.Properties.Resources.home_icon_icons_com_73532;
            this.iNICIOToolStripMenuItem.Name = "iNICIOToolStripMenuItem";
            this.iNICIOToolStripMenuItem.Size = new System.Drawing.Size(194, 63);
            this.iNICIOToolStripMenuItem.Text = "Inicio";
            this.iNICIOToolStripMenuItem.Click += new System.EventHandler(this.iNICIOToolStripMenuItem_Click);
            // 
            // hABITACIONESToolStripMenuItem
            // 
            this.hABITACIONESToolStripMenuItem.AutoSize = false;
            this.hABITACIONESToolStripMenuItem.Image = global::SistemaHotelero3._0.Properties.Resources.suitcase_with_white_details_icon_icons_com_73387;
            this.hABITACIONESToolStripMenuItem.Name = "hABITACIONESToolStripMenuItem";
            this.hABITACIONESToolStripMenuItem.Size = new System.Drawing.Size(194, 63);
            this.hABITACIONESToolStripMenuItem.Text = "Habitaciones";
            this.hABITACIONESToolStripMenuItem.Click += new System.EventHandler(this.hABITACIONESToolStripMenuItem_Click);
            // 
            // huéspedesToolStripMenuItem
            // 
            this.huéspedesToolStripMenuItem.AutoSize = false;
            this.huéspedesToolStripMenuItem.Image = global::SistemaHotelero3._0.Properties.Resources.group_profile_users_icon_icons_com_73540;
            this.huéspedesToolStripMenuItem.Name = "huéspedesToolStripMenuItem";
            this.huéspedesToolStripMenuItem.Size = new System.Drawing.Size(194, 63);
            this.huéspedesToolStripMenuItem.Text = "Huéspedes";
            this.huéspedesToolStripMenuItem.Click += new System.EventHandler(this.huéspedesToolStripMenuItem_Click);
            // 
            // reservasToolStripMenuItem
            // 
            this.reservasToolStripMenuItem.AutoSize = false;
            this.reservasToolStripMenuItem.Image = global::SistemaHotelero3._0.Properties.Resources.calendar_with_spring_binder_and_date_blocks_icon_icons_com_73645;
            this.reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            this.reservasToolStripMenuItem.Size = new System.Drawing.Size(194, 63);
            this.reservasToolStripMenuItem.Text = "Reservas";
            this.reservasToolStripMenuItem.Click += new System.EventHandler(this.reservasToolStripMenuItem_Click);
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.AutoSize = false;
            this.administraciónToolStripMenuItem.Image = global::SistemaHotelero3._0.Properties.Resources.cog_wheel_silhouette_icon_icons_com_73617;
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(194, 63);
            this.administraciónToolStripMenuItem.Text = "Administración";
            // 
            // reporteToolStripMenuItem
            // 
            this.reporteToolStripMenuItem.AutoSize = false;
            this.reporteToolStripMenuItem.Image = global::SistemaHotelero3._0.Properties.Resources.archivo_pdf;
            this.reporteToolStripMenuItem.Name = "reporteToolStripMenuItem";
            this.reporteToolStripMenuItem.Size = new System.Drawing.Size(194, 63);
            this.reporteToolStripMenuItem.Text = "Reporte";
            this.reporteToolStripMenuItem.Click += new System.EventHandler(this.reporteToolStripMenuItem_Click);
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = global::SistemaHotelero3._0.Properties.Resources.Logo;
            this.pictureBox12.Location = new System.Drawing.Point(450, 318);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(128, 124);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 171;
            this.pictureBox12.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(411, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 184;
            this.label1.Text = "Estado :";
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "CI",
            "NIT",
            "PASAPORTE"});
            this.comboBoxEstado.Location = new System.Drawing.Point(485, 271);
            this.comboBoxEstado.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(145, 21);
            this.comboBoxEstado.TabIndex = 185;
            // 
            // Administracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 584);
            this.Controls.Add(this.comboBoxEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxHoraFin);
            this.Controls.Add(this.comboBoxHoraInicio);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxNumDocumento);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.comboBoxJornada);
            this.Controls.Add(this.comboBoxRol);
            this.Controls.Add(this.dateTimePickerContratacion);
            this.Controls.Add(this.textBoxDireccion);
            this.Controls.Add(this.textBoxTelefono);
            this.Controls.Add(this.comboBoxTipoDocumento);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Administracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administracion";
            this.Load += new System.EventHandler(this.Administracion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxHoraFin;
        private System.Windows.Forms.ComboBox comboBoxHoraInicio;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxNumDocumento;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.ComboBox comboBoxJornada;
        private System.Windows.Forms.ComboBox comboBoxRol;
        private System.Windows.Forms.DateTimePicker dateTimePickerContratacion;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.ComboBox comboBoxTipoDocumento;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iNICIOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hABITACIONESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem huéspedesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxEstado;
    }
}