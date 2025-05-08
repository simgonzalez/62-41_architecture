using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartFridge.Models;
using SmartFridge.Services;

namespace SmartFridge.Forms
{
    public partial class frmCreateEditFoodRequest : Form
    {
        private FoodRequest _foodRequest; // Holds the current FoodRequest being edited or created
        private List<FoodRequestItem> foodRequestItems = new List<FoodRequestItem>();

        public frmCreateEditFoodRequest(FoodRequest foodRequest = null)
        {
            InitializeComponent();

            // If a FoodRequest is passed, we are editing; otherwise, we are creating a new one
            _foodRequest = foodRequest ?? new FoodRequest();
        }

        private async void frmCreateEditFoodRequest_Load(object sender, EventArgs e)
        {
            if (_foodRequest.Id != 0) // Editing an existing FoodRequest
            {
                txtName.Text = _foodRequest.Name;
                txtDescription.Text = _foodRequest.Description;
                dtpDeadline.Value = _foodRequest.DeadlineDate;

                try
                {
                    // Fetch items from the backend
                    foodRequestItems = await BackendService.GetFoodRequestItemsAsync(_foodRequest.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading food request items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    foodRequestItems = new List<FoodRequestItem>();
                }

                UpdateFoodRequestItemsGrid();
            }
        }


        private void btnAddItems_Click(object sender, EventArgs e)
        {
            using (var itemForm = new frmCreateEditFoodRequestItem())
            {
                if (itemForm.ShowDialog() == DialogResult.OK)
                {
                    foodRequestItems.Add(itemForm.FoodRequestItem);
                    UpdateFoodRequestItemsGrid();
                }
            }
        }

        private void UpdateFoodRequestItemsGrid()
        {
            dgvRequestItem.DataSource = null;

            // Create a new binding source to bind only the relevant properties
            var displayItems = foodRequestItems.Select(item => new
            {
                Food = item.Food?.Name, 
                Quantity = item.Quantity,
                Unit = item.Unit?.Name
            }).ToList();

            dgvRequestItem.DataSource = displayItems;

            // Customize column headers
            dgvRequestItem.Columns["Food"].HeaderText = "Food";
            dgvRequestItem.Columns["Quantity"].HeaderText = "Quantity";
            dgvRequestItem.Columns["Unit"].HeaderText = "Unit";
        }




        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (foodRequestItems.Count == 0)
                {
                    MessageBox.Show("At least one item is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Populate the FoodRequest object
                _foodRequest.Name = txtName.Text;
                _foodRequest.Description = txtDescription.Text;
                _foodRequest.DeadlineDate = dtpDeadline.Value;

                if (_foodRequest.Id == 0) 
                {
                    _foodRequest = await BackendService.CreateDataAsync<FoodRequest, FoodRequest>("food-requests", _foodRequest);
                    MessageBox.Show("Food request created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await BackendService.UpdateDataAsync<FoodRequest, FoodRequest>($"food-requests/{_foodRequest.Id}", _foodRequest);
                    MessageBox.Show("Food request updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Save each FoodRequestItem
                foreach (var item in foodRequestItems)
                {
                    item.RequestId = _foodRequest.Id; 
                    await BackendService.CreateFoodRequestItemAsync(_foodRequest.Id, item);
                }

                MessageBox.Show("All items saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the food request: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
