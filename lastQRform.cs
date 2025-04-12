using MySql.Data.MySqlClient;
using QRCoder;
using Saladpuk.PromptPay.Contracts;
using Saladpuk.PromptPay.Facades;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;


namespace WorldWines
{
    public partial class lastQRform : Form
    {
        private decimal subtotal;
        private decimal discountedTotal;

        public lastQRform()
        {
            InitializeComponent();
            LoadCartItems();

            openFileBtn.Enabled = false;
        }

        private void lastQRform_Load(object sender, EventArgs e)
        {
            discountedTotal = subtotal;
            ShowQrCode(discountedTotal);
          
        }

        private MySqlConnection DatabaseConnection()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=worldwine;Uid=root;Pwd=;";
            return new MySqlConnection(connectionString);

        }
        private void LoadCartItems()
        {
            using (MySqlConnection connection = DatabaseConnection())
            {
                connection.Open();
                string selectCommand = "SELECT ID, items, quantity, cost FROM cartprehistory";
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectCommand, connection))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    DisplayData(dataTable); // เรียกใช้ DisplayData เพื่อแสดงผล
                }
            }
        }
        private void DisplayData(DataTable dt)
        {
            dataGridView1.Rows.Clear(); // ล้างข้อมูลเดิมก่อนเพิ่มข้อมูลใหม่
            decimal localSubtotal = 0; // ตัวแปรสำหรับเก็บยอดรวม

            foreach (DataRow row in dt.Rows)
            {
                int rowIndex = dataGridView1.Rows.Add();

                // คำนวณยอดรวม
                decimal cost = Convert.ToDecimal(row["cost"]);
                int quantity = Convert.ToInt32(row["quantity"]);
                decimal total = cost * quantity;

                // กำหนดค่าให้กับเซลล์ใน DataGridView
                dataGridView1.Rows[rowIndex].Cells["columnID"].Value = row["ID"];
                dataGridView1.Rows[rowIndex].Cells["columnName"].Value = row["items"];
                dataGridView1.Rows[rowIndex].Cells["columnAmount"].Value = row["quantity"];
                dataGridView1.Rows[rowIndex].Cells["columnCost"].Value = row["cost"];
                dataGridView1.Rows[rowIndex].Cells["columnTotal"].Value = total;
                dataGridView1.Rows[rowIndex].Cells["columnTotal"].Style.Format = "#,##0";

                localSubtotal += total; //+total ใส่ subtotal
            }

            subtotal = localSubtotal;
            label3.Text = $"ยอดรวมสุทธิ : {subtotal:N} บาท";
        }

        private void clearCartPreHistory()
        {
            using (MySqlConnection connection = DatabaseConnection())
            {
                connection.Open();
                string deleteCartCmd = "DELETE FROM cartprehistory";
                using (MySqlCommand command = new MySqlCommand(deleteCartCmd, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void delFromWinestock()
        {
            using (MySqlConnection conn = DatabaseConnection())
            {
                conn.Open();
                string updateStockCmd = "UPDATE winestock " + "SET amount = amount - (SELECT quantity FROM cartprehistory WHERE ID = winestock.ID) " +
                                       "WHERE ID IN (SELECT ID FROM cartprehistory)";
                using (MySqlCommand command = new MySqlCommand(updateStockCmd, conn))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {

                    }
                    else
                    {

                    }
                }
            }
        }
        private void addToCartHistory()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection())
                {
                    conn.Open();

                    // ดึงข้อมูลชื่อและนามสกุลจากตาราง usersession
                    string query = "SELECT Name, Lastname FROM usersession WHERE id = (SELECT MAX(id) FROM usersession)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    string customerName = "";
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customerName = reader["Name"].ToString() + "  " + reader["Lastname"].ToString();
                        }
                    }

                    //เพิ่มข้อมูลลงใน carthistory
                    string insertCommand = "INSERT INTO carthistory (ID, items, quantity, cost, total, payment_date, Customer) " +
                                           "VALUES (@ID, @items, @quantity, @cost, @total, NOW(), @Customer)";
                    using (MySqlCommand command = new MySqlCommand(insertCommand, conn))
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["columnID"].Value != null)
                            {
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@ID", row.Cells["columnID"].Value.ToString());
                                command.Parameters.AddWithValue("@items", row.Cells["columnName"].Value.ToString());
                                command.Parameters.AddWithValue("@quantity", Convert.ToInt32(row.Cells["columnAmount"].Value));
                                command.Parameters.AddWithValue("@cost", Convert.ToDecimal(row.Cells["columnCost"].Value));
                                command.Parameters.AddWithValue("@total", Convert.ToDecimal(row.Cells["columnTotal"].Value));
                                command.Parameters.AddWithValue("@Customer", customerName);

                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected <= 0)
                                {
                                    MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล");
                                    return;
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("เพิ่มข้อมูลลงในประวัติการสั่งซื้อเรียบร้อยแล้ว");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเข้าถึงฐานข้อมูล: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดทั่วไป: " + ex.Message);
            }
        }

        private decimal totalPriceIncludingTax()
        {
            decimal totalPrice = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["columnCost"].Value != null && row.Cells["columnAmount"].Value != null)
                {
                    decimal price = Convert.ToDecimal(row.Cells["columnCost"].Value);
                    decimal quantity = Convert.ToDecimal(row.Cells["columnAmount"].Value);
                    totalPrice += price * quantity;
                }
            }
            return totalPrice;
        }

            private decimal valueAddedTax()
        {
            decimal valueAddedTax = 0;
            decimal totalPrice = totalPriceIncludingTax();
            decimal vatRate = 0.07m;
            valueAddedTax = totalPrice * vatRate;
            return valueAddedTax;
        }

        private decimal priceExcludingTax()
        {
            decimal priceExcludingTax = 0;
            decimal totalPrice = totalPriceIncludingTax();
            decimal vat = valueAddedTax();
            priceExcludingTax = totalPrice - vat;
            return priceExcludingTax;
        }



        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.PageSettings.PaperSize = new PaperSize("A4", 827, 1169);

            System.Drawing.Image BgPdf = Properties.Resources.WorldWinesBGPdf;
            e.Graphics.DrawImage(BgPdf, new Rectangle(0, 0, e.PageBounds.Width, e.PageBounds.Height));

            DataGridViewPrint(e.Graphics, dataGridView1);

            string Date = DateTimeOffset.Now.ToString("dd MMM yyyy", new CultureInfo("th-TH"));
            e.Graphics.DrawString(Date, new Font("K2D", 10, FontStyle.Bold), Brushes.Black, new PointF(699, 1044));

            decimal totalPriceIncTax = totalPriceIncludingTax();
            decimal vat = valueAddedTax();
            decimal priceExclTax = priceExcludingTax();
            decimal discountAmount = subtotal - discountedTotal;

            string priceExclTaxText = "ราคาไม่รวมภาษีมูลค่าเพิ่ม " + priceExclTax.ToString(" #,##0.00 ") + " บาท";
            string vatText = "ภาษีมูลค่าเพิ่ม (VAT 7%) " + vat.ToString(" #,##0.00 ") + " บาท";
            string discountText = "ส่วนลด " + discountAmount.ToString(" #,##0.00 ") + " บาท"; // ส่วนลด
            string totalPriceIncTaxText = "ราคาสุทธิ " + totalPriceIncTax.ToString(" #,##0.00 ") + " บาท";

            string name = "";
            string lastname = "";
            using (MySqlConnection conn = DatabaseConnection())
            {
                conn.Open();
                string query = "SELECT Name, Lastname FROM usersession WHERE id = (SELECT MAX(id) FROM usersession)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = reader["Name"].ToString();
                        lastname = reader["Lastname"].ToString();
                    }
                }
            }

            int x = 40;
            int y = 760;

            e.Graphics.DrawString(priceExclTaxText, new Font("K2D", 12), Brushes.Black, new PointF(x, y));
            e.Graphics.DrawString(vatText, new Font("K2D", 12), Brushes.Black, new PointF(x, y + 27));
            e.Graphics.DrawString(discountText, new Font("K2D", 12), Brushes.Black, new PointF(x, y + 54)); // แสดงส่วนลด
            e.Graphics.DrawString(totalPriceIncTaxText, new Font("K2D", 12), Brushes.Black, new PointF(x, y + 81));
            e.Graphics.DrawString("คุณ", new Font("K2D", 12), Brushes.Black, new PointF(x, y + 127));
            SizeF nameSize = e.Graphics.MeasureString(name, new Font("K2D", 12));
            e.Graphics.DrawString(name, new Font("K2D", 12), Brushes.Black, new PointF(x + 27, y + 127));
            e.Graphics.DrawString(lastname, new Font("K2D", 12), Brushes.Black, new PointF(x + 27 + nameSize.Width, y + 127));
        }



        private void DataGridViewPrint(Graphics g, DataGridView dataGridView)
        {
            SolidBrush myBrushRedWine = new SolidBrush(Color.FromArgb(159, 34, 34));

            int rowHeight = dataGridView.RowTemplate.Height;
            int cellHeightPadding = 5;

            int[] columnWidths = { 90, 400, 100, 100, 100 };

            int x = 40;
            int y = 175;

            // พิมพ์หัวตาราง
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                g.DrawString(dataGridView.Columns[i].HeaderText, new Font("K2D", 14, FontStyle.Bold), myBrushRedWine, x, y);
                x += columnWidths[i] + cellHeightPadding;
            }

            y += rowHeight + 13;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                x = 40;

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value != null)
                    {
                        string cellNum = row.Cells[i].Value.ToString();
                        if (decimal.TryParse(cellNum, out decimal numericValue))
                        {
                            cellNum = numericValue.ToString("#,##0.00");
                        }
                        g.DrawString(cellNum, new Font("K2D", 12, FontStyle.Regular), myBrushRedWine, x, y);
                    }
                    x += columnWidths[i] + cellHeightPadding;
                }

                y += rowHeight + 10;
            }
            myBrushRedWine.Dispose();
        }

        private void ShowQrCode(decimal amount)
        {
            IPromptPayBuilder builder = PPay.DynamicQR;
            string qr = PPay.DynamicQR.MobileNumber("0996344950").Amount((double)amount).CreateCreditTransferQrCode();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qr, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = qrCodeImage;
            decimal vatAmount = subtotal * 0.07m;

            //decimal vatAmount = amount * 0.07m;
            label2.Text = $"ราคาภาษีมูลค่าเพิ่ม : {vatAmount:N} บาท";
            label1.Text = $"ราคาไม่รวมภาษีมูลค่าเพิ่ม : {subtotal - vatAmount:N} บาท";
            label4.Text = $"ยอดเงินที่ต้องชำระ : {amount:N} บาท";
            //discountLbl.Text = $"ส่วนลด : {discountAmount:N} บาท";
        }

        private void showQrBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ทำรายการเสร็จสิ้น");
            addToCartHistory();
            delFromWinestock();
            showQrBtn.Enabled = false;
            cashBtn.Enabled = false;
        }

        private void cashBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ทำรายการเสร็จสิ้น");
            addToCartHistory();
            delFromWinestock();
            showQrBtn.Enabled = false;
            cashBtn.Enabled = false;
        }

        private void printDocBtn_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
                openFileBtn.Enabled = true;
            }
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\Users\pongs\OneDrive\Desktop\www\receipt";  // ระบุเส้นทางของโฟลเดอร์
            // ตรวจสอบว่าโฟลเดอร์มีไฟล์หรือไม่
            if (Directory.Exists(folderPath))
            {
                // ดึงรายการไฟล์ทั้งหมดในโฟลเดอร์
                var files = Directory.GetFiles(folderPath);

                // ค้นหาไฟล์ที่มีวันที่แก้ไขล่าสุด
                var latestFile = files.Select(file => new FileInfo(file)).OrderByDescending(f => f.LastWriteTime).FirstOrDefault();

                if (latestFile != null)
                {
                    System.Diagnostics.Process.Start(latestFile.FullName);
                }
                else
                {
                    MessageBox.Show("ไม่พบไฟล์ในโฟลเดอร์");
                }
            }
            else
            {
                MessageBox.Show("โฟลเดอร์ไม่ถูกต้อง");
            }
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            clearCartPreHistory();
            this.Close();
        }


        private void discountBtn_Click(object sender, EventArgs e)
        {
            string discountCode = textBoxDiscount.Text;
            if (discountCode == "worldwines2024")
            {
                MessageBox.Show("ได้รับส่วนลด 2%");
            }
            else
            {
                MessageBox.Show("โค้ดส่วนลดไม่ถูกต้อง");
                return;
            }
            ApplyDiscount(discountCode);
        }

        private void ApplyDiscount(string discountCode)
        {
            decimal discountAmount = 0;

            if (discountCode == "worldwines2024")
            {
                discountAmount = subtotal * 0.02m; // คำนวณส่วนลด 2%
            }
            discountedTotal = subtotal - discountAmount;

            // แสดงส่วนลดใน Label
            discountLbl.Text = $"ส่วนลด : {discountAmount:N} บาท";

            // อัปเดต QR Code สำหรับยอดเงินใหม่หลังหักส่วนลด
            ShowQrCode(discountedTotal);
        }


        private void textBoxDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hideBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    
    }
}
