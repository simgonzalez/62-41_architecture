namespace SmartFridge.Forms
{
    partial class frmCreateEditFoodRequestItem
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
            lblFood = new Label();
            lblCity = new Label();
            lblUnit = new Label();
            cmbFood = new ComboBox();
            cmbUnit = new ComboBox();
            nudQuantity = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(242, 131);
            btnCancel.Margin = new Padding(2, 2, 2, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(78, 20);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Canc&el";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(324, 131);
            btnSave.Margin = new Padding(2, 2, 2, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(78, 20);
            btnSave.TabIndex = 6;
            btnSave.Text = "Sa&ve";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // lblFood
            // 
            lblFood.AutoSize = true;
            lblFood.Location = new Point(85, 22);
            lblFood.Margin = new Padding(2, 0, 2, 0);
            lblFood.Name = "lblFood";
            lblFood.Size = new Size(34, 15);
            lblFood.TabIndex = 0;
            lblFood.Text = "&Food";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(85, 73);
            lblCity.Margin = new Padding(2, 0, 2, 0);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(53, 15);
            lblCity.TabIndex = 2;
            lblCity.Text = "&Quantity";
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(324, 73);
            lblUnit.Margin = new Padding(2, 0, 2, 0);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(29, 15);
            lblUnit.TabIndex = 4;
            lblUnit.Text = "&Unit";
            // 
            // cmbFood
            // 
            cmbFood.FormattingEnabled = true;
            cmbFood.Items.AddRange(new object[] { "-", "Carrots", "Potatoes", "..." });
            cmbFood.Location = new Point(85, 39);
            cmbFood.Margin = new Padding(2, 2, 2, 2);
            cmbFood.Name = "cmbFood";
            cmbFood.Size = new Size(319, 23);
            cmbFood.TabIndex = 1;
            // 
            // cmbUnit
            // 
            cmbUnit.FormattingEnabled = true;
            cmbUnit.Items.AddRange(new object[] { "KG", "L", "..." });
            cmbUnit.Location = new Point(324, 88);
            cmbUnit.Margin = new Padding(2, 2, 2, 2);
            cmbUnit.Name = "cmbUnit";
            cmbUnit.Size = new Size(80, 23);
            cmbUnit.TabIndex = 5;
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(85, 89);
            nudQuantity.Margin = new Padding(2, 2, 2, 2);
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(235, 23);
            nudQuantity.TabIndex = 3;
            nudQuantity.ThousandsSeparator = true;
            // 
            // frmCreateEditFoodRequestItem
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(491, 185);
            Controls.Add(nudQuantity);
            Controls.Add(cmbUnit);
            Controls.Add(cmbFood);
            Controls.Add(btnCancel);
            Controls.Add(lblUnit);
            Controls.Add(btnSave);
            Controls.Add(lblCity);
            Controls.Add(lblFood);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCreateEditFoodRequestItem";
            Text = "Food Request Item";
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private Label lblStreetNumber;
        private TextBox txtStreetNumber;
        private Label lblFood;
        private Label lblCity;
        private Label lblUnit;
        private ComboBox cmbFood;
        private ComboBox cmbUnit;
        private NumericUpDown nudQuantity;
    }
}