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
            dataGridView1 = new DataGridView();
            food = new DataGridViewTextBoxColumn();
            quantity = new DataGridViewTextBoxColumn();
            unit = new DataGridViewTextBoxColumn();
            lblDeadline = new Label();
            dtpDeadline = new DateTimePicker();
            lblFoodItems = new Label();
            btnAddItems = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(877, 772);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Canc&el";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(995, 772);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 9;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Location = new Point(72, 145);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(1035, 166);
            txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(72, 117);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(102, 25);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "&Description";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(72, 64);
            txtName.Name = "txtName";
            txtName.Size = new Size(1035, 31);
            txtName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblName.AutoSize = true;
            lblName.Location = new Point(72, 36);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 0;
            lblName.Text = "&Name";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { food, quantity, unit });
            dataGridView1.Location = new Point(72, 466);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1035, 288);
            dataGridView1.TabIndex = 8;
            // 
            // food
            // 
            food.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            food.HeaderText = "Food";
            food.MinimumWidth = 8;
            food.Name = "food";
            // 
            // quantity
            // 
            quantity.HeaderText = "Quantity";
            quantity.MinimumWidth = 8;
            quantity.Name = "quantity";
            quantity.Width = 150;
            // 
            // unit
            // 
            unit.HeaderText = "Unit";
            unit.MinimumWidth = 8;
            unit.Name = "unit";
            unit.Width = 150;
            // 
            // lblDeadline
            // 
            lblDeadline.AutoSize = true;
            lblDeadline.Location = new Point(72, 336);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new Size(81, 25);
            lblDeadline.TabIndex = 4;
            lblDeadline.Text = "D&eadline";
            // 
            // dtpDeadline
            // 
            dtpDeadline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpDeadline.Location = new Point(72, 366);
            dtpDeadline.Name = "dtpDeadline";
            dtpDeadline.Size = new Size(1035, 31);
            dtpDeadline.TabIndex = 5;
            // 
            // lblFoodItems
            // 
            lblFoodItems.AutoSize = true;
            lblFoodItems.Location = new Point(72, 434);
            lblFoodItems.Name = "lblFoodItems";
            lblFoodItems.Size = new Size(124, 25);
            lblFoodItems.TabIndex = 6;
            lblFoodItems.Text = "&Request Items";
            // 
            // btnAddItems
            // 
            btnAddItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddItems.Location = new Point(995, 429);
            btnAddItems.Name = "btnAddItems";
            btnAddItems.Size = new Size(112, 34);
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
            ClientSize = new Size(1178, 844);
            Controls.Add(btnAddItems);
            Controls.Add(lblFoodItems);
            Controls.Add(dtpDeadline);
            Controls.Add(lblDeadline);
            Controls.Add(dataGridView1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtName);
            Controls.Add(lblName);
            MinimumSize = new Size(1200, 900);
            Name = "frmCreateEditFoodRequest";
            Text = "Food request";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn food;
        private DataGridViewTextBoxColumn quantity;
        private DataGridViewTextBoxColumn unit;
        private Label lblDeadline;
        private DateTimePicker dtpDeadline;
        private Label lblFoodItems;
        private Button btnAddItems;
    }
}