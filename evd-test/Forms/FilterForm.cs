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
        // Storing the old filter just seems easier.
        public Filter Filter;
        public Filter OldFilter;

        public FilterForm()
        {
            InitializeComponent();
            Filter = new Filter();
            OldFilter = new Filter();
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
            if (Filter.SetFilters(YearFrom.Text, YearTo.Text,
                YearIntervalCheck.Checked, KomNr.Text, EjdNr.Text,
                HandelsprisFrom.Text, HandelsprisTo.Text, ErIUdbud.Checked) == 0) {

                OldFilter = Filter;

                this.Hide();
            }
            else
            {
                MessageBox.Show("Der var en fejl i formatet på en af filtrene",
                    "Filter format error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Just to make the CancButton_Click function a little shorter.
        // Number is the Filter attribute, nullValue is whatever is its default value.
        private string BuildFormString(TextBox textBox, object value, object nullValue)
        {
            if (value.Equals(nullValue))
            {
                return textBox.Text = "";
            }

            return textBox.Text = "" + value;
        }

        private void SetForm(Filter useFilter)
        {
            BuildFormString(YearFrom, useFilter.YearFrom, 0);
            BuildFormString(YearTo, useFilter.YearTo, 0);
            YearIntervalCheck.Checked = useFilter.YearChecked;
            BuildFormString(KomNr, useFilter.KomNr, 0);
            BuildFormString(EjdNr, useFilter.EjdNr, 0);
            BuildFormString(HandelsprisFrom, useFilter.HandelsprisFrom, (long) -1);
            BuildFormString(HandelsprisTo, useFilter.HandelsprisTo, (long) -1);
            ErIUdbud.Checked = useFilter.ErIUdbud;
        }

        private void CancButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SetForm(OldFilter);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            // Reset filter before resetting form
            Filter = new Filter();
            SetForm(Filter);
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
