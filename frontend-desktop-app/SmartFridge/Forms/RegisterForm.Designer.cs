namespace SmartFridge
{
    partial class FrmRegister
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
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            btnCancel = new Button();
            btnSignIn = new Button();
            lblPasswordConfirmation = new Label();
            txtPasswordConfirm = new TextBox();
            lblFirstname = new Label();
            txtFirstName = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            SuspendLayout();
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(64, 125);
            lblPassword.Margin = new Padding(2, 0, 2, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "&Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(64, 142);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(242, 23);
            txtPassword.TabIndex = 7;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(64, 77);
            lblUsername.Margin = new Padding(2, 0, 2, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(36, 15);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "&Email";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(64, 94);
            txtUsername.Margin = new Padding(2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(242, 23);
            txtUsername.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(64, 238);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(111, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnGoBack_Click;
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(200, 238);
            btnSignIn.Margin = new Padding(2);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(106, 23);
            btnSignIn.TabIndex = 10;
            btnSignIn.Text = "&Sign-in";
            btnSignIn.UseVisualStyleBackColor = true;
            // 
            // lblPasswordConfirmation
            // 
            lblPasswordConfirmation.AutoSize = true;
            lblPasswordConfirmation.Location = new Point(64, 176);
            lblPasswordConfirmation.Margin = new Padding(2, 0, 2, 0);
            lblPasswordConfirmation.Name = "lblPasswordConfirmation";
            lblPasswordConfirmation.Size = new Size(104, 15);
            lblPasswordConfirmation.TabIndex = 8;
            lblPasswordConfirmation.Text = "&Confirm password";
            // 
            // txtPasswordConfirm
            // 
            txtPasswordConfirm.Location = new Point(64, 193);
            txtPasswordConfirm.Margin = new Padding(2);
            txtPasswordConfirm.Name = "txtPasswordConfirm";
            txtPasswordConfirm.PasswordChar = '*';
            txtPasswordConfirm.Size = new Size(242, 23);
            txtPasswordConfirm.TabIndex = 9;
            // 
            // lblFirstname
            // 
            lblFirstname.AutoSize = true;
            lblFirstname.Location = new Point(64, 26);
            lblFirstname.Margin = new Padding(2, 0, 2, 0);
            lblFirstname.Name = "lblFirstname";
            lblFirstname.Size = new Size(59, 15);
            lblFirstname.TabIndex = 0;
            lblFirstname.Text = "&Firstname";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(64, 43);
            txtFirstName.Margin = new Padding(2);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(112, 23);
            txtFirstName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(200, 26);
            lblName.Margin = new Padding(2, 0, 2, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 2;
            lblName.Text = "&Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(200, 43);
            txtName.Margin = new Padding(2);
            txtName.Name = "txtName";
            txtName.Size = new Size(112, 23);
            txtName.TabIndex = 3;
            // 
            // FrmRegister
            // 
            AcceptButton = btnSignIn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(370, 296);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblFirstname);
            Controls.Add(txtFirstName);
            Controls.Add(lblPasswordConfirmation);
            Controls.Add(txtPasswordConfirm);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(btnCancel);
            Controls.Add(btnSignIn);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegister";
            Text = "Sign-in";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblUsername;
        private TextBox txtUsername;
        private Button btnCancel;
        private Button btnSignIn;
        private Label lblPasswordConfirmation;
        private TextBox txtPasswordConfirm;
        private Label lblFirstname;
        private TextBox txtFirstName;
        private Label lblName;
        private TextBox txtName;
    }
}