using System;
using System.Windows.Forms;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace SmartShevet
{
    public partial class AnnualInventoryForecastReportPanel : UserControl
    {
        public AnnualInventoryForecastReportPanel()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            initializeDateRanges();
            loadCategories();
        }

        private void initializeDateRanges()
        {
            startDatePicker.Value = DateTime.Now.AddMonths(-12);
            endDatePicker.Value = DateTime.Now;
        }

        private void loadCategories()
        {
            categoryComboBox.Items.Clear();
            categoryComboBox.Items.Add("הכל");
            foreach (Equipment eq in Program.Equipments)
            {
                if (!categoryComboBox.Items.Contains(eq.getCategory()))
                    categoryComboBox.Items.Add(eq.getCategory());
            }
            categoryComboBox.SelectedIndex = 0;
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = startDatePicker.Value.Date;
                DateTime endDate = endDatePicker.Value.Date.AddDays(1).AddSeconds(-1);
                string categoryFilter = categoryComboBox.SelectedItem.ToString() == "הכל" ? null : categoryComboBox.SelectedItem.ToString();

                string connectionString = ConfigurationManager.ConnectionStrings["SmartShevet.Properties.Settings.SmartShevetConnectionString"]?.ConnectionString;
                if (string.IsNullOrEmpty(connectionString))
                {
                    MessageBox.Show("לא נמצאה מחרוזת חיבור בקובץ ההגדרות", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_annual_inventory_forecast_report", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                        cmd.Parameters.AddWithValue("@categoryFilter", categoryFilter ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@includeOverdueOnly", 0);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);

                            if (ds.Tables.Count >= 4)
                            {
                                displayConsumables(ds.Tables[0]);
                                displayUnreturned(ds.Tables[1]);
                                displayDamagedMissing(ds.Tables[2]);
                                displayTotals(ds.Tables[3]);
                            }
                        }
                    }
                }

                MessageBox.Show("דוח נוצר בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בצור הדוח: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void displayConsumables(DataTable dt)
        {
            consumablesDataGridView.DataSource = dt;
            consumablesDataGridView.ReadOnly = true;
            adjustColumnWidths(consumablesDataGridView);
        }

        private void displayUnreturned(DataTable dt)
        {
            unretrurnedDataGridView.DataSource = dt;
            unretrurnedDataGridView.ReadOnly = true;
            adjustColumnWidths(unretrurnedDataGridView);
        }

        private void displayDamagedMissing(DataTable dt)
        {
            damagedDataGridView.DataSource = dt;
            damagedDataGridView.ReadOnly = true;
            adjustColumnWidths(damagedDataGridView);
        }

        private void displayTotals(DataTable dt)
        {
            totalsDataGridView.DataSource = dt;
            totalsDataGridView.ReadOnly = true;
            adjustColumnWidths(totalsDataGridView);
        }

        private void adjustColumnWidths(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Width = Math.Min(col.Width + 20, 300);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (mainForm.previousPanel != null)
                mainForm.showPanel(mainForm.previousPanel);
            else
                mainForm.showPanel(new LoginPanel());
        }
    }
}
