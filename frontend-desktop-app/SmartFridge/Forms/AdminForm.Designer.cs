namespace SmartFridge
{
    partial class FrmAdmin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tcAdminPanel = new TabControl();
            tpOrganizationPage = new TabPage();
            btnAddLine = new Button();
            dgvOrganization = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            organizationEmail = new DataGridViewTextBoxColumn();
            Status = new DataGridViewComboBoxColumn();
            tpUsers = new TabPage();
            dgvUsers = new DataGridView();
            userFirstName = new DataGridViewTextBoxColumn();
            userName = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            role = new DataGridViewComboBoxColumn();
            chkArchived = new DataGridViewCheckBoxColumn();
            tpUnits = new TabPage();
            dataGridView1 = new DataGridView();
            unitName = new DataGridViewTextBoxColumn();
            abbreviation = new DataGridViewTextBoxColumn();
            lblAdminPanel = new Label();
            txtFilterEmail = new TextBox();
            txtFilterName = new TextBox();
            lblFilters = new Label();
            txtName = new TextBox();
            txtFirstName = new TextBox();
            label1 = new Label();
            txtEmail = new TextBox();
            tcAdminPanel.SuspendLayout();
            tpOrganizationPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrganization).BeginInit();
            tpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tpUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tcAdminPanel
            // 
            tcAdminPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tcAdminPanel.Controls.Add(tpOrganizationPage);
            tcAdminPanel.Controls.Add(tpUsers);
            tcAdminPanel.Controls.Add(tpUnits);
            tcAdminPanel.Location = new Point(0, 82);
            tcAdminPanel.Name = "tcAdminPanel";
            tcAdminPanel.SelectedIndex = 0;
            tcAdminPanel.Size = new Size(1181, 763);
            tcAdminPanel.TabIndex = 0;
            // 
            // tpOrganizationPage
            // 
            tpOrganizationPage.Controls.Add(txtFilterEmail);
            tpOrganizationPage.Controls.Add(txtFilterName);
            tpOrganizationPage.Controls.Add(lblFilters);
            tpOrganizationPage.Controls.Add(btnAddLine);
            tpOrganizationPage.Controls.Add(dgvOrganization);
            tpOrganizationPage.Location = new Point(4, 34);
            tpOrganizationPage.Name = "tpOrganizationPage";
            tpOrganizationPage.Padding = new Padding(3);
            tpOrganizationPage.Size = new Size(1173, 725);
            tpOrganizationPage.TabIndex = 0;
            tpOrganizationPage.Text = "Organizations";
            tpOrganizationPage.UseVisualStyleBackColor = true;
            // 
            // btnAddLine
            // 
            btnAddLine.Location = new Point(9, 38);
            btnAddLine.Name = "btnAddLine";
            btnAddLine.Size = new Size(198, 35);
            btnAddLine.TabIndex = 1;
            btnAddLine.Text = "&Create organization";
            btnAddLine.UseVisualStyleBackColor = true;
            btnAddLine.Click += btnAddLine_Click;
            // 
            // dgvOrganization
            // 
            dgvOrganization.AllowUserToAddRows = false;
            dgvOrganization.AllowUserToDeleteRows = false;
            dgvOrganization.AllowUserToOrderColumns = true;
            dgvOrganization.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrganization.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrganization.Columns.AddRange(new DataGridViewColumn[] { name, description, address, organizationEmail, Status });
            dgvOrganization.Location = new Point(210, 3);
            dgvOrganization.Name = "dgvOrganization";
            dgvOrganization.ReadOnly = true;
            dgvOrganization.RowHeadersWidth = 62;
            dgvOrganization.Size = new Size(960, 719);
            dgvOrganization.TabIndex = 0;
            dgvOrganization.CellContentClick += dgvOrganization_CellContentClick;
            // 
            // name
            // 
            name.HeaderText = "Name";
            name.MinimumWidth = 8;
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 150;
            // 
            // description
            // 
            description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            description.DefaultCellStyle = dataGridViewCellStyle1;
            description.HeaderText = "Description";
            description.MinimumWidth = 8;
            description.Name = "description";
            description.ReadOnly = true;
            // 
            // address
            // 
            address.HeaderText = "Address";
            address.MinimumWidth = 8;
            address.Name = "address";
            address.ReadOnly = true;
            address.Width = 150;
            // 
            // organizationEmail
            // 
            organizationEmail.HeaderText = "Email";
            organizationEmail.MinimumWidth = 8;
            organizationEmail.Name = "organizationEmail";
            organizationEmail.ReadOnly = true;
            organizationEmail.Width = 150;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.Items.AddRange(new object[] { "Waiting for approval", "Approved", "Archived" });
            Status.MinimumWidth = 8;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 150;
            // 
            // tpUsers
            // 
            tpUsers.Controls.Add(txtEmail);
            tpUsers.Controls.Add(txtName);
            tpUsers.Controls.Add(txtFirstName);
            tpUsers.Controls.Add(label1);
            tpUsers.Controls.Add(dgvUsers);
            tpUsers.Location = new Point(4, 34);
            tpUsers.Name = "tpUsers";
            tpUsers.Padding = new Padding(3);
            tpUsers.Size = new Size(1173, 725);
            tpUsers.TabIndex = 1;
            tpUsers.Text = "Users";
            tpUsers.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { userFirstName, userName, email, role, chkArchived });
            dgvUsers.Dock = DockStyle.Right;
            dgvUsers.Location = new Point(209, 3);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(961, 719);
            dgvUsers.TabIndex = 0;
            // 
            // userFirstName
            // 
            userFirstName.HeaderText = "First Name";
            userFirstName.MinimumWidth = 8;
            userFirstName.Name = "userFirstName";
            userFirstName.Width = 150;
            // 
            // userName
            // 
            userName.HeaderText = "Name";
            userName.MinimumWidth = 8;
            userName.Name = "userName";
            userName.Width = 150;
            // 
            // email
            // 
            email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            email.HeaderText = "Email";
            email.MinimumWidth = 8;
            email.Name = "email";
            // 
            // role
            // 
            role.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            role.HeaderText = "Role";
            role.Items.AddRange(new object[] { "User", "Admin", "Organization member" });
            role.MinimumWidth = 8;
            role.Name = "role";
            role.Resizable = DataGridViewTriState.True;
            role.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // chkArchived
            // 
            chkArchived.HeaderText = "Archived";
            chkArchived.MinimumWidth = 8;
            chkArchived.Name = "chkArchived";
            chkArchived.Resizable = DataGridViewTriState.True;
            chkArchived.Width = 150;
            // 
            // tpUnits
            // 
            tpUnits.Controls.Add(dataGridView1);
            tpUnits.Location = new Point(4, 34);
            tpUnits.Name = "tpUnits";
            tpUnits.Padding = new Padding(3);
            tpUnits.Size = new Size(1173, 725);
            tpUnits.TabIndex = 2;
            tpUnits.Text = "Units";
            tpUnits.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { unitName, abbreviation });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1167, 719);
            dataGridView1.TabIndex = 0;
            // 
            // unitName
            // 
            unitName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            unitName.HeaderText = "Name";
            unitName.MinimumWidth = 8;
            unitName.Name = "unitName";
            // 
            // abbreviation
            // 
            abbreviation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            abbreviation.HeaderText = "Abbreviation";
            abbreviation.MinimumWidth = 8;
            abbreviation.Name = "abbreviation";
            // 
            // lblAdminPanel
            // 
            lblAdminPanel.AutoSize = true;
            lblAdminPanel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdminPanel.Location = new Point(4, 21);
            lblAdminPanel.Name = "lblAdminPanel";
            lblAdminPanel.Size = new Size(174, 38);
            lblAdminPanel.TabIndex = 1;
            lblAdminPanel.Text = "Admin panel";
            lblAdminPanel.Click += label1_Click;
            // 
            // txtFilterEmail
            // 
            txtFilterEmail.Location = new Point(9, 170);
            txtFilterEmail.Name = "txtFilterEmail";
            txtFilterEmail.PlaceholderText = "Email";
            txtFilterEmail.Size = new Size(195, 31);
            txtFilterEmail.TabIndex = 10;
            // 
            // txtFilterName
            // 
            txtFilterName.Location = new Point(9, 133);
            txtFilterName.Name = "txtFilterName";
            txtFilterName.PlaceholderText = "Name";
            txtFilterName.Size = new Size(195, 31);
            txtFilterName.TabIndex = 9;
            // 
            // lblFilters
            // 
            lblFilters.AutoSize = true;
            lblFilters.Location = new Point(9, 105);
            lblFilters.Name = "lblFilters";
            lblFilters.Size = new Size(55, 25);
            lblFilters.TabIndex = 8;
            lblFilters.Text = "filters";
            // 
            // txtName
            // 
            txtName.Location = new Point(8, 170);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(195, 31);
            txtName.TabIndex = 10;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(8, 133);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "First Name";
            txtFirstName.Size = new Size(195, 31);
            txtFirstName.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 105);
            label1.Name = "label1";
            label1.Size = new Size(55, 25);
            label1.TabIndex = 8;
            label1.Text = "filters";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(8, 207);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(195, 31);
            txtEmail.TabIndex = 11;
            // 
            // FrmAdmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 844);
            Controls.Add(lblAdminPanel);
            Controls.Add(tcAdminPanel);
            MinimumSize = new Size(1200, 900);
            Name = "FrmAdmin";
            Text = "Home";
            tcAdminPanel.ResumeLayout(false);
            tpOrganizationPage.ResumeLayout(false);
            tpOrganizationPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrganization).EndInit();
            tpUsers.ResumeLayout(false);
            tpUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tpUnits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tcAdminPanel;
        private TabPage tpOrganizationPage;
        private TabPage tpUsers;
        private Label lblAdminPanel;
        private DataGridView dgvOrganization;
        private TabPage tpUnits;
        private DataGridView dgvUsers;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn unitName;
        private DataGridViewTextBoxColumn abbreviation;
        private Button btnAddLine;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn description;
        private DataGridViewTextBoxColumn address;
        private DataGridViewTextBoxColumn organizationEmail;
        private DataGridViewComboBoxColumn Status;
        private DataGridViewTextBoxColumn userFirstName;
        private DataGridViewTextBoxColumn userName;
        private DataGridViewTextBoxColumn email;
        private DataGridViewComboBoxColumn role;
        private DataGridViewCheckBoxColumn chkArchived;
        private TextBox txtFilterEmail;
        private TextBox txtFilterName;
        private Label lblFilters;
        private TextBox txtName;
        private TextBox txtFirstName;
        private Label label1;
        private TextBox txtEmail;
    }
}
