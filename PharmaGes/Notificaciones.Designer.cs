namespace PharmaGes
{
    partial class Notificaciones
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
            dataGridView1 = new DataGridView();
            Productos = new Label();
            dataGridView2 = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(556, 142);
            dataGridView1.TabIndex = 0;
            // 
            // Productos
            // 
            Productos.AutoSize = true;
            Productos.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Productos.Location = new Point(12, 9);
            Productos.Name = "Productos";
            Productos.Size = new Size(389, 21);
            Productos.TabIndex = 19;
            Productos.Text = "Los siguientes productos están prontos a agotarse";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 204);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(556, 154);
            dataGridView2.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 180);
            label1.Name = "label1";
            label1.Size = new Size(477, 21);
            label1.TabIndex = 21;
            label1.Text = "Los siguientes productos están prontos vencer o ya vencieron";
            // 
            // Notificaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 370);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Controls.Add(Productos);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Notificaciones";
            Text = "Notificaciones";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label Productos;
        private DataGridView dataGridView2;
        private Label label1;
    }
}