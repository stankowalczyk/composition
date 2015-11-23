using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompositionTests
{
    /// <summary>
    /// Form Start
    /// Main entry form
    /// Allows for performing one of many options
    /// </summary>
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void btnCreateButton_Click(object sender, EventArgs e)
        {
            new frmSelection(WidgetType.Button).Show();
        }

        private void btnCreateImage_Click(object sender, EventArgs e)
        {
            new frmSelection(WidgetType.Image).Show();
        }

        private void btnCreateLabel_Click(object sender, EventArgs e)
        {
            new frmSelection(WidgetType.Label).Show();
        }

        private void btnCreateTextView_Click(object sender, EventArgs e)
        {
            new frmSelection(WidgetType.TextField).Show();
        }

        private void btnCreateMap_Click(object sender, EventArgs e)
        {
            new frmSelection(WidgetType.Map).Show();
        }

        private void btnRunButtonTest_Click(object sender, EventArgs e)
        {
            new frmTest(WidgetType.Button).Show();
        }

        private void btnRunImageTest_Click(object sender, EventArgs e)
        {
            new frmTest(WidgetType.Image).Show();
        }

        private void btnRunLabelTest_Click(object sender, EventArgs e)
        {
            new frmTest(WidgetType.Label).Show();
        }

        private void btnRunTextViewTest_Click(object sender, EventArgs e)
        {
            new frmTest(WidgetType.TextField).Show();
        }

        private void btnRunMapTestData_Click(object sender, EventArgs e)
        {
            new frmTest(WidgetType.Map).Show();
        }

        private void btnRefineTestData_Click(object sender, EventArgs e)
        {
            new frmRefine().Show();
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            new frmToCSV().Show();
        }
    }
}
