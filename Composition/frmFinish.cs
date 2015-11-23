using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Composition
{
    /// <summary>
    /// Form Finish Class
    /// Form notifying users that output to disk has finished and allows them to open the directory with the output.
    /// </summary>
    public partial class frmFinish : Form
    {
        private string _fullFilePath = "";

        public frmFinish(string fullFilePath)
        {
            InitializeComponent();
            _fullFilePath = fullFilePath;
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void lblProjectFileName_Click(object sender, EventArgs e)
        {
            OpenExplorer();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            OpenExplorer();
        }

        private void OpenExplorer()
        {
            Process.Start("explorer.exe", "/select, " + _fullFilePath);
        }

        private void frmFinish_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
