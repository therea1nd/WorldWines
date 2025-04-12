using MySql.Data.MySqlClient;
using Saladpuk.PromptPay.Facades;
using System;
using System.Data;
using System.Windows.Forms;
using Saladpuk.PromptPay.Contracts;
using System.Drawing;
using Font = System.Drawing.Font;
using System.Drawing.Printing;
using Image = System.Drawing.Image;
using Rectangle = System.Drawing.Rectangle;
using Color = System.Drawing.Color;
using System.Globalization;






namespace WorldWines
{
    public partial class paymentform : Form
    {
        public DataTable itemList;
        MySqlConnection conn;
        //private QrBuilder qrBuilder;
        //private BillPayment billPayment;
        //private CreditTransfer creditTransfer;

        public DataTable listitem { get; set; }

        public paymentform()
        {
            InitializeComponent();
            conn = databaseConnection();
            DisplayData();
            UpdateTotal();
            //Date = DateTime.Now.ToString("M/d/yyyy");
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=worldwine;Uid=root;Pwd=;";
            return new MySqlConnection(connectionString);
        }
        private void DisplayData()
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM cartprehistory", conn))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DisplayData(dt);
                }
            }
        }

        private void totalCost_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(totalCost.Text) && decimal.TryParse(totalCost.Text, out decimal number))
            {
                totalCost.Text = number.ToString("#,##0.00");
                totalCost.SelectionStart = totalCost.Text.Length;
            }

        }
        private void DisplayData(DataTable dt)
        {
            dataGridView1.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Height = 150;
                dataGridView1.Rows[rowIndex].Cells["ColumnID"].Value = row["ID"];
                dataGridView1.Rows[rowIndex].Cells["columnName"].Value = row["items"];
                dataGridView1.Rows[rowIndex].Cells["columnAmount"].Value = row["quantity"];
                dataGridView1.Rows[rowIndex].Cells["columnCost"].Value = row["cost"];
                dataGridView1.Rows[rowIndex].Cells["columnTotal"].Value = row["total"];
            }
        }
        private void payment_Load(object sender, EventArgs e)
        {
            UpdateTotal();

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        public void UpdateTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["columnTotal"].Value != null) // ตรวจสอบว่ามีค่าเป็น null หรือไม่
                {
                    decimal price = Convert.ToDecimal(row.Cells["columnTotal"].Value);
                    total += price;
                }
            }

            string cost = total.ToString();
            totalCost.Text = cost; // แสดงผลรวมใน TextBox
        }


        private void showQrBtn_Click(object sender, EventArgs e)
        {
            double totalAmount = Convert.ToDouble(totalCost.Text); // Assuming totalCost is the TextBox displaying the total amount
            QrCodeForm qrForm = new QrCodeForm(totalAmount, dataGridView1);
            qrForm.Show();
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            // คำสั่ง SQL สำหรับลบข้อมูลทั้งหมดในตาราง cartprehistory
            string deleteQuery = "DELETE FROM cartprehistory";

            // เชื่อมต่อกับฐานข้อมูล
            using (MySqlConnection connection = databaseConnection())
            {
                // เปิดการเชื่อมต่อ
                connection.Open();

                // สร้างคำสั่ง SQL
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
                {
                    // ทำการลบข้อมูล
                    cmd.ExecuteNonQuery();
                }
            }

            // ปิดฟอร์ม
            this.Close();
        }


        //public void qrpayment_Load(object sender, EventArgs e, double totalAmount)
        //{
        //    double qr_price = totalAmount;

        //    IPromptPayBuilder builder = PPay.DynamicQR;

        //    string qr = PPay.DynamicQR.MobileNumber("0996344950").Amount(qr_price).CreateCreditTransferQrCode();
        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(qr, QRCodeGenerator.ECCLevel.Q);
        //    QRCode qrCode = new QRCode(qrCodeData);
        //    Bitmap qrCodeImage = qrCode.GetGraphic(10);

        //    // Display the QR code image in the PictureBox 
        //    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        //    pictureBox1.Image = qrCodeImage;
        //}
        //private void finishBtn_Click(object sender, EventArgs e)
        //{
        //    conn.Open();
        //    string deleteQuery = "DELETE FROM cartprehistory";
        //    MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, conn);

        //    try
        //    {
        //        cmdDelete.ExecuteNonQuery();
        //        //MessageBox.Show("ลบข้อมูลทั้งหมดออกจากตะกร้าสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        dataGridView1.Rows.Clear(); // ลบแถวทั้งหมดใน DataGridView
        //        MessageBox.Show("ขอบคุณที่ใช้บริการ", "WorldWines", MessageBoxButtons.OK);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("เกิดข้อผิดพลาดในการลบข้อมูล: " + ex.Message, "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //        this.Close(); // ปิดหน้าต่าง paymentform
        //        //Application.Exit();                
        //    }

        //}

        public decimal priceExcludingTax()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["columnTotal"].Value != null) // ตรวจสอบว่ามีค่าเป็น null หรือไม่
                {
                    decimal price = Convert.ToDecimal(row.Cells["columnTotal"].Value);
                    total += price;
                }
            }

            // คำนวณภาษีมูลค่าเพิ่ม (VAT) ที่ 7%
            decimal vatRate = 0.07m; // อัตราภาษีมูลค่าเพิ่ม (VAT)
            decimal valueAddedTax = total * vatRate;

            return total - valueAddedTax;
        }

        public decimal valueAddedTax()
        {
            decimal total = totalPriceIncludingTax(); // เรียกใช้ totalPriceIncludingTax ที่คำนวณค่าแล้ว

            // คำนวณภาษีมูลค่าเพิ่ม (VAT) ที่ 7%
            decimal vatRate = 0.07m; // อัตราภาษีมูลค่าเพิ่ม (VAT)
            decimal valueAddedTax = total * vatRate;

            return valueAddedTax;
        }

        public decimal totalPriceIncludingTax()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["columnTotal"].Value != null) // ตรวจสอบว่ามีค่าเป็น null หรือไม่
                {
                    decimal price = Convert.ToDecimal(row.Cells["columnTotal"].Value);
                    total += price;
                }
            }

            return total;
        }


        private void printBtn_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set paper size to A4
            e.PageSettings.PaperSize = new PaperSize("A4", 827, 1169);

            Image BgPdf = Properties.Resources.WorldWinesBGPdf;
            e.Graphics.DrawImage(BgPdf, new Rectangle(0, 0, e.PageBounds.Width, e.PageBounds.Height));

            DataGridViewPrint(e.Graphics, dataGridView1);

            string Date = DateTimeOffset.Now.ToString("dd MMM yyyy", new CultureInfo("th-TH"));
            e.Graphics.DrawString(Date, new Font("K2D", 10, FontStyle.Bold), Brushes.Black, new PointF(699, 1044));

            decimal totalPriceIncTax = totalPriceIncludingTax();
            decimal vat = valueAddedTax();
            decimal priceExclTax = priceExcludingTax();

            // Format strings for displaying
            string priceExclTaxText = "ราคาไม่รวมภาษีมูลค่าเพิ่ม " + priceExclTax.ToString(" #,##0.00 ") + " บาท";
            string vatText = "ภาษีมูลค่าเพิ่ม (VAT 7%) " + vat.ToString(" #,##0.00 ") + " บาท";
            string totalPriceIncTaxText = "ราคาสุทธิ " + totalPriceIncTax.ToString(" #,##0.00 ") + " บาท";

            // Set appropriate coordinates for drawing
            int x = 80;
            int y = 770;

            // Draw the texts
            e.Graphics.DrawString(priceExclTaxText, new Font("K2D", 12), Brushes.Black, new PointF(x, y));
            e.Graphics.DrawString(vatText, new Font("K2D", 12), Brushes.Black, new PointF(x, y + 27));
            e.Graphics.DrawString(totalPriceIncTaxText, new Font("K2D", 12), Brushes.Black, new PointF(x, y + 54));
        }


        private void DataGridViewPrint(Graphics g, DataGridView dataGridView)
        {
            SolidBrush myBrushRedWine = new SolidBrush(Color.FromArgb(159, 34, 34));

            int rowHeight = dataGridView.RowTemplate.Height;
            int cellHeightPadding = 5;

            int x = 80; // Start X position
            int y = 175; // Start Y position

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                // Print Column Headers
                g.DrawString(column.HeaderText, new Font("K2D", 14, FontStyle.Bold), myBrushRedWine, x, y);
                x += column.Width + cellHeightPadding;
            }

            y += rowHeight + 10;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                x = 80; // Reset X position for each row

                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Print Cell Value
                    g.DrawString(cell.Value?.ToString() ?? "", new Font("K2D", 12, FontStyle.Regular), myBrushRedWine, x, y);
                    x += cell.Size.Width + cellHeightPadding;
                }

                y += rowHeight + 10;
            }
            myBrushRedWine.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void discount_Click(object sender, EventArgs e)
        {
            decimal originalTotalCost;

            if (decimal.TryParse(totalCost.Text, out originalTotalCost))
            {
                decimal discountedTotalCost = originalTotalCost;

                if (CodeBox.Text == "worldwine2024")
                {
                    discountedTotalCost *= 0.8m;
                    label4.Text = "คุณได้รับส่วนลด 20%";
                }
                else
                {
                    label4.Text = "";
                }

                totalCost.Text = discountedTotalCost.ToString("#,##0.00");
                totalCost.SelectionStart = totalCost.Text.Length;
            }
            else
            {

            }
        }


        private void CodeBox_TextChanged(object sender, EventArgs e)
        {
        
        }
        private void label4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void cashBtn_Click(object sender, EventArgs e)
        {
            // Ask user for confirmation before proceeding
            DialogResult result = MessageBox.Show(
                "คุณยืนยันการชำระเงินสดใช่หรือไม่?",
                "ยืนยันการชำระเงิน",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Update cart table (optional): If needed, update the cart table to reflect the completed purchase
                //  This logic would depend on your specific database schema

                // Confirm receipt printing
                DialogResult receiptResult = MessageBox.Show(
                    "ต้องการพิมพ์ใบเสร็จหรือไม่?",
                    "พิมพ์ใบเสร็จ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (receiptResult == DialogResult.Yes)
                {
                    // Print receipt
                    PrintDocument printDoc = new PrintDocument();
                    printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);

                    PrintDialog printDialog = new PrintDialog();
                    printDialog.Document = printDoc;

                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        printDoc.Print();
                    }
                }

                // Close the form
                this.Close();
            }
        }

    }
}

