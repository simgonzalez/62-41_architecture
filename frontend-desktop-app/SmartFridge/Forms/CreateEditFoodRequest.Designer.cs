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
            colFood = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colUnit = new DataGridViewTextBoxColumn();
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
            btnCancel.Location = new Point(614, 463);
            btnCancel.Margin = new Padding(2, 2, 2, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(78, 20);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Canc&el";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(696, 463);
            btnSave.Margin = new Padding(2, 2, 2, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(78, 20);
            btnSave.TabIndex = 9;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Location = new Point(50, 87);
            txtDescription.Margin = new Padding(2, 2, 2, 2);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(726, 101);
            txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(50, 70);
            lblDescription.Margin = new Padding(2, 0, 2, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "&Description";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(50, 38);
            txtName.Margin = new Padding(2, 2, 2, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(726, 23);
            txtName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblName.AutoSize = true;
            lblName.Location = new Point(50, 22);
            lblName.Margin = new Padding(2, 0, 2, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 0;
            lblName.Text = "&Name";
            // 
            // dgvRequestItem
            // 
            dgvRequestItem.AllowUserToAddRows = false;
            dgvRequestItem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRequestItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequestItem.Columns.AddRange(new DataGridViewColumn[] { colFood, colQuantity, colUnit });
            dgvRequestItem.Location = new Point(50, 280);
            dgvRequestItem.Margin = new Padding(2, 2, 2, 2);
            dgvRequestItem.Name = "dgvRequestItem";
            dgvRequestItem.RowHeadersWidth = 62;
            dgvRequestItem.Size = new Size(724, 173);
            dgvRequestItem.TabIndex = 8;
            // 
            // colFood
            // 
            colFood.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFood.HeaderText = "Food";
            colFood.MinimumWidth = 8;
            colFood.Name = "colFood";
            // 
            // colQuantity
            // 
            colQuantity.HeaderText = "Quantity";
            colQuantity.MinimumWidth = 8;
            colQuantity.Name = "colQuantity";
            colQuantity.Width = 150;
            // 
            // colUnit
            // 
            colUnit.HeaderText = "Unit";
            colUnit.MinimumWidth = 8;
            colUnit.Name = "colUnit";
            colUnit.Width = 150;
            // 
            // lblDeadline
            // 
            lblDeadline.AutoSize = true;
            lblDeadline.Location = new Point(50, 202);
            lblDeadline.Margin = new Padding(2, 0, 2, 0);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new Size(53, 15);
            lblDeadline.TabIndex = 4;
            lblDeadline.Text = "D&eadline";
            // 
            // dtpDeadline
            // 
            dtpDeadline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpDeadline.Location = new Point(50, 220);
            dtpDeadline.Margin = new Padding(2, 2, 2, 2);
            dtpDeadline.Name = "dtpDeadline";
            dtpDeadline.Size = new Size(726, 23);
            dtpDeadline.TabIndex = 5;
            // 
            // lblFoodItems
            // 
            lblFoodItems.AutoSize = true;
            lblFoodItems.Location = new Point(50, 260);
            lblFoodItems.Margin = new Padding(2, 0, 2, 0);
            lblFoodItems.Name = "lblFoodItems";
            lblFoodItems.Size = new Size(81, 15);
            lblFoodItems.TabIndex = 6;
            lblFoodItems.Text = "&Request Items";
            // 
            // btnAddItems
            // 
            btnAddItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddItems.Location = new Point(696, 257);
            btnAddItems.Margin = new Padding(2, 2, 2, 2);
            btnAddItems.Name = "btnAddItems";
            btnAddItems.Size = new Size(78, 20);
            btnAddItems.TabIndex = 7;
            btnAddItems.Text = "&New Item";
            btnAddItems.UseVisualStyleBackColor = true;
            btnAddItems.Click += btnAddItems_Click;
            // 
            // frmCreateEditFoodRequest
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(829, 517);
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
            Margin = new Padding(2, 2, 2, 2);
            MinimumSize = new Size(845, 556);
            Name = "frmCreateEditFoodRequest";
            Text = "Food request";
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
        private DataGridViewTextBoxColumn colFood;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colUnit;
        private Label lblDeadline;
        private DateTimePicker dtpDeadline;
        private Label lblFoodItems;
        private Button btnAddItems;
    }
}