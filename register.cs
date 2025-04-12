using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace WorldWines
{
    public partial class regisPage : Form
    {
        public MySqlConnection databaseConnection()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=worldwine;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public regisPage()
        {
            InitializeComponent();
        }

        public void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Name")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }
        public void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "Name";
                txtName.ForeColor = Color.Gray;
            }
        }
        public void txtLastName_Enter(object sender, EventArgs e)
        {
            if (txtLastName.Text == "Lastname")
            {
                txtLastName.Text = "";
                txtLastName.ForeColor = Color.Black;
            }
        }
        public void txtLastName_Leave(object sender, EventArgs e)
        {
            if (txtLastName.Text == "")
            {
                txtLastName.Text = "Lastame";
                txtLastName.ForeColor = Color.Gray;
            }
        }
        public void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }
        public void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }
        }
        public void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }
        public void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Gray;
            }
        }
        public void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "e-mail")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }
        public void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "E-mail";
                txtEmail.ForeColor = Color.Gray;
            }
        }
        public void txtTelophone_Enter(object sender, EventArgs e)
        {
            if (txtTelephone.Text == "0000000000")
            {
                txtTelephone.Text = "";
                txtTelephone.ForeColor = Color.Black;
            }
        }
        public void txtTelephone_Leave(object sender, EventArgs e)
        {
            if (txtTelephone.Text == "")
            {
                txtTelephone.Text = "0000000000";
                txtTelephone.ForeColor = Color.Gray;
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            try
            {
                conn.Open();

                // รับค่าจาก TextBox
                string name = txtName.Text;
                string lastname = txtLastName.Text;
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string email = txtEmail.Text;
                string telephone = txtTelephone.Text;

                // ตรวจสอบว่ามีข้อมูลที่ป้อนหรือไม่
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(telephone))
                {
                    MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ปรับตัวอักษรนำหน้าให้เป็นตัวใหญ่
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                name = textInfo.ToTitleCase(name.ToLower());
                lastname = textInfo.ToTitleCase(lastname.ToLower());

                // ตรวจสอบ username ซ้ำ
                MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM userstable WHERE username = @username", conn);
                checkCmd.Parameters.AddWithValue("@username", username);
                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (userCount > 0)
                {
                    MessageBox.Show("ชื่อผู้ใช้นี้ถูกใช้ไปแล้ว กรุณาใช้ชื่อผู้ใช้อื่น", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ตรวจสอบ email ซ้ำ
                MySqlCommand checkCmd1 = new MySqlCommand("SELECT COUNT(*) FROM userstable WHERE Email = @Email", conn);
                checkCmd1.Parameters.AddWithValue("@Email", email);
                int emailCount = Convert.ToInt32(checkCmd1.ExecuteScalar());

                if (emailCount > 0)
                {
                    MessageBox.Show("อีเมลนี้ถูกใช้ไปแล้ว กรุณาใช้อีเมลอื่น", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ตรวจสอบ telephone ซ้ำ
                MySqlCommand checkCmd2 = new MySqlCommand("SELECT COUNT(*) FROM userstable WHERE Telephone = @Telephone", conn);
                checkCmd2.Parameters.AddWithValue("@Telephone", telephone);
                int telCount = Convert.ToInt32(checkCmd2.ExecuteScalar());

                if (telCount > 0)
                {
                    MessageBox.Show("เบอร์โทรศัพท์นี้ถูกใช้ไปแล้ว กรุณาใช้หมายเลขโทรศัพท์อื่น", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ตรวจสอบว่าหมายเลขโทรศัพท์เป็นตัวเลข, 10 หลัก, และขึ้นต้นด้วย 0
                if (!telephone.All(char.IsDigit))
                {
                    MessageBox.Show("กรุณากรอกหมายเลขโทรศัพท์ที่เป็นตัวเลขเท่านั้น", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (telephone.Length != 10)
                {
                    MessageBox.Show("หมายเลขโทรศัพท์ต้องมี 10 หลัก", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (telephone[0] != '0')
                {
                    MessageBox.Show("หมายเลขโทรศัพท์ต้องขึ้นต้นด้วยเลข 0", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ถ้า username, email, tel ไม่ซ้ำ ให้ดำเนินการบันทึกข้อมูล
                MySqlCommand cmd = new MySqlCommand("INSERT INTO userstable (Name, Lastname, username, password, Email, Telephone) VALUES (@Name, @Lastname, @username, @password, @Email, @Telephone)", conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Lastname", lastname);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Telephone", telephone);

                cmd.ExecuteNonQuery();

                MessageBox.Show("สมัครสมาชิกสำเร็จ!", "สามารถปิดหน้าลงทะเบียนได้", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //
        }


        private void userCheckBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MySqlConnection conn = databaseConnection();

            try
            {
                conn.Open();
                string username = txtUsername.Text;

                // ตรวจสอบ username ซ้ำ
                MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM userstable WHERE username = @username", conn);
                checkCmd.Parameters.AddWithValue("@username", username);
                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (userCount > 0)
                {
                    MessageBox.Show("ชื่อผู้ใช้นี้ถูกใช้ไปแล้ว กรุณาใช้ชื่อผู้ใช้อื่น", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("ชื่อผู้ใช้นี้สามารถใช้ได้", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void emailCheckBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MySqlConnection conn = databaseConnection();

            try
            {
                conn.Open();
                string email = txtEmail.Text;

                // สร้างลิสต์ของโดเมนที่อนุญาต
                List<string> allowedDomains = new List<string> { "@gmail.com", "@email.com", "@หน่วยงาน.com", "@kkumail.com", "@hotmail.com", "@icloud.com" };

                // ตรวจสอบว่าที่อยู่อีเมลลงท้ายด้วยโดเมนที่อนุญาตหรือไม่
                bool isValidDomain = allowedDomains.Any(domain => email.EndsWith(domain));
                if (!isValidDomain)
                {
                    MessageBox.Show("กรุณาใช้ที่อยู่อีเมลที่ลงท้ายด้วยโดเมนที่อนุญาต (เช่น @gmail.com, @email.com, @icloud.com หรือ @kkumail.com)", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // ตรวจสอบ email ซ้ำในฐานข้อมูล
                MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM userstable WHERE Email = @Email", conn);
                checkCmd.Parameters.AddWithValue("@Email", email);
                int emailCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (emailCount > 0)
                {
                    MessageBox.Show("อีเมลนี้ถูกใช้ไปแล้ว กรุณาใช้อีเมลอื่น", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("อีเมลนี้สามารถใช้ได้ (กรุณาใช้ที่อยู่อีเมลจริง)", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


        private void telCheckBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MySqlConnection conn = databaseConnection();

            try
            {
                conn.Open();
                string telephone = txtTelephone.Text;

                if (!telephone.All(char.IsDigit))
                {
                    MessageBox.Show("กรุณากรอกหมายเลขโทรศัพท์ที่เป็นตัวเลขเท่านั้น", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (telephone.Length != 10)
                {
                    MessageBox.Show("หมายเลขโทรศัพท์ต้องมี 10 หลัก", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (telephone[0] != '0') 
                {
                    MessageBox.Show("หมายเลขโทรศัพท์ต้องขึ้นต้นด้วยเลข 0", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // ตรวจสอบ telephone ซ้ำ
                MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM userstable WHERE Telephone = @Telephone", conn);
                checkCmd.Parameters.AddWithValue("@Telephone", telephone);
                int telCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (telCount > 0)
                {
                    MessageBox.Show("หมายเลขโทรศัพท์นี้ถูกใช้ไปแล้ว กรุณาใช้หมายเลขโทรศัพท์อื่น", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("หมายเลขโทรศัพท์นี้สามารถใช้ได้", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}