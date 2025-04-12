using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WorldWines
{
    public partial class resetpassform : Form
    {
        private string randomCode;
        private int maxWrongAttempts = 3;
        private int wrongAttempts = 0;
        public static string to;
        private void findusernameTextBox_TextChanged(object sender, EventArgs e) { }

        private void newpassTextBox_TextChanged(object sender, EventArgs e) { }

        private void confirmpassTextBox_TextChanged(object sender, EventArgs e) { }

        public resetpassform()
        {
            InitializeComponent();
        }

        public MySqlConnection databaseConnection()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=worldwine;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        private void SendOTPButton_Click(object sender, EventArgs e)
        {
            string usernameOrTelephone = findUsernameTextBox.Text;
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = rand.Next(999999).ToString("D6"); //เจนรหัส otp 6 หลัก

            from = "pongskorn10114b@gmail.com";
            pass = "ohpeouvcujynpfsz";
            messageBody = "รหัสยืนยันของคุณ จาก WorldWines คือ " + randomCode;

            MailMessage message = new MailMessage
            {
                From = new MailAddress(from),
                Subject = "ยืนยัน OTP ของท่าน no-reply",
                Body = messageBody,
                IsBodyHtml = true
            };

            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from, pass)
            };

            string attachmentPath = @"C:\Users\pongs\OneDrive\Desktop\WorldWine\Pic\pages\winesecret2per.webp";
            if (System.IO.File.Exists(attachmentPath))
            {
                Attachment attachment = new Attachment(attachmentPath);
                message.Attachments.Add(attachment);
            }
 
            MySqlConnection conn = databaseConnection();
            try
            {
                conn.Open();
                string query = "SELECT * FROM userstable WHERE Username = @usernameOrTelephone OR Telephone = @usernameOrTelephone";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usernameOrTelephone", usernameOrTelephone);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string userEmail = reader["Email"].ToString();
                        string userTelephone = reader["Telephone"].ToString();

                        if (!string.IsNullOrEmpty(userEmail))
                        {
                            message.To.Add(userEmail);
                            smtp.Send(message);
                            MessageBox.Show("OTP ถูกส่งไปที่ " + userEmail + ".", "OTP Sent", MessageBoxButtons.OK);
                        }
                        else if (!string.IsNullOrEmpty(userTelephone))
                        {
                            MessageBox.Show("OTP ถูกส่งไปที่ " + userTelephone + ".", "OTP Sent", MessageBoxButtons.OK);
                            // Code to send OTP via SMS should go here
                        }
                        else
                        {
                            MessageBox.Show("ไม่มีข้อมูลในฐานระบบ", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบชื่อผู้ใช้/ เบอร์โทรศัพท์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่พบชื่อผู้ใช้/ เบอร์โทรศัพท์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVerify.Text))
            {
                MessageBox.Show("กรุณายืนยัน OTP ก่อน", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (randomCode == txtVerify.Text)
            {
                string newPassword = newPasswordTextBox.Text;
                string confirmPassword = confirmPasswordTextBox.Text;

                if (newPassword == confirmPassword)
                {
                    newPasswordTextBox.Enabled = true;
                    confirmPasswordTextBox.Enabled = true;
                    confirmBtn.Enabled = true;
                }
                else
                {
                    MessageBox.Show("กรุณากรอกรหัสผ่านให้ตรงกัน.", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                wrongAttempts += 1;
                if (wrongAttempts >= maxWrongAttempts)
                {
                    MessageBox.Show("คุณใส่รหัส OTP ผิดเกินจำนวนที่กำหนด กรุณาขอรหัส OTP ใหม่", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVerify.Text = "";
                    randomCode = "";
                }
                else
                {
                    MessageBox.Show("โปรดกรอก OTP ให้ถูกต้อง\nกรุณาลองใหม่", "ผิดพลาด", MessageBoxButtons.OK);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                newPasswordTextBox.UseSystemPasswordChar = false;
                confirmPasswordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                newPasswordTextBox.UseSystemPasswordChar = true;
                confirmPasswordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            string newPassword = newPasswordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            if (newPassword == confirmPassword)
            {
                MySqlConnection conn = databaseConnection();
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE userstable SET password = @Password WHERE Username = @Username OR Telephone = @Telephone", conn);
                    cmd.Parameters.AddWithValue("@Password", newPassword);
                    cmd.Parameters.AddWithValue("@Username", findUsernameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Telephone", findUsernameTextBox.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("รหัสผ่านถูกเปลี่ยนเรียบร้อยแล้ว.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสผ่านให้ตรงกัน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
