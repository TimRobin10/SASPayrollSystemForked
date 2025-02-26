namespace PresentationLayer.Views
{
    partial class Login_Form
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
            Login_Username = new TextBox();
            Login_Pass = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            Login_Register = new Button();
            Login_ShowPassword = new CheckBox();
            Login_ForgotPassword = new Button();
            SuspendLayout();
            // 
            // Login_Username
            // 
            Login_Username.Location = new Point(284, 82);
            Login_Username.Multiline = true;
            Login_Username.Name = "Login_Username";
            Login_Username.Size = new Size(211, 23);
            Login_Username.TabIndex = 0;
            // 
            // Login_Pass
            // 
            Login_Pass.Location = new Point(284, 122);
            Login_Pass.Multiline = true;
            Login_Pass.Name = "Login_Pass";
            Login_Pass.Size = new Size(211, 23);
            Login_Pass.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(212, 90);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 2;
            label1.Text = "Username: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(212, 130);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 3;
            label2.Text = "Password: ";
            // 
            // button1
            // 
            button1.Location = new Point(284, 176);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Log In";
            button1.UseVisualStyleBackColor = true;
            // 
            // Login_Register
            // 
            Login_Register.Location = new Point(420, 176);
            Login_Register.Name = "Login_Register";
            Login_Register.Size = new Size(75, 23);
            Login_Register.TabIndex = 5;
            Login_Register.Text = "Register";
            Login_Register.UseVisualStyleBackColor = true;
            // 
            // Login_ShowPassword
            // 
            Login_ShowPassword.AutoSize = true;
            Login_ShowPassword.Location = new Point(334, 151);
            Login_ShowPassword.Name = "Login_ShowPassword";
            Login_ShowPassword.Size = new Size(108, 19);
            Login_ShowPassword.TabIndex = 6;
            Login_ShowPassword.Text = "Show Password";
            Login_ShowPassword.UseVisualStyleBackColor = true;
            // 
            // Login_ForgotPassword
            // 
            Login_ForgotPassword.Location = new Point(334, 205);
            Login_ForgotPassword.Name = "Login_ForgotPassword";
            Login_ForgotPassword.Size = new Size(108, 23);
            Login_ForgotPassword.TabIndex = 7;
            Login_ForgotPassword.Text = "Forgot Password";
            Login_ForgotPassword.UseVisualStyleBackColor = true;
            // 
            // Login_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Login_ForgotPassword);
            Controls.Add(Login_ShowPassword);
            Controls.Add(Login_Register);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Login_Pass);
            Controls.Add(Login_Username);
            Name = "Login_Form";
            Text = "Login_Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Login_Username;
        private TextBox Login_Pass;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button Login_Register;
        private CheckBox Login_ShowPassword;
        private Button Login_ForgotPassword;
    }
}