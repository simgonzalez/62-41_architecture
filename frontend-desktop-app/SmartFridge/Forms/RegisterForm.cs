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
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    string firstName = txtFirstName.Text;
                    string name = txtName.Text;
                    string email = txtEmail.Text;
                    string password = txtPassword.Text;

                    await BackendService.RegisterAsync(firstName, name, email, password);

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
                    MessageBox.Show($"Registration failed: {ex.Message}");
                }
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please enter your first name.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter your name.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter your email.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter a password.");
                return false;
            }
            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }
            return true;
        }

    }
}
