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
    public partial class abtwPages : Form
    {
        public abtwPages()
        {
            InitializeComponent();
        }

        private void abtwPages_Load(object sender, EventArgs e)
        {

        }

        private void abwBtn_Click(object sender, EventArgs e)
        {
            welcomePage f5 = new welcomePage();
            f5.Show(); 
            Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            welcomePage f5 = new welcomePage();
            f5.Show();
            Visible = false;
        }
    }
}
