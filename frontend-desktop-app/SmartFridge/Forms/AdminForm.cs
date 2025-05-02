using SmartFridge.Forms;
using SmartFridge.Models;
using SmartFridge.Services;

namespace SmartFridge
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }


        private void btnAddLine_Click(object sender, EventArgs e)
        {
            new frmCreateEditOrganization().ShowDialog();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            _ = frmAdmin_LoadAsync(sender, e);
        }

        public void reloadOrganization()
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
    }
}
