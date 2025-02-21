namespace PresentationLayer.Views
{
    partial class Employee_Dashboard
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
            label1 = new Label();
            label3 = new Label();
            EmployeeDashboard_Attendance_TimeInButton = new Button();
            EmployeeDashboard_Attendance_TimeOutButton = new Button();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            EmployeeDashboard_AttendanceLog_Date = new DataGridViewTextBoxColumn();
            EmployeeDashboard_AttendanceLog_TimeOut = new DataGridViewTextBoxColumn();
            EmployeeDashboard_AttendanceLog_TimeIn = new DataGridViewTextBoxColumn();
            EmployeeDashboard_AttendanceLog_TotalHours = new DataGridViewTextBoxColumn();
            EmployeeDashboard_AttendanceLog_Status = new DataGridViewTextBoxColumn();
            textBox5 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(24, 9);
            label1.Name = "label1";
            label1.Size = new Size(167, 57);
            label1.TabIndex = 0;
            label1.Text = "Upcoming";
            // 
            // label3
            // 
            label3.Location = new Point(389, 9);
            label3.Name = "label3";
            label3.Size = new Size(169, 57);
            label3.TabIndex = 2;
            label3.Text = "Attendance";
            // 
            // EmployeeDashboard_Attendance_TimeInButton
            // 
            EmployeeDashboard_Attendance_TimeInButton.Location = new Point(389, 30);
            EmployeeDashboard_Attendance_TimeInButton.Name = "EmployeeDashboard_Attendance_TimeInButton";
            EmployeeDashboard_Attendance_TimeInButton.Size = new Size(75, 23);
            EmployeeDashboard_Attendance_TimeInButton.TabIndex = 3;
            EmployeeDashboard_Attendance_TimeInButton.Text = "Time in";
            EmployeeDashboard_Attendance_TimeInButton.UseVisualStyleBackColor = true;
            // 
            // EmployeeDashboard_Attendance_TimeOutButton
            // 
            EmployeeDashboard_Attendance_TimeOutButton.Location = new Point(470, 30);
            EmployeeDashboard_Attendance_TimeOutButton.Name = "EmployeeDashboard_Attendance_TimeOutButton";
            EmployeeDashboard_Attendance_TimeOutButton.Size = new Size(75, 23);
            EmployeeDashboard_Attendance_TimeOutButton.TabIndex = 4;
            EmployeeDashboard_Attendance_TimeOutButton.Text = "Time out";
            EmployeeDashboard_Attendance_TimeOutButton.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(24, 28);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(147, 23);
            dateTimePicker1.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(24, 96);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 56);
            textBox1.TabIndex = 6;
            textBox1.Text = "Total Salary";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(24, 158);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(151, 56);
            textBox2.TabIndex = 7;
            textBox2.Text = "Allowance";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 78);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 8;
            label4.Text = "Summary";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(24, 220);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(151, 56);
            textBox3.TabIndex = 9;
            textBox3.Text = "Bonuses";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(24, 282);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(151, 56);
            textBox4.TabIndex = 9;
            textBox4.Text = "Deductions";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { EmployeeDashboard_AttendanceLog_Date, EmployeeDashboard_AttendanceLog_TimeOut, EmployeeDashboard_AttendanceLog_TimeIn, EmployeeDashboard_AttendanceLog_TotalHours, EmployeeDashboard_AttendanceLog_Status });
            dataGridView1.Location = new Point(195, 96);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(545, 242);
            dataGridView1.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(195, 78);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 11;
            label5.Text = "Attendance Log";
            // 
            // EmployeeDashboard_AttendanceLog_Date
            // 
            EmployeeDashboard_AttendanceLog_Date.HeaderText = "Date";
            EmployeeDashboard_AttendanceLog_Date.Name = "EmployeeDashboard_AttendanceLog_Date";
            // 
            // EmployeeDashboard_AttendanceLog_TimeOut
            // 
            EmployeeDashboard_AttendanceLog_TimeOut.HeaderText = "Time Out";
            EmployeeDashboard_AttendanceLog_TimeOut.Name = "EmployeeDashboard_AttendanceLog_TimeOut";
            // 
            // EmployeeDashboard_AttendanceLog_TimeIn
            // 
            EmployeeDashboard_AttendanceLog_TimeIn.HeaderText = "Time In";
            EmployeeDashboard_AttendanceLog_TimeIn.Name = "EmployeeDashboard_AttendanceLog_TimeIn";
            // 
            // EmployeeDashboard_AttendanceLog_TotalHours
            // 
            EmployeeDashboard_AttendanceLog_TotalHours.HeaderText = "Total hours";
            EmployeeDashboard_AttendanceLog_TotalHours.Name = "EmployeeDashboard_AttendanceLog_TotalHours";
            // 
            // EmployeeDashboard_AttendanceLog_Status
            // 
            EmployeeDashboard_AttendanceLog_Status.HeaderText = "Status";
            EmployeeDashboard_AttendanceLog_Status.Name = "EmployeeDashboard_AttendanceLog_Status";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(197, 9);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(167, 54);
            textBox5.TabIndex = 12;
            textBox5.Text = "Total Hours";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 360);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(dataGridView1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(EmployeeDashboard_Attendance_TimeOutButton);
            Controls.Add(EmployeeDashboard_Attendance_TimeInButton);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "Dashboard";
            Text = "Employee Dashboard";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Button EmployeeDashboard_Attendance_TimeInButton;
        private Button EmployeeDashboard_Attendance_TimeOutButton;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox4;
        private DataGridView dataGridView1;
        private Label label5;
        private DataGridViewTextBoxColumn EmployeeDashboard_AttendanceLog_Date;
        private DataGridViewTextBoxColumn EmployeeDashboard_AttendanceLog_TimeOut;
        private DataGridViewTextBoxColumn EmployeeDashboard_AttendanceLog_TimeIn;
        private DataGridViewTextBoxColumn EmployeeDashboard_AttendanceLog_TotalHours;
        private DataGridViewTextBoxColumn EmployeeDashboard_AttendanceLog_Status;
        private TextBox textBox5;
    }
}