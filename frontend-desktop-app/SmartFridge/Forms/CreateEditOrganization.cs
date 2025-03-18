using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFridge.Forms
{
    public partial class frmCreateEditOrganization : Form
    {
        public frmCreateEditOrganization()
        {
            InitializeComponent();
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            new frmCreateEditAddress().ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
