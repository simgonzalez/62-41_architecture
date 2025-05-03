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
    public partial class frmCreateEditOrganization : Form
    {
        private readonly FormReloadData _parentForm;
        private Address _address;
        private Organization _organization; // Store the organization being edited

        // Constructor for creating a new organization
        public frmCreateEditOrganization(FormReloadData parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        // Constructor for editing an existing organization
        public frmCreateEditOrganization(FormReloadData parentForm, Organization organization)
        {
            InitializeComponent();
            _parentForm = parentForm;
            _organization = organization;

            // Populate fields with existing organization data
            txtName.Text = organization.Name;
            txtDescription.Text = organization.Description;
            _address = organization.Address;

            if (_address != null)
            {
                txtAddress.Text = $"{_address.Npa} {_address.City}";
            }
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            using (var addressForm = new frmCreateEditAddress(_address)) // Pass the existing address for editing
            {
                if (addressForm.ShowDialog() == DialogResult.OK)
                {
                    _address = addressForm.Address;
                    txtAddress.Text = $"{_address.Npa} {_address.City}";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_address == null)
            {
                MessageBox.Show("Please enter an address before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var organization = new Organization
            {
                Id = _organization?.Id ?? 0, // Use the existing ID if editing
                Name = txtName.Text,
                Description = txtDescription.Text,
                Address = _address
            };

            Task.Run(async () =>
            {
                try
                {
                    Organization result;
                    if (_organization == null)
                    {
                        result = await BackendService.CreateOrganizationAsync(organization);
                    }
                    else
                    {
                        result = await BackendService.UpdateOrganizationAsync(organization.Id, organization);
                    }

                    if (result != null)
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show($"Organization '{result.Name}' saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _parentForm.reloadOrganizationData();
                            Close();
                        }));
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show("Failed to save the organization. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show($"Failed to save organization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            });
        }
    }
}
