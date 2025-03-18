namespace SmartFridge.Forms
{
    partial class frmCreateEditOrganization
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
            lblName = new Label();
            txtName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblEmail = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            txtEmail = new TextBox();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblName.AutoSize = true;
            lblName.Location = new Point(107, 49);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 0;
            lblName.Text = "&Name";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(107, 77);
            txtName.Name = "txtName";
            txtName.Size = new Size(494, 31);
            txtName.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(107, 136);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(102, 25);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "&Description";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Location = new Point(107, 164);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(494, 108);
            txtDescription.TabIndex = 3;
            // 
            // lblAddress
            // 
            lblAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(107, 301);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(77, 25);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "&Address";
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAddress.Location = new Point(107, 329);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(494, 31);
            txtAddress.TabIndex = 5;
            txtAddress.Enter += txtAddress_Enter;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(107, 393);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 25);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "&Email";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Location = new Point(489, 488);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 8;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.Location = new Point(371, 488);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Canc&el";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Location = new Point(107, 421);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(494, 31);
            txtEmail.TabIndex = 7;
            // 
            // frmCreateEditOrganization
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(736, 594);
            Controls.Add(txtEmail);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblEmail);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtName);
            Controls.Add(lblName);
            MinimumSize = new Size(720, 650);
            Name = "frmCreateEditOrganization";
            Text = "Organization";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblEmail;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtEmail;
    }
}