using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Composition.Views;

namespace Composition
{
    /// <summary>
    /// Form Start Class
    /// The main (GUI) entry point.
    /// First step of the process
    /// Allows users to enter in details about the screen they are about to analyse
    /// </summary>
    public partial class frmStart : Form
    {
        private Bitmap _draggedImage;

        private frmWaiting _frmWaiting = new frmWaiting();

        public frmStart()
        {
            InitializeComponent();
            DropLoop(this);

            instructionTextBox.Text = Instructions.Step[0].Text;
        }

        private void DropLoop(Control control)
        {
            Control.ControlCollection collection = control.Controls;
            foreach (Control c in collection)
            {
                c.AllowDrop = true;
                c.DragEnter += new DragEventHandler(frmStart_DragEnter);
                c.DragDrop += new DragEventHandler(frmStart_DragDrop);
                DropLoop(c);
            }
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            instructionTextBox.Text = Instructions.Step[0].Text;
        }

        private void frmStart_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                _draggedImage = new Bitmap(fileList[0]);

                selectionPanel.BackgroundImageLayout = ImageLayout.Zoom;
                selectionPanel.BackgroundImage = _draggedImage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void frmStart_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bool canProceed = true;
            string message = "";

            if (txtScreenName.Text == "" || txtOrgURL.Text == "" || txtAppName.Text == "")
            {
                canProceed = false;
                message = "Please fill in all options!";
            }
            else if (_draggedImage == null)
            {
                canProceed = false;
                message = "Please drag an image in!";
            }

            if (canProceed && char.IsDigit(txtScreenName.Text[0]))
            {
                canProceed = false;
                message = "Screen name cannot start with a number";
            }

            if (canProceed && char.IsDigit(txtOrgURL.Text[0]))
            {
                canProceed = false;
                message = "Organisation URL cannot start with a number";
            }

            if (canProceed && char.IsDigit(txtAppName.Text[0]))
            {
                canProceed = false;
                message = "App name cannot start with a number";
            }

            if (canProceed)
            {
                _frmWaiting.Show();
                backgroundWorker.RunWorkerAsync();
                this.Hide();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = new frmActionBarSelection(_draggedImage, txtScreenName.Text, txtAppName.Text, txtOrgURL.Text);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((Form)e.Result).Show();
            _frmWaiting.Hide();
        }

        private void pbVideoHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("VideoHelp\\CompositionHelp.exe", "1");
            }
            catch (Exception)
            {
                MessageBox.Show("Could not open video help");
            }
        }

    }
}
