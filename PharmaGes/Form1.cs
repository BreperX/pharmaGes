namespace PharmaGes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UsuariosBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = UsuariosBtn.Height;
            pnlNav.Top = UsuariosBtn.Top;
            lblTitle.Text = "Usuarios";
            this.PnlFormLoader.Controls.Clear();
            Usuarios cargador_Vrb = new Usuarios() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            cargador_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(cargador_Vrb);
            cargador_Vrb.Show();
        }

        private void MercaciaBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = MercaciaBtn.Height;
            pnlNav.Top = MercaciaBtn.Top;
            lblTitle.Text = "Mercacia";
            this.PnlFormLoader.Controls.Clear();
            Mercancia cargador_Vrb = new Mercancia() {  Dock = DockStyle.Fill, TopLevel = false, TopMost = true  };
            cargador_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(cargador_Vrb);
            cargador_Vrb.Show();

        }

        private void VentasBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = VentasBtn.Height;
            pnlNav.Top = VentasBtn.Top;
            lblTitle.Text = "Ventas";
            this.PnlFormLoader.Controls.Clear();
            ventas cargador_Vrb = new ventas() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            cargador_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(cargador_Vrb);
            cargador_Vrb.Show();
        }

        private void ReportesBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = ReportesBtn.Height;
            pnlNav.Top = ReportesBtn.Top;
            lblTitle.Text = "Reportes";
            this.PnlFormLoader.Controls.Clear();
            Reportes cargador_Vrb = new Reportes() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            cargador_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(cargador_Vrb);
            cargador_Vrb.Show();
        }

        private void NotificacionesBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = NotificacionesBtn.Height;
            pnlNav.Top = NotificacionesBtn.Top;
            lblTitle.Text = "Notificaciones";
            this.PnlFormLoader.Controls.Clear();
            Notificaciones cargador_Vrb = new Notificaciones() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            cargador_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(cargador_Vrb);
            cargador_Vrb.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlNav.Height = 0;
            pnlNav.Top= 0;
            lblTitle.Text = "Inicio";
        }
    }
}
