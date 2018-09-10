using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace evd_test
{
    public partial class MainForm : Form
    {
        private FilterForm filterForm;

        public MainForm()
        {
            InitializeComponent(); 
            filterForm = new FilterForm();
        }

        private ToolTip tt = new ToolTip
        {
            InitialDelay = 0,
            ShowAlways = true,
            IsBalloon = true
        };

        private EvalueStorage firstFile;
        private EvalueStorage secondFile;

        private bool firstRun = true;
       
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
                if (TestCheck.Checked || StatCheck.Checked || GraphCheck.Checked)
                {
                    CollectDataButton.Enabled = true;
                }
                if (TestCheck.Checked && OutputFilename.Text == "")
                {
                    OutputFilename.Text = Path.GetDirectoryName(SecondFilename.Text) + "\\Test.csv";
                }              
                if (StatCheck.Checked && StatFilename.Text == "")
                {
                    StatFilename.Text = Path.GetDirectoryName(SecondFilename.Text) + "\\Statistik.csv";
                }              
                if (GraphCheck.Checked && GraphFilename.Text == "")
                {
                    GraphFilename.Text = Path.GetDirectoryName(SecondFilename.Text) + "\\Graph.csv";
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

        private int TaskStat(Statistic stat, List<StatisticProperty> statList)
        {
            if (StatCheck.Checked)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                List<string> stats = stat.BuildStatString(statList);
                File.WriteAllLines(StatFilename.Text, stats);

                sw.Stop();
                Console.WriteLine("Stat: {0}", sw.Elapsed);

                return 0;
            }
            return -1;
        }

        private int TaskGraph(List<StatisticProperty> statList)
        {
            if (GraphCheck.Checked)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                Graph graph = new Graph(statList);
                graph.FillGraph();
                File.WriteAllLines(GraphFilename.Text, graph.BuildOutputString());

                sw.Stop();
                Console.WriteLine("Graph: {0}", sw.Elapsed);

                return 0;
            }
            return -1;
        } 
        
        private async void BackgroundWorker_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            Task<int> firstFileTask;
            Task<int> secondFileTask;

            int error = 0;
            bool freshRun = true;

            if (!firstRun)
            {
                freshRun = freshRunCheck.Checked || 
                    // Even if it's just one file that changed,
                    // We still run fresh just in case.
                    firstFile.Filename != FirstFilename.Text ||
                    secondFile.Filename != SecondFilename.Text;
            }

            if (RadioBEC.Checked)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                firstFileTask = Task.Run(() =>
                    EvalueTest<EvalueBEC>.TryCollectData(
                        FirstFilename.Text, ref firstFile, 1, freshRun));

                secondFileTask = Task.Run(() =>
                    EvalueTest<EvalueBEC>.TryCollectData(
                        SecondFilename.Text, ref secondFile, 1, freshRun));

                error += await firstFileTask;
                error += await secondFileTask;

                sw.Stop();
                Console.WriteLine("Loading files: {0}", sw.Elapsed);

                //error += EvalueTest<EvalueBEC>.TryCollectData(FirstFilename.Text,
                //    ref firstFile, 1, freshRun);
                //error += EvalueTest<EvalueBEC>.TryCollectData(SecondFilename.Text,
                //    ref secondFile, 2, freshRun);
            }
            else if (RadioLSB.Checked)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                firstFileTask = Task.Run(() =>
                    EvalueTest<EvalueLSB>.TryCollectData(
                        FirstFilename.Text, ref firstFile, 1, freshRun));

                secondFileTask = Task.Run(() =>
                    EvalueTest<EvalueLSB>.TryCollectData(
                        SecondFilename.Text, ref secondFile, 1, freshRun));

                error += await firstFileTask;
                error += await secondFileTask;

                sw.Stop();
                Console.WriteLine("Loading files: {0}", sw.Elapsed);

                //error += EvalueTest<EvalueLSB>.TryCollectData(FirstFilename.Text,
                //    ref firstFile, 1, freshRun);
                //error += EvalueTest<EvalueLSB>.TryCollectData(SecondFilename.Text,
                //    ref secondFile, 2, freshRun);
            }

            if (error == 0)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                EvalueStorage filterSecondFile = 
                    filterForm.Filter.ApplyFilters(secondFile.Evalues);
                
                sw.Stop();
                Console.WriteLine("Filter file: {0}", sw.Elapsed);

                if (StatCheck.Checked || GraphCheck.Checked)
                {
                    sw = new Stopwatch();
                    sw.Start();

                    Statistic stat = new Statistic(firstFile, filterSecondFile);
                    List<StatisticProperty> statList = stat.BuildStats();
                    List<StatisticProperty> filteredStats =
                        filterForm.Filter.ApplyFilters(statList);

                    var statBuilder = Task.Run(() => TaskStat(stat, filteredStats));
                    var graphBuilder = Task.Run(() => TaskGraph(filteredStats));

                    // These two will be 0 on success and -1 if the stats or graph
                    // wasn't created. It does not really seem relevant to check for now.
                    int statRes = await statBuilder;
                    int graphRes = await graphBuilder;

                    sw.Stop();
                    Console.WriteLine("Stat and Graph: {0}", sw.Elapsed);
                }
                
                if (TestCheck.Checked)
                {
                    sw = new Stopwatch();
                    sw.Start();

                    string output = "Linjeantal fil 1;" + firstFile.Length() +
                        "\nLinjeantal fil 2;" + secondFile.Length() + "\n\n";

                    if (RadioLSB.Checked)
                    {
                        output += EvalueTest<EvalueLSB>.BuildOutputString(
                            firstFile, filterSecondFile);
                    }
                    else
                    {
                        output += EvalueTest<EvalueBEC>.BuildOutputString(
                            firstFile, filterSecondFile);
                    }
                    File.WriteAllText(OutputFilename.Text, output);
                    Process.Start(OutputFilename.Text);
                    
                    sw.Stop();
                    Console.WriteLine("Test fil: {0}", sw.Elapsed);
                }

                MessageBox.Show("Filen blev lavet", "File created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Invoke((MethodInvoker)delegate
            {
                FormPanel.Enabled = true;
                freshRunCheck.Visible = true;
            });

            firstRun = false;
        }
        
        // Checks if a file should be overridden
        private bool AllowOverride(string filename, bool isChecked, string type)
        {
            if (File.Exists(filename) && isChecked)
            { 
                DialogResult FileExistsResult = MessageBox.Show(type + " filen: " + filename + 
                    " findes allerede, vil du overskrive den?",
                    "Output file exists",MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                return (FileExistsResult == DialogResult.Yes);
            }

            return true;
        }

        private void CollectDataButton_Click(object sender, EventArgs e)
        {
            // If we are allowed to override any files checked, we can continue
            if (AllowOverride(OutputFilename.Text, TestCheck.Checked, "Test output")
                && AllowOverride(StatFilename.Text, StatCheck.Checked, "Statistik output")
                && AllowOverride(GraphFilename.Text, GraphCheck.Checked, "Graf"))
            {

                if (!BackgroundWorker.IsBusy)
                {
                    FormPanel.Enabled = false;
                    BackgroundWorker.RunWorkerAsync();
                }
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
            if (!TestCheck.Checked && !StatCheck.Checked && !GraphCheck.Checked)
            {
                CollectDataButton.Enabled = false;
            }
            else
            {
                if (File.Exists(FirstFilename.Text) &&
                    File.Exists(SecondFilename.Text))
                {
                    CollectDataButton.Enabled = true;
                }
            }
        }

        private void TestCheck_CheckedChanged(object sender, EventArgs e)
        {
            OutputFilenameButton.Enabled = TestCheck.Checked;
            OutputFilename.Enabled = TestCheck.Checked;

            if (File.Exists(SecondFilename.Text) && File.Exists(FirstFilename.Text) && OutputFilename.Text == "")
            {
                OutputFilename.Text = Path.GetDirectoryName(SecondFilename.Text) + "\\Test.csv";
            }
           
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

        private void GraphCheck_CheckedChanged(object sender, EventArgs e)
        {
            GraphFilenameButton.Enabled = GraphCheck.Checked;
            GraphFilename.Enabled = GraphCheck.Checked;

            if (File.Exists(SecondFilename.Text) && File.Exists(FirstFilename.Text) && GraphFilename.Text == "")
            {
                GraphFilename.Text = Path.GetDirectoryName(SecondFilename.Text) + "\\Graph.csv";
            }
            CheckChanged();
        }

        private void GraphPanel_MouseEnter(object sender, EventArgs e)
        {
            tt.Show(string.Empty, GraphFilenameButton);
            tt.Show("Tjek at begge input-filer eksisterer", GraphFilenameButton, 
                GraphFilenameButton.Width/3, GraphFilenameButton.Height * -2);
        }

        private void GraphPanel_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft();
        }

        private void GraphFilenameButton_Click(object sender, EventArgs e)
        {
            if (GraphFileDialog.ShowDialog() == DialogResult.OK)
            {
                GraphFilename.Text = GraphFileDialog.FileName;
            }
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            filterForm.ToggleStats(StatCheck.Checked || GraphCheck.Checked);
            filterForm.Show();
            filterForm.Focus();
        }
    }
}
