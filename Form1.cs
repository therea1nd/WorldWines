using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WorldWines
{
    public partial class topForm1 : Form
    {
        public topForm1()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            welcomePage f2 = new welcomePage();
            f2.Show();
            Visible = false;
        }
    }
}
