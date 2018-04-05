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
        public Filter<EvalueBEC> FilterBEC;
        public Filter<EvalueLSB> FilterLSB;

        public FilterForm()
        {
            InitializeComponent();
            FilterBEC = new Filter<EvalueBEC>();
            FilterLSB = new Filter<EvalueLSB>();
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
            if (FilterBEC.SetFilters(YearFrom.Text, YearTo.Text,
                YearIntervalCheck.Checked, KomNr.Text, EjdNr.Text,
                HandelsprisFrom.Text, HandelsprisTo.Text, ErIUdbud.Checked) == 0) {
                this.Hide();
            }
            else
            {
                MessageBox.Show("Der var en fejl i formatet på en af filtrene",
                    "Filter format error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
