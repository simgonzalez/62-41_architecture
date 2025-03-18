﻿namespace SmartFridge.Forms
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
            comboBox1 = new ComboBox();
            nudQuantity = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(345, 219);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Canc&el";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(463, 219);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 6;
            btnSave.Text = "Sa&ve";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // lblFood
            // 
            lblFood.AutoSize = true;
            lblFood.Location = new Point(121, 37);
            lblFood.Name = "lblFood";
            lblFood.Size = new Size(54, 25);
            lblFood.TabIndex = 0;
            lblFood.Text = "&Food";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(121, 121);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(80, 25);
            lblCity.TabIndex = 2;
            lblCity.Text = "&Quantity";
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(463, 121);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(44, 25);
            lblUnit.TabIndex = 4;
            lblUnit.Text = "&Unit";
            // 
            // cmbFood
            // 
            cmbFood.FormattingEnabled = true;
            cmbFood.Items.AddRange(new object[] { "-", "Carrots", "Potatoes", "..." });
            cmbFood.Location = new Point(121, 65);
            cmbFood.Name = "cmbFood";
            cmbFood.Size = new Size(454, 33);
            cmbFood.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "KG", "L", "..." });
            comboBox1.Location = new Point(463, 147);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(112, 33);
            comboBox1.TabIndex = 5;
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(121, 149);
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(336, 31);
            nudQuantity.TabIndex = 3;
            nudQuantity.ThousandsSeparator = true;
            // 
            // frmCreateEditFoodRequestItem
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(702, 308);
            Controls.Add(nudQuantity);
            Controls.Add(comboBox1);
            Controls.Add(cmbFood);
            Controls.Add(btnCancel);
            Controls.Add(lblUnit);
            Controls.Add(btnSave);
            Controls.Add(lblCity);
            Controls.Add(lblFood);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
        private ComboBox comboBox1;
        private NumericUpDown nudQuantity;
    }
}