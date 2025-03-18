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
            dataGridView1 = new DataGridView();
            foodRequestName = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            deadline = new DataGridViewTextBoxColumn();
            details = new DataGridViewLinkColumn();
            tpMembers = new TabPage();
            btnAddMember = new Button();
            dgvMembers = new DataGridView();
            firstname = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            tpOrganizationInfo = new TabPage();
            lblOrganizationPanel = new Label();
            fileSystemWatcher1 = new FileSystemWatcher();
            tabOrganizationPanel.SuspendLayout();
            tpRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tpMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
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
            tabOrganizationPanel.Size = new Size(1181, 775);
            tabOrganizationPanel.TabIndex = 0;
            tabOrganizationPanel.SelectedIndexChanged += TabOrganizationPanel_SelectedIndexChanged;
            // 
            // tpRequests
            // 
            tpRequests.Controls.Add(btnCreateFoodRequest);
            tpRequests.Controls.Add(dataGridView1);
            tpRequests.Location = new Point(4, 34);
            tpRequests.Name = "tpRequests";
            tpRequests.Padding = new Padding(3);
            tpRequests.Size = new Size(1173, 737);
            tpRequests.TabIndex = 0;
            tpRequests.Text = "Food Requests";
            tpRequests.UseVisualStyleBackColor = true;
            // 
            // btnCreateFoodRequest
            // 
            btnCreateFoodRequest.Location = new Point(6, 45);
            btnCreateFoodRequest.Name = "btnCreateFoodRequest";
            btnCreateFoodRequest.Size = new Size(198, 35);
            btnCreateFoodRequest.TabIndex = 3;
            btnCreateFoodRequest.Text = "&Create request";
            btnCreateFoodRequest.UseVisualStyleBackColor = true;
            btnCreateFoodRequest.Click += btnCreateFoodRequest_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { foodRequestName, description, deadline, details });
            dataGridView1.Location = new Point(210, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(960, 731);
            dataGridView1.TabIndex = 1;
            // 
            // foodRequestName
            // 
            foodRequestName.HeaderText = "Name";
            foodRequestName.MinimumWidth = 8;
            foodRequestName.Name = "foodRequestName";
            foodRequestName.ReadOnly = true;
            foodRequestName.Width = 150;
            // 
            // description
            // 
            description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            description.HeaderText = "Description";
            description.MinimumWidth = 8;
            description.Name = "description";
            description.ReadOnly = true;
            // 
            // deadline
            // 
            deadline.HeaderText = "Deadline";
            deadline.MinimumWidth = 8;
            deadline.Name = "deadline";
            deadline.ReadOnly = true;
            deadline.Width = 150;
            // 
            // details
            // 
            details.HeaderText = "Details";
            details.MinimumWidth = 8;
            details.Name = "details";
            details.ReadOnly = true;
            details.Width = 150;
            // 
            // tpMembers
            // 
            tpMembers.Controls.Add(btnAddMember);
            tpMembers.Controls.Add(dgvMembers);
            tpMembers.Location = new Point(4, 34);
            tpMembers.Name = "tpMembers";
            tpMembers.Size = new Size(1173, 737);
            tpMembers.TabIndex = 2;
            tpMembers.Text = "Members";
            tpMembers.UseVisualStyleBackColor = true;
            // 
            // btnAddMember
            // 
            btnAddMember.Location = new Point(9, 38);
            btnAddMember.Name = "btnAddMember";
            btnAddMember.Size = new Size(198, 35);
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
            dgvMembers.Columns.AddRange(new DataGridViewColumn[] { firstname, name, email });
            dgvMembers.Location = new Point(213, 0);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.ReadOnly = true;
            dgvMembers.RowHeadersWidth = 62;
            dgvMembers.Size = new Size(960, 737);
            dgvMembers.TabIndex = 0;
            // 
            // firstname
            // 
            firstname.HeaderText = "First Name";
            firstname.MinimumWidth = 8;
            firstname.Name = "firstname";
            firstname.ReadOnly = true;
            firstname.Width = 150;
            // 
            // name
            // 
            name.HeaderText = "Name";
            name.MinimumWidth = 8;
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 150;
            // 
            // email
            // 
            email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            email.HeaderText = "Email";
            email.MinimumWidth = 8;
            email.Name = "email";
            email.ReadOnly = true;
            // 
            // tpOrganizationInfo
            // 
            tpOrganizationInfo.Location = new Point(4, 34);
            tpOrganizationInfo.Name = "tpOrganizationInfo";
            tpOrganizationInfo.Padding = new Padding(3);
            tpOrganizationInfo.Size = new Size(1173, 737);
            tpOrganizationInfo.TabIndex = 1;
            tpOrganizationInfo.Text = "Organization Info";
            tpOrganizationInfo.UseVisualStyleBackColor = true;
            // 
            // lblOrganizationPanel
            // 
            lblOrganizationPanel.AutoSize = true;
            lblOrganizationPanel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrganizationPanel.Location = new Point(3, 19);
            lblOrganizationPanel.Name = "lblOrganizationPanel";
            lblOrganizationPanel.Size = new Size(184, 38);
            lblOrganizationPanel.TabIndex = 2;
            lblOrganizationPanel.Text = "Organization ";
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // frmOrganization
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 844);
            Controls.Add(lblOrganizationPanel);
            Controls.Add(tabOrganizationPanel);
            MinimumSize = new Size(1200, 900);
            Name = "frmOrganization";
            Text = "Organization administration";
            tabOrganizationPanel.ResumeLayout(false);
            tpRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tpMembers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
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
        private DataGridViewTextBoxColumn firstname;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn email;
        private Button btnCreateFoodRequest;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn foodRequestName;
        private DataGridViewTextBoxColumn description;
        private DataGridViewTextBoxColumn deadline;
        private DataGridViewLinkColumn details;
    }
}