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
        // TODO: FINISH GRAPH ON FORM
        private ToolTip tt = new ToolTip
        {
            InitialDelay = 0,
            ShowAlways = true,
            IsBalloon = true
        };
       
        private void MouseLeft()
        {
            tt.Dispose();
            // Reinit
            tt = new ToolTip
            {
                InitialDelay = 0,
                ShowAlways = true,
                IsBalloon = true
            };
        }

        private void InputTextChanged()
        {
            if (File.Exists(SecondFilename.Text) && File.Exists(FirstFilename.Text))
            {
                CollectDataButton.Enabled = true;
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
                    TestCheck.Checked = true;
                    if (StatCheck.Checked && StatFilename.Text == "")
                    {
                        StatFilename.Text = Path.GetDirectoryName(SecondFilename.Text) + "\\Statistik.csv";
                    }
                }
            }
            else
            {
                CollectDataButton.Enabled = false;
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
            tt.Show(string.Empty, OutputFilenameButton);
            tt.Show("Tjek at begge input-filer eksisterer", OutputFilenameButton, OutputFilenameButton.Width/3,
                OutputFilenameButton.Height * -2);
        }

        private void OutputPanel_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft();
        }
        
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int error = 0;

            if (RadioBEC.Checked)
            {
                List<EvalueBEC> firstFile = new List<EvalueBEC>();
                List<EvalueBEC> secondFile = new List<EvalueBEC>();
                StoreProperty<EvalueBEC> propStore = new StoreProperty<EvalueBEC>();

                error += EvalueTest<EvalueBEC>.TryCollectData(FirstFilename.Text, ref firstFile, 1, propStore);
                error += EvalueTest<EvalueBEC>.TryCollectData(SecondFilename.Text, ref secondFile, 2, propStore);

                if (error == 0)
                {
                    if (StatCheck.Checked)
                    {
                        Statistic<EvalueBEC> stat = new Statistic<EvalueBEC>(firstFile, secondFile, propStore);
                        List<string> stats = stat.BuildStats();

                        File.WriteAllLines(StatFilename.Text, stats);
                    }
                    if (TestCheck.Checked)

                    {
                        string output = EvalueTest<EvalueBEC>.BuildOutputString(firstFile, secondFile, propStore);

                        File.WriteAllText(OutputFilename.Text, output);
                        Process.Start(OutputFilename.Text);
                    }

                    MessageBox.Show("Filen blev lavet", "File created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (RadioLSB.Checked)
            {
                List<EvalueLSB> firstFile = new List<EvalueLSB>();
                List<EvalueLSB> secondFile = new List<EvalueLSB>();
                StoreProperty<EvalueLSB> propStore = new StoreProperty<EvalueLSB>();

                error += EvalueTest<EvalueLSB>.TryCollectData(FirstFilename.Text, ref firstFile, 1, propStore);
                error += EvalueTest<EvalueLSB>.TryCollectData(SecondFilename.Text, ref secondFile, 2, propStore);

                if (error == 0)
                {
                    if (StatCheck.Checked)
                    {
                        
                        Statistic<EvalueLSB> stat = new Statistic<EvalueLSB>(firstFile, secondFile, propStore);
                        List<string> stats = stat.BuildStats();

                        File.WriteAllLines(StatFilename.Text, stats);
                    }

                    if (TestCheck.Checked)
                    {
                        string output = EvalueTest<EvalueLSB>.BuildOutputString(firstFile, secondFile, propStore);

                        File.WriteAllText(OutputFilename.Text, output);
                        Process.Start(OutputFilename.Text);
                    }
                    
                    MessageBox.Show("Filen blev lavet", "File created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Invoke((MethodInvoker)delegate
            {
                FormPanel.Enabled = true;
            });

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
            
            if (File.Exists(StatFilename.Text))
            { 
                DialogResult FileExistsResult = MessageBox.Show("Statistik output filen: " + StatFilename.Text + 
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
            tt.Show(string.Empty, CollectDataButton);
            tt.Show("Tjek at begge input-filer eksisterer", CollectDataButton, 
                CollectDataButton.Width/3, CollectDataButton.Height * -1);
        }

        private void CollectDataPanel_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft();
        }

        private void CheckChanged()
        {
            if (!TestCheck.Checked && !StatCheck.Checked)
            {
                CollectDataButton.Enabled = false;
            }
            else
            {
                CollectDataButton.Enabled = true;
            }
        }

        private void TestCheck_CheckedChanged(object sender, EventArgs e)
        {
            OutputFilenameButton.Enabled = TestCheck.Checked;
            OutputFilename.Enabled = TestCheck.Checked;
            CheckChanged();
        }

        private void StatCheck_CheckedChanged(object sender, EventArgs e)
        {
            StatFilenameButton.Enabled = StatCheck.Checked;
            StatFilename.Enabled = StatCheck.Checked;

            if (File.Exists(SecondFilename.Text) && File.Exists(FirstFilename.Text) && StatFilename.Text == "")
            {
                StatFilename.Text = Path.GetDirectoryName(SecondFilename.Text) + "\\Statistik.csv";
            }
            CheckChanged();
        }

        private void StatFilePanel_MouseEnter(object sender, EventArgs e)
        {
            
            tt.Show(string.Empty, StatFilenameButton);
            tt.Show("Tjek at begge input-filer eksisterer", StatFilenameButton, 
                StatFilenameButton.Width/3, StatFilenameButton.Height * -2);
        }

        private void StatFilePanel_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft();
        }

        private void StatFilenameButton_Click(object sender, EventArgs e)
        {
            if (StatFileDialog.ShowDialog() == DialogResult.OK)
            {
                StatFilename.Text = StatFileDialog.FileName;
            }
        }
    }
}
