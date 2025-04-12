using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace WorldWines
{
    public partial class history : Form
    {
        private decimal totalAmount;

        public history()
        {
            InitializeComponent();
            TopThreeBestSellers();
        }

        private MySqlConnection conn;

        private MySqlConnection databaseConnection()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=worldwine;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        private void TopThreeBestSellers()
        {
            conn = databaseConnection();
            try
            {
                conn.Open();
                string query = @"SELECT items, SUM(quantity) AS TotalSold FROM carthistory GROUP BY items ORDER BY TotalSold DESC LIMIT 3";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                data.Fill(dt);

                labelTopFst.Text = "1. - ";
                labelTopSec.Text = "2. - ";
                labelTopThird.Text = "3. - ";

                //เรียงลำดับTOP3 ของสินค้าที่ขายดีที่สุด
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string itemName = dt.Rows[i]["items"].ToString();
                    string totalSold = dt.Rows[i]["TotalSold"].ToString();

                    switch (i)
                    {
                        case 0:
                            labelTopFst.Text = $"1. {itemName}\n- จำนวนที่ขาย {totalSold} ขวด";
                            break;
                        case 1:
                            labelTopSec.Text = $"2. {itemName}\n- จำนวนที่ขาย {totalSold} ขวด";
                            break;
                        case 2:
                            labelTopThird.Text = $"3. {itemName}\n- จำนวนที่ขาย {totalSold} ขวด";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }



        private void searchDateBtn_Click(object sender, EventArgs e)
        {
            // เรียกใช้ SalesHistoryWithSorting โดยใช้วันที่ที่เลือกใน DateTimePicker
            SalesHistoryWithSorting(dtpStartDate.Value, dtpEndDate.Value, "payment_date");
        }
        private void searchNameBtn_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchName.Text.Trim();

            if (!string.IsNullOrEmpty(searchValue))
            {
                SearchByNameOrID(searchValue);
            }
            else
            {
                MessageBox.Show("กรุณากรอกชื่อหรือรหัสสินค้าในการค้นหา");
            }
        }

        private void SearchByNameOrID(string searchValue)
        {
            conn = databaseConnection();
            try
            {
                conn.Open();
                string query = "SELECT IDstock, ID, items, quantity, cost, total, payment_date, Customer " +
                               "FROM carthistory " +
                               "WHERE items LIKE @SearchValue OR ID LIKE @SearchValue";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                data.Fill(dt);

                // แสดงข้อมูลใน DataGridView
                dataGridView1.DataSource = dt;

                dataGridView1.Columns["IDstock"].Visible = false;

                dataGridView1.Columns["ID"].HeaderText = "รหัสสินค้า";
                dataGridView1.Columns["ID"].Width = 100;

                dataGridView1.Columns["items"].HeaderText = "สินค้า";
                dataGridView1.Columns["items"].Width = 420;

                dataGridView1.Columns["quantity"].HeaderText = "จำนวน";
                dataGridView1.Columns["quantity"].Width = 80;

                dataGridView1.Columns["cost"].HeaderText = "ราคาต่อหน่วย";
                dataGridView1.Columns["cost"].Width = 120;
                dataGridView1.Columns["cost"].DefaultCellStyle.Format = "#,##0.00";

                dataGridView1.Columns["total"].HeaderText = "ราคารวม";
                dataGridView1.Columns["total"].Width = 120;
                dataGridView1.Columns["total"].DefaultCellStyle.Format = "#,##0.00";

                dataGridView1.Columns["payment_date"].HeaderText = "วันที่ขาย";
                dataGridView1.Columns["payment_date"].Width = 120;

                dataGridView1.Columns["Customer"].HeaderText = "ชื่อลูกค้า";
                dataGridView1.Columns["Customer"].Width = 185;

                totalAmount = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalAmount += Convert.ToDecimal(row["total"]);
                }
                lblTotalAmount.Text = $"ยอดขายทั้งหมด: {totalAmount.ToString("#,##0.00")} บาท";
                if (dt.Rows.Count > 0)
                {
                    DateTime FstDate = dt.AsEnumerable()
                                         .Min(row => row.Field<DateTime>("payment_date"));
                    DateTime LastDate = dt.AsEnumerable()
                                         .Max(row => row.Field<DateTime>("payment_date"));

                    lblDateRange.Text = $"ระหว่างวันที่ {FstDate.ToShortDateString()} ถึง {LastDate.ToShortDateString()}";
                    
                }
                else
                {
                    lblDateRange.Text = "ไม่พบข้อมูลในช่วงที่ระบุ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }



        private void SalesHistory(DateTime startDate, DateTime endDate, string sortBy)
        {
            conn = databaseConnection();
            try
            {
                conn.Open();
                string query = "SELECT IDstock, ID, items, quantity, cost, total, payment_date, Customer " +
                               "FROM carthistory " +
                               "WHERE payment_date BETWEEN @StartDate AND @EndDate ";

                MySqlCommand cmd2 = new MySqlCommand(query, conn);
                cmd2.Parameters.AddWithValue("@StartDate", startDate.Date);
                cmd2.Parameters.AddWithValue("@EndDate", endDate.Date);
                MySqlDataAdapter data = new MySqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                data.Fill(dt);

                // แสดงข้อมูลใน DataGridView
                dataGridView1.DataSource = dt;

                dataGridView1.Columns["IDstock"].Visible = false;

                dataGridView1.Columns["ID"].HeaderText = "รหัสสินค้า";
                dataGridView1.Columns["ID"].Width = 100;

                dataGridView1.Columns["items"].HeaderText = "สินค้า";
                dataGridView1.Columns["items"].Width = 420;

                dataGridView1.Columns["quantity"].HeaderText = "จำนวน";
                dataGridView1.Columns["quantity"].Width = 80;

                dataGridView1.Columns["cost"].HeaderText = "ราคาต่อหน่วย";
                dataGridView1.Columns["cost"].Width = 120;
                dataGridView1.Columns["cost"].DefaultCellStyle.Format = "#,##0";

                dataGridView1.Columns["total"].HeaderText = "ราคารวม";
                dataGridView1.Columns["total"].Width = 120;
                dataGridView1.Columns["total"].DefaultCellStyle.Format = "#,##0";

                dataGridView1.Columns["payment_date"].HeaderText = "วันที่ขาย";
                dataGridView1.Columns["payment_date"].Width = 120;

                dataGridView1.Columns["Customer"].HeaderText = "ชื่อลูกค้า";
                dataGridView1.Columns["Customer"].Width = 185;

                // คำนวณยอดรวมทั้งหมด
                totalAmount = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalAmount += Convert.ToDecimal(row["total"]);
                }

                // แสดงข้อมูลใน Label พร้อมฟอร์แมตตัวเลข
                lblDateRange.Text = $"ระหว่างวันที่ {startDate.ToShortDateString()} ถึง {endDate.ToShortDateString()}";
                lblTotalAmount.Text = $"ยอดขายทั้งหมด: {totalAmount.ToString("#,##0")} บาท";
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }




        private void SalesHistoryWithSorting(DateTime startDate, DateTime endDate, string sortBy)
        {
            //เรียกใช้ LoadSalesHistory โดยใช้วันที่ที่เลือกใน DateTimePicker และการเรียงลำดับตาม sortBy
            SalesHistory(startDate, endDate, sortBy);
        }


        private void secondAdminForm_Load(object sender, EventArgs e)
        {
            // Set MinDate and MaxDate for DateTimePickers
            dtpStartDate.MinDate = new DateTime(2000, 1, 1); // Example MinDate
            dtpStartDate.MaxDate = DateTime.Today;
            dtpEndDate.MinDate = new DateTime(2000, 1, 1); // Example MinDate
            dtpEndDate.MaxDate = DateTime.Today;

            // Set default values
            DateTime startDate = new DateTime(2024, 10, 1);
            DateTime today = DateTime.Today;

            dtpStartDate.Value = startDate >= dtpStartDate.MinDate && startDate <= dtpStartDate.MaxDate
                                 ? startDate
                                 : dtpStartDate.MinDate;

            dtpEndDate.Value = today >= dtpEndDate.MinDate && today <= dtpEndDate.MaxDate
                               ? today
                               : dtpEndDate.MinDate;

            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Format = DateTimePickerFormat.Short;
        }


        private void homeBtn_Click(object sender, EventArgs e)
        {
            loginPage backhome = new loginPage();
            backhome.Show();
            this.Visible = false;
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            firstAdminForm backAdmin = new firstAdminForm();
            backAdmin.Show();
            this.Visible = false;
        }

        private void lblSortBy_Click(object sender, EventArgs e)
        {

        }

        private void stockPBtn_Click(object sender, EventArgs e)
        {
            adminstock firstAdmin = new adminstock();
            firstAdmin.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nameSearchBtn_Click(object sender, EventArgs e)
        {
            {
                string searchValue = nameCustomerTxtbox.Text.Trim();

                if (!string.IsNullOrEmpty(searchValue))
                {
                    SearchByNameCustomer(searchValue);
                }
                else
                {
                    MessageBox.Show("กรุณากรอกชื่อลูกค้าในการค้นหา");
                }
            }

        }
        private void SearchByNameCustomer(string searchValue)
        {
            conn = databaseConnection();
            try
            {
                conn.Open();
                string query = "SELECT IDstock, ID, items, quantity, cost, total, payment_date, Customer " +
                               "FROM carthistory " +
                               "WHERE Customer LIKE @SearchValue";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                data.Fill(dt);

                // แสดงข้อมูลใน DataGridView
                dataGridView1.DataSource = dt;

                dataGridView1.Columns["IDstock"].Visible = false;

                dataGridView1.Columns["ID"].HeaderText = "รหัสสินค้า";
                dataGridView1.Columns["ID"].Width = 100;

                dataGridView1.Columns["items"].HeaderText = "สินค้า";
                dataGridView1.Columns["items"].Width = 420;

                dataGridView1.Columns["quantity"].HeaderText = "จำนวน";
                dataGridView1.Columns["quantity"].Width = 80;

                dataGridView1.Columns["cost"].HeaderText = "ราคาต่อหน่วย";
                dataGridView1.Columns["cost"].Width = 120;
                dataGridView1.Columns["cost"].DefaultCellStyle.Format = "#,##0.00";

                dataGridView1.Columns["total"].HeaderText = "ราคารวม";
                dataGridView1.Columns["total"].Width = 120;
                dataGridView1.Columns["total"].DefaultCellStyle.Format = "#,##0.00";

                dataGridView1.Columns["payment_date"].HeaderText = "วันที่ขาย";
                dataGridView1.Columns["payment_date"].Width = 120;

                dataGridView1.Columns["Customer"].HeaderText = "ชื่อลูกค้า";
                dataGridView1.Columns["Customer"].Width = 185;

                totalAmount = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalAmount += Convert.ToDecimal(row["total"]);
                }
                lblTotalAmount.Text = $"ยอดขายทั้งหมด: {totalAmount.ToString("#,##0.00")} บาท";
                if (dt.Rows.Count > 0)
                {
                    DateTime FstDate = dt.AsEnumerable()
                                         .Min(row => row.Field<DateTime>("payment_date"));
                    DateTime LastDate = dt.AsEnumerable()
                                         .Max(row => row.Field<DateTime>("payment_date"));

                    lblDateRange.Text = $"ระหว่างวันที่ {FstDate.ToShortDateString()} ถึง {LastDate.ToShortDateString()}";

                }
                else
                {
                    lblDateRange.Text = "ไม่พบข้อมูลในช่วงที่ระบุ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
