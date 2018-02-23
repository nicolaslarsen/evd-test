namespace evd_test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.FirstFileButton = new System.Windows.Forms.Button();
            this.FirstFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SecondFilename = new System.Windows.Forms.TextBox();
            this.SecondFileButton = new System.Windows.Forms.Button();
            this.OutputFilename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OutputPanel = new System.Windows.Forms.Panel();
            this.OutputFilenameButton = new System.Windows.Forms.Button();
            this.CollectDataButton = new System.Windows.Forms.Button();
            this.FirstFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SecondFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OutputFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.CollectDataPanel = new System.Windows.Forms.Panel();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.FormPanel = new System.Windows.Forms.Panel();
            this.RadioBEC = new System.Windows.Forms.RadioButton();
            this.RadioLSB = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.OutputPanel.SuspendLayout();
            this.CollectDataPanel.SuspendLayout();
            this.FormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FirstFileButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.FirstFilename, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SecondFilename, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.SecondFileButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.OutputFilename, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.OutputPanel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.RadioBEC, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.RadioLSB, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.91667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.08333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(575, 338);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 14, 10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "E-værdi fil 2:";
            // 
            // FirstFileButton
            // 
            this.FirstFileButton.Location = new System.Drawing.Point(88, 8);
            this.FirstFileButton.Margin = new System.Windows.Forms.Padding(10, 8, 0, 0);
            this.FirstFileButton.Name = "FirstFileButton";
            this.FirstFileButton.Size = new System.Drawing.Size(66, 23);
            this.FirstFileButton.TabIndex = 1;
            this.FirstFileButton.Text = "Vælg fil";
            this.FirstFileButton.UseVisualStyleBackColor = true;
            this.FirstFileButton.Click += new System.EventHandler(this.FirstFileButton_Click);
            // 
            // FirstFilename
            // 
            this.FirstFilename.Location = new System.Drawing.Point(185, 10);
            this.FirstFilename.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.FirstFilename.Name = "FirstFilename";
            this.FirstFilename.Size = new System.Drawing.Size(353, 20);
            this.FirstFilename.TabIndex = 4;
            this.FirstFilename.TextChanged += new System.EventHandler(this.FirstFilename_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 14, 10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-værdi fil 1:";
            // 
            // SecondFilename
            // 
            this.SecondFilename.Location = new System.Drawing.Point(185, 50);
            this.SecondFilename.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.SecondFilename.Name = "SecondFilename";
            this.SecondFilename.Size = new System.Drawing.Size(353, 20);
            this.SecondFilename.TabIndex = 5;
            this.SecondFilename.TextChanged += new System.EventHandler(this.SecondFilename_TextChanged);
            // 
            // SecondFileButton
            // 
            this.SecondFileButton.Location = new System.Drawing.Point(88, 48);
            this.SecondFileButton.Margin = new System.Windows.Forms.Padding(10, 8, 0, 0);
            this.SecondFileButton.Name = "SecondFileButton";
            this.SecondFileButton.Size = new System.Drawing.Size(66, 23);
            this.SecondFileButton.TabIndex = 3;
            this.SecondFileButton.Text = "Vælg fil";
            this.SecondFileButton.UseVisualStyleBackColor = true;
            this.SecondFileButton.Click += new System.EventHandler(this.SecondFileButton_Click);
            // 
            // OutputFilename
            // 
            this.OutputFilename.Location = new System.Drawing.Point(185, 309);
            this.OutputFilename.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.OutputFilename.Name = "OutputFilename";
            this.OutputFilename.Size = new System.Drawing.Size(353, 20);
            this.OutputFilename.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 313);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 14, 10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Test output fil:";
            // 
            // OutputPanel
            // 
            this.OutputPanel.Controls.Add(this.OutputFilenameButton);
            this.OutputPanel.Location = new System.Drawing.Point(88, 309);
            this.OutputPanel.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.OutputPanel.Name = "OutputPanel";
            this.OutputPanel.Size = new System.Drawing.Size(65, 23);
            this.OutputPanel.TabIndex = 6;
            this.OutputPanel.MouseEnter += new System.EventHandler(this.OutputPanel_MouseEnter);
            this.OutputPanel.MouseLeave += new System.EventHandler(this.OutputPanel_MouseLeave);
            // 
            // OutputFilenameButton
            // 
            this.OutputFilenameButton.Enabled = false;
            this.OutputFilenameButton.Location = new System.Drawing.Point(-1, 0);
            this.OutputFilenameButton.Margin = new System.Windows.Forms.Padding(10, 8, 0, 0);
            this.OutputFilenameButton.Name = "OutputFilenameButton";
            this.OutputFilenameButton.Size = new System.Drawing.Size(66, 23);
            this.OutputFilenameButton.TabIndex = 3;
            this.OutputFilenameButton.Text = "Gem som";
            this.OutputFilenameButton.UseVisualStyleBackColor = true;
            this.OutputFilenameButton.Click += new System.EventHandler(this.OutputFilenameButton_Click);
            // 
            // CollectDataButton
            // 
            this.CollectDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CollectDataButton.Enabled = false;
            this.CollectDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CollectDataButton.Location = new System.Drawing.Point(-1, 0);
            this.CollectDataButton.Name = "CollectDataButton";
            this.CollectDataButton.Size = new System.Drawing.Size(142, 37);
            this.CollectDataButton.TabIndex = 1;
            this.CollectDataButton.Text = "Indsaml test data";
            this.CollectDataButton.UseVisualStyleBackColor = true;
            this.CollectDataButton.Click += new System.EventHandler(this.CollectDataButton_Click);
            // 
            // FirstFileDialog
            // 
            this.FirstFileDialog.Filter = "Comma-Separated Values (*.csv)|*.csv|Text files (*.txt)|*.txt";
            // 
            // SecondFileDialog
            // 
            this.SecondFileDialog.Filter = "Comma-Separated Values (*.csv)|*.csv|Text files (*.txt)|*.txt";
            // 
            // OutputFileDialog
            // 
            this.OutputFileDialog.DefaultExt = "csv";
            this.OutputFileDialog.FileName = "Test";
            // 
            // CollectDataPanel
            // 
            this.CollectDataPanel.Controls.Add(this.CollectDataButton);
            this.CollectDataPanel.Location = new System.Drawing.Point(433, 347);
            this.CollectDataPanel.Name = "CollectDataPanel";
            this.CollectDataPanel.Size = new System.Drawing.Size(141, 37);
            this.CollectDataPanel.TabIndex = 2;
            this.CollectDataPanel.MouseEnter += new System.EventHandler(this.CollectDataPanel_MouseEnter);
            this.CollectDataPanel.MouseLeave += new System.EventHandler(this.CollectDataPanel_MouseLeave);
            // 
            // BackgroundWorker
            // 
            this.BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            // 
            // FormPanel
            // 
            this.FormPanel.Controls.Add(this.tableLayoutPanel1);
            this.FormPanel.Controls.Add(this.CollectDataPanel);
            this.FormPanel.Location = new System.Drawing.Point(12, 12);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(580, 387);
            this.FormPanel.TabIndex = 3;
            // 
            // RadioBEC
            // 
            this.RadioBEC.AutoSize = true;
            this.RadioBEC.Location = new System.Drawing.Point(10, 93);
            this.RadioBEC.Margin = new System.Windows.Forms.Padding(10);
            this.RadioBEC.Name = "RadioBEC";
            this.RadioBEC.Size = new System.Drawing.Size(46, 17);
            this.RadioBEC.TabIndex = 7;
            this.RadioBEC.TabStop = true;
            this.RadioBEC.Text = "BEC";
            this.RadioBEC.UseVisualStyleBackColor = true;
            // 
            // RadioLSB
            // 
            this.RadioLSB.AutoSize = true;
            this.RadioLSB.Location = new System.Drawing.Point(88, 93);
            this.RadioLSB.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.RadioLSB.Name = "RadioLSB";
            this.RadioLSB.Size = new System.Drawing.Size(45, 17);
            this.RadioLSB.TabIndex = 8;
            this.RadioLSB.TabStop = true;
            this.RadioLSB.Text = "LSB";
            this.RadioLSB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 421);
            this.Controls.Add(this.FormPanel);
            this.Name = "Form1";
            this.Text = "e-værdi leverance test";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.OutputPanel.ResumeLayout(false);
            this.CollectDataPanel.ResumeLayout(false);
            this.FormPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FirstFileButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SecondFileButton;
        private System.Windows.Forms.OpenFileDialog FirstFileDialog;
        private System.Windows.Forms.OpenFileDialog SecondFileDialog;
        private System.Windows.Forms.TextBox FirstFilename;
        private System.Windows.Forms.TextBox SecondFilename;
        private System.Windows.Forms.Button CollectDataButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OutputFilename;
        private System.Windows.Forms.Button OutputFilenameButton;
        private System.Windows.Forms.SaveFileDialog OutputFileDialog;
        private System.Windows.Forms.Panel CollectDataPanel;
        private System.Windows.Forms.Panel OutputPanel;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private System.Windows.Forms.Panel FormPanel;
        private System.Windows.Forms.RadioButton RadioBEC;
        private System.Windows.Forms.RadioButton RadioLSB;
    }
}

