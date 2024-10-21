namespace PharmaGes
{
    partial class ventas
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
            busquedatxt = new TextBox();
            buscarbtn = new Button();
            nombretxt = new TextBox();
            cantidadtxt = new TextBox();
            preciotxt = new TextBox();
            eliminarBtn = new Button();
            editarbtn = new Button();
            agregarbtn = new Button();
            totallbl = new Label();
            efectivolbl = new Label();
            carritodgv = new DataGridView();
            cambiolbl = new Label();
            Cancelarbtn = new Button();
            Pagarbtn = new Button();
            totaltxt = new TextBox();
            efectivotxt = new TextBox();
            cambiotxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)carritodgv).BeginInit();
            SuspendLayout();
            // 
            // busquedatxt
            // 
            busquedatxt.ForeColor = Color.Silver;
            busquedatxt.Location = new Point(12, 15);
            busquedatxt.Name = "busquedatxt";
            busquedatxt.Size = new Size(225, 23);
            busquedatxt.TabIndex = 2;
            busquedatxt.Text = "NOMBRE / CÓDIGO";
            busquedatxt.Enter += busquedatxt_Enter;
            busquedatxt.Leave += busquedatxt_Leave;
            // 
            // buscarbtn
            // 
            buscarbtn.BackColor = Color.FromArgb(0, 132, 132);
            buscarbtn.FlatAppearance.BorderSize = 0;
            buscarbtn.FlatStyle = FlatStyle.Flat;
            buscarbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buscarbtn.ForeColor = SystemColors.Control;
            buscarbtn.Location = new Point(349, 3);
            buscarbtn.Name = "buscarbtn";
            buscarbtn.Size = new Size(100, 35);
            buscarbtn.TabIndex = 11;
            buscarbtn.Text = "Buscar";
            buscarbtn.UseVisualStyleBackColor = false;
            buscarbtn.Click += buscarbtn_Click;
            // 
            // nombretxt
            // 
            nombretxt.ForeColor = Color.Silver;
            nombretxt.Location = new Point(12, 44);
            nombretxt.Name = "nombretxt";
            nombretxt.Size = new Size(225, 23);
            nombretxt.TabIndex = 12;
            nombretxt.Text = "NOMBRE";
            nombretxt.Enter += nombretxt_Enter;
            nombretxt.Leave += nombretxt_Leave;
            // 
            // cantidadtxt
            // 
            cantidadtxt.ForeColor = Color.Silver;
            cantidadtxt.Location = new Point(243, 44);
            cantidadtxt.Name = "cantidadtxt";
            cantidadtxt.Size = new Size(100, 23);
            cantidadtxt.TabIndex = 13;
            cantidadtxt.Text = "CANTIDAD";
            cantidadtxt.Enter += cantidadtxt_Enter;
            cantidadtxt.Leave += cantidadtxt_Leave;
            // 
            // preciotxt
            // 
            preciotxt.ForeColor = Color.Silver;
            preciotxt.Location = new Point(349, 44);
            preciotxt.Name = "preciotxt";
            preciotxt.Size = new Size(100, 23);
            preciotxt.TabIndex = 14;
            preciotxt.Text = "PRECIO";
            preciotxt.Enter += preciotxt_Enter;
            preciotxt.Leave += preciotxt_Leave;
            // 
            // eliminarBtn
            // 
            eliminarBtn.BackColor = Color.FromArgb(0, 132, 132);
            eliminarBtn.FlatAppearance.BorderSize = 0;
            eliminarBtn.FlatStyle = FlatStyle.Flat;
            eliminarBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            eliminarBtn.ForeColor = SystemColors.Control;
            eliminarBtn.Location = new Point(468, 44);
            eliminarBtn.Name = "eliminarBtn";
            eliminarBtn.Size = new Size(100, 35);
            eliminarBtn.TabIndex = 17;
            eliminarBtn.Text = "Eliminar";
            eliminarBtn.UseVisualStyleBackColor = false;
            eliminarBtn.Click += eliminarBtn_Click;
            // 
            // editarbtn
            // 
            editarbtn.BackColor = Color.FromArgb(0, 132, 132);
            editarbtn.FlatAppearance.BorderSize = 0;
            editarbtn.FlatStyle = FlatStyle.Flat;
            editarbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editarbtn.ForeColor = SystemColors.Control;
            editarbtn.Location = new Point(468, 85);
            editarbtn.Name = "editarbtn";
            editarbtn.Size = new Size(100, 35);
            editarbtn.TabIndex = 16;
            editarbtn.Text = "Cantidad";
            editarbtn.UseVisualStyleBackColor = false;
            editarbtn.Click += editarbtn_Click;
            // 
            // agregarbtn
            // 
            agregarbtn.BackColor = Color.FromArgb(0, 132, 132);
            agregarbtn.FlatAppearance.BorderSize = 0;
            agregarbtn.FlatStyle = FlatStyle.Flat;
            agregarbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            agregarbtn.ForeColor = SystemColors.Control;
            agregarbtn.Location = new Point(468, 3);
            agregarbtn.Name = "agregarbtn";
            agregarbtn.Size = new Size(100, 35);
            agregarbtn.TabIndex = 15;
            agregarbtn.Text = "Agregar";
            agregarbtn.UseVisualStyleBackColor = false;
            agregarbtn.Click += agregarbtn_Click;
            // 
            // totallbl
            // 
            totallbl.AutoSize = true;
            totallbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totallbl.Location = new Point(468, 123);
            totallbl.Name = "totallbl";
            totallbl.Size = new Size(52, 21);
            totallbl.TabIndex = 18;
            totallbl.Text = "Total:";
            // 
            // efectivolbl
            // 
            efectivolbl.AutoSize = true;
            efectivolbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            efectivolbl.Location = new Point(468, 173);
            efectivolbl.Name = "efectivolbl";
            efectivolbl.Size = new Size(71, 21);
            efectivolbl.TabIndex = 19;
            efectivolbl.Text = "efectivo: ";
            // 
            // carritodgv
            // 
            carritodgv.AllowUserToAddRows = false;
            carritodgv.AllowUserToDeleteRows = false;
            carritodgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            carritodgv.Location = new Point(12, 73);
            carritodgv.Name = "carritodgv";
            carritodgv.ReadOnly = true;
            carritodgv.Size = new Size(437, 285);
            carritodgv.TabIndex = 20;
            carritodgv.CellClick += carritodgv_CellClick;
            // 
            // cambiolbl
            // 
            cambiolbl.AutoSize = true;
            cambiolbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cambiolbl.Location = new Point(468, 223);
            cambiolbl.Name = "cambiolbl";
            cambiolbl.Size = new Size(71, 21);
            cambiolbl.TabIndex = 21;
            cambiolbl.Text = "Cambio: ";
            // 
            // Cancelarbtn
            // 
            Cancelarbtn.BackColor = Color.FromArgb(132, 0, 0);
            Cancelarbtn.FlatAppearance.BorderSize = 0;
            Cancelarbtn.FlatStyle = FlatStyle.Flat;
            Cancelarbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Cancelarbtn.ForeColor = SystemColors.Control;
            Cancelarbtn.Location = new Point(468, 282);
            Cancelarbtn.Name = "Cancelarbtn";
            Cancelarbtn.Size = new Size(100, 35);
            Cancelarbtn.TabIndex = 22;
            Cancelarbtn.Text = "Cancelar";
            Cancelarbtn.UseVisualStyleBackColor = false;
            Cancelarbtn.Click += Cancelarbtn_Click;
            // 
            // Pagarbtn
            // 
            Pagarbtn.BackColor = Color.FromArgb(0, 132, 132);
            Pagarbtn.FlatAppearance.BorderSize = 0;
            Pagarbtn.FlatStyle = FlatStyle.Flat;
            Pagarbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Pagarbtn.ForeColor = SystemColors.Control;
            Pagarbtn.Location = new Point(468, 323);
            Pagarbtn.Name = "Pagarbtn";
            Pagarbtn.Size = new Size(100, 35);
            Pagarbtn.TabIndex = 23;
            Pagarbtn.Text = "Pagar";
            Pagarbtn.UseVisualStyleBackColor = false;
            Pagarbtn.Click += Pagarbtn_Click;
            // 
            // totaltxt
            // 
            totaltxt.ForeColor = Color.Silver;
            totaltxt.Location = new Point(468, 147);
            totaltxt.Name = "totaltxt";
            totaltxt.Size = new Size(100, 23);
            totaltxt.TabIndex = 24;
            totaltxt.Text = "TOTAL";
            totaltxt.Enter += totaltxt_Enter;
            totaltxt.Leave += totaltxt_Leave;
            // 
            // efectivotxt
            // 
            efectivotxt.ForeColor = Color.Silver;
            efectivotxt.Location = new Point(468, 197);
            efectivotxt.Name = "efectivotxt";
            efectivotxt.Size = new Size(100, 23);
            efectivotxt.TabIndex = 25;
            efectivotxt.Text = "EFECTIVO";
            efectivotxt.TextChanged += efectivotxt_TextChanged;
            efectivotxt.Enter += efectivotxt_Enter;
            efectivotxt.Leave += efectivotxt_Leave;
            // 
            // cambiotxt
            // 
            cambiotxt.ForeColor = Color.Silver;
            cambiotxt.Location = new Point(468, 247);
            cambiotxt.Name = "cambiotxt";
            cambiotxt.Size = new Size(100, 23);
            cambiotxt.TabIndex = 26;
            cambiotxt.Text = "CAMBIO";
            cambiotxt.Enter += cambiotxt_Enter;
            cambiotxt.Leave += cambiotxt_Leave;
            // 
            // ventas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 370);
            Controls.Add(cambiotxt);
            Controls.Add(efectivotxt);
            Controls.Add(totaltxt);
            Controls.Add(Pagarbtn);
            Controls.Add(Cancelarbtn);
            Controls.Add(cambiolbl);
            Controls.Add(carritodgv);
            Controls.Add(efectivolbl);
            Controls.Add(totallbl);
            Controls.Add(eliminarBtn);
            Controls.Add(editarbtn);
            Controls.Add(agregarbtn);
            Controls.Add(preciotxt);
            Controls.Add(cantidadtxt);
            Controls.Add(nombretxt);
            Controls.Add(buscarbtn);
            Controls.Add(busquedatxt);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ventas";
            Text = "ventas";
            ((System.ComponentModel.ISupportInitialize)carritodgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox busquedatxt;
        private Button buscarbtn;
        private TextBox nombretxt;
        private TextBox cantidadtxt;
        private TextBox preciotxt;
        private Button eliminarBtn;
        private Button editarbtn;
        private Button agregarbtn;
        private Label totallbl;
        private Label efectivolbl;
        private DataGridView carritodgv;
        private Label cambiolbl;
        private Button Cancelarbtn;
        private Button Pagarbtn;
        private TextBox totaltxt;
        private TextBox efectivotxt;
        private TextBox cambiotxt;
    }
}