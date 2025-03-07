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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            tcAdminPanel = new TabControl();
            tpOrganizationPage = new TabPage();
            tpUsers = new TabPage();
            lblAdminPanel = new Label();
            dgvOrganization = new DataGridView();
            tpUnits = new TabPage();
            name = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            Status = new DataGridViewComboBoxColumn();
            contactPerson = new DataGridViewLinkColumn();
            dgvUsers = new DataGridView();
            email = new DataGridViewTextBoxColumn();
            roles = new DataGridViewComboBoxColumn();
            chkArchived = new DataGridViewCheckBoxColumn();
            dataGridView1 = new DataGridView();
            unitName = new DataGridViewTextBoxColumn();
            abbreviation = new DataGridViewTextBoxColumn();
            tcAdminPanel.SuspendLayout();
            tpOrganizationPage.SuspendLayout();
            tpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrganization).BeginInit();
            tpUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
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
            tpOrganizationPage.Controls.Add(dgvOrganization);
            tpOrganizationPage.Location = new Point(4, 34);
            tpOrganizationPage.Name = "tpOrganizationPage";
            tpOrganizationPage.Padding = new Padding(3);
            tpOrganizationPage.Size = new Size(1173, 725);
            tpOrganizationPage.TabIndex = 0;
            tpOrganizationPage.Text = "Organizations";
            tpOrganizationPage.UseVisualStyleBackColor = true;
            // 
            // tpUsers
            // 
            tpUsers.Controls.Add(dgvUsers);
            tpUsers.Location = new Point(4, 34);
            tpUsers.Name = "tpUsers";
            tpUsers.Padding = new Padding(3);
            tpUsers.Size = new Size(1173, 725);
            tpUsers.TabIndex = 1;
            tpUsers.Text = "Users";
            tpUsers.UseVisualStyleBackColor = true;
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
            // dgvOrganization
            // 
            dgvOrganization.AllowUserToDeleteRows = false;
            dgvOrganization.AllowUserToOrderColumns = true;
            dgvOrganization.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrganization.Columns.AddRange(new DataGridViewColumn[] { name, description, address, Status, contactPerson });
            dgvOrganization.Dock = DockStyle.Fill;
            dgvOrganization.Location = new Point(3, 3);
            dgvOrganization.Name = "dgvOrganization";
            dgvOrganization.RowHeadersWidth = 62;
            dgvOrganization.Size = new Size(1167, 719);
            dgvOrganization.TabIndex = 0;
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
            // name
            // 
            name.HeaderText = "Name";
            name.MinimumWidth = 8;
            name.Name = "name";
            name.Width = 150;
            // 
            // description
            // 
            description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            description.DefaultCellStyle = dataGridViewCellStyle5;
            description.HeaderText = "Description";
            description.MinimumWidth = 8;
            description.Name = "description";
            // 
            // address
            // 
            address.HeaderText = "Address";
            address.MinimumWidth = 8;
            address.Name = "address";
            address.Width = 150;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.Items.AddRange(new object[] { "Waiting for approval", "Approved", "Archived" });
            Status.MinimumWidth = 8;
            Status.Name = "Status";
            Status.Width = 150;
            // 
            // contactPerson
            // 
            contactPerson.HeaderText = "Person of contact";
            contactPerson.MinimumWidth = 8;
            contactPerson.Name = "contactPerson";
            contactPerson.Width = 150;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { email, roles, chkArchived });
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(3, 3);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(1167, 719);
            dgvUsers.TabIndex = 0;
            // 
            // email
            // 
            email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            email.HeaderText = "Email";
            email.MinimumWidth = 8;
            email.Name = "email";
            // 
            // roles
            // 
            roles.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            roles.HeaderText = "Roles";
            roles.Items.AddRange(new object[] { "User", "Admin", "Organization member" });
            roles.MinimumWidth = 8;
            roles.Name = "roles";
            roles.Resizable = DataGridViewTriState.True;
            roles.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // chkArchived
            // 
            chkArchived.HeaderText = "Archived";
            chkArchived.MinimumWidth = 8;
            chkArchived.Name = "chkArchived";
            chkArchived.Resizable = DataGridViewTriState.True;
            chkArchived.Width = 150;
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
            // FrmAdmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 844);
            Controls.Add(lblAdminPanel);
            Controls.Add(tcAdminPanel);
            MinimumSize = new Size(720, 540);
            Name = "FrmAdmin";
            Text = "Home";
            tcAdminPanel.ResumeLayout(false);
            tpOrganizationPage.ResumeLayout(false);
            tpUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrganization).EndInit();
            tpUnits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
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
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn description;
        private DataGridViewTextBoxColumn address;
        private DataGridViewComboBoxColumn Status;
        private DataGridViewLinkColumn contactPerson;
        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn email;
        private DataGridViewComboBoxColumn roles;
        private DataGridViewCheckBoxColumn chkArchived;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn unitName;
        private DataGridViewTextBoxColumn abbreviation;
    }
}
