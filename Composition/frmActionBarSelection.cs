using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

using Composition.Views;

namespace Composition
{
    /// <summary>
    /// From Action Bar Selection Class
    /// Second step of the process
    /// Alows the user to select the action bar of a screen
    /// </summary>
    public partial class frmActionBarSelection : Form
    {
        private int _instructionStepNumber = 0;

        private Design _design = new Design();
        private Bitmap _image;

        private Point _firstClickedPoint = new Point(-1, -1);
        private Point _secondClickedPoint = new Point(-1, -1);

        private int _width;
        private int _height;

        private bool _backgroundColourSelectorMode = false;

        private Color _backgroundColor = Color.Empty;

        private int _zoomAmount = 100;

        private frmWaiting _frmWaiting = new frmWaiting();

        private int _currentMousePositionX = 0;
        private int _currentMousePositionY = 0;
        private int _pbPrecisionImageX = 0;
        private int _pbPrecisionImageY = 0;

        public frmActionBarSelection(Bitmap image, string activityName, string appName, string orgURL)
        {
            InitializeComponent();

            (selectionPanel as Control).KeyDown += new KeyEventHandler(this.onKeyDown);
            (selectionPanel as Control).Select();
            (selectionPanel as Control).MouseWheel += new MouseEventHandler(this.onMouseWheel);
            (zoomedImageBox as Control).MouseWheel += new MouseEventHandler(this.onMouseWheel);

            _design.DesignImage = image;
            _design.ZoomPrecisionImage();
            _design.SetActivityName(activityName);
            _design.AppName = appName;
            _design.SetOrgURL(orgURL);

            _design.RegisterActivityNameWithStringsClass();
            _design.RegisterAppNameWithStringsClass();

            _image = _design.DesignImage;
            zoomedImageBox.Width = _image.Width;
            zoomedImageBox.Height = _image.Height;
            zoomedImageBox.BackgroundImage = _image;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                Process.Start("VideoHelp\\CompositionHelp.exe", "intro");
            }
            catch (Exception)
            {
                MessageBox.Show("Could not open video help");
            }

            IncrementStep();

            tmrPreviewUpdate.Enabled = true;
            tmrPreviewUpdate.Start();
        }

        private void UpdateVirtualWidthHeight()
        {
            _height = selectionPanel.Height;
            _width = (selectionPanel.Height / selectionPanel.BackgroundImage.Height) * selectionPanel.BackgroundImage.Width;
        }

        private void selectionPanel_MouseEnter(object sender, EventArgs e)
        {
            selectionPanel.Select();
        }

