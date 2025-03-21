namespace SmartFridge
{
    partial class frmAdmin
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tcAdminPanel = new TabControl();
            tpOrganizationPage = new TabPage();
            btnAddLine = new Button();
            dgvOrganization = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colOrganizationEmail = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewComboBoxColumn();
            tpUsers = new TabPage();
            dgvUsers = new DataGridView();
            colUserFirstName = new DataGridViewTextBoxColumn();
            colUserName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colRole = new DataGridViewComboBoxColumn();
            chkArchived = new DataGridViewCheckBoxColumn();
            tpUnits = new TabPage();
            dgvUnit = new DataGridView();
            colUnitName = new DataGridViewTextBoxColumn();
            colAbbreviation = new DataGridViewTextBoxColumn();
            lblAdminPanel = new Label();
            tcAdminPanel.SuspendLayout();
            tpOrganizationPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrganization).BeginInit();
            tpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tpUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnit).BeginInit();
            SuspendLayout();
            // 
            // tcAdminPanel
            // 
            tcAdminPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tcAdminPanel.Controls.Add(tpOrganizationPage);
            tcAdminPanel.Controls.Add(tpUsers);
            tcAdminPanel.Controls.Add(tpUnits);
            tcAdminPanel.Location = new Point(0, 49);
            tcAdminPanel.Margin = new Padding(2, 2, 2, 2);
            tcAdminPanel.Name = "tcAdminPanel";
            tcAdminPanel.SelectedIndex = 0;
            tcAdminPanel.Size = new Size(827, 458);
            tcAdminPanel.TabIndex = 0;
            // 
            // tpOrganizationPage
            // 
            tpOrganizationPage.Controls.Add(btnAddLine);
            tpOrganizationPage.Controls.Add(dgvOrganization);
            tpOrganizationPage.Location = new Point(4, 24);
            tpOrganizationPage.Margin = new Padding(2, 2, 2, 2);
            tpOrganizationPage.Name = "tpOrganizationPage";
            tpOrganizationPage.Padding = new Padding(2, 2, 2, 2);
            tpOrganizationPage.Size = new Size(819, 430);
            tpOrganizationPage.TabIndex = 0;
            tpOrganizationPage.Text = "Organizations";
            tpOrganizationPage.UseVisualStyleBackColor = true;
            // 
            // btnAddLine
            // 
            btnAddLine.Location = new Point(6, 23);
            btnAddLine.Margin = new Padding(2, 2, 2, 2);
            btnAddLine.Name = "btnAddLine";
            btnAddLine.Size = new Size(139, 21);
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
            dgvOrganization.Columns.AddRange(new DataGridViewColumn[] { colName, colDescription, colAddress, colOrganizationEmail, colStatus });
            dgvOrganization.Location = new Point(147, 2);
            dgvOrganization.Margin = new Padding(2, 2, 2, 2);
            dgvOrganization.Name = "dgvOrganization";
            dgvOrganization.ReadOnly = true;
            dgvOrganization.RowHeadersWidth = 62;
            dgvOrganization.Size = new Size(672, 431);
            dgvOrganization.TabIndex = 0;
            dgvOrganization.CellContentClick += dgvOrganization_CellContentClick;
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 150;
            // 
            // colDescription
            // 
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            colDescription.DefaultCellStyle = dataGridViewCellStyle2;
            colDescription.HeaderText = "Description";
            colDescription.MinimumWidth = 8;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            // 
            // colAddress
            // 
            colAddress.HeaderText = "Address";
            colAddress.MinimumWidth = 8;
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            colAddress.Width = 150;
            // 
            // colOrganizationEmail
            // 
            colOrganizationEmail.HeaderText = "Email";
            colOrganizationEmail.MinimumWidth = 8;
            colOrganizationEmail.Name = "colOrganizationEmail";
            colOrganizationEmail.ReadOnly = true;
            colOrganizationEmail.Width = 150;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Items.AddRange(new object[] { "Waiting for approval", "Approved", "Archived" });
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 150;
            // 
            // tpUsers
            // 
            tpUsers.Controls.Add(dgvUsers);
            tpUsers.Location = new Point(4, 24);
            tpUsers.Margin = new Padding(2, 2, 2, 2);
            tpUsers.Name = "tpUsers";
            tpUsers.Padding = new Padding(2, 2, 2, 2);
            tpUsers.Size = new Size(819, 430);
            tpUsers.TabIndex = 1;
            tpUsers.Text = "Users";
            tpUsers.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { colUserFirstName, colUserName, colEmail, colRole, chkArchived });
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(2, 2);
            dgvUsers.Margin = new Padding(2, 2, 2, 2);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(815, 426);
            dgvUsers.TabIndex = 0;
            // 
            // colUserFirstName
            // 
            colUserFirstName.HeaderText = "First Name";
            colUserFirstName.MinimumWidth = 8;
            colUserFirstName.Name = "colUserFirstName";
            colUserFirstName.Width = 150;
            // 
            // colUserName
            // 
            colUserName.HeaderText = "Name";
            colUserName.MinimumWidth = 8;
            colUserName.Name = "colUserName";
            colUserName.Width = 150;
            // 
            // colEmail
            // 
            colEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 8;
            colEmail.Name = "colEmail";
            // 
            // colRole
            // 
            colRole.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRole.HeaderText = "Role";
            colRole.Items.AddRange(new object[] { "User", "Admin", "Organization member" });
            colRole.MinimumWidth = 8;
            colRole.Name = "colRole";
            colRole.Resizable = DataGridViewTriState.True;
            colRole.SortMode = DataGridViewColumnSortMode.Automatic;
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
            tpUnits.Controls.Add(dgvUnit);
            tpUnits.Location = new Point(4, 24);
            tpUnits.Margin = new Padding(2, 2, 2, 2);
            tpUnits.Name = "tpUnits";
            tpUnits.Padding = new Padding(2, 2, 2, 2);
            tpUnits.Size = new Size(819, 430);
            tpUnits.TabIndex = 2;
            tpUnits.Text = "Units";
            tpUnits.UseVisualStyleBackColor = true;
            // 
            // dgvUnit
            // 
            dgvUnit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUnit.Columns.AddRange(new DataGridViewColumn[] { colUnitName, colAbbreviation });
            dgvUnit.Dock = DockStyle.Fill;
            dgvUnit.Location = new Point(2, 2);
            dgvUnit.Margin = new Padding(2, 2, 2, 2);
            dgvUnit.Name = "dgvUnit";
            dgvUnit.RowHeadersWidth = 62;
            dgvUnit.Size = new Size(815, 426);
            dgvUnit.TabIndex = 0;
            // 
            // colUnitName
            // 
            colUnitName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colUnitName.HeaderText = "Name";
            colUnitName.MinimumWidth = 8;
            colUnitName.Name = "colUnitName";
            // 
            // colAbbreviation
            // 
            colAbbreviation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colAbbreviation.HeaderText = "Abbreviation";
            colAbbreviation.MinimumWidth = 8;
            colAbbreviation.Name = "colAbbreviation";
            // 
            // lblAdminPanel
            // 
            lblAdminPanel.AutoSize = true;
            lblAdminPanel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdminPanel.Location = new Point(3, 13);
            lblAdminPanel.Margin = new Padding(2, 0, 2, 0);
            lblAdminPanel.Name = "lblAdminPanel";
            lblAdminPanel.Size = new Size(119, 25);
            lblAdminPanel.TabIndex = 1;
            lblAdminPanel.Text = "Admin panel";
            lblAdminPanel.Click += label1_Click;
            // 
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 517);
            Controls.Add(lblAdminPanel);
            Controls.Add(tcAdminPanel);
            Margin = new Padding(2, 2, 2, 2);
            MinimumSize = new Size(845, 556);
            Name = "frmAdmin";
            Text = "Home";
            tcAdminPanel.ResumeLayout(false);
            tpOrganizationPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrganization).EndInit();
            tpUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tpUnits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUnit).EndInit();
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
        private DataGridView dgvUnit;
        private DataGridViewTextBoxColumn colUnitName;
        private DataGridViewTextBoxColumn colAbbreviation;
        private Button btnAddLine;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colAddress;
        private DataGridViewTextBoxColumn colOrganizationEmail;
        private DataGridViewComboBoxColumn colStatus;
        private DataGridViewTextBoxColumn colUserFirstName;
        private DataGridViewTextBoxColumn colUserName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewComboBoxColumn colRole;
        private DataGridViewCheckBoxColumn chkArchived;
    }
}
