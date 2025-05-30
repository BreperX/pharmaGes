using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography; // Para el hashing
using Microsoft.Data.SqlClient;

namespace PharmaGes
{
    public partial class Login : Form
    {
        private const string connectionString = "Data Source=database.ctyyk2iy2mst.us-east-2.rds.amazonaws.com,1433;Initial Catalog=PharmaGes;User ID=admin;Password=adminadmin;Encrypt=True;TrustServerCertificate=True;";

        // Contador de intentos fallidos
        private int failedAttempts = 0;
        private const int MaxAttempts = 5;
        private DateTime lastFailedAttemptTime;


        public Login()
        {
            InitializeComponent();
        }

        private (bool, string) Loginform(string email, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT contrasena, r.id AS rol_id 
                        FROM usuarios u 
                        JOIN roles r ON u.rol_id = r.id 
                        WHERE LOWER(email) = LOWER(@Email)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Uso seguro de parámetros (ya estabas haciéndolo bien 👍)
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPasswordHash = reader["contrasena"] as string;
                                int rolId = Convert.ToInt32(reader["rol_id"]);

                                string rol = ConvertRoleIdToString(rolId);

                                if (storedPasswordHash != null && VerifyPasswordHash(password, storedPasswordHash))
                                {
                                    // Reiniciar el contador de intentos fallidos
                                    failedAttempts = 0;
                                    return (true, rol);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // No mostrar mensajes de error detallados al usuario final
                MessageBox.Show("Se produjo un error. Intenta nuevamente más tarde.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error interno: " + ex.Message); // Para registro interno
            }
            return (false, null);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder();
                foreach (var b in bytes)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            string hashOfInput = HashPassword(password);
            return hashOfInput.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.Silver;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            // Siempre aseguramos que la contraseña esté oculta
            txtpass.UseSystemPasswordChar = true;

            // Verificar si el usuario está bloqueado
            if (IsUserBlocked())
            {
                TimeSpan tiempoBloqueo = GetBlockingTime();
                MessageBox.Show($"Has superado el número máximo de intentos. Intenta nuevamente en {tiempoBloqueo.Minutes} minuto(s).", "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener y limpiar los datos ingresados
            string email = txtuser.Text.Trim();
            string password = txtpass.Text;

            if (!ValidateFields(email, password))
            {
                MessageBox.Show("Por favor, ingresa tus credenciales.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentar inicio de sesión
            var (isLoggedIn, userRole) = Loginform(email, password);
            if (isLoggedIn)
            {
                MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form1 = new Form1(userRole);
                form1.Show();
                this.Hide();
            }
            else
            {
                failedAttempts++;
                lastFailedAttemptTime = DateTime.Now;

                int remainingAttempts = MaxAttempts - (failedAttempts % MaxAttempts);
                string mensaje = remainingAttempts > 0
                    ? $"Usuario o contraseña incorrectos. Te quedan {remainingAttempts} intento(s)."
                    : "Has alcanzado el número máximo de intentos. Intenta más tarde.";

                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Limpiar la contraseña
            txtpass.Clear();
        }

        /// <summary>
        /// Calcula el tiempo de espera según la cantidad de bloqueos acumulados.
        /// </summary>
        private TimeSpan GetBlockingTime()
        {
            // Tiempo base de bloqueo
            TimeSpan baseBlockTime = TimeSpan.FromMinutes(1);

            // Calcula cuántas veces se ha excedido en múltiplos de 5
            int bloqueosPrevios = failedAttempts / MaxAttempts; // MaxAttempts = 5
            double multiplier = Math.Pow(2, bloqueosPrevios);

            return TimeSpan.FromMinutes(baseBlockTime.TotalMinutes * multiplier);
        }

        /// <summary>
        /// Verifica si el usuario está bloqueado.
        /// </summary>
        private bool IsUserBlocked()
        {
            if (failedAttempts < MaxAttempts)
                return false;

            TimeSpan tiempoBloqueo = GetBlockingTime();
            if (DateTime.Now - lastFailedAttemptTime < tiempoBloqueo)
                return true;

            // Reiniciar el conteo de intentos después del bloqueo
            failedAttempts = 0;
            return false;
        }

        /// <summary>
        /// Valida que los campos no estén vacíos.
        /// </summary>
        private bool ValidateFields(string email, string password)
        {
            return !(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
                     email == "USUARIO" || password == "CONTRASEÑA");
        }



        // Método para convertir el rol_id (número) a su nombre correspondiente
        private string ConvertRoleIdToString(int rolId)
        {
            switch (rolId)
            {
                case 1: return "admin";
                case 2: return "gerente";
                case 3: return "empleado";
                default: return "Unknown";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Para recuperar tu contraseña, contacta a administración.");
        }
    }
}