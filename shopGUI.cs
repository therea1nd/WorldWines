using System;
using System.Data;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static WorldWines.loginPage;
using static WorldWines.shopGUI;

namespace WorldWines
{
    public partial class shopGUI : Form
    {
        private string selectedProductId;

        private string selectedProductName;
        
        private decimal selectedProductPrice;

        public shopGUI()
        {
            InitializeComponent();
            LoadProducts(); //ดึง/อ่านข้อมูล สร้าง object แสดงสินค้าใน FlowLayoutPanel
        }
        
        private MySqlConnection DatabaseConnection()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=worldwine;Uid=root;Pwd=;";
            return new MySqlConnection(connectionString);
        }

        private void LoadProducts()
        {
            using (MySqlConnection connection = DatabaseConnection())
            {
                string selectCommand = "SELECT * FROM winestock";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectCommand, connection);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);

                flowLayoutPanel1.Controls.Clear();

                //สร้างลูป control product box ใหม่ใน FlowLayoutPanel
                foreach (DataRow row in table.Rows)
                {
                    var productControl = CreateProductBox(
                        row["ID"].ToString(),
                        row["Name"].ToString(),
                        row["Description"].ToString(),
                        row["amount"].ToString(),
                        Convert.ToDecimal(row["Cost"]),
                        (byte[])row["PIC"]);
                    flowLayoutPanel1.Controls.Add(productControl);
                }
            }
        }

        private Control CreateProductBox(string productId, string name, string description, string amount, decimal price, byte[] imageBytes)
        {
            var panel = new Panel { Size = new Size(210, 380), BorderStyle = BorderStyle.FixedSingle, ForeColor = Color.White, BackColor = Color.White };

            var nameLabel = new Label { Name = "nameLabel", Text = name, AutoSize = false,Size = new Size(180, 100), Font = new Font("K2D", 12, FontStyle.Bold), TextAlign = ContentAlignment.TopCenter, Dock = DockStyle.Top, ForeColor = Color.Black };

            var priceLabel = new Label { Name = "priceLabel", Font = new Font("K2D", 11), Text = $"฿ {price:N}", TextAlign = ContentAlignment.BottomRight, Dock = DockStyle.Bottom, ForeColor = Color.Black};

            var pictureBox = new PictureBox { Name = "pictureBox", Size = new Size(180, 240), SizeMode = PictureBoxSizeMode.StretchImage, Image = ByteArrayToImage(imageBytes) };

            //เพิ่ม Event สำหรับ Controls ภายใน Panel
            pictureBox.Click += (sender, e) => panel_Click(sender, e, productId, name, price);
            nameLabel.Click += (sender, e) => panel_Click(sender, e, productId, name, price);
            priceLabel.Click += (sender, e) => panel_Click(sender, e, productId, name, price);
            //วาง Control ภายใน Panel
            var layout = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown };
            layout.Controls.Add(pictureBox);
            layout.Controls.Add(nameLabel);
            layout.Controls.Add(priceLabel);

            panel.Controls.Add(layout); //เพิ่ม Layout ลงใน Panel(1)
            panel.Margin = new Padding(15);

            //เพิ่ม Event สำหรับการคลิกที่ Panel เพื่อเลือกสินค้า
            panel.Click += (sender, e) => panel_Click(sender, e, productId, name, price);

            return panel;
        }

        private void cfBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedProductId))
            {
                MessageBox.Show("โปรดเลือกสินค้าก่อนกดเพิ่มลงในตะกร้า");
                return;
            }

            // ตรวจสอบว่าค่าที่กรอกใน quantityText เป็นจำนวนที่ถูกต้องและมากกว่า 0
            if (!int.TryParse(quantityText.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("กรุณากรอกจำนวนที่ถูกต้อง");
                return;
            }

            // ตรวจสอบจำนวนในสต็อก
            int availableStock = GetAvailableStock(selectedProductId);
            if (quantity > availableStock)
            {
                MessageBox.Show($"จำนวนที่กรอก ({quantity}) มากกว่าจำนวนในสต็อก ({availableStock})");
                return;
            }

            AddToCart(selectedProductId, selectedProductName, selectedProductPrice, quantity);
        }

        // ฟังก์ชันเพื่อดึงจำนวนสินค้าที่มีในสต็อก
        private int GetAvailableStock(string productId)
        {
            using (MySqlConnection connection = DatabaseConnection())
            {
                string selectCommand = "SELECT amount FROM winestock WHERE ID = @ID";
                using (MySqlCommand command = new MySqlCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@ID", productId);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }



        private void refresh()
        {
            productNameLbl1.Text = "";
            countryLbl1.Text = "";
            costLbl1.Text = "";
            remainingLbl1.Text = "";
            selectedItemPicBox.Image = null;
            costTextBox.Text = "";
            quantityText.Text = "";
        }

        private void AddToCart(string productId, string productName, decimal price, int quantity)
        {
            using (MySqlConnection connection = DatabaseConnection())
            {
                connection.Open();
                // ตรวจสอบว่ามีสินค้าใน cartprehistory ไหม
                string checkExistingCommand = "SELECT quantity FROM cartprehistory WHERE ID = @ID";
                using (MySqlCommand checkCommand = new MySqlCommand(checkExistingCommand, connection))
                {
                    checkCommand.Parameters.AddWithValue("@ID", productId);
                    object existingQuantity = checkCommand.ExecuteScalar();

                    if (existingQuantity != null && existingQuantity != DBNull.Value)
                    {
                        //ถ้ามีสินค้าอยู่แล้ว ให้อัพเดตจำนวน
                        int currentQuantity = Convert.ToInt32(existingQuantity);
                        UpdateQuantityInCart(productId, currentQuantity + quantity);
                        refresh();

                    }
                    else
                    {
                        //ถ้าไม่มีสินค้า ให้เพิ่มใหม่
                        string insertCommand = "INSERT INTO cartprehistory (ID, items, cost, total, quantity) VALUES (@ID, @items, @cost, @total, @quantity)";
                        using (MySqlCommand command = new MySqlCommand(insertCommand, connection))
                        {
                            decimal total = price * quantity;

                            command.Parameters.AddWithValue("@ID", productId);
                            command.Parameters.AddWithValue("@items", productName);
                            command.Parameters.AddWithValue("@quantity", quantity);
                            command.Parameters.AddWithValue("@cost", price);
                            command.Parameters.AddWithValue("@total", total);
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show($"เพิ่มสินค้า {productName} จำนวน {quantity} ชิ้น ลงในตะกร้า");
                        refresh();

                    }
                }
            }
        }

        private void UpdateQuantityInCart(string productId, int newQuantity)
        {
            using (MySqlConnection connection = DatabaseConnection())
            {
                connection.Open();
                string updateCommand = "UPDATE cartprehistory SET quantity = @quantity WHERE ID = @ID";
                using (MySqlCommand command = new MySqlCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@quantity", newQuantity);
                    command.Parameters.AddWithValue("@ID", productId);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show($"อัพเดตจำนวนสินค้า {productId} เป็น {newQuantity} ชิ้น");
            }
        }

        //event หลักของหน้านี้
        private void panel_Click(object sender, EventArgs e, string id, string name, decimal price)
        {
            selectedProductId = id;
            selectedProductName = name;
            selectedProductPrice = price;

            MySqlConnection connection = DatabaseConnection();
            string selectCommand = "SELECT * FROM winestock WHERE ID = @id";

            using (MySqlCommand command = new MySqlCommand(selectCommand, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        byte[] imageBytes = (byte[])reader["PIC"];
                        string country = reader["country"].ToString();
                        string amount = reader["amount"].ToString();

                        // แสดงรูปภาพใน PictureBox
                        selectedItemPicBox.Image = ByteArrayToImage(imageBytes);

                        // แสดงชื่อสินค้า
                        productNameLbl1.Text = name;
                        productNameLbl1.AutoSize = false;
                        productNameLbl1.Width = 300;
                                               

                        // แสดงแหล่งที่มา
                        countryLbl1.Text = country;

                        // แสดงราคา
                        costLbl1.Text = $" {price:N} บาท";

                        // แสดงจำนวนคงเหลือ
                        remainingLbl1.Text = $" {amount} ชิ้น";

                        // แสดงราคาใน costTextBox
                        UpdateCostTextBox();
                    }
                }
            }
        }

        private void UpdateCostTextBox()
        {
            //รับค่าจำนวนสินค้าเอาไปคำนวณ
            //int quantity = (int)UpDownSelectedItem.Value;

            //รวมค่าเพื่อไปแสดงใน costTextBox
            decimal totalCost = selectedProductPrice; // * quantity

            costTextBox.Text = totalCost.ToString("N");
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (var ms = new System.IO.MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            //loginPage backhome = new loginPage();
            //backhome.Show();
            this.Visible = false;
            Application.Restart();
        }

        private void cartpBtn_Click(object sender, EventArgs e)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.Show();
            //this.Visible = false;
        }
        private void PanelVScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.AutoScrollPosition = new Point(0, e.NewValue);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hideBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void refBtn_Click_1(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
