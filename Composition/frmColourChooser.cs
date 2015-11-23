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
    /// Form Colour Chooser
    /// This is the third step of the process
    /// Allows users to select the primary, primary dark, and accent colours of a screen.
    /// </summary>
    public partial class frmColourChooser : Form
    {
        private frmActionBarSelection _callerForm;

        private Design _design;

        private bool _primaryColourSelection = false;
        private bool _primaryDarkColourSelection = false;
        private bool _accentColourSelection = false;

        private Color _primaryColor = Color.Empty;
        private Color _primaryDarkColor = Color.Empty;
        private Color _accentColor = Color.Empty;

        private double _zoomAmount = 100;

        public frmColourChooser(Design design, frmActionBarSelection callerForm)
        {
            InitializeComponent();

            _callerForm = callerForm;

            _design = design;

            (selectionPanel as Control).KeyDown += new KeyEventHandler(this.onKeyDown);
            (selectionPanel as Control).Select();
            (selectionPanel as Control).MouseWheel += new MouseEventHandler(this.onMouseWheel);
            (zoomedImageBox as Control).MouseWheel += new MouseEventHandler(this.onMouseWheel);

            zoomedImageBox.Width = _design.DesignImage.Width;
            zoomedImageBox.Height = _design.DesignImage.Height;
            zoomedImageBox.BackgroundImage = _design.DesignImage;

            try
            {
                _primaryColor = Colour.retrieveColour(Colour.PrimaryColourName);
                btnPrimaryColour.BackColor = _primaryColor;

                float brightness = _primaryColor.GetBrightness() * 100;
                brightness -= 10;

                if (brightness < 0)
                    brightness = 0;

                brightness = brightness / 100;

                _primaryDarkColor = Colour.ColourFromAhsb(255, _primaryColor.GetHue(), _primaryColor.GetSaturation(), brightness);
                btnPrimaryDarkColour.BackColor = _primaryDarkColor;
            }
            catch (Exception)
            {
                // Do nothing
            }

            if (_primaryColor.IsEmpty)
                btnPrimaryColour.Text = "Not Set";

            if (_primaryDarkColor.IsEmpty)
                btnPrimaryDarkColour.Text = "Not Set";

            if (_accentColor.IsEmpty)
                btnAccentColour.Text = "Not Set";
        }

        private void frmColourChooser_Load(object sender, EventArgs e)
        {
            instructionTextBox.Text = Instructions.Step[2].Text;
        }

        private void selectionPanel_MouseEnter(object sender, EventArgs e)
        {
            selectionPanel.Select();
        }

        private void zoomedImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            Color temp = _design.GetColourAt(e.X, e.Y, zoomedImageBox.Width, zoomedImageBox.Height);

            if (_primaryColourSelection)
            {
                _primaryColor = temp;
                btnPrimaryColour.BackColor = _primaryColor;
            }
            else if (_primaryDarkColourSelection)
            {
                _primaryDarkColor = temp;
                btnPrimaryDarkColour.BackColor = _primaryDarkColor;
            }
            else if (_accentColourSelection)
            {
                _accentColor = temp;
                btnAccentColour.BackColor = _accentColor;
            }

            _primaryColourSelection = false;
            _primaryDarkColourSelection = false;
            _accentColourSelection = false;

            if (_primaryColor.IsEmpty)
                btnPrimaryColour.Text = "Not Set";
            else
                btnPrimaryColour.Text = "";

            if (_primaryDarkColor.IsEmpty)
                btnPrimaryDarkColour.Text = "Not Set";
            else
                btnPrimaryDarkColour.Text = "";

            if (_accentColor.IsEmpty)
                btnAccentColour.Text = "Not Set";
            else
                btnAccentColour.Text = "";
        }

        private void zoomedImageBox_MouseEnter(object sender, EventArgs e)
        {
            selectionPanel.Select();
        }

        private void zoomedImageBox_MouseMove(object sender, MouseEventArgs e)
        {
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
            if (e.KeyData == Keys.W) // Up
            {
                if (zoomedImageBox.Location.Y < 50)
                {
                    zoomedImageBox.Location = new Point(zoomedImageBox.Location.X, zoomedImageBox.Location.Y + 20);
                }
            }
            else if (e.KeyData == Keys.S) // Down
            {
                if (zoomedImageBox.Location.Y + zoomedImageBox.Height > (selectionPanel.Height - 50))
                {
                    zoomedImageBox.Location = new Point(zoomedImageBox.Location.X, zoomedImageBox.Location.Y - 20);
                }
            }

            if (e.KeyData == Keys.A) // Left
            {
                if (zoomedImageBox.Location.X < 50)
                {
                    zoomedImageBox.Location = new Point(zoomedImageBox.Location.X + 20, zoomedImageBox.Location.Y);
                }
            }
            else if (e.KeyData == Keys.D) // Right
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

            _zoomAmount += zoomAmount;

            int oldWidth = zoomedImageBox.Width;

            if (_zoomAmount < 10)
                _zoomAmount = 10;

            if (_zoomAmount > 200)
                _zoomAmount = 200;

            zoomedImageBox.Width = (int)(zoomedImageBox.BackgroundImage.Width * (_zoomAmount / 100.0));
            zoomedImageBox.Height = (int)(zoomedImageBox.BackgroundImage.Height * (_zoomAmount / 100.0));

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
                zoomedImageBox.Location = new Point(zoomedImageBox.Location.X, selectionPanel.Height - 100);
            }

            if (zoomedImageBox.Location.X + zoomedImageBox.Width < 100)
            {
                zoomedImageBox.Location = new Point(100, zoomedImageBox.Location.Y);
            }

            if (zoomedImageBox.Location.Y + zoomedImageBox.Height < 100)
            {
                zoomedImageBox.Location = new Point(zoomedImageBox.Location.X, 100);
            }
        }

        private void UpdateButtonText()
        {
            if (_primaryColourSelection)
                btnPrimaryColour.Text = "Select a colour from the canvas";
            else if (_primaryColor.IsEmpty)
                btnPrimaryColour.Text = "Not Set";
            else
                btnPrimaryColour.Text = "";

            if (_primaryDarkColourSelection)
                btnPrimaryDarkColour.Text = "Select a colour from the canvas";
            else if (_primaryDarkColor.IsEmpty)
                btnPrimaryDarkColour.Text = "Not Set";
            else
                btnPrimaryDarkColour.Text = "";

            if (_accentColourSelection)
                btnAccentColour.Text = "Select a colour from the canvas";
            else if (_accentColor.IsEmpty)
                btnAccentColour.Text = "Not Set";
            else
                btnAccentColour.Text = "";
        }

        private void btnPrimaryColour_Click(object sender, EventArgs e)
        {
            _primaryColourSelection = !_primaryColourSelection;

            _primaryDarkColourSelection = false;
            _accentColourSelection = false;

            UpdateButtonText();
        }

        private void btnPrimaryDarkColour_Click(object sender, EventArgs e)
        {
            _primaryDarkColourSelection = !_primaryDarkColourSelection;

            _primaryColourSelection = false;
            _accentColourSelection = false;

            UpdateButtonText();
        }

        private void btnAccentColour_Click(object sender, EventArgs e)
        {
            _accentColourSelection = !_accentColourSelection;

            _primaryColourSelection = false;
            _primaryDarkColourSelection = false;

            UpdateButtonText();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (_primaryColor.IsEmpty)
            {
                MessageBox.Show("The primary colour must be selected", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Colour.AddPrimaryColour(_primaryColor);
            }
            catch (Exception)
            {
                // Do nothing
                // Raised if exists already
            }

            if (!_primaryDarkColor.IsEmpty)
            {
                try
                {
                    Colour.AddPrimaryDarkColour(_primaryDarkColor);
                }
                catch (Exception)
                {
                    // Do nothing
                    // Raised if exists already
                }
            }

            if (!_accentColor.IsEmpty)
            {
                try
                {
                    Colour.AddAccentColour(_accentColor);
                }
                catch (Exception)
                {
                    // Do nothing
                    // Raised if exists already
                }
            }

            _callerForm.Show();
            _callerForm.IncrementStep();
            this.Close();
        }

        private void pbVideoHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("VideoHelp\\CompositionHelp.exe", "3");
            }
            catch (Exception)
            {
                MessageBox.Show("Could not open video help");
            }
        }

        private void btnGenerateAutomatically_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primaryColor.IsEmpty)
                {
                    _primaryColor = Colour.retrieveColour(Colour.PrimaryColourName);
                    btnPrimaryColour.BackColor = _primaryColor;
                }

                float brightness = _primaryColor.GetBrightness() * 100;
                brightness -= 10;

                if (brightness < 0)
                    brightness = 0;

                brightness = brightness / 100;

                _primaryDarkColor = Colour.ColourFromAhsb(255, _primaryColor.GetHue(), _primaryColor.GetSaturation(), brightness);
                btnPrimaryDarkColour.BackColor = _primaryDarkColor;

                if (_primaryDarkColor.IsEmpty)
                    btnPrimaryDarkColour.Text = "Not Set";
                else
                    btnPrimaryDarkColour.Text = "";

                if (_primaryDarkColor.IsEmpty)
                    btnPrimaryDarkColour.Text = "Not Set";
                else
                    btnPrimaryDarkColour.Text = "";

                if (_accentColor.IsEmpty)
                    btnAccentColour.Text = "Not Set";
                else
                    btnAccentColour.Text = "";
            }
            catch (Exception)
            {
                // Do nothing
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            _primaryColor = Color.Empty;
            _primaryDarkColor = Color.Empty;
            _accentColor = Color.Empty;

            _primaryColourSelection = false;
            _primaryDarkColourSelection = false;
            _accentColourSelection = false;

            btnPrimaryColour.Text = "Not Set";
            btnPrimaryDarkColour.Text = "Not Set";
            btnAccentColour.Text = "Not Set";

            btnPrimaryColour.BackColor = Color.White;
            btnPrimaryDarkColour.BackColor = Color.White;
            btnAccentColour.BackColor = Color.White;
        }
    }
}
