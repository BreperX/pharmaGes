namespace PharmaGes
{
    partial class Login
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
            pictureBox1 = new PictureBox();
            txtuser = new TextBox();
            txtpass = new TextBox();
            btnlogin = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            linkLabel1 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.profile;
            pictureBox1.Location = new Point(125, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtuser
            // 
            txtuser.BackColor = Color.FromArgb(50, 52, 77);
            txtuser.BorderStyle = BorderStyle.None;
            txtuser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtuser.ForeColor = Color.LightGray;
            txtuser.Location = new Point(75, 140);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(200, 22);
            txtuser.TabIndex = 1;
            txtuser.Text = "USUARIO";
            txtuser.Enter += txtuser_Enter;
            txtuser.Leave += txtuser_Leave;
            // 
            // txtpass
            // 
            txtpass.BackColor = Color.FromArgb(50, 52, 77);
            txtpass.BorderStyle = BorderStyle.None;
            txtpass.Font = new Font("Segoe UI", 12F);
            txtpass.ForeColor = Color.LightGray;
            txtpass.Location = new Point(75, 190);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(200, 22);
            txtpass.TabIndex = 2;
            txtpass.Text = "CONTRASEÑA";
            txtpass.Enter += txtpass_Enter;
            txtpass.Leave += txtpass_Leave;
            // 
            // btnlogin
            // 
            btnlogin.BackColor = Color.FromArgb(0, 132, 132);
            btnlogin.FlatStyle = FlatStyle.Popup;
            btnlogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlogin.ForeColor = SystemColors.Control;
            btnlogin.Location = new Point(75, 250);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(200, 40);
            btnlogin.TabIndex = 3;
            btnlogin.Text = "Iniciar Sesion";
            btnlogin.UseVisualStyleBackColor = false;
            btnlogin.Click += btnlogin_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Location = new Point(75, 161);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 1);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Location = new Point(75, 211);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 1);
            panel2.TabIndex = 6;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.FromArgb(0, 132, 132);
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.FromArgb(0, 132, 132);
            linkLabel1.Location = new Point(115, 300);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(120, 15);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Olvido la contraseña?";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 52, 77);
            ClientSize = new Size(334, 361);
            Controls.Add(linkLabel1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnlogin);
            Controls.Add(txtpass);
            Controls.Add(txtuser);
            Controls.Add(pictureBox1);
            MaximizeBox = false;
            MaximumSize = new Size(350, 400);
            MinimumSize = new Size(350, 400);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtuser;
        private TextBox txtpass;
        private Button btnlogin;
        private Panel panel1;
        private Panel panel2;
        private LinkLabel linkLabel1;
    }
}