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
    public partial class frmOrganization : Form, FormReloadData
    {
        private const int TAB_ORGANIZATION_INFORMATION = 2;
        private frmCreateEditOrganization organizationForm;
        public frmOrganization()
        {
            InitializeComponent();
        }

        private void TabOrganizationPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the selected tab is the third one (index 2)
            if (tabOrganizationPanel.SelectedIndex == TAB_ORGANIZATION_INFORMATION)
            {
                ForceRenderFormInTab();
            }
        }

        private void ForceRenderFormInTab()
        {
            if (organizationForm == null || organizationForm.IsDisposed)
            {
                organizationForm = new frmCreateEditOrganization(this);
                organizationForm.TopLevel = false;
                organizationForm.FormBorderStyle = FormBorderStyle.None; organizationForm.Dock = DockStyle.Fill;
            }

            var targetTabPage = tabOrganizationPanel.TabPages[2];
            targetTabPage.Controls.Clear();

            targetTabPage.Controls.Add(organizationForm);
            organizationForm.Show();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            new frmAddMember().ShowDialog();
        }

        private void btnCreateFoodRequest_Click(object sender, EventArgs e)
        {
            new frmCreateEditFoodRequest().ShowDialog();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        public void reloadOrganizationData()
        {
            throw new NotImplementedException();
        }
    }
}
