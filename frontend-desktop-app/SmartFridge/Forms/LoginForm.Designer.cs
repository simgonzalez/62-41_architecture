namespace SmartFridge
{
    partial class frmLogin
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
            btnLogin = new Button();
            btnRegister = new Button();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(204, 144);
            btnLogin.Margin = new Padding(2, 2, 2, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(106, 23);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "&Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(69, 144);
            btnRegister.Margin = new Padding(2, 2, 2, 2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(106, 23);
            btnRegister.TabIndex = 3;
            btnRegister.Text = "&Sign-in";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(69, 59);
            txtUsername.Margin = new Padding(2, 2, 2, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(242, 23);
            txtUsername.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(69, 42);
            lblUsername.Margin = new Padding(2, 0, 2, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(36, 15);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "&Email";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(69, 90);
            lblPassword.Margin = new Padding(2, 0, 2, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "&Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(69, 107);
            txtPassword.Margin = new Padding(2, 2, 2, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(242, 23);
            txtPassword.TabIndex = 1;
            // 
            // frmLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 217);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(390, 256);
            Name = "frmLogin";
            Text = "Login";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnRegister;
        private TextBox txtUsername;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtPassword;
    }
}