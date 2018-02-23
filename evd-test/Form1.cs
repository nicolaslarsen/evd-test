using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace evd_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private ToolTip tt;

        private void InputTextChanged()
        {
            if (File.Exists(SecondFilename.Text) && File.Exists(FirstFilename.Text))
            {
                CollectDataButton.Enabled = true;
                OutputFilenameButton.Enabled = true;
                if (OutputFilename.Text == "")
                {
                    OutputFilename.Text = Path.GetDirectoryName(SecondFilename.Text) + "\\Test.csv";
                }
            }
            else
            {
                CollectDataButton.Enabled = false;
                OutputFilenameButton.Enabled = false;
                if (OutputFilename.Text == "")
                {
                    OutputFilename.Text = "";
                }
            }
        }

        private void FirstFilename_TextChanged(object sender, EventArgs e)
        {
            InputTextChanged();
        }

        private void SecondFilename_TextChanged(object sender, EventArgs e)
        {
            InputTextChanged();
        }

        private void FirstFileButton_Click(object sender, EventArgs e)
        {
            if (FirstFileDialog.ShowDialog() == DialogResult.OK)
            {
                FirstFilename.Text = FirstFileDialog.FileName;
            }
        }

        private void SecondFileButton_Click(object sender, EventArgs e)
        {
            if (SecondFileDialog.ShowDialog() == DialogResult.OK)
            {
                SecondFilename.Text = SecondFileDialog.FileName;
            }
        }

        private void OutputFilenameButton_Click(object sender, EventArgs e)
        {
            if (OutputFileDialog.ShowDialog() == DialogResult.OK)
            {
                OutputFilename.Text = OutputFileDialog.FileName;
            }
        }

        private void OutputPanel_MouseEnter(object sender, EventArgs e)
        {
            tt = new ToolTip
            {
                InitialDelay = 0,
                ShowAlways = true,
                IsBalloon = true
            };
            tt.Show(string.Empty, OutputFilenameButton);
            tt.Show("Tjek at begge input-filer eksisterer", OutputFilenameButton, OutputFilenameButton.Width/3, OutputFilenameButton.Height * -2);
        }

        private void OutputPanel_MouseLeave(object sender, EventArgs e)
        {
            tt.Dispose();
        }
        
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<EvalueBEC> firstFile = new List<EvalueBEC>();
            List<EvalueBEC> secondFile = new List<EvalueBEC>();
            int error = 0;

            try
            {
                firstFile = EvalueTest<EvalueBEC>.CollectData(FirstFilename.Text);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Fil 1 er ikke i det korekte format", "File 1 format error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error += 1;
            }

            try
            {
                secondFile = EvalueTest<EvalueBEC>.CollectData(SecondFilename.Text);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Fil 2 er ikke i det korekte format", "File 2 format error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error += 2;
            }

            if (error < 1)
            {
                string output = EvalueTest<EvalueBEC>.BuildOutputString(firstFile, secondFile);

                File.WriteAllText(OutputFilename.Text, output);
                this.Invoke((MethodInvoker)delegate
                {
                    FormPanel.Enabled = true;
                });
                MessageBox.Show("Filen blev lavet", "File created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(OutputFilename.Text);
            }
        }

        private void CollectDataButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(OutputFilename.Text))
            { 
                DialogResult FileExistsResult = MessageBox.Show("Output filen: " + OutputFilename.Text + 
                    " findes allerede, vil du overskrive den?",
                    "Output file exists",MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (!(FileExistsResult == DialogResult.Yes))
                {
                    return;
                }
            }

            if (!BackgroundWorker.IsBusy)
            {
                FormPanel.Enabled = false;
                BackgroundWorker.RunWorkerAsync();
            }
        }


        private void CollectDataPanel_MouseEnter(object sender, EventArgs e)
        {
            tt = new ToolTip
            {
                InitialDelay = 0,
                ShowAlways = true,
                IsBalloon = true
            };
            tt.Show(string.Empty, CollectDataButton);
            tt.Show("Tjek at begge input-filer eksisterer", CollectDataButton, CollectDataButton.Width/3, CollectDataButton.Height * -1);
        }

        private void CollectDataPanel_MouseLeave(object sender, EventArgs e)
        {
            tt.Dispose();
        }
    }
}
