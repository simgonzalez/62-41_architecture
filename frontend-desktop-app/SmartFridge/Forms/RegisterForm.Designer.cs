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
            lblPassword.Location = new Point(92, 208);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 25);
            lblPassword.TabIndex = 11;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(92, 236);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(344, 31);
            txtPassword.TabIndex = 7;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(92, 128);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(54, 25);
            lblUsername.TabIndex = 9;
            lblUsername.Text = "Email";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(92, 156);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(344, 31);
            txtUsername.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(92, 396);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(158, 38);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnGoBack_Click;
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(285, 396);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(151, 38);
            btnSignIn.TabIndex = 8;
            btnSignIn.Text = "&Sign-in";
            btnSignIn.UseVisualStyleBackColor = true;
            // 
            // lblPasswordConfirmation
            // 
            lblPasswordConfirmation.AutoSize = true;
            lblPasswordConfirmation.Location = new Point(92, 293);
            lblPasswordConfirmation.Name = "lblPasswordConfirmation";
            lblPasswordConfirmation.Size = new Size(158, 25);
            lblPasswordConfirmation.TabIndex = 13;
            lblPasswordConfirmation.Text = "Confirm password";
            // 
            // txtPasswordConfirm
            // 
            txtPasswordConfirm.Location = new Point(92, 321);
            txtPasswordConfirm.Name = "txtPasswordConfirm";
            txtPasswordConfirm.PasswordChar = '*';
            txtPasswordConfirm.Size = new Size(344, 31);
            txtPasswordConfirm.TabIndex = 12;
            // 
            // lblFirstname
            // 
            lblFirstname.AutoSize = true;
            lblFirstname.Location = new Point(92, 44);
            lblFirstname.Name = "lblFirstname";
            lblFirstname.Size = new Size(89, 25);
            lblFirstname.TabIndex = 15;
            lblFirstname.Text = "Firstname";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(92, 72);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(158, 31);
            txtFirstName.TabIndex = 14;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(285, 44);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 17;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(285, 72);
            txtName.Name = "txtName";
            txtName.Size = new Size(158, 31);
            txtName.TabIndex = 16;
            // 
            // FrmRegister
            // 
            AcceptButton = btnSignIn;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(528, 494);
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