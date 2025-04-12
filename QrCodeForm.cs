using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;
using QRCoder;
using Saladpuk.PromptPay.Contracts;
using Saladpuk.PromptPay.Facades;

namespace WorldWines
{
    public partial class QrCodeForm : Form
    {
        private DataGridView _dataGridView;
        private double _totalAmount;

        private void finishBtn_Click(object sender, EventArgs e)
        {
            // แสดง MessageBox เพื่อถามผู้ใช้ว่าต้องการพิมพ์ใบเสร็จหรือไม่
            DialogResult result = MessageBox.Show("คุณต้องการพิมพ์ใบเสร็จหรือไม่?", "พิมพ์ใบเสร็จ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // ถ้าผู้ใช้ตอบว่า Yes
            if (result == DialogResult.Yes)
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

            // ปิดฟอร์มนี้
            this.Close();
        }

        public QrCodeForm(double totalAmount, DataGridView dataGridView)
        {
            InitializeComponent();
            _totalAmount = totalAmount;
            _dataGridView = dataGridView;
            ShowQrCode(totalAmount);
        }

        private void ShowQrCode(double totalAmount)
        {
            IPromptPayBuilder builder = PPay.DynamicQR;
            string qr = PPay.DynamicQR.MobileNumber("0996344950").Amount(totalAmount).CreateCreditTransferQrCode();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qr, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            // Display the QR code image in the PictureBox
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = qrCodeImage;
            label1.Text = "ยอดเงินที่ต้องชำระ  :  " + totalAmount.ToString("#,##0.00") + "   บาท";
            //label1.Dock = DockStyle.Bottom;
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set paper size to A4
            e.PageSettings.PaperSize = new PaperSize("A4", 827, 1169);

            Image BgPdf = Properties.Resources.WorldWinesBGPdf;
            e.Graphics.DrawImage(BgPdf, new Rectangle(0, 0, e.PageBounds.Width, e.PageBounds.Height));

            DataGridViewPrint(e.Graphics, _dataGridView);

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

        public decimal priceExcludingTax()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                if (row.Cells["columnTotal"].Value != null)
                {
                    decimal price = Convert.ToDecimal(row.Cells["columnTotal"].Value);
                    total += price;
                }
            }

            decimal vatRate = 0.07m;
            decimal valueAddedTax = total * vatRate;

            return total - valueAddedTax;
        }

        public decimal valueAddedTax()
        {
            decimal total = totalPriceIncludingTax();

            decimal vatRate = 0.07m;
            decimal valueAddedTax = total * vatRate;

            return valueAddedTax;
        }

        public decimal totalPriceIncludingTax()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                if (row.Cells["columnTotal"].Value != null)
                {
                    decimal price = Convert.ToDecimal(row.Cells["columnTotal"].Value);
                    total += price;
                }
            }

            return total;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
