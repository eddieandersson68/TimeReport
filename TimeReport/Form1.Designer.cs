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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbxEmployee);
            this.groupBox1.Controls.Add(this.listbxDataFromDB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblEmployee);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 327);
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
            this.listbxDataFromDB.Location = new System.Drawing.Point(29, 90);
            this.listbxDataFromDB.Name = "listbxDataFromDB";
            this.listbxDataFromDB.Size = new System.Drawing.Size(784, 186);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 342);
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
    }
}

