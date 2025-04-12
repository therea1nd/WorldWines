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
    public partial class welcomePage : Form
    {
        public welcomePage()
        {
            InitializeComponent();
        }

        private void abwBtn_Click(object sender, EventArgs e)
        {
            promotion promotion = new promotion();
            promotion.Show();
        }


        private void bswBtn_Click(object sender, EventArgs e)
        {
            loginPage f9 = new loginPage();
            f9.Show();
            Visible = false;
        }
    }
}
