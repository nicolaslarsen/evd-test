using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace evd_test
{
    public partial class FilterForm : Form
    {
        public Filter Filter;
        public FilterForm()
        {
            InitializeComponent();
        }

        private void YearIntervalCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (YearIntervalCheck.Checked)
            {
                YearTo.Enabled = true;
            }
            else
            {
                YearTo.Text = "";
                YearTo.Enabled = false;
            }
        }

        private void SaveFilterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
