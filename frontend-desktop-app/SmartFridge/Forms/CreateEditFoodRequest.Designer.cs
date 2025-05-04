namespace SmartFridge.Forms
{
    partial class frmCreateEditFoodRequest
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
            btnCancel = new Button();
            btnSave = new Button();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtName = new TextBox();
            lblName = new Label();
            dgvRequestItem = new DataGridView();
            lblDeadline = new Label();
            dtpDeadline = new DateTimePicker();
            lblFoodItems = new Label();
            btnAddItems = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRequestItem).BeginInit();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(877, 772);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(111, 33);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Canc&el";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(994, 772);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(111, 33);
            btnSave.TabIndex = 9;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Location = new Point(71, 145);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(1035, 166);
            txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(71, 117);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(102, 25);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "&Description";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(71, 63);
            txtName.Name = "txtName";
            txtName.Size = new Size(1035, 31);
            txtName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblName.AutoSize = true;
            lblName.Location = new Point(71, 37);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 0;
            lblName.Text = "&Name";
            // 
            // dgvRequestItem
            // 
            dgvRequestItem.AllowUserToAddRows = false;
            dgvRequestItem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRequestItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequestItem.Location = new Point(71, 467);
            dgvRequestItem.Name = "dgvRequestItem";
            dgvRequestItem.RowHeadersWidth = 62;
            dgvRequestItem.Size = new Size(1034, 288);
            dgvRequestItem.TabIndex = 8;
            // 
            // lblDeadline
            // 
            lblDeadline.AutoSize = true;
            lblDeadline.Location = new Point(71, 337);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new Size(81, 25);
            lblDeadline.TabIndex = 4;
            lblDeadline.Text = "D&eadline";
            // 
            // dtpDeadline
            // 
            dtpDeadline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpDeadline.Location = new Point(71, 367);
            dtpDeadline.Name = "dtpDeadline";
            dtpDeadline.Size = new Size(1035, 31);
            dtpDeadline.TabIndex = 5;
            // 
            // lblFoodItems
            // 
            lblFoodItems.AutoSize = true;
            lblFoodItems.Location = new Point(71, 433);
            lblFoodItems.Name = "lblFoodItems";
            lblFoodItems.Size = new Size(124, 25);
            lblFoodItems.TabIndex = 6;
            lblFoodItems.Text = "&Request Items";
            // 
            // btnAddItems
            // 
            btnAddItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddItems.Location = new Point(994, 428);
            btnAddItems.Name = "btnAddItems";
            btnAddItems.Size = new Size(111, 33);
            btnAddItems.TabIndex = 7;
            btnAddItems.Text = "&New Item";
            btnAddItems.UseVisualStyleBackColor = true;
            btnAddItems.Click += btnAddItems_Click;
            // 
            // frmCreateEditFoodRequest
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(1184, 862);
            Controls.Add(btnAddItems);
            Controls.Add(lblFoodItems);
            Controls.Add(dtpDeadline);
            Controls.Add(lblDeadline);
            Controls.Add(dgvRequestItem);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtName);
            Controls.Add(lblName);
            MinimumSize = new Size(1198, 889);
            Name = "frmCreateEditFoodRequest";
            Text = "Food request";
            Load += frmCreateEditFoodRequest_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRequestItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCancel;
        private Button btnSave;
        private TextBox txtDescription;
        private Label lblDescription;
        private TextBox txtName;
        private Label lblName;
        private DataGridView dgvRequestItem;
        private Label lblDeadline;
        private DateTimePicker dtpDeadline;
        private Label lblFoodItems;
        private Button btnAddItems;
    }
}