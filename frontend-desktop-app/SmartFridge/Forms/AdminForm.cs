using SmartFridge.Forms;

namespace SmartFridge
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvOrganization_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            new frmCreateEditOrganization().ShowDialog();
        }
    }
}
