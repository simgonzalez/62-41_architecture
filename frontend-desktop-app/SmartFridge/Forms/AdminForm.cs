using System.ComponentModel;
using SmartFridge.Forms;
using SmartFridge.Models;
using SmartFridge.Services;

namespace SmartFridge
{
    public partial class frmAdmin : Form, FormReloadData
    {
        private HashSet<int> modifiedRows = new HashSet<int>();
        private System.Windows.Forms.Timer filterTimer;
        private CancellationTokenSource cancellationTokenSource;

        public frmAdmin()
        {
            InitializeComponent();
            filterTimer = new System.Windows.Forms.Timer();
            filterTimer.Interval = 500; 
            filterTimer.Tick += FilterTimer_Tick;
        }
        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            RestartFilterTimer();
        }

        private void txtFilterCity_TextChanged(object sender, EventArgs e)
        {
            RestartFilterTimer();
        }

        private void RestartFilterTimer()
        {
            // Stop the timer if it's already running
            filterTimer.Stop();

            // Restart the timer
            filterTimer.Start();
        }

        private async void FilterTimer_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            filterTimer.Stop();

            // Cancel any ongoing request
            cancellationTokenSource?.Cancel();

            // Create a new CancellationTokenSource
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                // Get filter values
                string name = txtFilterOrganization.Text;
                string city = txtFilterCity.Text;

                // Build query parameters
                var queryParams = new List<string>();
                if (!string.IsNullOrWhiteSpace(name)) queryParams.Add($"name={Uri.EscapeDataString(name)}");
                if (!string.IsNullOrWhiteSpace(city)) queryParams.Add($"city={Uri.EscapeDataString(city)}");

                string queryString = string.Join("&", queryParams);

                // Send the filtered request
                var organizations = await BackendService.GetFilteredOrganizationsAsync(queryString, cancellationTokenSource.Token);

