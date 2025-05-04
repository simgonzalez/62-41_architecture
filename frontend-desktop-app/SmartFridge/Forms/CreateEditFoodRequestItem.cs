using SmartFridge.Models;
using SmartFridge.Models.SmartFridge.Models;
using SmartFridge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFridge.Forms
{
    public partial class frmCreateEditFoodRequestItem : Form
    {
        public FoodRequestItem FoodRequestItem { get; private set; }

        public frmCreateEditFoodRequestItem()
        {
            InitializeComponent();
        }

        private async void frmCreateEditFoodRequestItem_Load(object sender, EventArgs e)
        {
            try
            {
                // Load foods
                var foods = await BackendService.getFoodsAsync();
                cmbFood.DataSource = foods;
                cmbFood.DisplayMember = "Name";
                cmbFood.ValueMember = "Id";

                // Load units
                var units = await BackendService.GetUnitsAsync();
                cmbUnit.DataSource = units;
                cmbUnit.DisplayMember = "Name";
                cmbUnit.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbFood.SelectedItem == null || cmbUnit.SelectedItem == null || decimal.IsNegative(nudQuantity.Value))
            {
                MessageBox.Show("Please select a food, a unit, and enter a quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(nudQuantity.Text, out var quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create the FoodRequestItem object
            FoodRequestItem = new FoodRequestItem
            {
                FoodId = int.Parse(cmbFood.SelectedValue.ToString()),
                FoodName = cmbFood.Text,
                UnitId = int.Parse(cmbUnit.SelectedValue.ToString()),
                UnitName = cmbUnit.Text,
                Quantity = quantity
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
