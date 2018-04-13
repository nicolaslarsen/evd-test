namespace evd_test
{
    partial class FilterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.YearFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.YearIntervalCheck = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.YearTo = new System.Windows.Forms.TextBox();
            this.SaveFilterButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.KomNr = new System.Windows.Forms.TextBox();
            this.EjdNr = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.HandelsprisTo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.HandelsprisFrom = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ErIUdbud = new System.Windows.Forms.CheckBox();
            this.CancButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.EvalueCompHandelsprisTo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.EvalueCompHandelsprisFrom = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.EvalueTo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.EvalueFrom = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.EvalueNewCompOldTo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.EvalueNewCompOldFrom = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Handelsdato:";
            // 
            // YearFrom
            // 
            this.YearFrom.Location = new System.Drawing.Point(46, 100);
            this.YearFrom.Name = "YearFrom";
            this.YearFrom.Size = new System.Drawing.Size(100, 20);
            this.YearFrom.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(525, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "OBS: Alt der efterlades tomt benyttes ikke i filtreringen (medmindre den specifik" +
    "t har et felt der kan krydses af). ";
            // 
            // YearIntervalCheck
            // 
            this.YearIntervalCheck.AutoSize = true;
            this.YearIntervalCheck.Location = new System.Drawing.Point(109, 77);
            this.YearIntervalCheck.Name = "YearIntervalCheck";
            this.YearIntervalCheck.Size = new System.Drawing.Size(61, 17);
            this.YearIntervalCheck.TabIndex = 3;
            this.YearIntervalCheck.Text = "Interval";
            this.YearIntervalCheck.UseVisualStyleBackColor = true;
            this.YearIntervalCheck.CheckedChanged += new System.EventHandler(this.YearIntervalCheck_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fra:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Til:";
            // 
            // YearTo
            // 
            this.YearTo.Enabled = false;
            this.YearTo.Location = new System.Drawing.Point(179, 100);
            this.YearTo.Name = "YearTo";
            this.YearTo.Size = new System.Drawing.Size(100, 20);
            this.YearTo.TabIndex = 6;
            // 
            // SaveFilterButton
            // 
            this.SaveFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveFilterButton.Location = new System.Drawing.Point(511, 433);
            this.SaveFilterButton.Name = "SaveFilterButton";
            this.SaveFilterButton.Size = new System.Drawing.Size(113, 51);
            this.SaveFilterButton.TabIndex = 7;
            this.SaveFilterButton.Text = "Gem";
            this.SaveFilterButton.UseVisualStyleBackColor = true;
            this.SaveFilterButton.Click += new System.EventHandler(this.SaveFilterButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kommune Nr:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ejendoms Nr:";
            // 
            // KomNr
            // 
            this.KomNr.Location = new System.Drawing.Point(3, 24);
            this.KomNr.Name = "KomNr";
            this.KomNr.Size = new System.Drawing.Size(100, 20);
            this.KomNr.TabIndex = 10;
            // 
            // EjdNr
            // 
            this.EjdNr.Location = new System.Drawing.Point(118, 24);
            this.EjdNr.Name = "EjdNr";
            this.EjdNr.Size = new System.Drawing.Size(100, 20);
            this.EjdNr.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.KomNr, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.EjdNr, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(371, 77);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(231, 54);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // HandelsprisTo
            // 
            this.HandelsprisTo.Location = new System.Drawing.Point(179, 173);
            this.HandelsprisTo.Name = "HandelsprisTo";
            this.HandelsprisTo.Size = new System.Drawing.Size(100, 20);
            this.HandelsprisTo.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Til:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Fra:";
            // 
            // HandelsprisFrom
            // 
            this.HandelsprisFrom.Location = new System.Drawing.Point(46, 173);
            this.HandelsprisFrom.Name = "HandelsprisFrom";
            this.HandelsprisFrom.Size = new System.Drawing.Size(100, 20);
            this.HandelsprisFrom.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Handelspris:";
            // 
            // ErIUdbud
            // 
            this.ErIUdbud.AutoSize = true;
            this.ErIUdbud.Location = new System.Drawing.Point(372, 176);
            this.ErIUdbud.Name = "ErIUdbud";
            this.ErIUdbud.Size = new System.Drawing.Size(140, 17);
            this.ErIUdbud.TabIndex = 19;
            this.ErIUdbud.Text = "Kun ejendomme i udbud";
            this.ErIUdbud.UseVisualStyleBackColor = true;
            // 
            // CancButton
            // 
            this.CancButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancButton.Location = new System.Drawing.Point(383, 433);
            this.CancButton.Name = "CancButton";
            this.CancButton.Size = new System.Drawing.Size(113, 51);
            this.CancButton.TabIndex = 20;
            this.CancButton.Text = "Annuller";
            this.CancButton.UseVisualStyleBackColor = true;
            this.CancButton.Click += new System.EventHandler(this.CancButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.Location = new System.Drawing.Point(18, 433);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(113, 51);
            this.ClearButton.TabIndex = 21;
            this.ClearButton.Text = "Ryd filtre";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(214, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Filtering foregår i øvrigt ud fra den nyeste fil. ";
            // 
            // EvalueCompHandelsprisTo
            // 
            this.EvalueCompHandelsprisTo.Location = new System.Drawing.Point(179, 352);
            this.EvalueCompHandelsprisTo.Name = "EvalueCompHandelsprisTo";
            this.EvalueCompHandelsprisTo.Size = new System.Drawing.Size(81, 20);
            this.EvalueCompHandelsprisTo.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(152, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Til:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 355);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Fra:";
            // 
            // EvalueCompHandelsprisFrom
            // 
            this.EvalueCompHandelsprisFrom.Location = new System.Drawing.Point(46, 352);
            this.EvalueCompHandelsprisFrom.Name = "EvalueCompHandelsprisFrom";
            this.EvalueCompHandelsprisFrom.Size = new System.Drawing.Size(81, 20);
            this.EvalueCompHandelsprisFrom.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 328);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(265, 17);
            this.label13.TabIndex = 29;
            this.label13.Text = "Ændring handelspris i forhold til e-værdi:";
            // 
            // EvalueTo
            // 
            this.EvalueTo.Location = new System.Drawing.Point(179, 240);
            this.EvalueTo.Name = "EvalueTo";
            this.EvalueTo.Size = new System.Drawing.Size(100, 20);
            this.EvalueTo.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(152, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Til:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 243);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(25, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Fra:";
            // 
            // EvalueFrom
            // 
            this.EvalueFrom.Location = new System.Drawing.Point(46, 240);
            this.EvalueFrom.Name = "EvalueFrom";
            this.EvalueFrom.Size = new System.Drawing.Size(100, 20);
            this.EvalueFrom.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 17);
            this.label16.TabIndex = 23;
            this.label16.Text = "E-værdi:";
            // 
            // EvalueNewCompOldTo
            // 
            this.EvalueNewCompOldTo.Location = new System.Drawing.Point(510, 352);
            this.EvalueNewCompOldTo.Name = "EvalueNewCompOldTo";
            this.EvalueNewCompOldTo.Size = new System.Drawing.Size(81, 20);
            this.EvalueNewCompOldTo.TabIndex = 38;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(483, 355);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 13);
            this.label17.TabIndex = 37;
            this.label17.Text = "Til:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(346, 355);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 13);
            this.label18.TabIndex = 36;
            this.label18.Text = "Fra:";
            // 
            // EvalueNewCompOldFrom
            // 
            this.EvalueNewCompOldFrom.Location = new System.Drawing.Point(377, 352);
            this.EvalueNewCompOldFrom.Name = "EvalueNewCompOldFrom";
            this.EvalueNewCompOldFrom.Size = new System.Drawing.Size(81, 20);
            this.EvalueNewCompOldFrom.TabIndex = 35;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(343, 328);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(227, 17);
            this.label19.TabIndex = 34;
            this.label19.Text = "Ændring E-værdi fil 1 i forhold til 2:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(12, 299);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(110, 17);
            this.label20.TabIndex = 39;
            this.label20.Text = "Statistik og graf:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(126, 352);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(20, 20);
            this.textBox1.TabIndex = 40;
            this.textBox1.Text = "%";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(259, 352);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(20, 20);
            this.textBox2.TabIndex = 41;
            this.textBox2.Text = "%";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(457, 352);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(20, 20);
            this.textBox3.TabIndex = 42;
            this.textBox3.Text = "%";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(590, 352);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(20, 20);
            this.textBox4.TabIndex = 43;
            this.textBox4.Text = "%";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 505);
            this.ControlBox = false;
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.EvalueNewCompOldTo);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.EvalueNewCompOldFrom);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.EvalueCompHandelsprisTo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.EvalueCompHandelsprisFrom);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.EvalueTo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.EvalueFrom);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.CancButton);
            this.Controls.Add(this.ErIUdbud);
            this.Controls.Add(this.HandelsprisTo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.HandelsprisFrom);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.SaveFilterButton);
            this.Controls.Add(this.YearTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.YearIntervalCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.YearFrom);
            this.Controls.Add(this.label1);
            this.Name = "FilterForm";
            this.Text = "Filtre";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox YearFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox YearIntervalCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox YearTo;
        private System.Windows.Forms.Button SaveFilterButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox KomNr;
        private System.Windows.Forms.TextBox EjdNr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox HandelsprisTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox HandelsprisFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ErIUdbud;
        private System.Windows.Forms.Button CancButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox EvalueCompHandelsprisTo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox EvalueCompHandelsprisFrom;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox EvalueTo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox EvalueFrom;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox EvalueNewCompOldTo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox EvalueNewCompOldFrom;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}