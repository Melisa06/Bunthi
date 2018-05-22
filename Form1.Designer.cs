namespace Bunthi
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnBuscar_Puertos = new System.Windows.Forms.Button();
            this.cmbPuertos = new System.Windows.Forms.ComboBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.btnArchivos = new System.Windows.Forms.Button();
            this.lblDatoRecibido = new System.Windows.Forms.Label();
            this.txtDatoRecibido = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Temperatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Luminosidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTime = new System.Windows.Forms.Timer(this.components);
            this.spPuertoSerial = new System.IO.Ports.SerialPort(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar_Puertos
            // 
            this.btnBuscar_Puertos.Location = new System.Drawing.Point(12, 12);
            this.btnBuscar_Puertos.Name = "btnBuscar_Puertos";
            this.btnBuscar_Puertos.Size = new System.Drawing.Size(151, 31);
            this.btnBuscar_Puertos.TabIndex = 0;
            this.btnBuscar_Puertos.Text = "BUSCAR PUERTOS";
            this.btnBuscar_Puertos.UseVisualStyleBackColor = true;
            this.btnBuscar_Puertos.Click += new System.EventHandler(this.btnBuscar_Puertos_Click);
            // 
            // cmbPuertos
            // 
            this.cmbPuertos.FormattingEnabled = true;
            this.cmbPuertos.Location = new System.Drawing.Point(180, 17);
            this.cmbPuertos.Name = "cmbPuertos";
            this.cmbPuertos.Size = new System.Drawing.Size(121, 21);
            this.cmbPuertos.TabIndex = 1;
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(323, 12);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(104, 31);
            this.btnConectar.TabIndex = 2;
            this.btnConectar.Text = "CONECTAR";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(451, 25);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(42, 13);
            this.lblTiempo.TabIndex = 3;
            this.lblTiempo.Text = "Tiempo";
            // 
            // btnArchivos
            // 
            this.btnArchivos.Location = new System.Drawing.Point(12, 74);
            this.btnArchivos.Name = "btnArchivos";
            this.btnArchivos.Size = new System.Drawing.Size(151, 32);
            this.btnArchivos.TabIndex = 4;
            this.btnArchivos.Text = "GUARDAR ARCHIVO";
            this.btnArchivos.UseVisualStyleBackColor = true;
            this.btnArchivos.Click += new System.EventHandler(this.btnArchivos_Click);
            // 
            // lblDatoRecibido
            // 
            this.lblDatoRecibido.AutoSize = true;
            this.lblDatoRecibido.Location = new System.Drawing.Point(13, 133);
            this.lblDatoRecibido.Name = "lblDatoRecibido";
            this.lblDatoRecibido.Size = new System.Drawing.Size(91, 13);
            this.lblDatoRecibido.TabIndex = 6;
            this.lblDatoRecibido.Text = "DATO RECIBIDO";
            // 
            // txtDatoRecibido
            // 
            this.txtDatoRecibido.Location = new System.Drawing.Point(180, 125);
            this.txtDatoRecibido.Name = "txtDatoRecibido";
            this.txtDatoRecibido.Size = new System.Drawing.Size(121, 20);
            this.txtDatoRecibido.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Temperatura,
            this.Luminosidad,
            this.Fecha,
            this.Hora});
            this.dataGridView1.Location = new System.Drawing.Point(16, 214);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(446, 173);
            this.dataGridView1.TabIndex = 8;
            // 
            // Temperatura
            // 
            this.Temperatura.HeaderText = "Temperatura";
            this.Temperatura.Name = "Temperatura";
            // 
            // Luminosidad
            // 
            this.Luminosidad.HeaderText = "Luminosidad";
            this.Luminosidad.Name = "Luminosidad";
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Hora
            // 
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            // 
            // tTime
            // 
            this.tTime.Enabled = true;
            this.tTime.Tick += new System.EventHandler(this.tTime_Tick);
            // 
            // spPuertoSerial
            // 
            this.spPuertoSerial.RtsEnable = true;
            this.spPuertoSerial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spPuertoSerial_DataReceived);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Bunthi";
            this.saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files |*.*";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // txtBrowse
            // 
            this.txtBrowse.Location = new System.Drawing.Point(190, 81);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.Size = new System.Drawing.Size(111, 20);
            this.txtBrowse.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 411);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtDatoRecibido);
            this.Controls.Add(this.lblDatoRecibido);
            this.Controls.Add(this.btnArchivos);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.cmbPuertos);
            this.Controls.Add(this.btnBuscar_Puertos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar_Puertos;
        private System.Windows.Forms.ComboBox cmbPuertos;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Button btnArchivos;
        private System.Windows.Forms.Label lblDatoRecibido;
        private System.Windows.Forms.TextBox txtDatoRecibido;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Luminosidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.Timer tTime;
        private System.IO.Ports.SerialPort spPuertoSerial;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtBrowse;
    }
}

