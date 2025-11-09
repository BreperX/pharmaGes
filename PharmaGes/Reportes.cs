using System;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace PharmaGes
{
    public partial class Reportes : Form
    {
        private string connectionString = "Data Source=DESKTOP-ATVMJU1;Initial Catalog=PharmaGes;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;\r\n";

        // Variable para determinar el tipo de reporte
        private string tipoReporte = "";

        public Reportes()
        {
            InitializeComponent();
        }

        // Botón para generar el reporte según las fechas seleccionadas
        private void Generarbtn_Click_1(object sender, EventArgs e)
        {
            DateTime fechaInicio = Desdedtp.Value;
            DateTime fechaFin = hastadtp.Value;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.");
                return;
            }

            if (tipoReporte == "Diario" || tipoReporte == "Semanal" || tipoReporte == "Mensual")
            {
                GenerarReportePDF(tipoReporte, fechaInicio, fechaFin);
            }
            else
            {
                MessageBox.Show("Por favor seleccione un tipo de reporte.");
            }
        }

        private void GenerarReportePDF(string tipoReporte, DateTime fechaInicio, DateTime fechaFin)
        {
            // Verificar que el rango de fechas no exceda los 31 días
            if (tipoReporte == "Diario" && (fechaFin - fechaInicio).TotalDays > 31)
            {
                MessageBox.Show("El rango máximo para el reporte diario es de 31 días.");
                return;
            }

            // Definir la ruta del escritorio y la carpeta "reportes"
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string reportFolder = Path.Combine(desktopPath, "reportes");

            // Crear la carpeta si no existe
            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }

            // Definir el nombre del archivo PDF
            string filePath = Path.Combine(reportFolder, $"Reporte_{tipoReporte}_{fechaInicio:yyyyMMdd}_{fechaFin:yyyyMMdd}.pdf");

            using (PdfWriter writer = new PdfWriter(filePath))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);
                    document.Add(new Paragraph($"Reporte de Ventas - {tipoReporte}"));
                    document.Add(new Paragraph($"Desde: {fechaInicio:dd/MM/yyyy} Hasta: {fechaFin:dd/MM/yyyy}"));
                    document.Add(new Paragraph(new string('-', 50)));

                    string query = "";
                    Dictionary<string, decimal> ventasPorDia = new Dictionary<string, decimal>();
                    Dictionary<int, decimal> ventasPorSemana = new Dictionary<int, decimal>();
                    Dictionary<int, decimal> ventasPorMes = new Dictionary<int, decimal>();

                    if (tipoReporte == "Diario")
                    {
                        query = @"
                SELECT CAST(v.fecha AS DATE) AS Fecha, COALESCE(SUM(v.total), 0) AS TotalVentas
                FROM facturas v
                WHERE v.fecha BETWEEN @FechaInicio AND @FechaFin
                GROUP BY CAST(v.fecha AS DATE)
                ORDER BY Fecha";
                    }
                    else if (tipoReporte == "Semanal")
                    {
                        query = @"
                SELECT DATEPART(week, v.fecha) AS Semana, COALESCE(SUM(v.total), 0) AS TotalVentas
                FROM facturas v
                WHERE v.fecha BETWEEN @FechaInicio AND @FechaFin
                GROUP BY DATEPART(week, v.fecha)
                ORDER BY Semana";
                    }
                    else if (tipoReporte == "Mensual")
                    {
                        query = @"
                SELECT DATEPART(month, v.fecha) AS Mes, COALESCE(SUM(v.total), 0) AS TotalVentas
                FROM facturas v
                WHERE v.fecha BETWEEN @FechaInicio AND @FechaFin
                GROUP BY DATEPART(month, v.fecha)
                ORDER BY Mes";
                    }

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                            command.Parameters.AddWithValue("@FechaFin", fechaFin);

                            SqlDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (tipoReporte == "Diario")
                                {
                                    string fecha = reader.GetDateTime(0).ToString("dd/MM/yyyy");
                                    decimal totalVentas = reader.GetDecimal(1);
                                    ventasPorDia[fecha] = totalVentas;
                                }
                                else if (tipoReporte == "Semanal")
                                {
                                    int semana = reader.GetInt32(0);
                                    decimal totalVentas = reader.GetDecimal(1);
                                    ventasPorSemana[semana] = totalVentas;
                                }
                                else if (tipoReporte == "Mensual")
                                {
                                    int mes = reader.GetInt32(0);
                                    decimal totalVentas = reader.GetDecimal(1);
                                    ventasPorMes[mes] = totalVentas;
                                }
                            }
                        }
                    }

                    // Mostrar resultados en el PDF
                    if (tipoReporte == "Diario")
                    {
                        foreach (var item in ventasPorDia)
                        {
                            document.Add(new Paragraph($"Fecha: {item.Key}, Total Ventas: {item.Value}"));
                        }

                        // Identificar el día con más y menos ventas
                        var maxDia = ventasPorDia.OrderByDescending(v => v.Value).FirstOrDefault();
                        var minDia = ventasPorDia.OrderBy(v => v.Value).FirstOrDefault();

                        if (maxDia.Key != null)
                        {
                            document.Add(new Paragraph($"Día con más ventas: {maxDia.Key} - Total: {maxDia.Value}"));
                        }
                        else
                        {
                            document.Add(new Paragraph("No se realizaron ventas en el período especificado."));
                        }

                        if (minDia.Key != null)
                        {
                            document.Add(new Paragraph($"Día con menos ventas: {minDia.Key} - Total: {minDia.Value}"));
                        }
                        else
                        {
                            document.Add(new Paragraph("No se realizaron ventas en el período especificado."));
                        }
                    }
                    else if (tipoReporte == "Semanal")
                    {
                        foreach (var item in ventasPorSemana)
                        {
                            document.Add(new Paragraph($"Semana: {item.Key}, Total Ventas: {item.Value}"));
                        }

                        var maxSemana = ventasPorSemana.OrderByDescending(v => v.Value).FirstOrDefault();
                        var minSemana = ventasPorSemana.OrderBy(v => v.Value).FirstOrDefault();

                        if (maxSemana.Key != 0)
                        {
                            document.Add(new Paragraph($"Semana con más ventas: {maxSemana.Key} - Total: {maxSemana.Value}"));
                        }
                        else
                        {
                            document.Add(new Paragraph("No se realizaron ventas en el período especificado."));
                        }

                        if (minSemana.Key != 0)
                        {
                            document.Add(new Paragraph($"Semana con menos ventas: {minSemana.Key} - Total: {minSemana.Value}"));
                        }
                        else
                        {
                            document.Add(new Paragraph("No se realizaron ventas en el período especificado."));
                        }
                    }
                    else if (tipoReporte == "Mensual")
                    {
                        foreach (var item in ventasPorMes)
                        {
                            string mesNombre = new DateTime(2024, item.Key, 1).ToString("MMMM");
                            document.Add(new Paragraph($"{mesNombre} Total Ventas: {item.Value}"));
                        }

                        var maxMes = ventasPorMes.OrderByDescending(v => v.Value).FirstOrDefault();
                        var minMes = ventasPorMes.OrderBy(v => v.Value).FirstOrDefault();

                        if (maxMes.Key != 0)
                        {
                            string mesMaxNombre = new DateTime(2024, maxMes.Key, 1).ToString("MMMM");
                            document.Add(new Paragraph($"Mes con más ventas: {mesMaxNombre} - Total: {maxMes.Value}"));
                        }
                        else
                        {
                            document.Add(new Paragraph("No se realizaron ventas en el período especificado."));
                        }

                        if (minMes.Key != 0)
                        {
                            string mesMinNombre = new DateTime(2024, minMes.Key, 1).ToString("MMMM");
                            document.Add(new Paragraph($"Mes con menos ventas: {mesMinNombre} - Total: {minMes.Value}"));
                        }
                        else
                        {
                            document.Add(new Paragraph("No se realizaron ventas en el período especificado."));
                        }
                    }
                }
            }

            // Abrir el archivo PDF generado
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        // Eventos para seleccionar el tipo de reporte
        private void Diabtn_Click(object sender, EventArgs e) => tipoReporte = "Diario";
        private void Semanabtn_Click(object sender, EventArgs e) => tipoReporte = "Semanal";
        private void Mesbtn_Click(object sender, EventArgs e) => tipoReporte = "Mensual";
    }
}