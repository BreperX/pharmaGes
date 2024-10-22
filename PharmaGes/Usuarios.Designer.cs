namespace PharmaGes
{
    partial class Usuarios
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
            usuariosdgv = new DataGridView();
            BorrarBtn = new Button();
            Editarbtn = new Button();
            nametxt = new TextBox();
            Agregarbtn = new Button();
            emailtxt = new TextBox();
            passtxt = new TextBox();
            rolescb = new ComboBox();
            busquedatxt = new TextBox();
            Buscarbtn = new Button();
            refrescarbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)usuariosdgv).BeginInit();
            SuspendLayout();
            // 
            // usuariosdgv
            // 
            usuariosdgv.AllowUserToAddRows = false;
            usuariosdgv.AllowUserToDeleteRows = false;
            usuariosdgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usuariosdgv.Location = new Point(12, 99);
            usuariosdgv.Name = "usuariosdgv";
            usuariosdgv.ReadOnly = true;
            usuariosdgv.Size = new Size(450, 259);
            usuariosdgv.TabIndex = 0;
            usuariosdgv.CellClick += usuariosdgv_CellClick;
            // 
            // BorrarBtn
            // 
            BorrarBtn.BackColor = Color.FromArgb(0, 132, 132);
            BorrarBtn.FlatAppearance.BorderSize = 0;
            BorrarBtn.FlatStyle = FlatStyle.Flat;
            BorrarBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BorrarBtn.ForeColor = SystemColors.Control;
            BorrarBtn.Location = new Point(468, 181);
            BorrarBtn.Name = "BorrarBtn";
            BorrarBtn.Size = new Size(100, 35);
            BorrarBtn.TabIndex = 13;
            BorrarBtn.Text = "Borrar";
            BorrarBtn.UseVisualStyleBackColor = false;
            BorrarBtn.Click += BorrarBtn_Click;
            // 
            // Editarbtn
            // 
            Editarbtn.BackColor = Color.FromArgb(0, 132, 132);
            Editarbtn.FlatAppearance.BorderSize = 0;
            Editarbtn.FlatStyle = FlatStyle.Flat;
            Editarbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Editarbtn.ForeColor = SystemColors.Control;
            Editarbtn.Location = new Point(468, 140);
            Editarbtn.Name = "Editarbtn";
            Editarbtn.Size = new Size(100, 35);
            Editarbtn.TabIndex = 12;
            Editarbtn.Text = "Editar";
            Editarbtn.UseVisualStyleBackColor = false;
            Editarbtn.Click += Editarbtn_Click;
            // 
            // nametxt
            // 
            nametxt.ForeColor = Color.Silver;
            nametxt.Location = new Point(12, 41);
            nametxt.Name = "nametxt";
            nametxt.Size = new Size(225, 23);
            nametxt.TabIndex = 11;
            nametxt.Text = "NOMBRE";
            nametxt.Enter += nametxt_Enter;
            nametxt.Leave += nametxt_Leave;
            // 
            // Agregarbtn
            // 
            Agregarbtn.BackColor = Color.FromArgb(0, 132, 132);
            Agregarbtn.FlatAppearance.BorderSize = 0;
            Agregarbtn.FlatStyle = FlatStyle.Flat;
            Agregarbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Agregarbtn.ForeColor = SystemColors.Control;
            Agregarbtn.Location = new Point(468, 99);
            Agregarbtn.Name = "Agregarbtn";
            Agregarbtn.Size = new Size(100, 35);
            Agregarbtn.TabIndex = 10;
            Agregarbtn.Text = "Agregar";
            Agregarbtn.UseVisualStyleBackColor = false;
            Agregarbtn.Click += Agregarbtn_Click;
            // 
            // emailtxt
            // 
            emailtxt.ForeColor = Color.Silver;
            emailtxt.Location = new Point(12, 70);
            emailtxt.Name = "emailtxt";
            emailtxt.Size = new Size(225, 23);
            emailtxt.TabIndex = 14;
            emailtxt.Text = "CONTRASEÑA";
            emailtxt.Enter += emailtxt_Enter;
            emailtxt.Leave += emailtxt_Leave;
            // 
            // passtxt
            // 
            passtxt.ForeColor = Color.Silver;
            passtxt.Location = new Point(243, 70);
            passtxt.Name = "passtxt";
            passtxt.Size = new Size(219, 23);
            passtxt.TabIndex = 15;
            passtxt.Text = "EMAIL";
            passtxt.Enter += passtxt_Enter;
            passtxt.Leave += passtxt_Leave;
            // 
            // rolescb
            // 
            rolescb.FormattingEnabled = true;
            rolescb.Items.AddRange(new object[] { "Administrador", "Gerente", "Empleado" });
            rolescb.Location = new Point(243, 41);
            rolescb.Name = "rolescb";
            rolescb.Size = new Size(121, 23);
            rolescb.TabIndex = 16;
            rolescb.Text = "Roles";
            // 
            // busquedatxt
            // 
            busquedatxt.ForeColor = Color.Silver;
            busquedatxt.Location = new Point(12, 12);
            busquedatxt.Name = "busquedatxt";
            busquedatxt.Size = new Size(225, 23);
            busquedatxt.TabIndex = 17;
            busquedatxt.Text = "NOMBRE / EMAIL";
            busquedatxt.Enter += busquedatxt_Enter;
            busquedatxt.Leave += busquedatxt_Leave;
            // 
            // Buscarbtn
            // 
            Buscarbtn.BackColor = Color.FromArgb(0, 132, 132);
            Buscarbtn.FlatAppearance.BorderSize = 0;
            Buscarbtn.FlatStyle = FlatStyle.Flat;
            Buscarbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Buscarbtn.ForeColor = SystemColors.Control;
            Buscarbtn.Location = new Point(468, 12);
            Buscarbtn.Name = "Buscarbtn";
            Buscarbtn.Size = new Size(100, 35);
            Buscarbtn.TabIndex = 18;
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
            refrescarbtn.Location = new Point(468, 53);
            refrescarbtn.Name = "refrescarbtn";
            refrescarbtn.Size = new Size(100, 35);
            refrescarbtn.TabIndex = 19;
            refrescarbtn.Text = "Refrescar";
            refrescarbtn.UseVisualStyleBackColor = false;
            refrescarbtn.Click += refrescarbtn_Click;
            // 
            // Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 370);
            Controls.Add(refrescarbtn);
            Controls.Add(Buscarbtn);
            Controls.Add(busquedatxt);
            Controls.Add(rolescb);
            Controls.Add(passtxt);
            Controls.Add(emailtxt);
            Controls.Add(BorrarBtn);
            Controls.Add(Editarbtn);
            Controls.Add(nametxt);
            Controls.Add(Agregarbtn);
            Controls.Add(usuariosdgv);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Usuarios";
            Text = "Usuarios";
            Load += Usuarios_Load;
            ((System.ComponentModel.ISupportInitialize)usuariosdgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView usuariosdgv;
        private Button BorrarBtn;
        private Button Editarbtn;
        private TextBox nametxt;
        private Button Agregarbtn;
        private TextBox emailtxt;
        private TextBox passtxt;
        private ComboBox rolescb;
        private TextBox busquedatxt;
        private Button Buscarbtn;
        private Button refrescarbtn;
    }
}