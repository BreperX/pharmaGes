using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PharmaGes
{
    public partial class Mercancia : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-ATVMJU1;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;\r\n";

        public Mercancia()
        {
            InitializeComponent();
            nametxt.MaxLength = 50;
            codigotxt.MaxLength = 10;
            descripciontxt.MaxLength = 200;
            stocktxt.MaxLength = 4;
            preciotxt.MaxLength = 8;

        }

        public void llenar_tabla()
        {
            using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-ATVMJU1;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;\r\n"))
            {
                conexion.Open();
                string consulta = "SELECT codigo, nombre, descripcion, stock, precio, fecha_caducidad FROM medicamentos";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dgvMercancia.DataSource = dt;
                ConfigurarColumnasDataGridView(); // Configurar las columnas después de llenar el DataGridView
            }
        }


        public void limpiar()
        {
            nametxt.Clear();
            codigotxt.Clear();
            descripciontxt.Clear();
            stocktxt.Clear();
            preciotxt.Clear();
            nametxt.Text = "NOMBRE";
            nametxt.ForeColor = Color.Silver;
            codigotxt.Text = "CÓDIGO";
            codigotxt.ForeColor = Color.Silver;
            preciotxt.Text = "PRECIO";
            preciotxt.ForeColor = Color.Silver;
            descripciontxt.Text = "DESCRIPCIÓN";
            descripciontxt.ForeColor = Color.Silver;
            stocktxt.Text = "STOCK";
            stocktxt.ForeColor = Color.Silver;
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

        private void codigotxt_Enter(object sender, EventArgs e)
        {
            if (codigotxt.Text == "CÓDIGO")
            {
                codigotxt.Text = "";
                codigotxt.ForeColor = Color.Black;
            }
        }

        private void codigotxt_Leave(object sender, EventArgs e)
        {
            if (codigotxt.Text == "")
            {
                codigotxt.Text = "CÓDIGO";
                codigotxt.ForeColor = Color.Silver;
            }
        }

        private void descripciontxt_Enter(object sender, EventArgs e)
        {
            if (descripciontxt.Text == "DESCRIPCIÓN")
            {
                descripciontxt.Text = "";
                descripciontxt.ForeColor = Color.Black;
            }
        }

        private void descripciontxt_Leave(object sender, EventArgs e)
        {
            if (descripciontxt.Text == "")
            {
                descripciontxt.Text = "DESCRIPCIÓN";
                descripciontxt.ForeColor = Color.Silver;
            }
        }

        private void stocktxt_Enter(object sender, EventArgs e)
        {
            if (stocktxt.Text == "STOCK")
            {
                stocktxt.Text = "";
                stocktxt.ForeColor = Color.Black;
            }
        }

        private void stocktxt_Leave(object sender, EventArgs e)
        {
            if (stocktxt.Text == "")
            {
                stocktxt.Text = "STOCK";
                stocktxt.ForeColor = Color.Silver;
            }
        }

        private void preciotxt_Enter(object sender, EventArgs e)
        {
            if (preciotxt.Text == "PRECIO")
            {
                preciotxt.Text = "";
                preciotxt.ForeColor = Color.Black;
            }
        }

        private void preciotxt_Leave(object sender, EventArgs e)
        {
            if (preciotxt.Text == "")
            {
                preciotxt.Text = "PRECIO";
                preciotxt.ForeColor = Color.Silver;
            }
        }

        private void Mercancia_Load(object sender, EventArgs e)
        {
            llenar_tabla();
            ConfigurarColumnasDataGridView();
        }

        private void BuscarEnTiempoReal()
        {
            string codigo = codigotxt.Text.Trim();
            string nombre = nametxt.Text.Trim();
            string descripcion = descripciontxt.Text.Trim();
            string stock = stocktxt.Text.Trim();
            string precio = preciotxt.Text.Trim();
            string fechaCaducidad = fecha.Text.Trim();

            try
            {
                using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-ATVMJU1;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;\r\n"))
                {
                    conexion.Open();
                    string consulta = "SELECT codigo, nombre, descripcion, stock, precio, fecha_caducidad FROM medicamentos WHERE " +
                                      "codigo LIKE @codigo OR " +
                                      "nombre LIKE @nombre OR " +
                                      "descripcion LIKE @descripcion OR " +
                                      "stock LIKE @stock OR " +
                                      "precio LIKE @precio OR " +
                                      "fecha_caducidad LIKE @fecha_caducidad";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@codigo", "%" + codigo + "%");
                        comando.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                        comando.Parameters.AddWithValue("@descripcion", "%" + descripcion + "%");
                        comando.Parameters.AddWithValue("@stock", "%" + stock + "%");
                        comando.Parameters.AddWithValue("@precio", "%" + precio + "%");
                        comando.Parameters.AddWithValue("@fecha_caducidad", "%" + fechaCaducidad + "%");

                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            codigotxt.Text = row["codigo"].ToString();
                            nametxt.Text = row["nombre"].ToString();
                            descripciontxt.Text = row["descripcion"].ToString();
                            stocktxt.Text = row["stock"].ToString();
                            preciotxt.Text = row["precio"].ToString();
                            fecha.Text = row["fecha_caducidad"].ToString();

                            nametxt.ForeColor = Color.Black;
                            codigotxt.ForeColor = Color.Black;
                            descripciontxt.ForeColor = Color.Black;
                            stocktxt.ForeColor = Color.Black;
                            preciotxt.ForeColor = Color.Black;
                        }
                        else
                        {
                            limpiar(); // Limpiar los campos si no se encuentra el registro
                        }

                        dgvMercancia.DataSource = dt; // Actualizar el DataGridView con las opciones que concuerdan
                        ConfigurarColumnasDataGridView(); // Configurar las columnas después de actualizar el DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Inesperado");
            }
        }


        private void ConfigurarColumnasDataGridView()
        {
            if (dgvMercancia.Columns.Count > 0)
            {
                dgvMercancia.Columns["codigo"].DisplayIndex = 0;
                dgvMercancia.Columns["nombre"].DisplayIndex = 1;
                dgvMercancia.Columns["descripcion"].DisplayIndex = 2;
                dgvMercancia.Columns["stock"].DisplayIndex = 3;
                dgvMercancia.Columns["precio"].DisplayIndex = 4;
                dgvMercancia.Columns["fecha_caducidad"].DisplayIndex = 5;

                foreach (DataGridViewColumn column in dgvMercancia.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic; // Habilitar la ordenación
                }
            }
        }





        private void Agregarbtn_Click(object sender, EventArgs e)
        {
            // Verificar si los campos requeridos están vacíos o contienen texto predefinido
            if (string.IsNullOrWhiteSpace(nametxt.Text) || nametxt.Text == "NOMBRE" ||
                string.IsNullOrWhiteSpace(codigotxt.Text) || codigotxt.Text == "CÓDIGO" ||
                string.IsNullOrWhiteSpace(descripciontxt.Text) || descripciontxt.Text == "DESCRIPCIÓN" ||
                string.IsNullOrWhiteSpace(stocktxt.Text) || stocktxt.Text == "STOCK" ||
                string.IsNullOrWhiteSpace(preciotxt.Text) || preciotxt.Text == "PRECIO")
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error");
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-ATVMJU1;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;\r\n"))
                {
                    conexion.Open();

                    // Verificar si ya existe un registro con el mismo código
                    string codigo = codigotxt.Text;
                    string consultaVerificar = "SELECT COUNT(*) FROM medicamentos WHERE codigo = @codigo";
                    using (SqlCommand comandoVerificar = new SqlCommand(consultaVerificar, conexion))
                    {
                        comandoVerificar.Parameters.AddWithValue("@codigo", codigo);
                        int count = (int)comandoVerificar.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Ya existe un registro con el mismo código.", "Error");
                            return;
                        }
                    }

                    // Si no existe, proceder con la inserción
                    string consultaInsertar = "INSERT INTO medicamentos (nombre, codigo, descripcion, stock, precio, fecha_caducidad) " +
                                              "VALUES (@nombre, @codigo, @descripcion, @stock, @precio, @fecha_caducidad)";
                    using (SqlCommand comandoInsertar = new SqlCommand(consultaInsertar, conexion))
                    {
                        comandoInsertar.Parameters.AddWithValue("@nombre", nametxt.Text);
                        comandoInsertar.Parameters.AddWithValue("@codigo", codigotxt.Text);
                        comandoInsertar.Parameters.AddWithValue("@descripcion", descripciontxt.Text);
                        comandoInsertar.Parameters.AddWithValue("@stock", stocktxt.Text);
                        comandoInsertar.Parameters.AddWithValue("@precio", preciotxt.Text);
                        comandoInsertar.Parameters.AddWithValue("@fecha_caducidad", DateTime.Parse(fecha.Text).ToString("yyyy-MM-dd"));

                        int filasAfectadas = comandoInsertar.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Registro agregado correctamente.", "Éxito");
                            limpiar();
                            llenar_tabla();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el registro.", "Error");
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
            // Verificar si se ingresó un valor en el campo de Código
            if (string.IsNullOrEmpty(codigotxt.Text))
            {
                MessageBox.Show("Por favor, ingrese un código antes de editar un registro.", "Error");
                return; // Salir del método si falta el código
            }

            // Validar el stock
            if (!int.TryParse(stocktxt.Text, out int stock))
            {
                MessageBox.Show("El stock debe ser un número entero válido.", "Error");
                return;
            }

            // Validar el precio
            if (!decimal.TryParse(preciotxt.Text, out decimal precio))
            {
                MessageBox.Show("El precio debe ser un número decimal válido.", "Error");
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    string consulta = "UPDATE medicamentos SET " +
                                      "nombre = @nombre, " +
                                      "descripcion = @descripcion, " +
                                      "stock = @stock, " +
                                      "precio = @precio, " +
                                      "fecha_caducidad = @fecha_caducidad " +
                                      "WHERE codigo = @codigo";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nametxt.Text);
                        comando.Parameters.AddWithValue("@codigo", codigotxt.Text);
                        comando.Parameters.AddWithValue("@descripcion", descripciontxt.Text);
                        comando.Parameters.AddWithValue("@stock", stock);
                        comando.Parameters.AddWithValue("@precio", precio);
                        comando.Parameters.AddWithValue("@fecha_caducidad", DateTime.Parse(fecha.Text).ToString("yyyy-MM-dd"));

                        int num = comando.ExecuteNonQuery();
                        if (num > 0)
                        {
                            MessageBox.Show("Registro modificado correctamente", "Registro Modificado");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún registro para actualizar.", "Error");
                        }
                    }
                    llenar_tabla();
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Inesperado");
            }
        }


        private void BorrarBtn_Click(object sender, EventArgs e)
        {
            // Verificar si se ingresó un valor en el campo de Identificación
            if (string.IsNullOrEmpty(codigotxt.Text))
            {
                MessageBox.Show("Por favor, ingrese una identificación antes de eliminar un registro.", "Error");
                return; // Salir del método si falta la identificación
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-ATVMJU1;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;\r\n"))
                    {
                        conexion.Open();
                        string consulta = "delete from medicamentos where codigo=@codigo"; // Usar parámetros para evitar inyección SQL
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@codigo", codigotxt.Text);
                            int num = comando.ExecuteNonQuery();
                            if (num > 0)
                            {
                                MessageBox.Show("Registro eliminado correctamente", "Registro Eliminado");
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ningún registro para eliminar.", "Error");
                            }
                        }
                        llenar_tabla();
                        limpiar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Inesperado");
                }
            }
        }

        private void dgvMercancia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurarse de que no es un encabezado de columna y que la fila existe
            if (e.RowIndex >= 0 && e.RowIndex < dgvMercancia.Rows.Count)
            {
                DataGridViewRow row = dgvMercancia.Rows[e.RowIndex];
                if (row.Cells.Count > 5) // Asegurarse de que hay suficientes celdas
                {
                    codigotxt.Text = row.Cells["codigo"].Value?.ToString() ?? "";
                    nametxt.Text = row.Cells["nombre"].Value?.ToString() ?? "";
                    descripciontxt.Text = row.Cells["descripcion"].Value?.ToString() ?? "";
                    stocktxt.Text = row.Cells["stock"].Value?.ToString() ?? "";
                    preciotxt.Text = row.Cells["precio"].Value?.ToString() ?? "";
                    fecha.Text = row.Cells["fecha_caducidad"].Value?.ToString() ?? "";

                    codigotxt.ForeColor = Color.Black;
                    nametxt.ForeColor = Color.Black;
                    descripciontxt.ForeColor = Color.Black;
                    stocktxt.ForeColor = Color.Black;
                    preciotxt.ForeColor = Color.Black;
                }
                else
                {
                    MessageBox.Show("La fila seleccionada no tiene suficientes celdas.", "Error");
                }
            }
            else if (e.RowIndex < 0) // Es un encabezado de columna
            {
                // No hacer nada para evitar errores
            }
            else
            {
                MessageBox.Show("Seleccione una celda válida dentro de la tabla.", "Error");
            }
        }




        private void Buscarbtn_Click(object sender, EventArgs e)
        {
            BuscarEnTiempoReal();
        }

        private void refrescarbtn_Click(object sender, EventArgs e)
        {
            RefrescarTodo();
        }

        private void RefrescarTodo()
        {
            // Limpiar todos los TextBox
            limpiar();

            // Refrescar el DataGridView
            llenar_tabla();
        }


    }
}
