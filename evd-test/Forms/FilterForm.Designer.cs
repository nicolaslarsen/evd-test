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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Årstal: ";
            // 
            // YearFrom
            // 
            this.YearFrom.Location = new System.Drawing.Point(70, 100);
            this.YearFrom.Name = "YearFrom";
            this.YearFrom.Size = new System.Drawing.Size(100, 20);
            this.YearFrom.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(519, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "OBS: Alt der efterlades tomt benyttes ikke i filtreringen (medmindre den specifik" +
    "t har et felt der kan krydses af)";
            // 
            // YearIntervalCheck
            // 
            this.YearIntervalCheck.AutoSize = true;
            this.YearIntervalCheck.Location = new System.Drawing.Point(70, 77);
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
            this.label3.Location = new System.Drawing.Point(39, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fra:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Til:";
            // 
            // YearTo
            // 
            this.YearTo.Enabled = false;
            this.YearTo.Location = new System.Drawing.Point(204, 100);
            this.YearTo.Name = "YearTo";
            this.YearTo.Size = new System.Drawing.Size(100, 20);
            this.YearTo.TabIndex = 6;
            // 
            // SaveFilterButton
            // 
            this.SaveFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveFilterButton.Location = new System.Drawing.Point(511, 474);
            this.SaveFilterButton.Name = "SaveFilterButton";
            this.SaveFilterButton.Size = new System.Drawing.Size(113, 51);
            this.SaveFilterButton.TabIndex = 7;
            this.SaveFilterButton.Text = "Gem";
            this.SaveFilterButton.UseVisualStyleBackColor = true;
            this.SaveFilterButton.Click += new System.EventHandler(this.SaveFilterButton_Click);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 537);
            this.ControlBox = false;
            this.Controls.Add(this.SaveFilterButton);
            this.Controls.Add(this.YearTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.YearIntervalCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.YearFrom);
            this.Controls.Add(this.label1);
            this.Name = "FilterForm";
            this.Text = "FilterForm";
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
    }
}