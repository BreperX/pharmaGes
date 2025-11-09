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
using System.IO;
using System.Diagnostics;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Geom;

namespace PharmaGes
{
    public partial class ventas : Form
    {
        public ventas()
        {
            InitializeComponent();
            InicializarCarritoDgv();
            nombretxt.Enabled = false;
            preciotxt.Enabled = false;
            totaltxt.Enabled = false;
            cambiotxt.Enabled = false;
        }



        private void InicializarCarritoDgv()
        {
            carritodgv.ColumnCount = 3;
            carritodgv.Columns[0].Name = "nombre";
            carritodgv.Columns[1].Name = "cantidad";
            carritodgv.Columns[2].Name = "precio";

            carritodgv.Columns[0].HeaderText = "Nombre";
            carritodgv.Columns[1].HeaderText = "Cantidad";
            carritodgv.Columns[2].HeaderText = "Precio";
        }

        private void ActualizarTotalYCambio()
        {
            decimal total = 0;
            decimal efectivo = 0;
            decimal cambio = 0;

            foreach (DataGridViewRow row in carritodgv.Rows)
            {
                if (row.Cells["precio"].Value != null && row.Cells["cantidad"].Value != null)
                {
                    decimal precio = Convert.ToDecimal(row.Cells["precio"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);
                    total += precio * cantidad; // Multiplicar el precio por la cantidad
                }
            }

            totaltxt.Text = total.ToString("C");

            if (decimal.TryParse(efectivotxt.Text, out efectivo) && efectivotxt.Text != "EFECTIVO")
            {
                cambio = efectivo - total;
            }

            cambiotxt.Text = cambio.ToString("C");

            // Si el cambio es negativo, mostrarlo en rojo
            if (cambio < 0)
            {
                cambiotxt.ForeColor = Color.Red;
            }
            else
            {
                cambiotxt.ForeColor = Color.Black;
            }
        }


        private void busquedatxt_Enter(object sender, EventArgs e)
        {
            if (busquedatxt.Text == "NOMBRE / CÓDIGO")
            {
                busquedatxt.Text = "";
                busquedatxt.ForeColor = Color.Black;
            }
        }

        private void busquedatxt_Leave(object sender, EventArgs e)
        {
            if (busquedatxt.Text == "")
            {
                busquedatxt.Text = "NOMBRE / CÓDIGO";
                busquedatxt.ForeColor = Color.Silver;
            }
        }

        private void nombretxt_Enter(object sender, EventArgs e)
        {
            if (nombretxt.Text == "NOMBRE")
            {
                nombretxt.Text = "";
                nombretxt.ForeColor = Color.Black;
            }
        }

        private void nombretxt_Leave(object sender, EventArgs e)
        {
            if (nombretxt.Text == "")
            {
                nombretxt.Text = "NOMBRE";
                nombretxt.ForeColor = Color.Silver;
            }
        }

        private void cantidadtxt_Enter(object sender, EventArgs e)
        {
            if (cantidadtxt.Text == "CANTIDAD")
            {
                cantidadtxt.Text = "";
                cantidadtxt.ForeColor = Color.Black;
            }
        }

        private void cantidadtxt_Leave(object sender, EventArgs e)
        {
            if (cantidadtxt.Text == "")
            {
                cantidadtxt.Text = "CANTIDAD";
                cantidadtxt.ForeColor = Color.Silver;
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

        private void buscarbtn_Click(object sender, EventArgs e)
        {
            string busqueda = busquedatxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(busqueda) || busqueda == "NOMBRE / CÓDIGO")
            {
                MessageBox.Show("Por favor, ingrese un nombre o código para buscar.", "Error");
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-ATVMJU1;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;\r\n"))
                {
                    conexion.Open();
                    string consulta = "SELECT nombre, stock, precio FROM medicamentos WHERE codigo LIKE @busqueda OR nombre LIKE @busqueda";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nombretxt.Text = reader["nombre"].ToString();
                                cantidadtxt.Text = "1"; // Por defecto, cantidad inicial en 1
                                preciotxt.Text = reader["precio"].ToString();
                                nombretxt.ForeColor = Color.Black;
                                cantidadtxt.ForeColor = Color.Black;
                                preciotxt.ForeColor = Color.Black;
                                cantidadtxt.Enabled = true; // Habilitar el campo de cantidad
                                busquedatxt.Text = "NOMBRE / CÓDIGO";
                                busquedatxt.ForeColor = Color.Silver;
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ningún medicamento con ese nombre o código.", "Error");
                                limpiarCamposBusqueda();
                                busquedatxt.Text = "NOMBRE / CÓDIGO";
                                busquedatxt.ForeColor = Color.Silver;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Inesperado");
            }
        }

        private void limpiarCamposBusqueda()
        {
            nombretxt.Text = "NOMBRE";
            cantidadtxt.Text = "CANTIDAD";
            preciotxt.Text = "PRECIO";
            nombretxt.ForeColor = Color.Silver;
            cantidadtxt.ForeColor = Color.Silver;
            preciotxt.ForeColor = Color.Silver;
            cantidadtxt.Enabled = false;
        }



        private void agregarbtn_Click(object sender, EventArgs e)
        {
            if (nombretxt.Text == "NOMBRE" || string.IsNullOrWhiteSpace(cantidadtxt.Text) || preciotxt.Text == "PRECIO")
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios antes de agregar.", "Error");
                return;
            }

            int cantidadIngresada;
            if (!int.TryParse(cantidadtxt.Text, out cantidadIngresada) || cantidadIngresada <= 0)
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida.", "Error");
                return;
            }

            int stockDisponible = ObtenerStockDisponible(nombretxt.Text);
            if (cantidadIngresada > stockDisponible)
            {
                MessageBox.Show("La cantidad ingresada excede el inventario disponible.", "Error");
                return;
            }

            bool productoExistente = false;
            foreach (DataGridViewRow fila in carritodgv.Rows)
            {
                if (fila.Cells["nombre"].Value.ToString() == nombretxt.Text)
                {
                    int nuevaCantidad = cantidadIngresada + Convert.ToInt32(fila.Cells["cantidad"].Value);
                    if (nuevaCantidad > stockDisponible)
                    {
                        MessageBox.Show("La cantidad total excede el inventario disponible.", "Error");
                        return;
                    }
                    fila.Cells["cantidad"].Value = nuevaCantidad;
                    productoExistente = true;
                    break;
                }
            }

            if (!productoExistente)
            {
                carritodgv.Rows.Add(nombretxt.Text, cantidadIngresada, preciotxt.Text);
            }

            ActualizarTotalYCambio();
            limpiarCamposBusqueda();
        }



        private int ObtenerStockDisponible(string nombreMedicamento)
        {
            int stockDisponible = 0;

            try
            {
                using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-ATVMJU1;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;\r\n"))
                {
                    conexion.Open();
                    string consulta = "SELECT stock FROM medicamentos WHERE nombre = @nombre";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nombreMedicamento);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                stockDisponible = Convert.ToInt32(reader["stock"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Inesperado");
            }

            return stockDisponible;
        }


        private void editarbtn_Click(object sender, EventArgs e)
        {
            if (carritodgv.SelectedCells.Count > 0)
            {
                int rowIndex = carritodgv.SelectedCells[0].RowIndex;
                DataGridViewRow row = carritodgv.Rows[rowIndex];

                int nuevaCantidad;
                ActualizarTotalYCambio();
                if (!int.TryParse(cantidadtxt.Text, out nuevaCantidad) || nuevaCantidad <= 0)
                {
                    MessageBox.Show("Por favor, ingrese una cantidad válida mayor a cero.", "Error");
                    return;
                }

                int stockDisponible = ObtenerStockDisponible(nombretxt.Text);
                if (nuevaCantidad > stockDisponible)
                {
                    MessageBox.Show("La cantidad ingresada excede el inventario disponible.", "Error");
                    return;
                }

                row.Cells["cantidad"].Value = nuevaCantidad;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila o celda para editar.", "Error");
            }
        }



        private void Cancelarbtn_Click(object sender, EventArgs e)
        {
            // Limpiar todos los TextBox
            limpiarCamposBusqueda();

            // Limpiar el DataGridView
            carritodgv.Rows.Clear();

            // Limpiar las etiquetas de total, efectivo y cambio
            totaltxt.Text = "TOTAL";
            efectivotxt.Text = "EFECTIVO";
            cambiotxt.Text = "CAMBIO";
        }


        private void Pagarbtn_Click(object sender, EventArgs e)
        {
            decimal efectivo, total, cambio;

            if (!decimal.TryParse(totaltxt.Text, System.Globalization.NumberStyles.Currency, null, out total))
            {
                MessageBox.Show("El total no es válido.", "Error");
                return;
            }

            if (!decimal.TryParse(efectivotxt.Text, System.Globalization.NumberStyles.Currency, null, out efectivo))
            {
                MessageBox.Show("El efectivo ingresado no es válido.", "Error");
                return;
            }

            cambio = efectivo - total;

            if (cambio < 0)
            {
                MessageBox.Show("El efectivo ingresado es insuficiente. Por favor, verifique y ajuste la cantidad.", "Error");
                return;
            }

            GuardarFactura();

            string folderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Facturas");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = $"Factura_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pdf";
            string filePath = System.IO.Path.Combine(folderPath, fileName);

            CrearFacturaPDF(filePath);

            MessageBox.Show("Factura generada correctamente.", "Éxito");

            // Abrir el PDF generado
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
            limpiarCamposBusqueda();
            carritodgv.Rows.Clear();
            totaltxt.Clear();
            efectivotxt.Clear();
            cambiotxt.Clear();
        }

        private void GuardarFactura()
        {
            try
            { 
            int usuario_id = 1;
            decimal total = decimal.Parse(totaltxt.Text, System.Globalization.NumberStyles.Currency);
            int factura_id;

            using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-ATVMJU1;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;\r\n"))
            {
                conexion.Open();
                string consultaFactura = "INSERT INTO facturas (usuario_id, total) OUTPUT INSERTED.id VALUES (@usuario_id, @total)";
                using (SqlCommand comandoFactura = new SqlCommand(consultaFactura, conexion))
                {
                    comandoFactura.Parameters.AddWithValue("@usuario_id", usuario_id);
                    comandoFactura.Parameters.AddWithValue("@total", total);
                    // Obtener el ID de la factura insertada
                    factura_id = (int)comandoFactura.ExecuteScalar();
                }

                foreach (DataGridViewRow row in carritodgv.Rows)
                {
                    if (row.Cells["nombre"].Value != null)
                    {
                        string nombreMedicamento = row.Cells["nombre"].Value.ToString();
                        int cantidad = int.Parse(row.Cells["cantidad"].Value.ToString());
                        decimal precio = decimal.Parse(row.Cells["precio"].Value.ToString(), System.Globalization.NumberStyles.Currency);

                        // Obtener el medicamento_id según el nombre
                        int medicamento_id = ObtenerMedicamentoId(nombreMedicamento);

                        // Insertar detalles de la factura
                        string consultaDetalles = "INSERT INTO detalles_factura (factura_id, medicamento_id, cantidad, precio) VALUES (@factura_id, @medicamento_id, @cantidad, @precio)";
                        using (SqlCommand comandoDetalles = new SqlCommand(consultaDetalles, conexion))
                        {
                            comandoDetalles.Parameters.AddWithValue("@factura_id", factura_id);
                            comandoDetalles.Parameters.AddWithValue("@medicamento_id", medicamento_id);
                            comandoDetalles.Parameters.AddWithValue("@cantidad", cantidad);
                            comandoDetalles.Parameters.AddWithValue("@precio", precio);
                            comandoDetalles.ExecuteNonQuery();
                        }

                        // Actualizar el stock del medicamento
                        string actualizarStock = "UPDATE medicamentos SET stock = stock - @cantidad WHERE id = @medicamento_id";
                        using (SqlCommand comandoStock = new SqlCommand(actualizarStock, conexion))
                        {
                            comandoStock.Parameters.AddWithValue("@cantidad", cantidad);
                            comandoStock.Parameters.AddWithValue("@medicamento_id", medicamento_id);
                            comandoStock.ExecuteNonQuery();
                        }
                    }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la factura: " + ex.Message, "Error");
            }
        }


        private int ObtenerMedicamentoId(string nombre)
        {
            int medicamento_id = 0;
            using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-ATVMJU1;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;\r\n"))
            {
                conexion.Open();
                string consulta = "SELECT id FROM medicamentos WHERE nombre = @nombre";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    object result = comando.ExecuteScalar();
                    if (result != null)
                    {
                        medicamento_id = (int)result;
                    }
                    else
                    {
                        MessageBox.Show($"No se encontró el medicamento: {nombre}", "Error");
                    }
                }
            }
            return medicamento_id;
        }


        private void CrearFacturaPDF(string filePath)
        {
            try
            {
                using (PdfWriter writer = new PdfWriter(filePath))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document document = new Document(pdf, PageSize.A6); // Tamaño del papel reducido

                        // Añadir título
                        document.Add(new Paragraph("Factura")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(20));

                        // Añadir fecha y número de factura
                        string numeroFactura = System.IO.Path.GetFileNameWithoutExtension(filePath);
                        document.Add(new Paragraph($"Factura No: {numeroFactura}")
                            .SetTextAlignment(TextAlignment.RIGHT));
                        document.Add(new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"))
                            .SetTextAlignment(TextAlignment.RIGHT));

                        // Añadir tabla con productos
                        Table table = new Table(UnitValue.CreatePercentArray(new float[] { 3, 1, 1 })).UseAllAvailableWidth();
                        table.AddHeaderCell("Producto");
                        table.AddHeaderCell("Cantidad");
                        table.AddHeaderCell("Precio");

                        foreach (DataGridViewRow row in carritodgv.Rows)
                        {
                            if (row.Cells["nombre"].Value != null)
                            {
                                table.AddCell(row.Cells["nombre"].Value.ToString());
                                table.AddCell(row.Cells["cantidad"].Value.ToString());
                                table.AddCell(row.Cells["precio"].Value.ToString());
                            }
                        }

                        // Añadir tabla al documento
                        document.Add(table);

                        // Añadir total, efectivo y cambio
                        document.Add(new Paragraph($"Total: {totaltxt.Text}")
                            .SetTextAlignment(TextAlignment.RIGHT));
                        document.Add(new Paragraph($"Efectivo: {efectivotxt.Text}")
                            .SetTextAlignment(TextAlignment.RIGHT));
                        document.Add(new Paragraph($"Cambio: {cambiotxt.Text}")
                            .SetTextAlignment(TextAlignment.RIGHT));

                        document.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generando el PDF: " + ex.Message, "Error");
            }
        }


        private void carritodgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < carritodgv.Rows.Count)
            {
                DataGridViewRow row = carritodgv.Rows[e.RowIndex];
                if (row.Cells.Count > 2) // Asegurarse de que hay suficientes celdas
                {
                    nombretxt.Text = row.Cells["nombre"].Value?.ToString() ?? "";
                    cantidadtxt.Text = row.Cells["cantidad"].Value?.ToString() ?? "";
                    preciotxt.Text = row.Cells["precio"].Value?.ToString() ?? "";

                    nombretxt.ForeColor = Color.Black;
                    cantidadtxt.ForeColor = Color.Black;
                    preciotxt.ForeColor = Color.Black;
                    cantidadtxt.Enabled = true; // Habilitar el campo de cantidad para edición
                }
                else
                {
                    MessageBox.Show("La fila seleccionada no tiene suficientes celdas.", "Error");
                }
            }
        }

        private void eliminarBtn_Click(object sender, EventArgs e)
        {
            if (carritodgv.SelectedCells.Count > 0)
            {
                int rowIndex = carritodgv.SelectedCells[0].RowIndex;
                carritodgv.Rows.RemoveAt(rowIndex);
                busquedatxt.Text = "NOMBRE / CÓDIGO";
                busquedatxt.ForeColor = Color.Silver;
                ActualizarTotalYCambio();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila o celda para eliminar.", "Error");
            }
        }


        private void totaltxt_Enter(object sender, EventArgs e)
        {
            if (totaltxt.Text == "TOTAL")
            {
                totaltxt.Text = "";
                totaltxt.ForeColor = Color.Black;
            }
        }

        private void totaltxt_Leave(object sender, EventArgs e)
        {
            if (totaltxt.Text == "")
            {
                totaltxt.Text = "TOTAL";
                totaltxt.ForeColor = Color.Silver;
            }
        }

        private void efectivotxt_Enter(object sender, EventArgs e)
        {
            if (efectivotxt.Text == "EFECTIVO")
            {
                efectivotxt.Text = "";
                efectivotxt.ForeColor = Color.Black;
            }
        }

        private void efectivotxt_Leave(object sender, EventArgs e)
        {
            if (efectivotxt.Text == "")
            {
                efectivotxt.Text = "EFECTIVO";
                efectivotxt.ForeColor = Color.Silver;
            }
        }

        private void cambiotxt_Enter(object sender, EventArgs e)
        {
            if (cambiotxt.Text == "CAMBIO")
            {
                cambiotxt.Text = "";
                cambiotxt.ForeColor = Color.Black;
            }
        }

        private void cambiotxt_Leave(object sender, EventArgs e)
        {
            if (cambiotxt.Text == "")
            {
                cambiotxt.Text = "CAMBIO";
                cambiotxt.ForeColor = Color.Silver;
            }
        }

        private void efectivotxt_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotalYCambio();
        }

    }
}
