using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartFridge.Models;
using SmartFridge.Services;

namespace SmartFridge.Forms
{
    public partial class frmOrganization : Form, FormReloadData
    {
        private const int TAB_ORGANIZATION_INFORMATION = 2;
        private const int TAB_MEMBERS = 1;
        
        private Organization Organization;
        private System.Windows.Forms.Timer filterTimer;
        private CancellationTokenSource cancellationTokenSource;

        private frmCreateEditOrganization organizationForm;
        public frmOrganization()
        {
            InitializeComponent();
            LoadOrganizationAsync();

            filterTimer = new System.Windows.Forms.Timer();
            filterTimer.Interval = 500; 
            filterTimer.Tick += FilterTimer_Tick;
        }

        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            RestartFilterTimer();
        }

        private void txtFilterDescription_TextChanged(object sender, EventArgs e)
        {
            RestartFilterTimer();
        }

        private void RestartFilterTimer()
        {
            filterTimer.Stop();

            filterTimer.Start();
        }

        private async void FilterTimer_Tick(object sender, EventArgs e)
        {
            filterTimer.Stop();

            cancellationTokenSource?.Cancel();

            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                string name = txtFilterRequestName.Text;
                string description = txtRequestDescription.Text;

                // Build query parameters
                var queryParams = new List<string>();
                if (!string.IsNullOrWhiteSpace(name)) queryParams.Add($"name={Uri.EscapeDataString(name)}");
                if (!string.IsNullOrWhiteSpace(description)) queryParams.Add($"description={Uri.EscapeDataString(description)}");

                string queryString = string.Join("&", queryParams);

                // Send the filtered request
                var foodRequests = await BackendService.GetFilteredFoodRequestsAsync(queryString, cancellationTokenSource.Token);

                // Update the DataGridView
                dgvFoodRequest.DataSource = null;
                dgvFoodRequest.DataSource = foodRequests;

                // Hide all columns by default
                foreach (DataGridViewColumn column in dgvFoodRequest.Columns)
                {
                    column.Visible = false;
                }

                // Show only relevant columns
                dgvFoodRequest.Columns["Id"].Visible = true;
                dgvFoodRequest.Columns["Id"].HeaderText = "Food Request ID";

                dgvFoodRequest.Columns["Name"].Visible = true;
                dgvFoodRequest.Columns["Name"].HeaderText = "Name";

                dgvFoodRequest.Columns["Description"].Visible = true;
                dgvFoodRequest.Columns["Description"].HeaderText = "Description";

                dgvFoodRequest.Columns["DeadlineDate"].Visible = true;
                dgvFoodRequest.Columns["DeadlineDate"].HeaderText = "Deadline";

                dgvFoodRequest.Columns["Status"].Visible = true;
                dgvFoodRequest.Columns["Status"].HeaderText = "Status";

                dgvFoodRequest.Columns["OrganizationName"].Visible = true;
                dgvFoodRequest.Columns["OrganizationName"].HeaderText = "Organization";

                dgvFoodRequest.Columns["ResponsibleUserName"].Visible = true;
                dgvFoodRequest.Columns["ResponsibleUserName"].HeaderText = "Responsible User";

                dgvFoodRequest.Columns["CreatedByUserName"].Visible = true;
                dgvFoodRequest.Columns["CreatedByUserName"].HeaderText = "Created By";

                // Optionally, set column display order
                dgvFoodRequest.Columns["Id"].DisplayIndex = 0;
                dgvFoodRequest.Columns["Name"].DisplayIndex = 1;
                dgvFoodRequest.Columns["Description"].DisplayIndex = 2;
                dgvFoodRequest.Columns["DeadlineDate"].DisplayIndex = 3;
                dgvFoodRequest.Columns["Status"].DisplayIndex = 4;
                dgvFoodRequest.Columns["OrganizationName"].DisplayIndex = 5;
                dgvFoodRequest.Columns["ResponsibleUserName"].DisplayIndex = 6;
                dgvFoodRequest.Columns["CreatedByUserName"].DisplayIndex = 7;

                dgvFoodRequest.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void LoadOrganizationAsync()
        {
            this.Organization = await BackendService.GetCurrentUserOrganizationAsync();
        }


        private void TabOrganizationPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabOrganizationPanel.SelectedIndex == TAB_ORGANIZATION_INFORMATION)
            {
                ForceRenderFormInTab();
            }
            else if (tabOrganizationPanel.SelectedIndex == TAB_MEMBERS)
            {
                if (Organization != null)
                {
                    LoadOrganizationUsers(Organization.Id);
                }
                else
                {
                    MessageBox.Show("Organization information is not loaded. Please ensure the organization is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvFoodRequest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the double-click is on a valid row
            if (e.RowIndex >= 0)
            {
                // Get the selected FoodRequest object
                var selectedFoodRequest = (FoodRequest)dgvFoodRequest.Rows[e.RowIndex].DataBoundItem;

                // Open the Create/Edit form with the selected FoodRequest
                using (var editFoodRequestForm = new frmCreateEditFoodRequest(selectedFoodRequest))
                {
                    if (editFoodRequestForm.ShowDialog() == DialogResult.OK)
                    {
                        // Reload the list of food requests after editing
                        LoadFoodRequests();
                    }
                }
            }
        }

        private async void ForceRenderFormInTab()
        {
            try
            {
               
                if (organizationForm == null || organizationForm.IsDisposed)
                {
                    // Pass the retrieved organization to the frmCreateEditOrganization form
                    organizationForm = new frmCreateEditOrganization(this, Organization);
                    organizationForm.TopLevel = false;
                    organizationForm.FormBorderStyle = FormBorderStyle.None;
                    organizationForm.Dock = DockStyle.Fill;
                }

                var targetTabPage = tabOrganizationPanel.TabPages[2];
                targetTabPage.Controls.Clear();

                targetTabPage.Controls.Add(organizationForm);
                organizationForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the organization information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAddMember_Click(object sender, EventArgs e)
        {
            using (var addMemberForm = new frmAddMember(Organization.Id))
            {
                if (addMemberForm.ShowDialog() == DialogResult.OK)
                {
                    // Reload the members list after adding a new member
                    LoadOrganizationUsers(Organization.Id);
                }
            }
        }


        private void btnCreateFoodRequest_Click(object sender, EventArgs e)
        {
            using (var createFoodRequestForm = new frmCreateEditFoodRequest())
            {
                if (createFoodRequestForm.ShowDialog() == DialogResult.OK)
                {
                    LoadFoodRequests();
                }
            }
        }


        private async void LoadFoodRequests()
        {
            try
            {
                // Fetch food requests from the backend
                var foodRequests = await BackendService.GetFoodRequestsAsync();

                // Bind the data to the DataGridView
                dgvFoodRequest.DataSource = null;
                dgvFoodRequest.DataSource = foodRequests;

                // Hide all columns by default
                foreach (DataGridViewColumn column in dgvFoodRequest.Columns)
                {
                    column.Visible = false;
                }

                // Show only relevant columns
                dgvFoodRequest.Columns["Id"].Visible = true;
                dgvFoodRequest.Columns["Id"].HeaderText = "Food Request ID";

                dgvFoodRequest.Columns["Name"].Visible = true;
                dgvFoodRequest.Columns["Name"].HeaderText = "Name";

                dgvFoodRequest.Columns["Description"].Visible = true;
                dgvFoodRequest.Columns["Description"].HeaderText = "Description";

                dgvFoodRequest.Columns["DeadlineDate"].Visible = true;
                dgvFoodRequest.Columns["DeadlineDate"].HeaderText = "Deadline";

                dgvFoodRequest.Columns["Status"].Visible = true;
                dgvFoodRequest.Columns["Status"].HeaderText = "Status";

                dgvFoodRequest.Columns["OrganizationName"].Visible = true;
                dgvFoodRequest.Columns["OrganizationName"].HeaderText = "Organization";

                dgvFoodRequest.Columns["ResponsibleUserName"].Visible = true;
                dgvFoodRequest.Columns["ResponsibleUserName"].HeaderText = "Responsible User";

                dgvFoodRequest.Columns["CreatedByUserName"].Visible = true;
                dgvFoodRequest.Columns["CreatedByUserName"].HeaderText = "Created By";

                // Optionally, set column display order
                dgvFoodRequest.Columns["Id"].DisplayIndex = 0;
                dgvFoodRequest.Columns["Name"].DisplayIndex = 1;
                dgvFoodRequest.Columns["Description"].DisplayIndex = 2;
                dgvFoodRequest.Columns["DeadlineDate"].DisplayIndex = 3;
                dgvFoodRequest.Columns["Status"].DisplayIndex = 4;
                dgvFoodRequest.Columns["OrganizationName"].DisplayIndex = 5;
                dgvFoodRequest.Columns["ResponsibleUserName"].DisplayIndex = 6;
                dgvFoodRequest.Columns["CreatedByUserName"].DisplayIndex = 7;

                // Optionally, auto-size columns for better readability
                dgvFoodRequest.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading food requests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void OrganizationForm_Load(object sender, EventArgs e)
        {
            // Call the method to load food requests when the form loads
            LoadFoodRequests();
        }

        public void reloadOrganizationData()
        {
            ForceRenderFormInTab();
        }

        private async void LoadOrganizationUsers(int organizationId)
        {
            try
            {
                // Fetch users from the backend
                var users = await BackendService.GetOrganizationUsersAsync(organizationId);

                // Bind the full User objects to the DataGridView
                dgvMembers.DataSource = null;
                dgvMembers.DataSource = users;
                dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // Customize column headers
                dgvMembers.Columns["Id"].HeaderText = "ID";
                dgvMembers.Columns["Name"].HeaderText = "Name";
                dgvMembers.Columns["First_Name"].HeaderText = "First Name";
                dgvMembers.Columns["Email"].HeaderText = "Email";

                // Hide unwanted columns
                if (dgvMembers.Columns.Contains("Role"))
                    dgvMembers.Columns["Role"].Visible = false;
                if (dgvMembers.Columns.Contains("Password"))
                    dgvMembers.Columns["Password"].Visible = false;

                // Add a "Delete" button column if it doesn't already exist
                if (!dgvMembers.Columns.Contains("Delete"))
                {
                    var deleteButtonColumn = new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "Actions",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    dgvMembers.Columns.Add(deleteButtonColumn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading organization users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0)
            {
                var selectedUser = (User)dgvMembers.SelectedRows[0].DataBoundItem;

                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to remove {selectedUser.Name} from the organization?",
                    "Confirm Remove",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Remove the user from the organization
                        await BackendService.RemoveUserFromOrganizationAsync(Organization.Id, selectedUser.Id);

                        // Reload the users
                        LoadOrganizationUsers(Organization.Id);

                        MessageBox.Show("User removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while removing the user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to remove.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMembers.Columns[e.ColumnIndex].Name == "Delete")
            {
                var selectedUser = (User)dgvMembers.Rows[e.RowIndex].DataBoundItem;

                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to remove {selectedUser.Name} from the organization?",
                    "Confirm Remove",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Remove the user from the organization
                        await BackendService.RemoveUserFromOrganizationAsync(Organization.Id, selectedUser.Id);

                        // Reload the users
                        LoadOrganizationUsers(Organization.Id);

                        MessageBox.Show("User removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while removing the user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
