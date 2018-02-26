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
                if (!RadioBEC.Checked && !RadioLSB.Checked)
                {
                    // Just check filename, user has the option to change it anyway
                    if (Path.GetFileName(SecondFilename.Text).Substring(0,3) == "LSB")
                    {
                        RadioLSB.Checked = true;
                    }
                    // We assume BEC as the standard format (or at least I do)
                    else
                    {
                        RadioBEC.Checked = true;
                    }
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
            int error = 0;

            if (RadioBEC.Checked)
            {
                List<EvalueBEC> firstFile = new List<EvalueBEC>();
                List<EvalueBEC> secondFile = new List<EvalueBEC>();

                error += EvalueTest<EvalueBEC>.TryCollectData(FirstFilename.Text, ref firstFile, 1);
                error += EvalueTest<EvalueBEC>.TryCollectData(FirstFilename.Text, ref secondFile, 2);
                if (error == 0)
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
            if (RadioLSB.Checked)
            {
                List<EvalueLSB> firstFile = new List<EvalueLSB>();
                List<EvalueLSB> secondFile = new List<EvalueLSB>();

                error += EvalueTest<EvalueLSB>.TryCollectData(FirstFilename.Text, ref firstFile, 1);
                error += EvalueTest<EvalueLSB>.TryCollectData(FirstFilename.Text, ref secondFile, 2);
                if (error == 0)
                {
                    string output = EvalueTest<EvalueLSB>.BuildOutputString(firstFile, secondFile);
    
                    File.WriteAllText(OutputFilename.Text, output);
                    this.Invoke((MethodInvoker)delegate
                    {
                        FormPanel.Enabled = true;
                    });
                    MessageBox.Show("Filen blev lavet", "File created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(OutputFilename.Text);
                }
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
