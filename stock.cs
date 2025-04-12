using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Xml.Linq;
using System.Runtime.Remoting.Contexts;
using System.Data.SqlClient;
using Guna.UI2.WinForms.Suite;
using Mysqlx.Crud;
using System.Collections;


namespace WorldWines
{
    public partial class adminstock : Form
    {


        MySqlConnection conn; // ประกาศตัวแปร conn เป็นตัวแปรที่สามารถเข้าถึงได้ทั่วไปในคลาส
        public MySqlConnection databaseConnection()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=worldwine;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public adminstock()
        {
            InitializeComponent();
            conn = databaseConnection(); // เรียกใช้ฟังก์ชัน databaseConnection() เพื่อสร้างการเชื่อมต่อและกำหนดให้ conn เป็นการเชื่อมต่อนั้น
            
            FillDGV(); // เรียกใช้ FillDGV เพื่อโหลดข้อมูลใน DataGridView ทันทีเมื่อ Form ถูกโหลดขึ้นมา

        }

        private void adminstock_Load(object sender, EventArgs e)
        {
            // ตรวจสอบว่ามีการเชื่อมต่อกับฐานข้อมูลหรือไม่
            if (conn.State != ConnectionState.Closed)
            {
                return;
            }
            conn.Open(); // เปิดการเชื่อมต่อฐานข้อมูล
        }
        public void ExecMyQuery(MySqlCommand mcomd, string myMsg)
        {
            try
            {
                int rowsAffected = mcomd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show(myMsg);
                }
                else
                {
                    MessageBox.Show("No rows affected.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Query Not Executed: " + ex.Message);

            }

            FillDGV();
        }
        public void FillDGV()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM winestock", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.Rows.Clear();

            
            // วนซ้ำแต่ละแถวใน datatable
            foreach (DataRow row in dt.Rows)
            {
                // เพิ่มแถว
                int rowIndex = dataGridView1.Rows.Add();

                // สร้างเซลของรูปภาพ
                DataGridViewImageCell imgCell = new DataGridViewImageCell();

                //ดึงข้อมูลภาพจากคอลัมน์ pic และแปลงเป็น Image
                Byte[] imageData = (Byte[])row["pic"];
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    imgCell.Value = image;
                    byte[] img = ms.ToArray();
                }

                imgCell.ImageLayout = DataGridViewImageCellLayout.Stretch;
                // ตั้งค่าเซลในคอลัมน์ CustomColumn5 เป็นรูปภาพ
                dataGridView1.Rows[rowIndex].Cells["customColumn5"] = imgCell;