                // Update the DataGridView
                dgvOrganization.DataSource = null;
                dgvOrganization.DataSource = organizations;
            }
            catch (OperationCanceledException)
            {
                // Request was canceled, no action needed
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAddLine_Click(object sender, EventArgs e)
        {
            new frmCreateEditOrganization(this).ShowDialog();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            _ = frmAdmin_LoadAsync(sender, e);
        }

        public void reloadOrganizationData()
        {
            _ = frmAdmin_LoadAsync(this, EventArgs.Empty);
        }

        private async Task frmAdmin_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                var organizations = await BackendService.GetOrganizationsAsync();

                dgvOrganization.DataSource = organizations;

                var descriptionColumn = dgvOrganization.Columns["Description"];
                if (descriptionColumn != null)
                {
                    descriptionColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load organizations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrganization_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrganization.Columns[e.ColumnIndex].Name == "Address" && e.Value is Address address)
            {
                e.Value = $"{address.Npa}, {address.City}";
                e.FormattingApplied = true;
            }
        }

        private void dgvOrganization_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrganization.Columns[e.ColumnIndex].Name == "Address")
            {
                var address = dgvOrganization.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as Address;
                if (address != null)
                {
                    MessageBox.Show(
                        $"Street: {address.Street_Name} {address.Street_Number}\n" +
                        $"NPA: {address.Npa}\n" +
                        $"City: {address.City}",
                        "Address Details",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        private void dgvOrganization_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedOrganization = dgvOrganization.Rows[e.RowIndex].DataBoundItem as Organization;

                if (selectedOrganization != null)
                {
                    using (var editForm = new frmCreateEditOrganization(this, selectedOrganization))
                    {
                        editForm.ShowDialog();
                    }
                }
            }
        }

        private void tcAdminPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            modifiedRows.Clear();
            if (tcAdminPanel.SelectedTab == tpUsers)
            {
                Task.Run(async () =>
                {
                    try
                    {
                        var users = await BackendService.GetUsersAsync();

                        // Convert the list to a BindingList
                        var bindingList = new BindingList<User>(users);

                        Invoke(new Action(() =>
                        {
                            dgvUsers.DataSource = null;
                            dgvUsers.Columns.Clear();

                            // Add columns for user properties
                            var idColumn = new DataGridViewTextBoxColumn
                            {
                                HeaderText = "ID",
                                Name = "Id",
                                DataPropertyName = "Id",
                                ReadOnly = true // Mark as read-only
                            };
                            dgvUsers.Columns.Add(idColumn);

                            var nameColumn = new DataGridViewTextBoxColumn
                            {
                                HeaderText = "Name",
                                Name = "Name",
                                DataPropertyName = "Name",
                                ReadOnly = false // Editable
                            };
                            dgvUsers.Columns.Add(nameColumn);

                            var emailColumn = new DataGridViewTextBoxColumn
                            {
                                HeaderText = "Email",
                                Name = "Email",
                                DataPropertyName = "Email",
                                ReadOnly = false, // Editable
                                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Fill available space
                            };
                            dgvUsers.Columns.Add(emailColumn);

                            var firstNameColumn = new DataGridViewTextBoxColumn
                            {
                                HeaderText = "First Name",
                                Name = "First_Name",
                                DataPropertyName = "First_Name",
                                ReadOnly = false // Editable
                            };
                            dgvUsers.Columns.Add(firstNameColumn);

                            // Add a single column for Role
                            var roleColumn = new DataGridViewTextBoxColumn
                            {
                                HeaderText = "Role",
                                Name = "Role",
                                DataPropertyName = "Role", // Bind to the Role property
                                ReadOnly = false // Editable
                            };
                            dgvUsers.Columns.Add(roleColumn);

                            // Add a delete button column
                            var deleteButtonColumn = new DataGridViewButtonColumn
                            {
                                HeaderText = "Actions",
                                Name = "Delete",
                                Text = "Delete",
                                UseColumnTextForButtonValue = true
                            };
                            dgvUsers.Columns.Add(deleteButtonColumn);

                            // Allow editing and adding rows
                            dgvUsers.AllowUserToAddRows = true;
                            dgvUsers.ReadOnly = false;

                            // Bind the data directly to the BindingList
                            dgvUsers.DataSource = bindingList;

                            // Ensure only specific columns are editable
                            dgvUsers.Columns["Name"].ReadOnly = false;
                            dgvUsers.Columns["Email"].ReadOnly = false;
                            dgvUsers.Columns["First_Name"].ReadOnly = false;
                            dgvUsers.Columns["Role"].ReadOnly = false;

                            // Hide the Password column if it exists
                            if (dgvUsers.Columns.Contains("Password"))
                            {
                                dgvUsers.Columns["Password"].Visible = false;
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show($"Failed to load users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                });
            }
            else if (tcAdminPanel.SelectedTab == tpUnits)
                {
                    Task.Run(async () =>
                    {
                        try
                        {
                            var units = await BackendService.GetUnitsAsync();

                            // Convert the list to a BindingList
                            var bindingList = new BindingList<Unit>(units);

                            Invoke(new Action(() =>
                            {
                                dgvUnit.DataSource = null;
                                dgvUnit.Columns.Clear();

                                // Add columns for unit properties
                                var idColumn = new DataGridViewTextBoxColumn
                                {
                                    HeaderText = "ID",
                                    Name = "Id",
                                    DataPropertyName = "Id",
                                    ReadOnly = true // Mark as read-only
                                };
                                dgvUnit.Columns.Add(idColumn);

                                var nameColumn = new DataGridViewTextBoxColumn
                                {
                                    HeaderText = "Name",
                                    Name = "Name",
                                    DataPropertyName = "Name",
                                    ReadOnly = false, // Editable
                                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Fill available space

                                };
                                dgvUnit.Columns.Add(nameColumn);

                                var codeColumn = new DataGridViewTextBoxColumn
                                {
                                    HeaderText = "Code",
                                    Name = "Code",
                                    DataPropertyName = "Code",
                                    ReadOnly = false // Editable
                                };
                                dgvUnit.Columns.Add(codeColumn);

                                // Add a delete button column
                                var deleteButtonColumn = new DataGridViewButtonColumn
                                {
                                    HeaderText = "Actions",
                                    Name = "Delete",
                                    Text = "Delete",
                                    UseColumnTextForButtonValue = true
                                };
                                dgvUnit.Columns.Add(deleteButtonColumn);

                                // Allow editing and adding rows
                                dgvUnit.AllowUserToAddRows = true;
                                dgvUnit.ReadOnly = false;

                                // Bind the data directly to the BindingList
                                dgvUnit.DataSource = bindingList;

                                // Ensure only specific columns are editable
                                dgvUnit.Columns["Name"].ReadOnly = false;
                                dgvUnit.Columns["Code"].ReadOnly = false;
                            }));
                        }
                        catch (Exception ex)
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show($"Failed to load units: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }
                    });
                }
        }

        private void dgvUnits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUnit.Columns[e.ColumnIndex] is DataGridViewButtonColumn buttonColumn && buttonColumn.Name == "Delete")
            {
                var unitId = dgvUnit.Rows[e.RowIndex].Cells["Id"].Value as int? ?? 0;

                if (unitId == 0)
                {
                    MessageBox.Show("Cannot delete a new row that hasn't been saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show("Are you sure you want to delete this unit?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    Task.Run(async () =>
                    {
                        try
                        {
                            await BackendService.DeleteUnitAsync(unitId);
                            Invoke(new Action(() =>
                            {
                                dgvUnit.Rows.RemoveAt(e.RowIndex);
                                MessageBox.Show("Unit deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }));
                        }
                        catch (Exception ex)
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show($"Failed to delete unit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }
                    });
                }
            }
        }


        private void dgvUnits_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Mark the row as modified
                modifiedRows.Add(e.RowIndex);
            }
        }

        private void dgvUnits_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && modifiedRows.Contains(e.RowIndex)) // Only process modified rows
            {
                var row = dgvUnit.Rows[e.RowIndex];

                // Extract row data
                var unitId = row.Cells["Id"].Value as int? ?? 0; // Default to 0 for new rows
                var name = row.Cells["Name"].Value?.ToString();
                var code = row.Cells["Code"].Value?.ToString();

                // Validate that no field is null or empty
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(code))
                {
                    MessageBox.Show("All fields must be filled out before saving.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a Unit object
                var unit = new Unit
                {
                    Id = unitId,
                    Name = name,
                    Code = code
                };

                // Determine if it's a new row or an update
                if (unitId == 0)
                {
                    // Send POST request for new rows
                    Task.Run(async () =>
                    {
                        try
                        {
                            await BackendService.CreateUnitAsync(unit);
                            MessageBox.Show("Unit created successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show($"Failed to create unit: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }
                    });
                }
                else
                {
                    // Send PUT request for existing rows
                    Task.Run(async () =>
                    {
                        try
                        {
                            await BackendService.UpdateUnitAsync(unitId, unit);
                            MessageBox.Show("Unit updated successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show($"Failed to update unit: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }
                    });
                }

                // Remove the row from the modified set
                modifiedRows.Remove(e.RowIndex);
            }
        }


        private void dgvUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Mark the row as modified
                modifiedRows.Add(e.RowIndex);
            }
        }
        private void dgvUsers_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && modifiedRows.Contains(e.RowIndex)) // Only process modified rows
            {
                var row = dgvUsers.Rows[e.RowIndex];

                // Extract row data
                var userId = row.Cells["Id"].Value as int? ?? 0; // Default to 0 for new rows
                var name = row.Cells["Name"].Value?.ToString();
                var email = row.Cells["Email"].Value?.ToString();
                var firstName = row.Cells["First_Name"].Value?.ToString();
                var role = row.Cells["Role"].Value?.ToString();

                // Validate that no field is null or empty
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                    string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(role))
                {
                    MessageBox.Show("All fields must be filled out before saving.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a User object
                var user = new User
                {
                    Id = userId,
                    Name = name,
                    Email = email,
                    First_Name = firstName,
                    Role = role,
                    Password = userId == 0 ? "smartfridge123" : null // Set default password for new users
                };

                // Determine if it's a new row or an update
                if (userId == 0)
                {
                    // Send POST request for new rows
                    Task.Run(async () =>
                    {
                        try
                        {
                            await BackendService.CreateUserAsync(user);
                            MessageBox.Show("User created successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show($"Failed to create user: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }
                    });
                }
                else
                {
                    // Send PUT request for existing rows
                    Task.Run(async () =>
                    {
                        try
                        {
                            user.Password = null;
                            await BackendService.UpdateUserAsync(userId, user);
                            MessageBox.Show("User updated successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show($"Failed to update user: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }
                    });
                }

                // Remove the row from the modified set
                modifiedRows.Remove(e.RowIndex);
            }
        }


        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsers.Columns[e.ColumnIndex] is DataGridViewButtonColumn buttonColumn && buttonColumn.Name == "Delete")
            {
                var userId = dgvUsers.Rows[e.RowIndex].Cells["Id"].Value as int? ?? 0;

                if (userId == 0)
                {
                    MessageBox.Show("Cannot delete a new row that hasn't been saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    Task.Run(async () =>
                    {
                        try
                        {
                            await BackendService.DeleteUserAsync(userId);
                            Invoke(new Action(() =>
                            {
                                dgvUsers.Rows.RemoveAt(e.RowIndex);
                                MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }));
                        }
                        catch (Exception ex)
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show($"Failed to delete user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }
                    });
                }
            }
        }
    }
}
