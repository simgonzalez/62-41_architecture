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

namespace SmartFridge.Forms
{
    public partial class frmCreateEditAddress : Form
    {
        public Address Address { get; private set; }

        // Constructor for creating a new address
        public frmCreateEditAddress()
        {
            InitializeComponent();
        }

        // Constructor for editing an existing address
        public frmCreateEditAddress(Address address)
        {
            InitializeComponent();

            if (address != null)
            {
                Address = address;

                // Populate fields with existing address data
                txtStreet.Text = address.Street_Name;
                txtStreetNumber.Text = address.Street_Number;
                txtNpa.Text = address.Npa;
                txtCity.Text = address.City;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Address = new Address
                {
                    Id = Address?.Id ?? 0, // Use the existing ID if editing
                    Street_Name = txtStreet.Text,
                    Street_Number = txtStreetNumber.Text,
                    Npa = txtNpa.Text,
                    City = txtCity.Text
                };

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save address: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
