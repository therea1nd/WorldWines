using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WorldWines
{
    public partial class ShoppingCart : Form
    {
        private FlowLayoutPanel flowLayoutPanel1;

        public ShoppingCart()
        {
            InitializeComponent();
            CustomLayouts();
        }

        private void CustomLayouts()
        {
            // สร้าง FlowLayoutPanel ใหม่
            flowLayoutPanel1 = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            //เพิ่ม FlowLayoutPanelใหม่ ลงใน panel1 ที่มีอยู่
            panel1.Controls.Add(flowLayoutPanel1);

            //ตั้งค่าขนาด GroupBox ให้เป็น AutoSize 
            groupBox2.AutoSize = true;
        }

        private void ShoppingCart_Load(object sender, EventArgs e)
        {
            LoadCartItems();
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
                string selectCommand = @"SELECT ID, items, SUM(quantity) AS totalQuantity, cost FROM cartprehistory GROUP BY ID, items, cost"; //แก้ไขตรงนี้ให้ดึง ID มาด้วย
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectCommand, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                flowLayoutPanel1.Controls.Clear();
                decimal subtotal = 0;

                foreach (DataRow row in dataTable.Rows)
                {
                    var itemPanel = CreateItemPanel(
                        row["ID"].ToString(),  // ส่ง ID ไปให้ CreateItemPanel
                        row["items"].ToString(),
                        Convert.ToInt32(row["totalQuantity"]),
                        Convert.ToDecimal(row["cost"]));

                    flowLayoutPanel1.Controls.Add(itemPanel);
                    subtotal += Convert.ToDecimal(row["cost"]) * Convert.ToInt32(row["totalQuantity"]);
                }

                //lblSubtotal.Text = $"ราคาสุทธิ : {subtotal:N} บาท";
                subtotalTextBox.Text = $"{subtotal:N}";
            }
        }

        private Panel CreateItemPanel(string productId, string productName, int quantity, decimal price)
        {

            
            var panel = new Panel
            {
                Size = new Size(550, 100), // ปรับขนาด
                BackColor = Color.FromArgb(242, 229, 229), // พื้นหลังสีอ่อน
            };

            var nameLabel = new Label
            {
                Text = productName,
                AutoSize = true,
                Font = new Font("K2D", 12, FontStyle.Bold),
                Location = new Point(10, 10)
            };

            var quantityLabel = new Label
            {
                Text = $"จำนวน: {quantity}",
                AutoSize = true,
                Font = new Font("K2D", 10),
                Location = new Point(10, 40),
                Name = "quantityLabel"
            };

            var priceLabel = new Label
            {
                Text = $"ราคา: {price:N} บาท",
                AutoSize = true,
                Font = new Font("K2D", 10),
                Location = new Point(10, 70)
            };

            var increaseButton = new Button
            {
                Text = "+",
                Location = new Point(460, 40),
                Size = new Size(30, 30),
                ForeColor = Color.Green,
                BackColor = Color.Snow
            };

            var decreaseButton = new Button
            {
                Text = "-",
                Location = new Point(500, 40),
                Size = new Size(30, 30),
                ForeColor = Color.Red,
                BackColor = Color.Snow
            };

            increaseButton.Click += (sender, e) =>
            {
                int currentQuantity = int.Parse(quantityLabel.Text.Split(':')[1].Trim());
                UpdateQuantity(productId, productName, currentQuantity + 1, price, quantityLabel);
            };

            decreaseButton.Click += (sender, e) =>
            {
                int currentQuantity = int.Parse(quantityLabel.Text.Split(':')[1].Trim());
                UpdateQuantity(productId, productName, currentQuantity - 1, price, quantityLabel);
            };
            //ยัดปุ่ม
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(quantityLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(increaseButton);
            panel.Controls.Add(decreaseButton);

            return panel;
        }

        private void UpdateQuantity(string productId, string productName, int newQuantity, decimal price, Label quantityLabel)
        {
            if (newQuantity < 0)
            {
                MessageBox.Show("จำนวนสินค้าต้องมากกว่าหรือเท่ากับ 0");
                return;
            }

            using (MySqlConnection connection = DatabaseConnection())
            {
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 1. ดึงข้อมูลสินค้าจาก winestock (ใช้ productId ในการค้นหา)
                    int currentStock = 0;
                    string selectStockCommand = "SELECT amount FROM winestock WHERE id = @id";
                    using (MySqlCommand command = new MySqlCommand(selectStockCommand, connection))
                    {
                        command.Parameters.AddWithValue("@id", productId);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            currentStock = Convert.ToInt32(result);
                        }
                    }

                    // 2. ตรวจสอบว่ามีสินค้าใน stock เพียงพอหรือไม่ (ถ้า newQuantity > 0)
                    if (newQuantity > currentStock)
                    {
                        MessageBox.Show("สินค้าในสต็อกไม่เพียงพอ");
                        return;
                    }

                    // 3. อัปเดต cartprehistory หรือลบรายการ (ใช้ productId ในการค้นหา)
                    string updateCartCommand;
                    if (newQuantity > 0)
                    {
                        updateCartCommand = "UPDATE cartprehistory SET quantity = @quantity WHERE id = @id";
                    }
                    else
                    {
                        updateCartCommand = "DELETE FROM cartprehistory WHERE id = @id";
                    }

                    using (MySqlCommand command = new MySqlCommand(updateCartCommand, connection))
                    {
                        command.Parameters.AddWithValue("@quantity", newQuantity);
                        command.Parameters.AddWithValue("@id", productId);
                        command.ExecuteNonQuery();
                    }

                    // 4. ลบส่วนอัพเดต winestock ออก

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error updating quantity: {ex.Message}");
                }
            }

            quantityLabel.Text = $"จำนวน: {newQuantity}";
            LoadCartItems();
        }


        private void payBtn_Click(object sender, EventArgs e)
        {
            //คำนวณ totalAmount จาก lblSubtotal
            decimal totalAmount = 0;
            if (decimal.TryParse(lblSubtotal.Text.Replace("ราคาสุทธิ : ", "").Replace(" บาท", ""), out decimal parsedSubtotal))
            {
                totalAmount = parsedSubtotal;
            }

            lastQRform lastQRForm = new lastQRform();
            this.Close();
            lastQRForm.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hideBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
