using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WorldWines
{
    public partial class loginPage : Form
    {
        public static class Userinfo
        {
            public static string Name { get; set; }
            public static string Lastname { get; set; }
        }

        public loginPage()
        {
            InitializeComponent();
        }

        public MySqlConnection databaseConnection()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=worldwine;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public void loginBtn_Click(object sender, EventArgs e)
        {
            string username = txtInput.Text;
            string password = txtPass.Text;

            using (MySqlConnection conn = databaseConnection())
            {
                try
                {
                    conn.Open();

                    //เอาชื่อนามสกลุออกมา
                    string getUserQuery = "SELECT Name, Lastname FROM userstable WHERE (username = @user OR telephone = @user) AND password = @password";
                    MySqlCommand getUserCmd = new MySqlCommand(getUserQuery, conn);
                    getUserCmd.Parameters.AddWithValue("@user", username);
                    getUserCmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = getUserCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Userinfo.Name = reader["Name"].ToString();
                            Userinfo.Lastname = reader["Lastname"].ToString();
                        }
                    }
                    if (!string.IsNullOrEmpty(Userinfo.Name) && !string.IsNullOrEmpty(Userinfo.Lastname))
                    {
                        string createNewSession = "INSERT INTO usersession (Name, Lastname) VALUES (@Name, @Lastname)"; //เพิ่มเข้า usersession
                        MySqlCommand createSessionCmd = new MySqlCommand(createNewSession, conn);
                        createSessionCmd.Parameters.AddWithValue("@Name", Userinfo.Name);
                        createSessionCmd.Parameters.AddWithValue("@Lastname", Userinfo.Lastname);
                        createSessionCmd.ExecuteNonQuery();
                        MessageBox.Show($"ยินดีต้อนรับ คุณ {Userinfo.Name} {Userinfo.Lastname}", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Visible = false;

                        shopGUI sg = new shopGUI();
                        sg.Show();
                        this.Close();
                    }
                    else if (username == "moo" && password == "deng")
                    {
                        this.Visible = false;
                        firstAdminForm f10 = new firstAdminForm();
                        f10.ShowDialog();
                    }
                    else
                    {
                        CustomMessageBoxForm customM = new CustomMessageBoxForm("Who're you??");
                        customM.ShowDialog();
                        txtInput.Text = "";
                        txtPass.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBoxForm customM = new CustomMessageBoxForm("Wait a minute!!: " + ex.Message);
                    customM.ShowDialog();
                    txtInput.Text = "";
                    txtPass.Text = "";
                }
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            regisPage f6 = new regisPage(); //Form5
            f6.Show();
            Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //รีรหัสผ่าน
        {
            resetpassform form = new resetpassform();
            form.ShowDialog();
        }
        private void txtInput_Leave(object sender, EventArgs e)
        {

            if (txtInput.Text == "")
            {
                txtInput.Text = "Username/Telephone";
                txtInput.ForeColor = Color.Silver;
            }
        }

        private void txtInput_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                txtInput.Text = "";
                txtInput.ForeColor = Color.Black;
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }


    }

}




