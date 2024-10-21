namespace PharmaGes
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PanelMenu = new Panel();
            pnlNav = new Panel();
            NotificacionesBtn = new Button();
            UsuariosBtn = new Button();
            ReportesBtn = new Button();
            VentasBtn = new Button();
            MercaciaBtn = new Button();
            panelLogo = new Panel();
            panelTitleBar = new Panel();
            lblTitle = new Label();
            PnlFormLoader = new Panel();
            PanelMenu.SuspendLayout();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = Color.FromArgb(50, 52, 77);
            PanelMenu.Controls.Add(pnlNav);
            PanelMenu.Controls.Add(NotificacionesBtn);
            PanelMenu.Controls.Add(UsuariosBtn);
            PanelMenu.Controls.Add(ReportesBtn);
            PanelMenu.Controls.Add(VentasBtn);
            PanelMenu.Controls.Add(MercaciaBtn);
            PanelMenu.Controls.Add(panelLogo);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(220, 450);
            PanelMenu.TabIndex = 0;
            // 
            // pnlNav
            // 
            pnlNav.BackColor = Color.FromArgb(0, 132, 132);
            pnlNav.Location = new Point(0, 80);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(3, 370);
            pnlNav.TabIndex = 6;
            // 
            // NotificacionesBtn
            // 
            NotificacionesBtn.Dock = DockStyle.Top;
            NotificacionesBtn.FlatAppearance.BorderSize = 0;
            NotificacionesBtn.FlatStyle = FlatStyle.Flat;
            NotificacionesBtn.ForeColor = SystemColors.Control;
            NotificacionesBtn.ImageAlign = ContentAlignment.MiddleLeft;
            NotificacionesBtn.Location = new Point(0, 320);
            NotificacionesBtn.Name = "NotificacionesBtn";
            NotificacionesBtn.Padding = new Padding(12, 0, 0, 0);
            NotificacionesBtn.Size = new Size(220, 60);
            NotificacionesBtn.TabIndex = 5;
            NotificacionesBtn.Text = "   Notificaciones";
            NotificacionesBtn.TextAlign = ContentAlignment.MiddleLeft;
            NotificacionesBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            NotificacionesBtn.UseVisualStyleBackColor = true;
            NotificacionesBtn.Click += NotificacionesBtn_Click;
            // 
            // UsuariosBtn
            // 
            UsuariosBtn.Dock = DockStyle.Top;
            UsuariosBtn.FlatAppearance.BorderSize = 0;
            UsuariosBtn.FlatStyle = FlatStyle.Flat;
            UsuariosBtn.ForeColor = SystemColors.Control;
            UsuariosBtn.ImageAlign = ContentAlignment.MiddleLeft;
            UsuariosBtn.Location = new Point(0, 260);
            UsuariosBtn.Name = "UsuariosBtn";
            UsuariosBtn.Padding = new Padding(12, 0, 0, 0);
            UsuariosBtn.Size = new Size(220, 60);
            UsuariosBtn.TabIndex = 4;
            UsuariosBtn.Text = "   Usuarios";
            UsuariosBtn.TextAlign = ContentAlignment.MiddleLeft;
            UsuariosBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            UsuariosBtn.UseVisualStyleBackColor = true;
            UsuariosBtn.Click += UsuariosBtn_Click;
            // 
            // ReportesBtn
            // 
            ReportesBtn.Dock = DockStyle.Top;
            ReportesBtn.FlatAppearance.BorderSize = 0;
            ReportesBtn.FlatStyle = FlatStyle.Flat;
            ReportesBtn.ForeColor = SystemColors.Control;
            ReportesBtn.ImageAlign = ContentAlignment.MiddleLeft;
            ReportesBtn.Location = new Point(0, 200);
            ReportesBtn.Name = "ReportesBtn";
            ReportesBtn.Padding = new Padding(12, 0, 0, 0);
            ReportesBtn.Size = new Size(220, 60);
            ReportesBtn.TabIndex = 3;
            ReportesBtn.Text = "   Reportes";
            ReportesBtn.TextAlign = ContentAlignment.MiddleLeft;
            ReportesBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            ReportesBtn.UseVisualStyleBackColor = true;
            ReportesBtn.Click += ReportesBtn_Click;
            // 
            // VentasBtn
            // 
            VentasBtn.Dock = DockStyle.Top;
            VentasBtn.FlatAppearance.BorderSize = 0;
            VentasBtn.FlatStyle = FlatStyle.Flat;
            VentasBtn.ForeColor = SystemColors.Control;
            VentasBtn.ImageAlign = ContentAlignment.MiddleLeft;
            VentasBtn.Location = new Point(0, 140);
            VentasBtn.Name = "VentasBtn";
            VentasBtn.Padding = new Padding(12, 0, 0, 0);
            VentasBtn.Size = new Size(220, 60);
            VentasBtn.TabIndex = 2;
            VentasBtn.Text = "   Ventas";
            VentasBtn.TextAlign = ContentAlignment.MiddleLeft;
            VentasBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            VentasBtn.UseVisualStyleBackColor = true;
            VentasBtn.Click += VentasBtn_Click;
            // 
            // MercaciaBtn
            // 
            MercaciaBtn.Dock = DockStyle.Top;
            MercaciaBtn.FlatAppearance.BorderSize = 0;
            MercaciaBtn.FlatStyle = FlatStyle.Flat;
            MercaciaBtn.ForeColor = SystemColors.Control;
            MercaciaBtn.ImageAlign = ContentAlignment.MiddleLeft;
            MercaciaBtn.Location = new Point(0, 80);
            MercaciaBtn.Name = "MercaciaBtn";
            MercaciaBtn.Padding = new Padding(12, 0, 0, 0);
            MercaciaBtn.Size = new Size(220, 60);
            MercaciaBtn.TabIndex = 1;
            MercaciaBtn.Text = "   Mercacia";
            MercaciaBtn.TextAlign = ContentAlignment.MiddleLeft;
            MercaciaBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            MercaciaBtn.UseVisualStyleBackColor = true;
            MercaciaBtn.Click += MercaciaBtn_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(34, 34, 55);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 80);
            panelLogo.TabIndex = 0;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 132, 132);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(220, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(580, 80);
            panelTitleBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(270, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(80, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "INICIO";
            // 
            // PnlFormLoader
            // 
            PnlFormLoader.Location = new Point(220, 80);
            PnlFormLoader.Name = "PnlFormLoader";
            PnlFormLoader.Size = new Size(580, 370);
            PnlFormLoader.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PnlFormLoader);
            Controls.Add(panelTitleBar);
            Controls.Add(PanelMenu);
            ForeColor = Color.FromArgb(50, 52, 77);
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            PanelMenu.ResumeLayout(false);
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMenu;
        private Button MercaciaBtn;
        private Panel panelLogo;
        private Button VentasBtn;
        private Button ReportesBtn;
        private Button UsuariosBtn;
        private Panel panelTitleBar;
        private Label lblTitle;
        private Button NotificacionesBtn;
        private Panel panel1;
        private Panel pnlNav;
        private Panel PnlFormLoader;
    }
}
