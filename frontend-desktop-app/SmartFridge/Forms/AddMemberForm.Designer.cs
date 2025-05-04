namespace SmartFridge.Forms
{
    partial class frmAddMember
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
            cmbUsers = new ComboBox();
            btnAddMember = new Button();
            lblNewMember = new Label();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // cmbUsers
            // 
            cmbUsers.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbUsers.FormattingEnabled = true;
            cmbUsers.Items.AddRange(new object[] { "user1", "user2", "user3" });
            cmbUsers.Location = new Point(36, 61);
            cmbUsers.Name = "cmbUsers";
            cmbUsers.Size = new Size(456, 33);
            cmbUsers.TabIndex = 0;
            // 
            // btnAddMember
            // 
            btnAddMember.Location = new Point(380, 123);
            btnAddMember.Name = "btnAddMember";
            btnAddMember.Size = new Size(112, 34);
            btnAddMember.TabIndex = 1;
            btnAddMember.Text = "&Add";
            btnAddMember.UseVisualStyleBackColor = true;
            btnAddMember.Click += btnAddMember_Click;
            // 
            // lblNewMember
            // 
            lblNewMember.AutoSize = true;
            lblNewMember.Location = new Point(36, 33);
            lblNewMember.Name = "lblNewMember";
            lblNewMember.Size = new Size(79, 25);
            lblNewMember.TabIndex = 2;
            lblNewMember.Text = "&Member";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(262, 123);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmAddMember
            // 
            AcceptButton = btnAddMember;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(558, 207);
            Controls.Add(btnCancel);
            Controls.Add(lblNewMember);
            Controls.Add(btnAddMember);
            Controls.Add(cmbUsers);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmAddMember";
            Text = "Add Members";
            Load += frmAddMember_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbUsers;
        private Button btnAddMember;
        private Label lblNewMember;
        private Button btnCancel;
    }
}