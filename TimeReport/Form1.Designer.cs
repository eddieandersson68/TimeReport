namespace TimeReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbxEmployee = new System.Windows.Forms.ComboBox();
            this.listbxDataFromDB = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cmbxProject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxWeek = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxWorkedHours = new System.Windows.Forms.TextBox();
            this.btnSubmitReport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSubmitReport);
            this.groupBox1.Controls.Add(this.tbxWorkedHours);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbxWeek);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbxProject);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbxEmployee);
            this.groupBox1.Controls.Add(this.listbxDataFromDB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblEmployee);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 601);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TimeRepport";
            // 
            // cmbxEmployee
            // 
            this.cmbxEmployee.FormattingEnabled = true;
            this.cmbxEmployee.Location = new System.Drawing.Point(29, 44);
            this.cmbxEmployee.Name = "cmbxEmployee";
            this.cmbxEmployee.Size = new System.Drawing.Size(262, 21);
            this.cmbxEmployee.TabIndex = 4;
            this.cmbxEmployee.SelectedIndexChanged += new System.EventHandler(this.cmbxEmployee_SelectedIndexChanged);
            // 
            // listbxDataFromDB
            // 
            this.listbxDataFromDB.FormattingEnabled = true;
            this.listbxDataFromDB.Location = new System.Drawing.Point(29, 222);
            this.listbxDataFromDB.Name = "listbxDataFromDB";
            this.listbxDataFromDB.Size = new System.Drawing.Size(551, 303);
            this.listbxDataFromDB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Worked hours for current selection";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(26, 28);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(53, 13);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "Employee";
            // 
            // cmbxProject
            // 
            this.cmbxProject.FormattingEnabled = true;
            this.cmbxProject.Location = new System.Drawing.Point(318, 44);
            this.cmbxProject.Name = "cmbxProject";
            this.cmbxProject.Size = new System.Drawing.Size(262, 21);
            this.cmbxProject.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(315, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Project";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Week";
            // 
            // cmbxWeek
            // 
            this.cmbxWeek.FormattingEnabled = true;
            this.cmbxWeek.Location = new System.Drawing.Point(29, 124);
            this.cmbxWeek.Name = "cmbxWeek";
            this.cmbxWeek.Size = new System.Drawing.Size(46, 21);
            this.cmbxWeek.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Worked Hours";
            // 
            // tbxWorkedHours
            // 
            this.tbxWorkedHours.Location = new System.Drawing.Point(29, 184);
            this.tbxWorkedHours.Name = "tbxWorkedHours";
            this.tbxWorkedHours.Size = new System.Drawing.Size(100, 20);
            this.tbxWorkedHours.TabIndex = 10;
            // 
            // btnSubmitReport
            // 
            this.btnSubmitReport.Location = new System.Drawing.Point(309, 561);
            this.btnSubmitReport.Name = "btnSubmitReport";
            this.btnSubmitReport.Size = new System.Drawing.Size(75, 23);
            this.btnSubmitReport.TabIndex = 11;
            this.btnSubmitReport.Text = "Submit Report";
            this.btnSubmitReport.UseVisualStyleBackColor = true;
            this.btnSubmitReport.Click += new System.EventHandler(this.btnSubmitReport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 628);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "TimeReport";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listbxDataFromDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbxEmployee;
        private System.Windows.Forms.Button btnSubmitReport;
        private System.Windows.Forms.TextBox tbxWorkedHours;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbxWeek;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbxProject;
        private System.Windows.Forms.Label label1;
    }
}

