using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;



namespace WorldWines
{
    public partial class shop : Form
    {

        public DataTable itemList;
        MySqlConnection conn; // ประกาศตัวแปร conn เป็นตัวแปรที่สามารถเข้าถึงได้ทั่วไปในคลาส
        public shop()
        {
            InitializeComponent();
            conn = databaseConnection();
            DisplayData();
            dataGridView1.Columns["ID"].DataPropertyName = "ID";
            UpdateTotal();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=worldwine;Uid=root;Pwd=;";
            return new MySqlConnection(connectionString);
        }

        private void DisplayData()
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM winestock", conn))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DisplayData(dt);
                }
            }
        }

        private void DisplayData(DataTable dt)
        {
            dataGridView1.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Height = 150;

                DataGridViewImageCell imgCell = new DataGridViewImageCell();
                byte[] imageData = (byte[])row["pic"];
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    imgCell.Value = image;
                }
                imgCell.ImageLayout = DataGridViewImageCellLayout.Stretch;

                dataGridView1.Rows[rowIndex].Cells["customColumn1"].Value = row["Name"];
                dataGridView1.Rows[rowIndex].Cells["customColumn2"].Value = row["Alcohol"];
                dataGridView1.Rows[rowIndex].Cells["customColumn3"].Value = row["Country"];
                dataGridView1.Rows[rowIndex].Cells["customColumn4"].Value = row["Cost"];
                dataGridView1.Rows[rowIndex].Cells["customColumn5"] = imgCell;
                dataGridView1.Rows[rowIndex].Cells["customColumn6"].Value = row["description"];
                dataGridView1.Rows[rowIndex].Cells["customColumn7"].Value = row["amount"];
                dataGridView1.Rows[rowIndex].Cells["ID"].Value = row["ID"];
            }
        }


        private void cartBtn_Click(object sender, EventArgs e)//เข้าไปแก้ไขตะกร้า
        {

        }


        private void addBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("กรุณาเลือกรายการก่อนที่จะเพิ่มสินค้าลงในตะกร้า", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            int quantity = (int)numericUpDown.Value;
            string productId = selectedRow.Cells["ID"].Value.ToString();

            int currentCount = Convert.ToInt32(selectedRow.Cells["customColumn7"].Value);
            int newCount = currentCount - quantity;

            if (newCount < 0)
            {
                MessageBox.Show("ไม่สามารถลดจำนวนสินค้าได้เนื่องจากจำนวนในสต็อกไม่เพียงพอ", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal price = Convert.ToDecimal(selectedRow.Cells["customColumn4"].Value);
            decimal totalPrice = price * quantity;

            totalTextbox.Text = totalPrice.ToString();
            AddToCart(selectedRow);
            
            try
            {
                conn.Open();
                UpdateCount(productId, newCount);
                DisplayData();
                UpdateTotal();

                MessageBox.Show("เพิ่มสินค้าลงในตะกร้าเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void AddToCart(DataGridViewRow selectedRow)
        {
            decimal price = Convert.ToDecimal(selectedRow.Cells["customColumn4"].Value);
            int quantity = (int)numericUpDown.Value;
            decimal totalPrice = price * quantity;

            // ตรวจสอบว่ามี ID ซ้ำกันหรือไม่
            bool found = false;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                string existingID = row.Cells["columnID"].Value.ToString();
                string newID = selectedRow.Cells["ID"].Value.ToString();

                if (existingID.Equals(newID, StringComparison.OrdinalIgnoreCase))
                {
                    // พบ ID ซ้ำกัน ให้อัปเดตข้อมูลที่มีอยู่แล้ว
                    UpdateCartItem(row, quantity);
                    found = true;
                    break;
                }
            }

            // หากไม่พบ ID ที่ซ้ำกัน ให้ทำการเพิ่มแถวใหม่
            if (!found)
            {
                // เพิ่มแถวใหม่
                int index = dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Height = 150;

                // เพิ่มข้อมูลจาก dataGridView1 ไปยัง dataGridView2 ตาม column ที่ระบุ
                dataGridView2.Rows[index].Cells["columnID"].Value = selectedRow.Cells["ID"].Value;
                dataGridView2.Rows[index].Cells["columnName"].Value = selectedRow.Cells["customColumn1"].Value;
                dataGridView2.Rows[index].Cells["columnAmount"].Value = numericUpDown.Value;
                dataGridView2.Rows[index].Cells["columnCurCost"].Value = selectedRow.Cells["customColumn4"].Value;
                dataGridView2.Rows[index].Cells["columnAlcohol"].Value = selectedRow.Cells["customColumn2"].Value;
                dataGridView2.Rows[index].Cells["columnCost"].Value = totalPrice;
            }

            // เคลียร์ช่อง totalTextbox,NumericUD
            totalTextbox.Text = "";
            numericUpDown.Value = 0;
        }

        public void UpdateCartItem(DataGridViewRow existingRow, int quantityToAdd)
        {
            int currentQuantity = Convert.ToInt32(existingRow.Cells["columnAmount"].Value);
            int newQuantity = currentQuantity + quantityToAdd;

            // อัปเดตจำนวนสินค้า
            existingRow.Cells["columnAmount"].Value = newQuantity;

            // คำนวณราคารวมใหม่
            decimal unitPrice = Convert.ToDecimal(existingRow.Cells["columnCurCost"].Value);
            decimal totalPrice = unitPrice * newQuantity;
            existingRow.Cells["columnCost"].Value = totalPrice;
        }

        private void UpdateCount(string productId, int newCount)
        {
            string query = "UPDATE winestock SET amount = @amount WHERE ID = @ID";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@amount", newCount);
                cmd.Parameters.AddWithValue("@ID", productId);
                cmd.ExecuteNonQuery();
            }
        }

        private void totalTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(totalTextbox.Text) && decimal.TryParse(totalTextbox.Text, out decimal number))
            {
                totalTextbox.Text = number.ToString("#,##0.00");
                totalTextbox.SelectionStart = totalTextbox.Text.Length; // ให้เคอร์เซอร์อยู่ที่ตำแหน่งสุดท้าย
            }
        }
        private void backHomeBtn_Click(object sender, EventArgs e)
        {
            topForm1 t1 = new topForm1();
            t1.Show();
            this.Close();
        }
        // ให้ปรับตำแหน่งของปุ่มเมื่อเลื่อน


        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("กรุณาเลือกรายการก่อนที่จะเพิ่มจำนวน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int quantity = (int)numericUpDown.Value;
            decimal price = Convert.ToDecimal(selectedRow.Cells["customColumn4"].Value); // แก้ชื่อคอลัมน์ตามที่ใช้งานจริง
            decimal totalPrice = price * quantity;

            totalTextbox.Text = totalPrice.ToString();
        }

        public void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Check if the clicked cell is a blank cell or not
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ||
                    dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value ||
                    string.IsNullOrWhiteSpace(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    // Unbind the selected item
                    dataGridView2.ClearSelection();
                }
            }
            UpdateTotal();
        }


        public void payBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("กรุณาเพิ่มสินค้าลงในตะกร้าก่อนที่จะทำการชำระเงิน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
                return;
            }

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                string ID = row.Cells["columnID"].Value.ToString();
                string itemName = row.Cells["columnName"].Value.ToString();
                int quantity;
                if (!int.TryParse(row.Cells["columnAmount"].Value.ToString(), out quantity))
                {
                    MessageBox.Show("การแปลงข้อมูล quantity ล้มเหลว");
                    conn.Close();
                    return;
                }

                double unitCost;
                if (!double.TryParse(row.Cells["columnCurCost"].Value.ToString(), out unitCost))
                {
                    MessageBox.Show("การแปลงข้อมูล unitCost ล้มเหลว");
                    conn.Close();
                    return;
                }

                double totalCost;
                if (!double.TryParse(row.Cells["columnCost"].Value.ToString(), out totalCost))
                {
                    MessageBox.Show("การแปลงข้อมูล totalCost ล้มเหลว");
                    conn.Close();
                    return;
                }

                string query = "INSERT INTO carthistory (ID, items, quantity, cost, total, payment_date) VALUES (@ID, @Name, @quantity, @Cost, @total, NOW())";
                using (MySqlCommand cmdpay = new MySqlCommand(query, conn))
                {
                    cmdpay.Parameters.AddWithValue("@ID", ID);
                    cmdpay.Parameters.AddWithValue("@Name", itemName);
                    cmdpay.Parameters.AddWithValue("@quantity", quantity);
                    cmdpay.Parameters.AddWithValue("@Cost", unitCost);
                    cmdpay.Parameters.AddWithValue("@total", totalCost);

                    cmdpay.ExecuteNonQuery();
                }

                string query2 = "INSERT INTO cartprehistory (ID, items, quantity, cost, total) VALUES (@ID, @Name, @quantity, @Cost, @total)";
                using (MySqlCommand cmdpay2 = new MySqlCommand(query2, conn))
                {
                    cmdpay2.Parameters.AddWithValue("@ID", ID);
                    cmdpay2.Parameters.AddWithValue("@Name", itemName);
                    cmdpay2.Parameters.AddWithValue("@quantity", quantity);
                    cmdpay2.Parameters.AddWithValue("@Cost", unitCost);
                    cmdpay2.Parameters.AddWithValue("@total", totalCost);

                    cmdpay2.ExecuteNonQuery();
                }
            }

            conn.Close();
            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView2.Rows.Clear();
            total2.Clear();
            paymentform f19 = new paymentform();
            f19.ShowDialog();
        }

        private void AddCounttocart(string productId, int quantityToAdd)
        {
            string query = "UPDATE winestock SET amount = amount + @quantityToAdd WHERE ID = @ID";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@quantityToAdd", quantityToAdd);
                cmd.Parameters.AddWithValue("@ID", productId);
                cmd.ExecuteNonQuery();
            }
        }
        private void minusCountfromcart(string productId, int quantityToAdd)
        {
            string query = "UPDATE winestock SET amount = amount - @quantityToAdd WHERE ID = @ID";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@quantityToAdd", quantityToAdd);
                cmd.Parameters.AddWithValue("@ID", productId);
                cmd.ExecuteNonQuery();
            }
        }
        private void deleteBtn_Click (object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                string productId = selectedRow.Cells["columnID"].Value.ToString();
                int quantity = Convert.ToInt32(selectedRow.Cells["columnAmount"].Value);
                conn.Open();
                try
                {
                    AddCounttocart(productId, quantity); // คืนค่าจำนวนสินค้าในฐานข้อมูล
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    conn.Close();
                    return;
                }
                dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                //MessageBox.Show("ลบสินค้าออกจากตะกร้าเรียบร้อยแล้ว", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DisplayData();
                UpdateTotal();
            }
            if (dataGridView2.SelectedRows.Count < 0)
            {
                MessageBox.Show("กรุณาเลือกรายการก่อนที่จะลบสินค้าตะกร้าดิ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void decreaseBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                string productId = selectedRow.Cells["columnID"].Value.ToString();
                int currentQuantity = Convert.ToInt32(selectedRow.Cells["columnAmount"].Value);
                decimal unitCost = Convert.ToDecimal(selectedRow.Cells["columnCurCost"].Value);


                // ตรวจสอบว่าจำนวนสินค้าในตะกร้ามากกว่าหรือเท่ากับ 1 หรือไม่
                if (currentQuantity >= 1)
                {
                    // ลดจำนวนสินค้าในตะกร้าลง 1 หน่วย
                    int newQuantity = currentQuantity - 1;

                    // เพิ่มจำนวนสินค้าที่ถูกลดลงในฐานข้อมูล
                    conn.Open();
                    try
                    {
                        AddCounttocart(productId, 1); // เพิ่มจำนวนสินค้าในฐานข้อมูล
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        conn.Close();
                        return;
                    }
                
                    // อัปเดตจำนวนสินค้าใน dataGridView2
                    selectedRow.Cells["columnAmount"].Value = newQuantity;
                    decimal totalPrice = unitCost * newQuantity;
                    selectedRow.Cells["columnCost"].Value = totalPrice;

                    //MessageBox.Show("ลดจำนวนสินค้าในตะกร้าและคืนค่าให้กับฐานข้อมูลเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (newQuantity == 0)
                    {
                        dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                    }
                    // อัปเดตข้อมูลรวมในตะกร้า
                    DisplayData();
                    UpdateTotal();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถลดจำนวนสินค้าได้เพราะมีจำนวนสินค้าในตะกร้าเหลือ 0", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกรายการที่ต้องการลดจำนวนในตะกร้า", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void increaseBtn_Click(object sender, EventArgs e) 
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                string productId = selectedRow.Cells["columnID"].Value.ToString();
                int currentQuantity = Convert.ToInt32(selectedRow.Cells["columnAmount"].Value);
                // ตรวจสอบว่าจำนวนสินค้าในตะกร้ามากกว่าหรือเท่ากับ 1 หรือไม่
                if (currentQuantity >= 1)
                {
                    // ลดจำนวนสินค้าในตะกร้าลง 1 หน่วย
                    int newQuantity = currentQuantity + 1;

                    // เพิ่มจำนวนสินค้าที่ถูกลดลงในฐานข้อมูล
                    conn.Open();
                    try
                    {
                        minusCountfromcart(productId, 1); // เพิ่มจำนวนสินค้าในฐานข้อมูล
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        conn.Close();
                        return;
                    }

                    // อัปเดตจำนวนสินค้าใน dataGridView2
                    selectedRow.Cells["columnAmount"].Value = newQuantity;
                    decimal unitCost = Convert.ToDecimal(selectedRow.Cells["columnCurCost"].Value);
                    decimal totalPrice = unitCost * newQuantity;
                    selectedRow.Cells["columnCost"].Value = totalPrice;
                    // อัปเดตข้อมูลรวมในตะกร้า
                    DisplayData();
                    UpdateTotal();
                }
                else
                {
                    MessageBox.Show("สินค้าหมด", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกรายการที่ต้องการเพิ่มจำนวนในตะกร้า", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void UpdateTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                decimal price = Convert.ToDecimal(row.Cells["columnCost"].Value);
                total += price;
            }

            string cost = total.ToString();
            total2.Text = cost; // แสดงผลรวมใน TextBox
        }

        private void shop_Load(object sender, EventArgs e)
        {

        }

        private void total2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(total2.Text) && decimal.TryParse(total2.Text, out decimal number))
            {
                total2.Text = number.ToString("#,##0.00");
                total2.SelectionStart = total2.Text.Length; // ให้เคอร์เซอร์อยู่ที่ตำแหน่งสุดท้าย
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}