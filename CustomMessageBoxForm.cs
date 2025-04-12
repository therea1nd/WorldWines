using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldWines
{
    public partial class CustomMessageBoxForm : Form
    {
        public CustomMessageBoxForm(string message)
        {
            InitializeComponent();
            //messageLabel.Text = message;
        }

        public void sorryBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
        }
    }
}

