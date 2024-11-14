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
        private const string connectionString = "Data Source=DESKTOP-CIKGIAC;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False";

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

                    // Consulta para obtener el rol_id y la contraseña
                    string query = "SELECT contrasena, r.id AS rol_id FROM usuarios u JOIN roles r ON u.rol_id = r.id WHERE LOWER(email) = LOWER(@Email)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPasswordHash = reader["contrasena"] as string;
                                int rolId = Convert.ToInt32(reader["rol_id"]);

                                // Convertir el rol_id a su nombre correspondiente
                                string rol = ConvertRoleIdToString(rolId);

                                // Verificar la contraseña
                                if (storedPasswordHash != null && VerifyPasswordHash(password, storedPasswordHash))
                                {
                                    return (true, rol);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    sb.Append(b.ToString("X2")); // Convertir a hexadecimal en mayúsculas
                }
                return sb.ToString();
            }
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            string hashOfInput = HashPassword(password);
            // Eliminamos la línea de depuración
            // MessageBox.Show($"Hash ingresado: {hashOfInput}\nHash almacenado: {storedHash}"); // Para depuración
            return hashOfInput == storedHash;
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
            string email = txtuser.Text;
            string password = txtpass.Text;

            // Realizar el intento de inicio de sesión
            var (isLoggedIn, userRole) = Loginform(email, password);
            if (isLoggedIn)
            {
                MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Pasar el rol del usuario a Form1
                Form1 form1 = new Form1(userRole); // Aquí pasamos el userRole al constructor de Form1
                form1.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para convertir el rol_id (número) a su nombre correspondiente
        private string ConvertRoleIdToString(int rolId)
        {
            switch (rolId)
            {
                case 1:
                    return "admin";    // Admin
                case 2:
                    return "gerente";  // Gerente
                case 3:
                    return "empleado"; // Empleado
                default:
                    return "Unknown";  // Si no es un rol reconocido
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Para recuperar tu contraseña, contacta a administración.");
        }
    }
}