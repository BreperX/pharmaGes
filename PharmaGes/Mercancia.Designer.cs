namespace PharmaGes
{
    partial class Mercancia
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
            Agregarbtn = new Button();
            nametxt = new TextBox();
            codigotxt = new TextBox();
            descripciontxt = new TextBox();
            stocktxt = new TextBox();
            preciotxt = new TextBox();
            dgvMercancia = new DataGridView();
            fecha = new DateTimePicker();
            Editarbtn = new Button();
            BorrarBtn = new Button();
            Buscarbtn = new Button();
            refrescarbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMercancia).BeginInit();
            SuspendLayout();
            // 
            // Agregarbtn
            // 
            Agregarbtn.BackColor = Color.FromArgb(0, 132, 132);
            Agregarbtn.FlatAppearance.BorderSize = 0;
            Agregarbtn.FlatStyle = FlatStyle.Flat;
            Agregarbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Agregarbtn.ForeColor = SystemColors.Control;
            Agregarbtn.Location = new Point(474, 99);
            Agregarbtn.Name = "Agregarbtn";
            Agregarbtn.Size = new Size(100, 35);
            Agregarbtn.TabIndex = 0;
            Agregarbtn.Text = "Agregar";
            Agregarbtn.UseVisualStyleBackColor = false;
            Agregarbtn.Click += Agregarbtn_Click;
            // 
            // nametxt
            // 
            nametxt.ForeColor = Color.Silver;
            nametxt.Location = new Point(12, 12);
            nametxt.Name = "nametxt";
            nametxt.Size = new Size(225, 23);
            nametxt.TabIndex = 1;
            nametxt.Text = "NOMBRE";
            nametxt.Enter += nametxt_Enter;
            nametxt.Leave += nametxt_Leave;
            // 
            // codigotxt
            // 
            codigotxt.ForeColor = Color.Silver;
            codigotxt.Location = new Point(12, 41);
            codigotxt.Name = "codigotxt";
            codigotxt.Size = new Size(225, 23);
            codigotxt.TabIndex = 2;
            codigotxt.Text = "CÓDIGO";
            codigotxt.Enter += codigotxt_Enter;
            codigotxt.Leave += codigotxt_Leave;
            // 
            // descripciontxt
            // 
            descripciontxt.ForeColor = Color.Silver;
            descripciontxt.Location = new Point(12, 70);
            descripciontxt.Name = "descripciontxt";
            descripciontxt.Size = new Size(225, 23);
            descripciontxt.TabIndex = 3;
            descripciontxt.Text = "DESCRIPCIÓN";
            descripciontxt.Enter += descripciontxt_Enter;
            descripciontxt.Leave += descripciontxt_Leave;
            // 
            // stocktxt
            // 
            stocktxt.ForeColor = Color.Silver;
            stocktxt.Location = new Point(243, 12);
            stocktxt.Name = "stocktxt";
            stocktxt.Size = new Size(225, 23);
            stocktxt.TabIndex = 4;
            stocktxt.Text = "STOCK";
            stocktxt.Enter += stocktxt_Enter;
            stocktxt.Leave += stocktxt_Leave;
            // 
            // preciotxt
            // 
            preciotxt.ForeColor = Color.Silver;
            preciotxt.Location = new Point(243, 41);
            preciotxt.Name = "preciotxt";
            preciotxt.Size = new Size(225, 23);
            preciotxt.TabIndex = 5;
            preciotxt.Text = "PRECIO";
            preciotxt.Enter += preciotxt_Enter;
            preciotxt.Leave += preciotxt_Leave;
            // 
            // dgvMercancia
            // 
            dgvMercancia.AllowUserToAddRows = false;
            dgvMercancia.AllowUserToDeleteRows = false;
            dgvMercancia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMercancia.Location = new Point(12, 99);
            dgvMercancia.Name = "dgvMercancia";
            dgvMercancia.ReadOnly = true;
            dgvMercancia.Size = new Size(456, 259);
            dgvMercancia.TabIndex = 6;
            dgvMercancia.CellClick += dgvMercancia_CellClick;
            // 
            // fecha
            // 
            fecha.Format = DateTimePickerFormat.Short;
            fecha.Location = new Point(243, 70);
            fecha.Name = "fecha";
            fecha.Size = new Size(225, 23);
            fecha.TabIndex = 7;
            fecha.Value = new DateTime(1990, 1, 1, 0, 0, 0, 0);
            // 
            // Editarbtn
            // 
            Editarbtn.BackColor = Color.FromArgb(0, 132, 132);
            Editarbtn.FlatAppearance.BorderSize = 0;
            Editarbtn.FlatStyle = FlatStyle.Flat;
            Editarbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Editarbtn.ForeColor = SystemColors.Control;
            Editarbtn.Location = new Point(474, 140);
            Editarbtn.Name = "Editarbtn";
            Editarbtn.Size = new Size(100, 35);
            Editarbtn.TabIndex = 8;
            Editarbtn.Text = "Editar";
            Editarbtn.UseVisualStyleBackColor = false;
            Editarbtn.Click += Editarbtn_Click;
            // 
            // BorrarBtn
            // 
            BorrarBtn.BackColor = Color.FromArgb(0, 132, 132);
            BorrarBtn.FlatAppearance.BorderSize = 0;
            BorrarBtn.FlatStyle = FlatStyle.Flat;
            BorrarBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BorrarBtn.ForeColor = SystemColors.Control;
            BorrarBtn.Location = new Point(474, 181);
            BorrarBtn.Name = "BorrarBtn";
            BorrarBtn.Size = new Size(100, 35);
            BorrarBtn.TabIndex = 9;
            BorrarBtn.Text = "Borrar";
            BorrarBtn.UseVisualStyleBackColor = false;
            BorrarBtn.Click += BorrarBtn_Click;
            // 
            // Buscarbtn
            // 
            Buscarbtn.BackColor = Color.FromArgb(0, 132, 132);
            Buscarbtn.FlatAppearance.BorderSize = 0;
            Buscarbtn.FlatStyle = FlatStyle.Flat;
            Buscarbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Buscarbtn.ForeColor = SystemColors.Control;
            Buscarbtn.Location = new Point(474, 58);
            Buscarbtn.Name = "Buscarbtn";
            Buscarbtn.Size = new Size(100, 35);
            Buscarbtn.TabIndex = 10;
            Buscarbtn.Text = "Buscar";
            Buscarbtn.UseVisualStyleBackColor = false;
            Buscarbtn.Click += Buscarbtn_Click;
            // 
            // refrescarbtn
            // 
            refrescarbtn.BackColor = Color.FromArgb(0, 132, 132);
            refrescarbtn.FlatAppearance.BorderSize = 0;
            refrescarbtn.FlatStyle = FlatStyle.Flat;
            refrescarbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            refrescarbtn.ForeColor = SystemColors.Control;
            refrescarbtn.Location = new Point(474, 17);
            refrescarbtn.Name = "refrescarbtn";
            refrescarbtn.Size = new Size(100, 35);
            refrescarbtn.TabIndex = 11;
            refrescarbtn.Text = "Refrescar";
            refrescarbtn.UseVisualStyleBackColor = false;
            refrescarbtn.Click += refrescarbtn_Click;
            // 
            // Mercancia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 370);
            Controls.Add(refrescarbtn);
            Controls.Add(Buscarbtn);
            Controls.Add(BorrarBtn);
            Controls.Add(Editarbtn);
            Controls.Add(fecha);
            Controls.Add(dgvMercancia);
            Controls.Add(preciotxt);
            Controls.Add(stocktxt);
            Controls.Add(descripciontxt);
            Controls.Add(codigotxt);
            Controls.Add(nametxt);
            Controls.Add(Agregarbtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Mercancia";
            Text = "Mercancia";
            Load += Mercancia_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMercancia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Agregarbtn;
        private TextBox nametxt;
        private TextBox codigotxt;
        private TextBox descripciontxt;
        private TextBox stocktxt;
        private TextBox preciotxt;
        private DataGridView dgvMercancia;
        private DateTimePicker fecha;
        private Button Editarbtn;
        private Button BorrarBtn;
        private Button Buscarbtn;
        private Button refrescarbtn;
    }
}