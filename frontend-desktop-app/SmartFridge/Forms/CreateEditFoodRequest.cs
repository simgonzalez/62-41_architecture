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
    public partial class frmCreateEditFoodRequest : Form
    {
        public frmCreateEditFoodRequest()
        {
            InitializeComponent();
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            new frmCreateEditFoodRequestItem().ShowDialog();
        }
    }
}
