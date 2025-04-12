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
    public partial class firstAdminForm : Form
    {
        public firstAdminForm()
        {
            InitializeComponent();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            this.Close();
            history secondAdminForm = new history();
            secondAdminForm.Show();

        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            this.Close();
            adminstock stock = new adminstock();
            stock.Show();
        }
    }
}
