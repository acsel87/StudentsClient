namespace Student_UI
{
    partial class Dashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.studentComboBox = new System.Windows.Forms.ComboBox();
            this.yearLabel = new System.Windows.Forms.Label();
            this.teacherComboBox = new System.Windows.Forms.ComboBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.teacherLabel = new System.Windows.Forms.Label();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.gradeDataGridView = new System.Windows.Forms.DataGridView();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addGradeButton = new System.Windows.Forms.Button();
            this.editGradeButton = new System.Windows.Forms.Button();
            this.rateButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.rateComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gradeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Student:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Class:";
            // 
            // studentComboBox
            // 
            this.studentComboBox.FormattingEnabled = true;
            this.studentComboBox.Location = new System.Drawing.Point(105, 37);
            this.studentComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.studentComboBox.Name = "studentComboBox";
            this.studentComboBox.Size = new System.Drawing.Size(365, 29);
            this.studentComboBox.TabIndex = 11;
            this.studentComboBox.SelectedValueChanged += new System.EventHandler(this.StudentComboBox_SelectedValueChanged);
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(496, 41);
            this.yearLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(27, 21);
            this.yearLabel.TabIndex = 12;
            this.yearLabel.Text = "1st";
            // 
            // teacherComboBox
            // 
            this.teacherComboBox.FormattingEnabled = true;
            this.teacherComboBox.Location = new System.Drawing.Point(105, 90);
            this.teacherComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.teacherComboBox.Name = "teacherComboBox";
            this.teacherComboBox.Size = new System.Drawing.Size(237, 29);
            this.teacherComboBox.TabIndex = 13;
            this.teacherComboBox.SelectedValueChanged += new System.EventHandler(this.TeacherComboBox_SelectedValueChanged);
            // 
            // userLabel
            // 
            this.userLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(784, 566);
            this.userLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(84, 21);
            this.userLabel.TabIndex = 14;
            this.userLabel.Text = "Alex Andru";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "Teacher:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 206);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "Rating:";
            // 
            // teacherLabel
            // 
            this.teacherLabel.AutoSize = true;
            this.teacherLabel.Location = new System.Drawing.Point(102, 169);
            this.teacherLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.teacherLabel.Name = "teacherLabel";
            this.teacherLabel.Size = new System.Drawing.Size(68, 21);
            this.teacherLabel.TabIndex = 18;
            this.teacherLabel.Text = "<name>";
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.Location = new System.Drawing.Point(101, 206);
            this.ratingLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(32, 21);
            this.ratingLabel.TabIndex = 19;
            this.ratingLabel.Text = "5/7";
            // 
            // gradeDataGridView
            // 
            this.gradeDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gradeDataGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gradeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gradeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Grade,
            this.Date,
            this.Notes});
            this.gradeDataGridView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.gradeDataGridView.Location = new System.Drawing.Point(259, 150);
            this.gradeDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gradeDataGridView.MultiSelect = false;
            this.gradeDataGridView.Name = "gradeDataGridView";
            this.gradeDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gradeDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gradeDataGridView.RowHeadersVisible = false;
            this.gradeDataGridView.RowHeadersWidth = 40;
            this.gradeDataGridView.Size = new System.Drawing.Size(590, 292);
            this.gradeDataGridView.TabIndex = 20;
            // 
            // Grade
            // 
            this.Grade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Grade.DefaultCellStyle = dataGridViewCellStyle1;
            this.Grade.FillWeight = 114.2132F;
            this.Grade.HeaderText = "Grade";
            this.Grade.MaxInputLength = 2;
            this.Grade.MinimumWidth = 50;
            this.Grade.Name = "Grade";
            this.Grade.ReadOnly = true;
            this.Grade.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Grade.Width = 193;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.NullValue = null;
            this.Date.DefaultCellStyle = dataGridViewCellStyle2;
            this.Date.FillWeight = 114.2132F;
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 100;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Date.Width = 194;
            // 
            // Notes
            // 
            this.Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Notes.FillWeight = 71.5736F;
            this.Notes.HeaderText = "Notes";
            this.Notes.MinimumWidth = 200;
            this.Notes.Name = "Notes";
            this.Notes.ReadOnly = true;
            this.Notes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // addGradeButton
            // 
            this.addGradeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addGradeButton.Location = new System.Drawing.Point(259, 462);
            this.addGradeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addGradeButton.Name = "addGradeButton";
            this.addGradeButton.Size = new System.Drawing.Size(114, 37);
            this.addGradeButton.TabIndex = 21;
            this.addGradeButton.Text = "Add Grade";
            this.addGradeButton.UseVisualStyleBackColor = true;
            // 
            // editGradeButton
            // 
            this.editGradeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editGradeButton.Location = new System.Drawing.Point(735, 462);
            this.editGradeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editGradeButton.Name = "editGradeButton";
            this.editGradeButton.Size = new System.Drawing.Size(114, 37);
            this.editGradeButton.TabIndex = 22;
            this.editGradeButton.Text = "Edit Grade";
            this.editGradeButton.UseVisualStyleBackColor = true;
            // 
            // rateButton
            // 
            this.rateButton.Location = new System.Drawing.Point(23, 251);
            this.rateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rateButton.Name = "rateButton";
            this.rateButton.Size = new System.Drawing.Size(114, 37);
            this.rateButton.TabIndex = 23;
            this.rateButton.Text = "Rate Teacher";
            this.rateButton.UseVisualStyleBackColor = true;
            this.rateButton.Click += new System.EventHandler(this.RateButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(196, 255);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 30);
            this.label6.TabIndex = 25;
            this.label6.Text = "/ 7";
            // 
            // rateComboBox
            // 
            this.rateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rateComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rateComboBox.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rateComboBox.FormatString = "N0";
            this.rateComboBox.FormattingEnabled = true;
            this.rateComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.rateComboBox.Location = new System.Drawing.Point(145, 254);
            this.rateComboBox.Name = "rateComboBox";
            this.rateComboBox.Size = new System.Drawing.Size(45, 33);
            this.rateComboBox.Sorted = true;
            this.rateComboBox.TabIndex = 27;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 601);
            this.Controls.Add(this.rateComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rateButton);
            this.Controls.Add(this.editGradeButton);
            this.Controls.Add(this.addGradeButton);
            this.Controls.Add(this.gradeDataGridView);
            this.Controls.Add(this.ratingLabel);
            this.Controls.Add(this.teacherLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.teacherComboBox);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.studentComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(900, 640);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox studentComboBox;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.ComboBox teacherComboBox;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label teacherLabel;
        private System.Windows.Forms.Label ratingLabel;
        private System.Windows.Forms.DataGridView gradeDataGridView;
        private System.Windows.Forms.Button addGradeButton;
        private System.Windows.Forms.Button editGradeButton;
        private System.Windows.Forms.Button rateButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.ComboBox rateComboBox;
    }
}

