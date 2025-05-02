using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartFridge.Forms;
using SmartFridge.Services;

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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                try
                {
                    string email = txtUsername.Text;
                    string password = txtPassword.Text;

                    await BackendService.LoginAsync(email, password);

                    var userInfo = await BackendService.GetUserInfoAsync();

                    if (userInfo.Roles.Contains("admin"))
                    {
                        Hide();
                        new frmAdmin().ShowDialog();
                        Close();
                    }
                    else
                    {
                        Hide();
                        new frmOrganization().ShowDialog();
                        Close();
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Login failed: {ex.Message}");
                }
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
