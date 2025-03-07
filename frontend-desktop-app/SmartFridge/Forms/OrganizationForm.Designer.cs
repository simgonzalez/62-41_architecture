namespace SmartFridge.Forms
{
    partial class OrganizationForm
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
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "test, test, test", "test" }, -1);
            tabOrganizationPanel = new TabControl();
            tpRequests = new TabPage();
            tpOrganizationInfo = new TabPage();
            lblOrganizationPanel = new Label();
            fileSystemWatcher1 = new FileSystemWatcher();
            lvwFoodRequests = new ListView();
            chDeadline = new ColumnHeader();
            chDescription = new ColumnHeader();
            chResponsible = new ColumnHeader();
            chItems = new ColumnHeader();
            label1 = new Label();
            tpMembers = new TabPage();
            label2 = new Label();
            tabOrganizationPanel.SuspendLayout();
            tpRequests.SuspendLayout();
            tpOrganizationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            tpMembers.SuspendLayout();
            SuspendLayout();
            // 
            // tabOrganizationPanel
            // 
            tabOrganizationPanel.Controls.Add(tpRequests);
            tabOrganizationPanel.Controls.Add(tpMembers);
            tabOrganizationPanel.Controls.Add(tpOrganizationInfo);
            tabOrganizationPanel.Location = new Point(-1, 70);
            tabOrganizationPanel.Name = "tabOrganizationPanel";
            tabOrganizationPanel.SelectedIndex = 0;
            tabOrganizationPanel.Size = new Size(1178, 775);
            tabOrganizationPanel.TabIndex = 0;
            // 
            // tpRequests
            // 
            tpRequests.Controls.Add(lvwFoodRequests);
            tpRequests.Location = new Point(4, 34);
            tpRequests.Name = "tpRequests";
            tpRequests.Padding = new Padding(3);
            tpRequests.Size = new Size(1170, 737);
            tpRequests.TabIndex = 0;
            tpRequests.Text = "Food Requests";
            tpRequests.UseVisualStyleBackColor = true;
            // 
            // tpOrganizationInfo
            // 
            tpOrganizationInfo.Controls.Add(label1);
            tpOrganizationInfo.Location = new Point(4, 34);
            tpOrganizationInfo.Name = "tpOrganizationInfo";
            tpOrganizationInfo.Padding = new Padding(3);
            tpOrganizationInfo.Size = new Size(1170, 737);
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
            // lvwFoodRequests
            // 
            lvwFoodRequests.Columns.AddRange(new ColumnHeader[] { chDeadline, chDescription, chResponsible, chItems });
            lvwFoodRequests.Dock = DockStyle.Fill;
            lvwFoodRequests.Items.AddRange(new ListViewItem[] { listViewItem2 });
            lvwFoodRequests.Location = new Point(3, 3);
            lvwFoodRequests.Name = "lvwFoodRequests";
            lvwFoodRequests.Size = new Size(1164, 731);
            lvwFoodRequests.TabIndex = 0;
            lvwFoodRequests.UseCompatibleStateImageBehavior = false;
            // 
            // chDeadline
            // 
            chDeadline.Text = "Deadline";
            // 
            // chDescription
            // 
            chDescription.Text = "Description";
            // 
            // chResponsible
            // 
            chResponsible.Text = "Responsible";
            // 
            // chItems
            // 
            chItems.Text = "Items view";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(508, 377);
            label1.Name = "label1";
            label1.Size = new Size(259, 25);
            label1.TabIndex = 0;
            label1.Text = "FORM TO EDIT THE ORG INFO ";
            // 
            // tpMembers
            // 
            tpMembers.Controls.Add(label2);
            tpMembers.Location = new Point(4, 34);
            tpMembers.Name = "tpMembers";
            tpMembers.Size = new Size(1170, 737);
            tpMembers.TabIndex = 2;
            tpMembers.Text = "Members";
            tpMembers.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(456, 356);
            label2.Name = "label2";
            label2.Size = new Size(393, 25);
            label2.TabIndex = 1;
            label2.Text = "list view with the option to add new members ? ";
            // 
            // OrganizationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 844);
            Controls.Add(lblOrganizationPanel);
            Controls.Add(tabOrganizationPanel);
            MinimumSize = new Size(720, 540);
            Name = "OrganizationForm";
            Text = "Organization administration";
            tabOrganizationPanel.ResumeLayout(false);
            tpRequests.ResumeLayout(false);
            tpOrganizationInfo.ResumeLayout(false);
            tpOrganizationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            tpMembers.ResumeLayout(false);
            tpMembers.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabOrganizationPanel;
        private TabPage tpRequests;
        private TabPage tpOrganizationInfo;
        private Label lblOrganizationPanel;
        private FileSystemWatcher fileSystemWatcher1;
        private ListView lvwFoodRequests;
        private ColumnHeader chDeadline;
        private ColumnHeader chDescription;
        private ColumnHeader chResponsible;
        private ColumnHeader chItems;
        private TabPage tpMembers;
        private Label label1;
        private Label label2;
    }
}