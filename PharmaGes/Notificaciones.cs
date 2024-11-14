using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PharmaGes
{
    public partial class Notificaciones : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-CIKGIAC;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;";

        public Notificaciones()
        {
            InitializeComponent();
            LoadLowStockProducts();
            LoadExpiringProducts();
        }

        private void LoadLowStockProducts()
        {
            // Definimos el umbral de "bajo stock"
            int lowStockThreshold = 5;

            // Consulta SQL para obtener medicamentos con stock menor o igual al umbral
            string query = "SELECT codigo AS 'codigo', nombre AS 'Nombre', stock AS 'Stock Disponible' FROM medicamentos WHERE stock <= @lowStockThreshold";

            // Usamos SqlConnection y SqlCommand para conectarnos y ejecutar la consulta
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@lowStockThreshold", lowStockThreshold);

                // Abrimos la conexión
                connection.Open();

                // Usamos SqlDataAdapter para llenar un DataTable con los resultados de la consulta
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Asignamos el DataTable al DataGridView
                dataGridView1.DataSource = dataTable;
            }

            // Configuramos encabezados de columna en caso de que sea necesario
            dataGridView1.Columns["codigo"].HeaderText = "Codigo del Medicamento";
            dataGridView1.Columns["Nombre"].HeaderText = "Nombre del Medicamento";
            dataGridView1.Columns["Stock Disponible"].HeaderText = "Cantidad en Stock";
        }

        private void LoadExpiringProducts()
        {
            int daysUntilExpiry = 30;
            string query = "SELECT codigo AS codigo, nombre AS ProductName, fecha_caducidad AS ExpiryDate FROM medicamentos WHERE fecha_caducidad <= DATEADD(day, @daysUntilExpiry, GETDATE())";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@daysUntilExpiry", daysUntilExpiry);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;
            }

            dataGridView2.Columns["codigo"].HeaderText = "Codigo del Producto";
            dataGridView2.Columns["ProductName"].HeaderText = "Nombre del Producto";
            dataGridView2.Columns["ExpiryDate"].HeaderText = "Fecha de Caducidad";
        }
    }
}
