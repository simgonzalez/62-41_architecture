namespace SmartFridge.Forms
{
    partial class frmOrganization
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
            tabOrganizationPanel = new TabControl();
            tpRequests = new TabPage();
            btnCreateFoodRequest = new Button();
            dgvFoodRequest = new DataGridView();
            colFoodRequestName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colDeadline = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewComboBoxColumn();
            colDetails = new DataGridViewLinkColumn();
            tpMembers = new TabPage();
            btnAddMember = new Button();
            dgvMembers = new DataGridView();
            colFirstname = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            tpOrganizationInfo = new TabPage();
            lblOrganizationPanel = new Label();
            txtEmail = new TextBox();
            txtName = new TextBox();
            txtFilterFirstName = new TextBox();
            lblFilters = new Label();
            txtRequestDescription = new TextBox();
            txtFilterRequestName = new TextBox();
            lblFilter = new Label();
            dtpFilterDeadline = new DateTimePicker();
            tabOrganizationPanel.SuspendLayout();
            tpRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFoodRequest).BeginInit();
            tpMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            SuspendLayout();
            // 
            // tabOrganizationPanel
            // 
            tabOrganizationPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabOrganizationPanel.Controls.Add(tpRequests);
            tabOrganizationPanel.Controls.Add(tpMembers);
            tabOrganizationPanel.Controls.Add(tpOrganizationInfo);
            tabOrganizationPanel.Location = new Point(-1, 70);
            tabOrganizationPanel.Name = "tabOrganizationPanel";
            tabOrganizationPanel.SelectedIndex = 0;
            tabOrganizationPanel.Size = new Size(1177, 770);
            tabOrganizationPanel.TabIndex = 0;
            tabOrganizationPanel.SelectedIndexChanged += TabOrganizationPanel_SelectedIndexChanged;
            // 
            // tpRequests
            // 
            tpRequests.Controls.Add(dtpFilterDeadline);
            tpRequests.Controls.Add(txtRequestDescription);
            tpRequests.Controls.Add(txtFilterRequestName);
            tpRequests.Controls.Add(lblFilter);
            tpRequests.Controls.Add(btnCreateFoodRequest);
            tpRequests.Controls.Add(dgvFoodRequest);
            tpRequests.Location = new Point(4, 34);
            tpRequests.Name = "tpRequests";
            tpRequests.Padding = new Padding(3, 3, 3, 3);
            tpRequests.Size = new Size(1169, 732);
            tpRequests.TabIndex = 0;
            tpRequests.Text = "Food Requests";
            tpRequests.UseVisualStyleBackColor = true;
            // 
            // btnCreateFoodRequest
            // 
            btnCreateFoodRequest.Location = new Point(6, 45);
            btnCreateFoodRequest.Name = "btnCreateFoodRequest";
            btnCreateFoodRequest.Size = new Size(199, 35);
            btnCreateFoodRequest.TabIndex = 3;
            btnCreateFoodRequest.Text = "&Create request";
            btnCreateFoodRequest.UseVisualStyleBackColor = true;
            btnCreateFoodRequest.Click += btnCreateFoodRequest_Click;
            // 
            // dgvFoodRequest
            // 
            dgvFoodRequest.AllowUserToAddRows = false;
            dgvFoodRequest.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFoodRequest.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFoodRequest.Columns.AddRange(new DataGridViewColumn[] { colFoodRequestName, colDescription, colDeadline, colStatus, colDetails });
            dgvFoodRequest.Location = new Point(210, 3);
            dgvFoodRequest.Name = "dgvFoodRequest";
            dgvFoodRequest.ReadOnly = true;
            dgvFoodRequest.RowHeadersWidth = 62;
            dgvFoodRequest.Size = new Size(953, 723);
            dgvFoodRequest.TabIndex = 1;
            // 
            // colFoodRequestName
            // 
            colFoodRequestName.HeaderText = "Name";
            colFoodRequestName.MinimumWidth = 8;
            colFoodRequestName.Name = "colFoodRequestName";
            colFoodRequestName.ReadOnly = true;
            colFoodRequestName.Width = 150;
            // 
            // colDescription
            // 
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescription.HeaderText = "Description";
            colDescription.MinimumWidth = 8;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            // 
            // colDeadline
            // 
            colDeadline.HeaderText = "Deadline";
            colDeadline.MinimumWidth = 8;
            colDeadline.Name = "colDeadline";
            colDeadline.ReadOnly = true;
            colDeadline.Width = 150;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Resizable = DataGridViewTriState.True;
            colStatus.SortMode = DataGridViewColumnSortMode.Automatic;
            colStatus.Width = 150;
            // 
            // colDetails
            // 
            colDetails.HeaderText = "Details";
            colDetails.MinimumWidth = 8;
            colDetails.Name = "colDetails";
            colDetails.ReadOnly = true;
            colDetails.Width = 150;
            // 
            // tpMembers
            // 
            tpMembers.Controls.Add(txtEmail);
            tpMembers.Controls.Add(txtName);
            tpMembers.Controls.Add(txtFilterFirstName);
            tpMembers.Controls.Add(lblFilters);
            tpMembers.Controls.Add(btnAddMember);
            tpMembers.Controls.Add(dgvMembers);
            tpMembers.Location = new Point(4, 34);
            tpMembers.Name = "tpMembers";
            tpMembers.Size = new Size(1169, 732);
            tpMembers.TabIndex = 2;
            tpMembers.Text = "Members";
            tpMembers.UseVisualStyleBackColor = true;
            // 
            // btnAddMember
            // 
            btnAddMember.Location = new Point(9, 38);
            btnAddMember.Name = "btnAddMember";
            btnAddMember.Size = new Size(199, 35);
            btnAddMember.TabIndex = 2;
            btnAddMember.Text = "&Add Member";
            btnAddMember.UseVisualStyleBackColor = true;
            btnAddMember.Click += btnAddMember_Click;
            // 
            // dgvMembers
            // 
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembers.Columns.AddRange(new DataGridViewColumn[] { colFirstname, colName, colEmail });
            dgvMembers.Location = new Point(213, 0);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.ReadOnly = true;
            dgvMembers.RowHeadersWidth = 62;
            dgvMembers.Size = new Size(956, 732);
            dgvMembers.TabIndex = 0;
            // 
            // colFirstname
            // 
            colFirstname.HeaderText = "First Name";
            colFirstname.MinimumWidth = 8;
            colFirstname.Name = "colFirstname";
            colFirstname.ReadOnly = true;
            colFirstname.Width = 150;
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 150;
            // 
            // colEmail
            // 
            colEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 8;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // tpOrganizationInfo
            // 
            tpOrganizationInfo.Location = new Point(4, 34);
            tpOrganizationInfo.Name = "tpOrganizationInfo";
            tpOrganizationInfo.Padding = new Padding(3, 3, 3, 3);
            tpOrganizationInfo.Size = new Size(1169, 732);
            tpOrganizationInfo.TabIndex = 1;
            tpOrganizationInfo.Text = "Organization Info";
            tpOrganizationInfo.UseVisualStyleBackColor = true;
            // 
            // lblOrganizationPanel
            // 
            lblOrganizationPanel.AutoSize = true;
            lblOrganizationPanel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrganizationPanel.Location = new Point(3, 18);
            lblOrganizationPanel.Name = "lblOrganizationPanel";
            lblOrganizationPanel.Size = new Size(184, 38);
            lblOrganizationPanel.TabIndex = 2;
            lblOrganizationPanel.Text = "Organization ";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(9, 217);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(199, 31);
            txtEmail.TabIndex = 12;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(8, 180);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(199, 31);
            txtName.TabIndex = 11;
            // 
            // txtFilterFirstName
            // 
            txtFilterFirstName.Location = new Point(9, 143);
            txtFilterFirstName.Name = "txtFilterFirstName";
            txtFilterFirstName.PlaceholderText = "First name";
            txtFilterFirstName.Size = new Size(199, 31);
            txtFilterFirstName.TabIndex = 10;
            // 
            // lblFilters
            // 
            lblFilters.AutoSize = true;
            lblFilters.Location = new Point(9, 115);
            lblFilters.Name = "lblFilters";
            lblFilters.Size = new Size(58, 25);
            lblFilters.TabIndex = 9;
            lblFilters.Text = "&Filters";
            // 
            // txtRequestDescription
            // 
            txtRequestDescription.Location = new Point(5, 177);
            txtRequestDescription.Name = "txtRequestDescription";
            txtRequestDescription.PlaceholderText = "Description";
            txtRequestDescription.Size = new Size(199, 31);
            txtRequestDescription.TabIndex = 11;
            // 
            // txtFilterRequestName
            // 
            txtFilterRequestName.Location = new Point(6, 140);
            txtFilterRequestName.Name = "txtFilterRequestName";
            txtFilterRequestName.PlaceholderText = "Name";
            txtFilterRequestName.Size = new Size(199, 31);
            txtFilterRequestName.TabIndex = 10;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(6, 112);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(58, 25);
            lblFilter.TabIndex = 9;
            lblFilter.Text = "&Filters";
            // 
            // dtpFilterDeadline
            // 
            dtpFilterDeadline.Location = new Point(6, 214);
            dtpFilterDeadline.MinDate = new DateTime(2025, 3, 22, 0, 0, 0, 0);
            dtpFilterDeadline.Name = "dtpFilterDeadline";
            dtpFilterDeadline.Size = new Size(199, 31);
            dtpFilterDeadline.TabIndex = 12;
            // 
            // frmOrganization
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 844);
            Controls.Add(lblOrganizationPanel);
            Controls.Add(tabOrganizationPanel);
            MinimumSize = new Size(1198, 889);
            Name = "frmOrganization";
            Text = "Organization administration";
            tabOrganizationPanel.ResumeLayout(false);
            tpRequests.ResumeLayout(false);
            tpRequests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFoodRequest).EndInit();
            tpMembers.ResumeLayout(false);
            tpMembers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabOrganizationPanel;
        private TabPage tpRequests;
        private Label lblOrganizationPanel;
        private FileSystemWatcher fileSystemWatcher1;
        private TabPage tpMembers;
        private TabPage tpOrganizationInfo;
        private DataGridView dgvMembers;
        private Button btnAddMember;
        private DataGridViewTextBoxColumn colFirstname;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colEmail;
        private Button btnCreateFoodRequest;
        private DataGridView dgvFoodRequest;
        private DataGridViewTextBoxColumn colFoodRequestName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colDeadline;
        private DataGridViewComboBoxColumn colStatus;
        private DataGridViewLinkColumn colDetails;
        private TextBox txtEmail;
        private TextBox txtName;
        private TextBox txtFilterFirstName;
        private Label lblFilters;
        private TextBox txtRequestDescription;
        private TextBox txtFilterRequestName;
        private Label lblFilter;
        private DateTimePicker dtpFilterDeadline;
    }
}