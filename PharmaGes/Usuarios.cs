using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-CIKGIAC;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;"))
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
                using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-CIKGIAC;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;"))
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
                using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-CIKGIAC;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;"))
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
        }




        private void Agregarbtn_Click(object sender, EventArgs e)
        {
            if (nametxt.Text == "NOMBRE" || passtxt.Text == "CONTRASEÑA" || emailtxt.Text == "EMAIL" || string.IsNullOrWhiteSpace(nametxt.Text) || string.IsNullOrWhiteSpace(passtxt.Text) || string.IsNullOrWhiteSpace(emailtxt.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error");
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-CIKGIAC;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;"))
                {
                    conexion.Open();
                    string consulta = "INSERT INTO usuarios (nombre, email, contrasena, rol_id) VALUES (@nombre, @email, @contrasena, @rol_id)";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nametxt.Text);
                        comando.Parameters.AddWithValue("@contrasena", passtxt.Text);
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
                int rol_id = Convert.ToInt32(rolescb.SelectedValue);

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contrasena))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error");
                    return;
                }

                try
                {
                    using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-CIKGIAC;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;"))
                    {
                        conexion.Open();
                        string consulta = "UPDATE usuarios SET nombre = @nombre, email = @email, contrasena = @contrasena, rol_id = @rol_id WHERE id = @id";
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@id", id);
                            comando.Parameters.AddWithValue("@nombre", nombre);
                            comando.Parameters.AddWithValue("@email", email);
                            comando.Parameters.AddWithValue("@contrasena", contrasena);
                            comando.Parameters.AddWithValue("@rol_id", rol_id);
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
                    using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-CIKGIAC;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;"))
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
            if (e.RowIndex >= 0 && e.RowIndex < usuariosdgv.Rows.Count) // Verificar que no es un encabezado de columna y que la fila existe
            {
                DataGridViewRow row = usuariosdgv.Rows[e.RowIndex];

                if (row.Cells["nombre"].Value != null)
                    nametxt.Text = row.Cells["nombre"].Value.ToString();

                if (row.Cells["email"].Value != null)
                    emailtxt.Text = row.Cells["email"].Value.ToString();

                if (row.Cells["contrasena"].Value != null)
                    passtxt.Text = row.Cells["contrasena"].Value.ToString();

                if (row.Cells["rol"].Value != null)
                {
                    string rol = row.Cells["rol"].Value.ToString();
                    rolescb.SelectedIndex = rolescb.FindStringExact(rol); // Buscar y seleccionar el rol en el ComboBox
                }

                nametxt.ForeColor = Color.Black;
                emailtxt.ForeColor = Color.Black;
                passtxt.ForeColor = Color.Black;
            }
        }

    }
}
