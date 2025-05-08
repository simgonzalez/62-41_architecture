using SmartFridge.Models;
using SmartFridge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFridge.Forms
{
    public partial class frmAddMember : Form
    {
        private int _organizationId;

        public frmAddMember(int organizationId)
        {
            InitializeComponent();
            _organizationId = organizationId;
        }

        private async void frmAddMember_Load(object sender, EventArgs e)
        {
            try
            {
                // Fetch all users
                var allUsers = await BackendService.GetUsersForOrganizationAsync();

                // Fetch current members of the organization
                var currentMembers = await BackendService.GetOrganizationUsersAsync(_organizationId);

                // Filter out users who are already part of the organization
                var availableUsers = allUsers.Where(user => !currentMembers.Any(member => member.Id == user.Id)).ToList();

                // Bind the filtered data to the ComboBox
                cmbUsers.DataSource = availableUsers;
                cmbUsers.DisplayMember = "Name"; // Display the user's name
                cmbUsers.ValueMember = "Id";    // Use the user's ID as the value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddMember_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem != null)
            {
                var selectedUser = (User)cmbUsers.SelectedItem;

                try
                {
                    // Add the selected user to the organization
                    await BackendService.AddUserToOrganizationAsync(_organizationId, selectedUser.Id);

                    MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Set DialogResult to OK to signal success
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while adding the user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to add.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
