using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;

namespace PharmaGes
{
    public partial class Login : Form
    {
        // Define la cadena de conexión correctamente
        private const string connectionString = "Data Source=DESKTOP-CIKGIAC;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False";

        public Login()
        {
            InitializeComponent();
        }

        private bool Loginform(string email, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) // Utiliza la cadena de conexión definida
                {
                    connection.Open();

                    // Cambiar el nombre de la tabla y los campos para que coincidan con la nueva estructura
                    string query = "SELECT * FROM usuarios WHERE email = @Email AND contrasena = @Contrasena";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Contrasena", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
            string email = txtuser.Text; // Asumiendo que el campo de usuario ahora es el email
            string password = txtpass.Text;

            if (Loginform(email, password))
            {
                MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el formulario Form1
                Form1 form1 = new Form1();
                form1.Show();

                // Cerrar el formulario de login
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