        private void zoomedImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (_backgroundColourSelectorMode)
            {
                _backgroundColourSelectorMode = false;
                btnBackgroundColour.Text = "";
                _backgroundColor = _design.GetColourAt(e.X, e.Y, zoomedImageBox.Width, zoomedImageBox.Height);
                btnBackgroundColour.BackColor = _backgroundColor;
            }
            else
            {
                if (_firstClickedPoint.X == -1)
                {
                    _firstClickedPoint = new Point(e.X, e.Y);
                    lblFirstPoint.Text = "First point selected";
                    btnClearFirstPoint.Visible = true;

                    firstClickViewPanel.BackgroundImage = _design.GetPointPreview(e.X, e.Y, firstClickViewPanel.Width, firstClickViewPanel.Height, zoomedImageBox.Width, zoomedImageBox.Height);
                }
                else
                {
                    int x1 = 0;
                    int y1 = 0;
                    int x2 = 0;
                    int y2 = 0;

                    if (_firstClickedPoint.X < e.X)
                    {
                        x1 = _firstClickedPoint.X;
                        x2 = e.X;
                    }
                    else
                    {
                        x1 = e.X;
                        x2 = _firstClickedPoint.X;
                    }

                    if (_firstClickedPoint.Y < e.Y)
                    {
                        y1 = _firstClickedPoint.Y;
                        y2 = e.Y;
                    }
                    else
                    {
                        y1 = e.Y;
                        y2 = _firstClickedPoint.Y;
                    }

                    _firstClickedPoint = new Point(-1, -1);
                    lblFirstPoint.Text = "First point not selected";
                    btnClearFirstPoint.Visible = false;
                    firstClickViewPanel.BackgroundImage = null;

                    if (_instructionStepNumber == 1)
                        _design.CreateImageWithAreaGrayedOut(0, 0, _image.Width, y2, zoomedImageBox.Width, zoomedImageBox.Height);

                    this.Hide();

                    _frmWaiting.Show();

                    FrmMainWorkerArgument arg = new FrmMainWorkerArgument();
                    arg.Segment = _design.GetSegment(x1, y1, x2, y2, zoomedImageBox.Width, zoomedImageBox.Height);
                    arg.InstructionStepNumber = _instructionStepNumber;
                    arg.BackgroundColor = _backgroundColor;
                    arg.Design = _design;
                    arg.Caller = this;
                    backgroundWorker.RunWorkerAsync(arg);
                }
            }
        }

        private void zoomedImageBox_MouseEnter(object sender, EventArgs e)
        {
            selectionPanel.Select();
        }

        private void zoomedImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            _currentMousePositionX = e.X;
            _currentMousePositionY = e.Y;

            if (e.Y + zoomedImageBox.Location.Y + 220 > selectionPanel.Height) // Down
            {
                _pbPrecisionImageY = e.Y + zoomedImageBox.Location.Y - 220;
            }
            else
            {
                _pbPrecisionImageY = e.Y + zoomedImageBox.Location.Y + 20;
            }

            if (e.X + zoomedImageBox.Location.X + 220 > selectionPanel.Width) // Right
            {
                _pbPrecisionImageX = e.X + zoomedImageBox.Location.X - 220;
            }
            else
            {
                _pbPrecisionImageX = e.X + zoomedImageBox.Location.X + 20;
            }

            //Console.WriteLine(e.X + " " + e.Y);
            int X = e.X + zoomedImageBox.Location.X;
            int Y = e.Y + zoomedImageBox.Location.Y;

            if (X > selectionPanel.Width - 25) // Left
            {
                if (zoomedImageBox.Location.X + zoomedImageBox.Width > (selectionPanel.Width - 50))
                {
                    zoomedImageBox.Location = new Point(zoomedImageBox.Location.X - 1, zoomedImageBox.Location.Y);
                }
            }
            else if (X < 25) // Right
            {
                if (zoomedImageBox.Location.X < 50)
                {
                    zoomedImageBox.Location = new Point(zoomedImageBox.Location.X + 1, zoomedImageBox.Location.Y);
                }
            }

            if (Y > selectionPanel.Height - 25) // Down
            {
                if (zoomedImageBox.Location.Y + zoomedImageBox.Height > (selectionPanel.Height - 50))
                {
                    zoomedImageBox.Location = new Point(zoomedImageBox.Location.X, zoomedImageBox.Location.Y - 1);
                }
            }
            else if (Y < 25)  // Up
            {
                if (zoomedImageBox.Location.Y < 50)
                {
                    zoomedImageBox.Location = new Point(zoomedImageBox.Location.X, zoomedImageBox.Location.Y + 1);
                }
            }
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W) // Down
            {
                if (zoomedImageBox.Location.Y < 50)
                {
                    zoomedImageBox.Location = new Point(zoomedImageBox.Location.X, zoomedImageBox.Location.Y + 20);
                }
            }
            else if (e.KeyData == Keys.S) // Up
            {
                if (zoomedImageBox.Location.Y + zoomedImageBox.Height > (selectionPanel.Height - 50))
                {
                    zoomedImageBox.Location = new Point(zoomedImageBox.Location.X, zoomedImageBox.Location.Y - 20);
                }
            }

            if (e.KeyData == Keys.A) // Right
            {
                if (zoomedImageBox.Location.X < 50)
                {
                    zoomedImageBox.Location = new Point(zoomedImageBox.Location.X + 20, zoomedImageBox.Location.Y);
                }
            }
            else if (e.KeyData == Keys.D) // Left
            {
                if (zoomedImageBox.Location.X + zoomedImageBox.Width > (selectionPanel.Width - 50))
                {
                    zoomedImageBox.Location = new Point(zoomedImageBox.Location.X - 20, zoomedImageBox.Location.Y);
                }
            }
        }

        private void onMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int zoomAmount = e.Delta * SystemInformation.MouseWheelScrollLines / 120 * -1;

            int oldWidth = zoomedImageBox.Width;

            _zoomAmount += zoomAmount;

            if (_zoomAmount < 10)
                _zoomAmount = 10;

            if (_zoomAmount > 400)
                _zoomAmount = 400;

            zoomedImageBox.Width = (int)(_image.Width * (_zoomAmount / 100.0));
            zoomedImageBox.Height = (int)(_image.Height * (_zoomAmount / 100.0));


            if (oldWidth != zoomedImageBox.Width)
            {
                zoomAmount = e.Delta * SystemInformation.MouseWheelScrollLines / 120 * -1;

                zoomedImageBox.Location = new Point(
                    (int)(zoomedImageBox.Location.X * ((100 - zoomAmount) / 100.0)),
                    (int)(zoomedImageBox.Location.Y * ((100 - zoomAmount) / 100.0)));
            }

            if (zoomedImageBox.Location.X > selectionPanel.Width - 100)
            {
                zoomedImageBox.Location = new Point(selectionPanel.Width - 100, zoomedImageBox.Location.Y);
            }

            if (zoomedImageBox.Location.Y > selectionPanel.Height - 100)
            {
                zoomedImageBox.Location = new Point( zoomedImageBox.Location.X, selectionPanel.Height - 100);
            }

            if (zoomedImageBox.Location.X + zoomedImageBox.Width < 100)
            {
                zoomedImageBox.Location = new Point(100, zoomedImageBox.Location.Y);
            }

            if (zoomedImageBox.Location.Y + zoomedImageBox.Height < 100)
            {
                zoomedImageBox.Location = new Point(zoomedImageBox.Location.X, 100);
            }

            //zoomedImageBox.Location = new Point(
            //    (int)(((zoomedImageBox.Location.X - (selectionPanel.Width / 2)) * ((100 - zoomAmount) / 100.0)) + (selectionPanel.Width / 2)),
            //    (int)(((zoomedImageBox.Location.Y - (selectionPanel.Height / 2)) * ((100 - zoomAmount) / 100.0)) + (selectionPanel.Height / 2)));
        }

        private void btnBackgroundColour_Click(object sender, EventArgs e)
        {
            _backgroundColourSelectorMode = !_backgroundColourSelectorMode;

            if (_backgroundColourSelectorMode)
            {
                btnBackgroundColour.Text = "Select a colour from the canvas";
            }
            else if (_backgroundColor == Color.Empty)
            {
                btnBackgroundColour.Text = "Not Set";
            }
            else
            {
                btnBackgroundColour.Text = "";
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            IncrementStep();
        }

        public void IncrementStep()
        {
            if (_instructionStepNumber < Instructions.Step.Length)
            {
                _instructionStepNumber++;
                instructionTextBox.Text = Instructions.Step[_instructionStepNumber].Text;

                if (_instructionStepNumber == 1)
                {
                    btnSkip.Visible = true;
                    btnGenerate.Visible = false;
                }
                else
                {
                    panelReminder.Visible = true;
                    btnSkip.Visible = false;
                    btnGenerate.Visible = true;
                }

                if (_instructionStepNumber == 2)
                {
                    this.Hide();
                    frmColourChooser frm = new frmColourChooser(_design, this);
                    frm.Show();

                    tmrPreviewUpdate.Stop();
                    tmrPreviewUpdate.Enabled = false;
                }

                if (_instructionStepNumber == 3 && _design.ImageWithGrayedOutParts != null)
                {
                    _image = _design.ImageWithGrayedOutParts;
                    zoomedImageBox.BackgroundImage = _image;
                }
                
                if (_instructionStepNumber == 3)
                {
                    tmrPreviewUpdate.Enabled = true;
                    tmrPreviewUpdate.Start();

                    lblStepTitle.Text = "Step 4 of 4";
                }
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            tmrPreviewUpdate.Stop();
            tmrPreviewUpdate.Enabled = false;

            this.Hide();
            _frmWaiting.Show();
            backgroundWriteProjectWorker.RunWorkerAsync();
        }

        private void btnClearFirstPoint_Click(object sender, EventArgs e)
        {
            _firstClickedPoint = new Point(-1, -1);
            lblFirstPoint.Text = "First point not selected";
            btnClearFirstPoint.Visible = false;
            firstClickViewPanel.BackgroundImage = null;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FrmMainWorkerArgument arg = (FrmMainWorkerArgument)(e.Argument);

            if (arg.InstructionStepNumber == 1)
            {
                try
                {
                    e.Result = new frmActionBarAnalysis(arg.Segment, arg.BackgroundColor, arg.Caller, arg.Design);
                }
                catch (Exception ex)
                {
                    e.Result = new frmException(ex);
                }
            }
            else
            {
                try
                {
                    e.Result = new frmSegmentAnalysis(arg.Segment, arg.BackgroundColor, arg.Design);
                }
                catch (Exception ex)
                {
                    e.Result = new frmException(ex);
                }
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.Show();
                _frmWaiting.Hide();

                if (e.Result.GetType() == typeof(frmException))
                {
                    if (MessageBox.Show("Exception Caught - would you like to see the details?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ((frmException)(e.Result)).Show();
                    }
                }
                else
                {
                    ((Form)e.Result).Show();
                }
            }
            catch (Exception)
            {

            }
        }

        private void backgroundWriteProjectWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ProjectWriter.WriteProjectToDisk(_design);
        }

        private void backgroundWriteProjectWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _frmWaiting.Hide();
            new frmFinish(ProjectWriter.ProjectPath).Show();
        }

        private void pbBackgroundColour_Click(object sender, EventArgs e)
        {
            _backgroundColourSelectorMode = !_backgroundColourSelectorMode;

            if (_backgroundColourSelectorMode)
            {
                btnBackgroundColour.Text = "Select a colour from the canvas";
            }
            else
            {
                btnBackgroundColour.Text = "";
            }

            panelReminder.Visible = false;
        }

        private void pbVideoHelp_Click(object sender, EventArgs e)
        {
            try
            {
                if (_instructionStepNumber == 1)
                    Process.Start("VideoHelp\\CompositionHelp.exe", "2");
                else
                    Process.Start("VideoHelp\\CompositionHelp.exe", "4");
            }
            catch (Exception)
            {
                MessageBox.Show("Could not open video help");
            }
        }

        private void panelReminder_Click(object sender, EventArgs e)
        {
            panelReminder.Visible = false;
        }

        private void tmrPreviewUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                pbPrecisionImage.Location = new Point(_pbPrecisionImageX, _pbPrecisionImageY);

                pbPrecisionImage.BackgroundImage = _design.GetPointPreviewZoomed(_currentMousePositionX, _currentMousePositionY, 200, 200, zoomedImageBox.Width, zoomedImageBox.Height);
            }
            catch (Exception)
            {

            }
        }

        private void selectionPanel_Resize(object sender, EventArgs e)
        {

        }
    }

    public class FrmMainWorkerArgument
    {
        public Bitmap Segment { get; set; }
        public Design Design { get; set; }
        public Color BackgroundColor { get; set; }
        public frmActionBarSelection Caller { get; set; }
        public int InstructionStepNumber { get; set; }

    }
}
