﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartFridge.Forms;

namespace SmartFridge
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private Boolean validateForm()
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Please enter a username");
                return false;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter a password");
                return false;
            }
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (validateForm()) {
                if(txtUsername.Text == "org")
                {
                    Hide();
                    new frmOrganization().ShowDialog();
                    Close();
                }
                Hide();
                new frmAdmin().ShowDialog();
                Close();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmRegister().ShowDialog();
            this.Show();
        }
    }
}
