﻿namespace SmartFridge
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
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
            lblFilter = new Label();
            txtFilterOrganization = new TextBox();
            txtFilterEmail = new TextBox();
            txtName = new TextBox();
            txtFilterFirstName = new TextBox();
            lblFilters = new Label();
            txtEmail = new TextBox();
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
            tcAdminPanel.Location = new Point(4, 82);
            tcAdminPanel.Name = "tcAdminPanel";
            tcAdminPanel.SelectedIndex = 0;
            tcAdminPanel.Size = new Size(1177, 777);
            tcAdminPanel.TabIndex = 0;
            // 
            // tpOrganizationPage
            // 
            tpOrganizationPage.Controls.Add(txtFilterEmail);
            tpOrganizationPage.Controls.Add(txtFilterOrganization);
            tpOrganizationPage.Controls.Add(lblFilter);
            tpOrganizationPage.Controls.Add(btnAddLine);
            tpOrganizationPage.Controls.Add(dgvOrganization);
            tpOrganizationPage.Location = new Point(4, 34);
            tpOrganizationPage.Name = "tpOrganizationPage";
            tpOrganizationPage.Padding = new Padding(3, 3, 3, 3);
            tpOrganizationPage.Size = new Size(1169, 730);
            tpOrganizationPage.TabIndex = 0;
            tpOrganizationPage.Text = "Organizations";
            tpOrganizationPage.UseVisualStyleBackColor = true;
            // 
            // btnAddLine
            // 
            btnAddLine.Location = new Point(9, 38);
            btnAddLine.Name = "btnAddLine";
            btnAddLine.Size = new Size(199, 35);
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
            dgvOrganization.Location = new Point(213, 3);
            dgvOrganization.Name = "dgvOrganization";
            dgvOrganization.ReadOnly = true;
            dgvOrganization.RowHeadersWidth = 62;
            dgvOrganization.Size = new Size(953, 718);
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
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            colDescription.DefaultCellStyle = dataGridViewCellStyle5;
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
            tpUsers.Controls.Add(txtEmail);
            tpUsers.Controls.Add(txtName);
            tpUsers.Controls.Add(txtFilterFirstName);
            tpUsers.Controls.Add(lblFilters);
            tpUsers.Controls.Add(dgvUsers);
            tpUsers.Location = new Point(4, 34);
            tpUsers.Name = "tpUsers";
            tpUsers.Padding = new Padding(3, 3, 3, 3);
            tpUsers.Size = new Size(1169, 739);
            tpUsers.TabIndex = 1;
            tpUsers.Text = "Users";
            tpUsers.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { colUserFirstName, colUserName, colEmail, colRole, chkArchived });
            dgvUsers.Location = new Point(212, 3);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(954, 733);
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
            tpUnits.Location = new Point(4, 34);
            tpUnits.Name = "tpUnits";
            tpUnits.Padding = new Padding(3, 3, 3, 3);
            tpUnits.Size = new Size(1173, 725);
            tpUnits.TabIndex = 2;
            tpUnits.Text = "Units";
            tpUnits.UseVisualStyleBackColor = true;
            // 
            // dgvUnit
            // 
            dgvUnit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUnit.Columns.AddRange(new DataGridViewColumn[] { colUnitName, colAbbreviation });
            dgvUnit.Dock = DockStyle.Fill;
            dgvUnit.Location = new Point(3, 3);
            dgvUnit.Name = "dgvUnit";
            dgvUnit.RowHeadersWidth = 62;
            dgvUnit.Size = new Size(1167, 719);
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
            lblAdminPanel.Location = new Point(4, 22);
            lblAdminPanel.Name = "lblAdminPanel";
            lblAdminPanel.Size = new Size(174, 38);
            lblAdminPanel.TabIndex = 1;
            lblAdminPanel.Text = "Admin panel";
            lblAdminPanel.Click += label1_Click;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(9, 111);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(58, 25);
            lblFilter.TabIndex = 2;
            lblFilter.Text = "&Filters";
            // 
            // txtFilterOrganization
            // 
            txtFilterOrganization.Location = new Point(9, 139);
            txtFilterOrganization.Name = "txtFilterOrganization";
            txtFilterOrganization.PlaceholderText = "Name";
            txtFilterOrganization.Size = new Size(199, 31);
            txtFilterOrganization.TabIndex = 3;
            // 
            // txtFilterEmail
            // 
            txtFilterEmail.Location = new Point(8, 176);
            txtFilterEmail.Name = "txtFilterEmail";
            txtFilterEmail.PlaceholderText = "Email";
            txtFilterEmail.Size = new Size(199, 31);
            txtFilterEmail.TabIndex = 4;
            // 
            // txtName
            // 
            txtName.Location = new Point(7, 175);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(199, 31);
            txtName.TabIndex = 7;
            // 
            // txtFilterFirstName
            // 
            txtFilterFirstName.Location = new Point(8, 138);
            txtFilterFirstName.Name = "txtFilterFirstName";
            txtFilterFirstName.PlaceholderText = "First name";
            txtFilterFirstName.Size = new Size(199, 31);
            txtFilterFirstName.TabIndex = 6;
            // 
            // lblFilters
            // 
            lblFilters.AutoSize = true;
            lblFilters.Location = new Point(8, 110);
            lblFilters.Name = "lblFilters";
            lblFilters.Size = new Size(58, 25);
            lblFilters.TabIndex = 5;
            lblFilters.Text = "&Filters";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(8, 212);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(199, 31);
            txtEmail.TabIndex = 8;
            // 
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 862);
            Controls.Add(lblAdminPanel);
            Controls.Add(tcAdminPanel);
            MinimumSize = new Size(1198, 889);
            Name = "frmAdmin";
            Text = "Admin panel";
            tcAdminPanel.ResumeLayout(false);
            tpOrganizationPage.ResumeLayout(false);
            tpOrganizationPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrganization).EndInit();
            tpUsers.ResumeLayout(false);
            tpUsers.PerformLayout();
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
        private Label lblFilter;
        private TextBox txtFilterOrganization;
        private TextBox txtFilterEmail;
        private TextBox txtName;
        private TextBox txtFilterFirstName;
        private Label lblFilters;
        private TextBox txtEmail;
    }
}
