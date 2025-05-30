using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;  // Para SHA256
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace PharmaGes
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            CargarRoles();
            usuariosdgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usuariosdgv.MultiSelect = false;


        }

        private void CargarRoles()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection("Data Source=database.ctyyk2iy2mst.us-east-2.rds.amazonaws.com,1433;Initial Catalog=PharmaGes;User ID=admin;Password=adminadmin;Encrypt=True;TrustServerCertificate=True;"))
                {
                    conexion.Open();
                    string consulta = "SELECT id, nombre FROM roles";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);

                        rolescb.DataSource = dt;
                        rolescb.DisplayMember = "nombre";
                        rolescb.ValueMember = "id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Inesperado");
            }

        }


        private void busquedatxt_Enter(object sender, EventArgs e)
        {
            if (busquedatxt.Text == "NOMBRE / EMAIL")
            {
                busquedatxt.Text = "";
                busquedatxt.ForeColor = Color.Black;
            }
        }

        private void busquedatxt_Leave(object sender, EventArgs e)
        {
            if (busquedatxt.Text == "")
            {
                busquedatxt.Text = "NOMBRE / EMAIL";
                busquedatxt.ForeColor = Color.Silver;
            }
        }

        private void nametxt_Enter(object sender, EventArgs e)
        {
            if (nametxt.Text == "NOMBRE")
            {
                nametxt.Text = "";
                nametxt.ForeColor = Color.Black;
            }
        }

        private void nametxt_Leave(object sender, EventArgs e)
        {
            if (nametxt.Text == "")
            {
                nametxt.Text = "NOMBRE";
                nametxt.ForeColor = Color.Silver;
            }
        }

        private void passtxt_Enter(object sender, EventArgs e)
        {
            if (passtxt.Text == "CONTRASEÑA")
            {
                passtxt.Text = "";
                passtxt.ForeColor = Color.Black;
            }
        }

        private void passtxt_Leave(object sender, EventArgs e)
        {
            if (passtxt.Text == "")
            {
                passtxt.Text = "CONTRASEÑA";
                passtxt.ForeColor = Color.Silver;
            }
        }

        private void emailtxt_Enter(object sender, EventArgs e)
        {
            if (emailtxt.Text == "EMAIL")
            {
                emailtxt.Text = "";
                emailtxt.ForeColor = Color.Black;
            }
        }

        private void emailtxt_Leave(object sender, EventArgs e)
        {
            if (emailtxt.Text == "")
            {
                emailtxt.Text = "EMAIL";
                emailtxt.ForeColor = Color.Silver;
            }
        }

        private void Buscarbtn_Click(object sender, EventArgs e)
        {
            string busqueda = busquedatxt.Text.Trim();
            if (string.IsNullOrWhiteSpace(busqueda) || busqueda == "NOMBRE / EMAIL")
            {
                MessageBox.Show("Por favor, ingrese un nombre o correo electrónico para buscar.", "Error");
                return;
            }
            try
            {
                using (SqlConnection conexion = new SqlConnection("Data Source = database.ctyyk2iy2mst.us - east - 2.rds.amazonaws.com, 1433; Initial Catalog = PharmaGes; User ID = admin; Password = adminadmin; Encrypt = True; TrustServerCertificate = True; "))
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM usuarios WHERE nombre LIKE @busqueda OR email LIKE @busqueda";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);
                        usuariosdgv.DataSource = dt; // Actualizar el DataGridView con los resultados de la búsqueda
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Inesperado");
            }
        }



        private void refrescarbtn_Click(object sender, EventArgs e)
        {


            try
            {
                using (SqlConnection conexion = new SqlConnection("Data Source=database.ctyyk2iy2mst.us-east-2.rds.amazonaws.com,1433;Initial Catalog=PharmaGes;User ID=admin;Password=adminadmin;Encrypt=True;TrustServerCertificate=True;"))
                {
                    conexion.Open();
                    string consulta = "SELECT u.id, u.nombre, u.email, u.contrasena, r.nombre AS rol FROM usuarios u JOIN roles r ON u.rol_id = r.id";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);
                        usuariosdgv.DataSource = dt; // Actualizar el DataGridView con los resultados
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Inesperado");
            }

            nametxt.Text = "NOMBRE";
            nametxt.ForeColor = Color.Silver;
            passtxt.Text = "CONTRASEÑA";
            passtxt.ForeColor = Color.Silver;
            emailtxt.Text = "EMAIL";
            emailtxt.ForeColor = Color.Silver;
            rolescb.Text = "Roles";
            busquedatxt.Text = "NOMBRE / EMAIL";
            busquedatxt.ForeColor = Color.Silver;
        }




        private void Agregarbtn_Click(object sender, EventArgs e)
        {
            if (nametxt.Text == "NOMBRE" || passtxt.Text == "CONTRASEÑA" || emailtxt.Text == "EMAIL" || string.IsNullOrWhiteSpace(nametxt.Text) || string.IsNullOrWhiteSpace(passtxt.Text) || string.IsNullOrWhiteSpace(emailtxt.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error");
                return;
            }

            // Hash de la contraseña (en texto plano)
            string contrasenaHash = HashPassword(passtxt.Text);

            try
            {
                using (SqlConnection conexion = new SqlConnection("Data Source = database.ctyyk2iy2mst.us - east - 2.rds.amazonaws.com, 1433; Initial Catalog = PharmaGes; User ID = admin; Password = adminadmin; Encrypt = True; TrustServerCertificate = True; "))
                {
                    conexion.Open();
                    string consulta = "INSERT INTO usuarios (nombre, email, contrasena, rol_id) VALUES (@nombre, @email, @contrasena, @rol_id)";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nametxt.Text);
                        comando.Parameters.AddWithValue("@contrasena", contrasenaHash);  // Usar el hash de la contraseña
                        comando.Parameters.AddWithValue("@email", emailtxt.Text);
                        comando.Parameters.AddWithValue("@rol_id", rolescb.SelectedValue);
                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Usuario agregado correctamente.", "Éxito");
                            refrescarbtn_Click(sender, e); // Actualizar el DataGridView
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el usuario.", "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Inesperado");
            }
        }



        private void Editarbtn_Click(object sender, EventArgs e)
        {
            if (usuariosdgv.SelectedCells.Count > 0)
            {
                int rowIndex = usuariosdgv.SelectedCells[0].RowIndex;
                DataGridViewRow row = usuariosdgv.Rows[rowIndex];
                string id = row.Cells["id"].Value.ToString();
                string nombre = nametxt.Text.Trim();
                string email = emailtxt.Text.Trim();
                string contrasena = passtxt.Text.Trim();

                // Obtener el rol seleccionado en el ComboBox y su id
                int rol_id = Convert.ToInt32(rolescb.SelectedValue);
                string rol_nombre = rolescb.Text;  // Obtiene el nombre del rol seleccionado

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contrasena))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error");
                    return;
                }

                // Hash de la contraseña
                string contrasenaHash = HashPassword(contrasena);

                try
                {
                    using (SqlConnection conexion = new SqlConnection("Data Source=database.ctyyk2iy2mst.us-east-2.rds.amazonaws.com,1433;Initial Catalog=PharmaGes;User ID=admin;Password=adminadmin;Encrypt=True;TrustServerCertificate=True;"))
                    {
                        conexion.Open();
                        string consulta = "UPDATE usuarios SET nombre = @nombre, email = @email, contrasena = @contrasena, rol_id = @rol_id WHERE id = @id";
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            // Añadir los parámetros necesarios para la consulta SQL
                            comando.Parameters.AddWithValue("@id", id);
                            comando.Parameters.AddWithValue("@nombre", nombre);
                            comando.Parameters.AddWithValue("@email", email);
                            comando.Parameters.AddWithValue("@contrasena", contrasenaHash);  // Usar el hash de la contraseña
                            comando.Parameters.AddWithValue("@rol_id", rol_id);  // Enviar el ID del rol
                            int filasAfectadas = comando.ExecuteNonQuery();
                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("Usuario actualizado correctamente.", "Éxito");
                                refrescarbtn_Click(sender, e); // Actualizar el DataGridView
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el usuario.", "Error");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Inesperado");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para editar.", "Error");
            }
        }





        private void BorrarBtn_Click(object sender, EventArgs e)
        {
            if (usuariosdgv.SelectedCells.Count > 0)
            {
                int rowIndex = usuariosdgv.SelectedCells[0].RowIndex;
                DataGridViewRow row = usuariosdgv.Rows[rowIndex];

                string id = row.Cells["id"].Value.ToString();

                try
                {
                    using (SqlConnection conexion = new SqlConnection("Data Source=database.ctyyk2iy2mst.us-east-2.rds.amazonaws.com,1433;Initial Catalog=PharmaGes;User ID=admin;Password=adminadmin;Encrypt=True;TrustServerCertificate=True;"))
                    {
                        conexion.Open();
                        string consulta = "DELETE FROM usuarios WHERE id = @id";
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@id", id);
                            int filasAfectadas = comando.ExecuteNonQuery();
                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("Usuario eliminado correctamente.", "Éxito");
                                refrescarbtn_Click(sender, e); // Actualizar el DataGridView
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el usuario.", "Error");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Inesperado");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Error");
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            refrescarbtn_Click(sender, e);
        }

        private void usuariosdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < usuariosdgv.Rows.Count)
            {
                DataGridViewRow row = usuariosdgv.Rows[e.RowIndex];

                if (row.Cells["nombre"].Value != null)
                    nametxt.Text = row.Cells["nombre"].Value.ToString();

                if (row.Cells["EMAIL"].Value != null)
                    emailtxt.Text = row.Cells["EMAIL"].Value.ToString();


                if (row.Cells["rol"].Value != null)
                {
                    string rol = row.Cells["rol"].Value.ToString();
                    rolescb.SelectedIndex = rolescb.FindStringExact(rol); // Buscar y seleccionar el rol en el ComboBox
                }

                nametxt.ForeColor = Color.Black;
                emailtxt.ForeColor = Color.Black;

            }
        }

        private void usuariosdgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (usuariosdgv.Columns[e.ColumnIndex].Name == "contrasena")
            {
                if (e.Value != null)
                {
                    // Mostrar la contraseña como asteriscos
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
        }
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "");
                return hashString.ToUpper();  // Convertir todo a mayúsculas
            }
        }

    }
}
