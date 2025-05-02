namespace SmartFridge.Forms
{
    partial class frmCreateEditAddress
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
            lblStreet = new Label();
            txtStreet = new TextBox();
            txtStreetNumber = new TextBox();
            lblStreetNumber = new Label();
            txtCity = new TextBox();
            lblCity = new Label();
            txtCanton = new TextBox();
            lblCanton = new Label();
            btnSave = new Button();
            lblNpa = new Label();
            txtNpa = new TextBox();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblStreet
            // 
            lblStreet.AutoSize = true;
            lblStreet.Location = new Point(107, 49);
            lblStreet.Name = "lblStreet";
            lblStreet.Size = new Size(57, 25);
            lblStreet.TabIndex = 0;
            lblStreet.Text = "&Street";
            // 
            // txtStreet
            // 
            txtStreet.Location = new Point(107, 77);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new Size(336, 31);
            txtStreet.TabIndex = 1;
            // 
            // txtStreetNumber
            // 
            txtStreetNumber.Location = new Point(451, 77);
            txtStreetNumber.Name = "txtStreetNumber";
            txtStreetNumber.Size = new Size(112, 31);
            txtStreetNumber.TabIndex = 2;
            // 
            // lblStreetNumber
            // 
            lblStreetNumber.AutoSize = true;
            lblStreetNumber.Location = new Point(451, 49);
            lblStreetNumber.Name = "lblStreetNumber";
            lblStreetNumber.Size = new Size(36, 25);
            lblStreetNumber.TabIndex = 3;
            lblStreetNumber.Text = "&No";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(107, 161);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(336, 31);
            txtCity.TabIndex = 5;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(107, 133);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(42, 25);
            lblCity.TabIndex = 4;
            lblCity.Text = "&City";
            // 
            // txtCanton
            // 
            txtCanton.Location = new Point(107, 248);
            txtCanton.Name = "txtCanton";
            txtCanton.Size = new Size(456, 31);
            txtCanton.TabIndex = 9;
            // 
            // lblCanton
            // 
            lblCanton.AutoSize = true;
            lblCanton.Location = new Point(107, 220);
            lblCanton.Name = "lblCanton";
            lblCanton.Size = new Size(69, 25);
            lblCanton.TabIndex = 8;
            lblCanton.Text = "C&anton";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(451, 315);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 10;
            btnSave.Text = "Sa&ve";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblNpa
            // 
            lblNpa.AutoSize = true;
            lblNpa.Location = new Point(449, 133);
            lblNpa.Name = "lblNpa";
            lblNpa.Size = new Size(45, 25);
            lblNpa.TabIndex = 6;
            lblNpa.Text = "N&pa";
            // 
            // txtNpa
            // 
            txtNpa.Location = new Point(449, 161);
            txtNpa.Name = "txtNpa";
            txtNpa.Size = new Size(112, 31);
            txtNpa.TabIndex = 7;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(333, 315);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Canc&el";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmCreateEditAddress
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(698, 402);
            Controls.Add(btnCancel);
            Controls.Add(lblNpa);
            Controls.Add(txtNpa);
            Controls.Add(btnSave);
            Controls.Add(txtCanton);
            Controls.Add(lblCanton);
            Controls.Add(txtCity);
            Controls.Add(lblCity);
            Controls.Add(lblStreetNumber);
            Controls.Add(txtStreetNumber);
            Controls.Add(txtStreet);
            Controls.Add(lblStreet);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCreateEditAddress";
            Text = "Address";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStreet;
        private TextBox txtStreet;
        private TextBox txtStreetNumber;
        private Label lblStreetNumber;
        private TextBox txtCity;
        private Label lblCity;
        private TextBox txtCanton;
        private Label lblCanton;
        private Button btnSave;
        private Label lblNpa;
        private TextBox txtNpa;
        private Button btnCancel;
    }
}