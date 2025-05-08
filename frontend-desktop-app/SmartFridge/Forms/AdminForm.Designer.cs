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
            tcAdminPanel = new TabControl();
            tpOrganizationPage = new TabPage();
            txtFilterCity = new TextBox();
            txtFilterOrganization = new TextBox();
            lblFilter = new Label();
            btnAddLine = new Button();
            dgvOrganization = new DataGridView();
            tpUsers = new TabPage();
            txtEmail = new TextBox();
            txtName = new TextBox();
            txtFilterFirstName = new TextBox();
            lblFilters = new Label();
            dgvUsers = new DataGridView();
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
            tcAdminPanel.Location = new Point(4, 82);
            tcAdminPanel.Name = "tcAdminPanel";
            tcAdminPanel.SelectedIndex = 0;
            tcAdminPanel.Size = new Size(1177, 777);
            tcAdminPanel.TabIndex = 0;
            tcAdminPanel.SelectedIndexChanged += tcAdminPanel_SelectedIndexChanged;
            // 
            // tpOrganizationPage
            // 
            tpOrganizationPage.Controls.Add(txtFilterCity);
            tpOrganizationPage.Controls.Add(txtFilterOrganization);
            tpOrganizationPage.Controls.Add(lblFilter);
            tpOrganizationPage.Controls.Add(btnAddLine);
            tpOrganizationPage.Controls.Add(dgvOrganization);
            tpOrganizationPage.Location = new Point(4, 34);
            tpOrganizationPage.Name = "tpOrganizationPage";
            tpOrganizationPage.Padding = new Padding(3);
            tpOrganizationPage.Size = new Size(1169, 739);
            tpOrganizationPage.TabIndex = 0;
            tpOrganizationPage.Text = "Organizations";
            tpOrganizationPage.UseVisualStyleBackColor = true;
            // 
            // txtFilterCity
            // 
            txtFilterCity.Location = new Point(8, 176);
            txtFilterCity.Name = "txtFilterCity";
            txtFilterCity.PlaceholderText = "City/Npa";
            txtFilterCity.Size = new Size(199, 31);
            txtFilterCity.TabIndex = 4;
            txtFilterCity.TextChanged += txtFilterCity_TextChanged;
            // 
            // txtFilterOrganization
            // 
            txtFilterOrganization.Location = new Point(9, 139);
            txtFilterOrganization.Name = "txtFilterOrganization";
            txtFilterOrganization.PlaceholderText = "Name";
            txtFilterOrganization.Size = new Size(199, 31);
            txtFilterOrganization.TabIndex = 3;
            txtFilterOrganization.TextChanged += txtFilterName_TextChanged;
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
            dgvOrganization.Location = new Point(213, 3);
            dgvOrganization.Name = "dgvOrganization";
            dgvOrganization.ReadOnly = true;
            dgvOrganization.RowHeadersWidth = 62;
            dgvOrganization.Size = new Size(953, 718);
            dgvOrganization.TabIndex = 0;
            dgvOrganization.CellClick += dgvOrganization_CellClick;
            dgvOrganization.CellDoubleClick += dgvOrganization_CellDoubleClick;
            dgvOrganization.CellFormatting += dgvOrganization_CellFormatting;
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
            tpUsers.Padding = new Padding(3);
            tpUsers.Size = new Size(1169, 739);
            tpUsers.TabIndex = 1;
            tpUsers.Text = "Users";
            tpUsers.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(8, 212);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(199, 31);
            txtEmail.TabIndex = 8;
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
            // dgvUsers
            // 
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(212, 3);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(954, 733);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            dgvUsers.CellValueChanged += dgvUsers_CellValueChanged;
            dgvUsers.RowValidated += dgvUsers_RowValidated;
            // 
            // tpUnits
            // 
            tpUnits.Controls.Add(dgvUnit);
            tpUnits.Location = new Point(4, 34);
            tpUnits.Name = "tpUnits";
            tpUnits.Padding = new Padding(3);
            tpUnits.Size = new Size(1169, 739);
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
            dgvUnit.Size = new Size(1163, 733);
            dgvUnit.TabIndex = 0;
            dgvUnit.CellContentClick += dgvUnits_CellContentClick;
            dgvUnit.CellValueChanged += dgvUnits_CellValueChanged;
            dgvUnit.RowValidated += dgvUnits_RowValidated;
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
            Load += frmAdmin_Load;
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
        private Label lblFilter;
        private TextBox txtFilterOrganization;
        private TextBox txtFilterCity;
        private TextBox txtName;
        private TextBox txtFilterFirstName;
        private Label lblFilters;
        private TextBox txtEmail;
    }
}