                // ตั้งค่าอื่นๆ ในแถว
                dataGridView1.Rows[rowIndex].Cells["CustomColumn1"].Value = row["ID"];
                dataGridView1.Rows[rowIndex].Cells["CustomColumn2"].Value = row["Name"];
                dataGridView1.Rows[rowIndex].Cells["CustomColumn3"].Value = row["Cost"];
                dataGridView1.Rows[rowIndex].Cells["CustomColumn4"].Value = row["Alcohol"];
                dataGridView1.Rows[rowIndex].Cells["customColumn6"].Value = row["amount"];
            }
        }
        public void dataGridView1_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่ามีแถวที่ถูกเลือกหรือไม่
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                // ดึงข้อมูลจากแถวที่ถูกเลือกใน DataGridView
                string selectedID = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                // เรียกใช้เมธอดเพื่อแสดงข้อมูลใน TextBox, piuctureBox2 โดยใช้ ID ที่ได้จาก DataGridView
                DisplayDataInTextBox(selectedID);
                DisplayPicInpictureBox2(selectedID);
            }
        }
        //เปิดรูปจาก datagrid ไว้มาแสดงใน pictureBox2
        public void DisplayPicInpictureBox2(string selectedID) //อ่านข้อมูล
        {
            string query = "SELECT pic FROM winestock WHERE ID = @ID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", selectedID);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    // ดึงข้อมูลรูปภาพจากฐานข้อมูล
                    byte[] imageData = (byte[])reader["pic"];

                    if (imageData != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            // สร้างรูปภาพจาก MemoryStream และกำหนดให้ PictureBox แสดงรูปภาพนี้
                            pictureBox2.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        // ถ้าไม่มีรูปภาพในฐานข้อมูล ให้เซ็ตรูปภาพใน PictureBox เป็น null
                        pictureBox2.Image = null;
                    }
                }
                else
                {
                    // ถ้าไม่พบข้อมูลที่ตรงกับ selectedID ในฐานข้อมูล
                    // ให้เซ็ตรูปภาพใน PictureBox เป็น null
                    pictureBox2.Image = null;
                }
            }
        }

        //เปิดข้อมุลจาก datagrid ไว้มาแสดงใน textbox
        public void DisplayDataInTextBox(string selectedID)
        {

            string query = "SELECT * FROM winestock WHERE ID = @ID";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            //กำหนดค่า parameter ให้กับคำสั่ง SQL เพื่อค้นหาตาม ID
            cmd.Parameters.AddWithValue("@ID", selectedID);

            //สร้าง SqlDataReader เพื่ออ่านข้อมูลที่ได้จากการสั่ง SQL
            using (MySqlDataReader dataReader = cmd.ExecuteReader())
            {
                //วนลูปเพื่ออ่านข้อมูลและแสดงใน TextBox หรือที่ต้องการ
                while (dataReader.Read())
                {
                    idstockValuetxt.Text = dataReader["id_stock"].ToString();
                    txtId.Text = dataReader["ID"].ToString();
                    txtName.Text = dataReader["Name"].ToString();
                    txtAlco.Text = dataReader["Alcohol"].ToString();
                    txtBottle.Text = dataReader["bottlesize"].ToString();
                    txtCost.Text = dataReader["Cost"].ToString();
                    txtCountry.Text = dataReader["country"].ToString();
                    txtDescription.Text = dataReader["description"].ToString();
                    numericUpDown1.Value = Convert.ToInt32(dataReader["amount"]);
                    txtVintage.Text = dataReader["year"].ToString();
                }
            }
        }

        

        public void chPicBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

            opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif;";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(opf.FileName);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        public void addNewBtn_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่ามีรูปภาพที่ถูกโหลดเข้ามาหรือไม่
            if (pictureBox2.Image != null)
            {
                // แปลงรูปภาพให้เป็น byte array
                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                byte[] img = ms.ToArray();

                // สร้างคำสั่ง SQL เพื่อเพิ่มข้อมูลใหม่ลงในฐานข้อมูล
                MySqlCommand cmd = new MySqlCommand("INSERT INTO winestock(ID, Name, Cost, description, country, bottlesize, Alcohol, amount, year, pic) VALUES(@ID, @Name, @Cost, @description, @country, @bottlesize, @Alcohol, @Amount, @year, @pic)", conn);

                // เพิ่มข้อมูลในพารามิเตอร์
                cmd.Parameters.Add("@id_stock", MySqlDbType.VarChar).Value = idstockValuetxt.Text;
                cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = txtId.Text;
                cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtName.Text;
                cmd.Parameters.Add("@Cost", MySqlDbType.VarChar).Value = txtCost.Text;
                cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = txtDescription.Text;
                cmd.Parameters.Add("@country", MySqlDbType.VarChar).Value = txtCountry.Text;
                cmd.Parameters.Add("@bottlesize", MySqlDbType.VarChar).Value = txtBottle.Text;
                cmd.Parameters.Add("@Alcohol", MySqlDbType.VarChar).Value = txtAlco.Text;
                cmd.Parameters.Add("@Amount", MySqlDbType.Int32).Value = (int)numericUpDown1.Value;
                cmd.Parameters.Add("@year", MySqlDbType.VarChar).Value = txtVintage.Text;
                cmd.Parameters.Add("@pic", MySqlDbType.LongBlob).Value = img;

                // ทำการ execute คำสั่ง SQL
                ExecMyQuery(cmd, "Data Inserted");
            }
            else
            {
                // ถ้าไม่มีรูปภาพถูกโหลดเข้ามา ให้แจ้งเตือนให้ผู้ใช้โปรดเลือกรูปภาพ
                MessageBox.Show("Please select an image.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void updateDataBtn_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            byte[] img = ms.ToArray();
            // กำหนดคำสั่ง SQL UPDATE และระบุคอลัมน์ที่ต้องการปรับปรุง
            MySqlCommand cmd = new MySqlCommand("UPDATE winestock SET Name = @Name, Cost = @Cost, description = @description, country = @country, bottlesize = @bottlesize, Alcohol = @Alcohol, amount = @Amount, year = @year, pic = @pic WHERE id_stock = @id_stock", conn);

            // เพิ่มพารามิเตอร์และกำหนดค่าข้อมูล
            cmd.Parameters.Add("@id_stock", MySqlDbType.VarChar).Value = idstockValuetxt.Text;
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = txtId.Text;
            cmd.Parameters.Add("@Name", MySqlDbType.Text).Value = txtName.Text;
            cmd.Parameters.Add("@Cost", MySqlDbType.VarChar).Value = txtCost.Text;
            cmd.Parameters.Add("@description", MySqlDbType.Text).Value = txtDescription.Text;
            cmd.Parameters.Add("@country", MySqlDbType.VarChar).Value = txtCountry.Text;
            cmd.Parameters.Add("@bottlesize", MySqlDbType.Text).Value = txtBottle.Text;
            cmd.Parameters.Add("@Alcohol", MySqlDbType.Text).Value = txtAlco.Text;
            cmd.Parameters.Add("@Amount", MySqlDbType.Int32).Value = (int)numericUpDown1.Value;
            cmd.Parameters.Add("@year", MySqlDbType.Text).Value = txtVintage.Text;
            cmd.Parameters.Add("@pic", MySqlDbType.Blob).Value = img;

            // เรียกใช้เมธอด ExecMyQuery เพื่อ Execute SQL Command
            ExecMyQuery(cmd, "Data Updated");
        }

        public void delBtn_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM winestock WHERE id_stock = @id_stock", conn);

            cmd.Parameters.Add("@id_stock", MySqlDbType.VarChar).Value=idstockValuetxt.Text;

            ExecMyQuery(cmd, "Data Deleted");
        }

        private void clearFieldBtn_Click(object sender, EventArgs e)
        {
            idstockValuetxt.Text = "";
            txtId.Text = "";
            txtName.Text = "";
            txtCost.Text = "";
            txtDescription.Text = "";
            txtCountry.Text = "";
            txtBottle.Text = "";
            txtAlco.Text = "";
            txtVintage.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void idstockValuetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            loginPage backhome = new loginPage();
            backhome.Show();
            this.Visible = false;
        }

        private void historyBtn_Click(object sender, EventArgs e)
        {

        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // หากไม่ใช่ตัวเลขหรือ backspace ยกเลิกการป้อนข้อมูล
                e.Handled = true;
            }
        }

        private void txtBottle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // หากไม่ใช่ตัวเลขหรือ backspace ยกเลิกการป้อนข้อมูล
                e.Handled = true;
            }
        }
    }
}