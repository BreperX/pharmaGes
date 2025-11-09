using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace PharmaGes
{
    public partial class Form1 : Form
    {
        // Propiedad para almacenar el rol del usuario
        public string UserRole { get; set; }

        public Form1(string userRole) // Se espera el rol como parámetro
        {
            InitializeComponent();
            UserRole = userRole;  // Asignamos el rol recibido desde Login
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlNav.Height = 0;
            pnlNav.Top = 0;
            lblTitle.Text = "Inicio";

            // Establecer permisos según el rol del usuario
            SetButtonPermissions(UserRole);

            // Verificar productos con bajo stock y productos próximos a vencer
            CheckLowStockAndExpiry();
        }

        private readonly string connectionString = "Data Source=DESKTOP-ATVMJU1;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
        public void SetButtonPermissions(string userRole)
        {
            // Convertir el rol a minúsculas para evitar problemas de mayúsculas/minúsculas
            userRole = userRole.ToLower();  // Convierte todo a minúsculas

            MessageBox.Show("UserRole recibido: " + userRole);  // Para depuración

            if (userRole == "admin")
            {
                // Habilitar todos los botones para el rol Admin
                UsuariosBtn.Enabled = true;
                MercaciaBtn.Enabled = true;
                VentasBtn.Enabled = true;
                ReportesBtn.Enabled = true;
                NotificacionesBtn.Enabled = true;
            }
            else if (userRole == "gerente")
            {
                // Habilitar todos los botones excepto Usuarios para el rol Gerente
                UsuariosBtn.Enabled = false;
                MercaciaBtn.Enabled = true;
                VentasBtn.Enabled = true;
                ReportesBtn.Enabled = true;
                NotificacionesBtn.Enabled = true;
            }
            else if (userRole == "empleado")
            {
                // Habilitar solo Ventas y Mercancia para el rol Empleado
                UsuariosBtn.Enabled = false;
                MercaciaBtn.Enabled = true;
                VentasBtn.Enabled = true;
                ReportesBtn.Enabled = false;
                NotificacionesBtn.Enabled = false;
            }
            else
            {
                // Deshabilitar todos los botones si el rol no es reconocido
                UsuariosBtn.Enabled = false;
                MercaciaBtn.Enabled = false;
                VentasBtn.Enabled = false;
                ReportesBtn.Enabled = false;
                NotificacionesBtn.Enabled = false;
            }
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
            lblTitle.Text = "Mercancia";
            this.PnlFormLoader.Controls.Clear();
            Mercancia cargador_Vrb = new Mercancia() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
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
            lblTitle.Text = "Notificaciones ";
            this.PnlFormLoader.Controls.Clear();
            Notificaciones cargador_Vrb = new Notificaciones() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            cargador_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(cargador_Vrb);
            cargador_Vrb.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CheckLowStockAndExpiry()
        {
            // Consultas para verificar productos con bajo stock y productos próximos a vencer
            string queryLowStock = "SELECT COUNT(*) FROM medicamentos WHERE stock <= 5";
            string queryExpiringProducts = "SELECT COUNT(*) FROM medicamentos WHERE fecha_caducidad <= DATEADD(day, 30, GETDATE())";

            try
            {
                // Establecer la conexión con la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Verificar bajo stock
                    using (SqlCommand command = new SqlCommand(queryLowStock, connection))
                    {
                        int lowStockCount = (int)command.ExecuteScalar();

                        if (lowStockCount > 0)  // Si hay productos con bajo stock
                        {
                            Notificacion_aca.Visible = true;  // Habilita la visibilidad del icono
                            Notificacion_aca.Icon = SystemIcons.Warning;  // Asigna un icono de advertencia
                            Notificacion_aca.ShowBalloonTip(0, "Alerta de Stock Bajo", "Hay productos con menos de 5 unidades en stock.", ToolTipIcon.Warning);
                        }
                        else
                        {
                            Notificacion_aca.Visible = false;  // Si no hay productos con bajo stock, ocúltalo
                        }
                    }

                    // Verificar productos próximos a vencer
                    using (SqlCommand command = new SqlCommand(queryExpiringProducts, connection))
                    {
                        int expiringCount = (int)command.ExecuteScalar();

                        if (expiringCount > 0)  // Si hay productos próximos a vencer
                        {
                            Notificacion_ven.Visible = true;  // Habilita la visibilidad del icono
                            Notificacion_ven.Icon = SystemIcons.Warning;  // Asigna un icono de advertencia
                            Notificacion_ven.ShowBalloonTip(0, "Alerta de Productos Vencidos", "Hay productos próximos a vencer en los próximos 30 días.", ToolTipIcon.Warning);
                        }
                        else
                        {
                            Notificacion_ven.Visible = false;  // Si no hay productos próximos a vencer, ocúltalo
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores (si es necesario, agrega un log o algún manejo específico)
                Console.WriteLine("Error al verificar stock y vencimientos: " + ex.Message);
            }
        }




    }
}
