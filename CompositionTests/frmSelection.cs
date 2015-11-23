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
using System.IO;
using Newtonsoft.Json;

namespace CompositionTests
{
    /// <summary>
    /// Form Selection
    /// Form used to create image segment test data
    /// Used to create background colour, first X&Y + Width and height
    /// Also used to select the primary colour of a screen
    /// </summary>
    public partial class frmSelection : Form
    {
        private ImageTestData _currentImage;

        private List<ImageTestData> _images;
        private Point _firstClickedPoint = new Point(-1, -1);

        private List<string> _imagePaths;
        private int _index = -1;

        private string _fileToLoad = "testdate_";

        private double _zoomAmount = 100;

        private bool _backgroundColourSelectionMode = false;
        private bool _primaryColourSelectionMode = false;

        private Color _backgroundColour;
        private Color _primaryColour;
        private Bitmap _image;

        private int _widgetCount = 0;

        private bool _loadedFromJSON = false;

        public frmSelection(WidgetType type)
        {
            InitializeComponent();

            (selectionPanel as Control).KeyDown += new KeyEventHandler(this.onKeyDown);
            (selectionPanel as Control).Select();
            (selectionPanel as Control).MouseWheel += new MouseEventHandler(this.onMouseWheel);
            (zoomedImageBox as Control).MouseWheel += new MouseEventHandler(this.onMouseWheel);

            _fileToLoad += type.ToString() + ".json";

            if (File.Exists(_fileToLoad))
            {
                string file = File.ReadAllText(_fileToLoad);
                _images = JsonConvert.DeserializeObject<List<ImageTestData>>(file);

                foreach (ImageTestData item in _images)
                {
                    _widgetCount += item.WidgetAreaList.Count;
                }

                _index = _images.Count - 1;
                _currentImage = _images[_images.Count - 1];
                _images.RemoveAt(_images.Count - 1);

                _loadedFromJSON = true;
            }
            else
            {
                _images = new List<ImageTestData>();
            }

            _imagePaths = Directory.GetFiles("testimages\\").ToList<string>();

            lblType.Text = type.ToString();
        }

        private void frmColourChooser_Load(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        private void selectionPanel_MouseEnter(object sender, EventArgs e)
        {
            selectionPanel.Select();
        }

        private void zoomedImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (_backgroundColourSelectionMode)
            {
                double divisor = zoomedImageBox.Width / (double)_image.Width;
                _backgroundColour = _image.GetPixel((int)(e.X / divisor), (int)(e.Y / divisor));

                BackgroundColour();
            }
            else if (_primaryColourSelectionMode)
            {
                double divisor = zoomedImageBox.Width / (double)_image.Width;
                _primaryColour = _image.GetPixel((int)(e.X / divisor), (int)(e.Y / divisor));

                PrimaryColour();
            }
            else if (_firstClickedPoint.X == -1)
            {
                _firstClickedPoint = new Point(e.X, e.Y);
                lblFirstPoint.Text = "First point selected";
                btnClearFirstPoint.Visible = true;
            }
            else
            {
                if (_backgroundColour == Color.Empty)
                {
                    MessageBox.Show("Background colour");

                    _firstClickedPoint = new Point(-1, -1);
                    lblFirstPoint.Text = "Waiting...";
                    btnClearFirstPoint.Visible = false;
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
                    lblFirstPoint.Text = "Added, waiting for next First";
                    btnClearFirstPoint.Visible = false;

                    WidgetArea w = new WidgetArea();
                    w.X1 = x1;
                    w.X2 = x2;
                    w.Y1 = y1;
                    w.Y2 = y2;
                    w.BackgroundColourRed = Convert.ToInt32(_backgroundColour.R);
                    w.BackgroundColourGreen = Convert.ToInt32(_backgroundColour.G);
                    w.BackgroundColourBlue = Convert.ToInt32(_backgroundColour.B);
                    _currentImage.WidgetAreaList.Add(w);

                    _widgetCount++;
                    lblCount.Text = _widgetCount.ToString();
                }
            }
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
            else if (e.KeyData == Keys.D1)
            {
                LoadNextImage();
            }
            else if (e.KeyData == Keys.Escape)
            {
                _firstClickedPoint = new Point(-1, -1);
                lblFirstPoint.Text = "First point not selected";
                btnClearFirstPoint.Visible = false;
            }
            else if (e.KeyData == Keys.B)
            {
                BackgroundColour();
            }
        }

        private void onMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int zoomAmount = e.Delta * SystemInformation.MouseWheelScrollLines / 120 * -1;

            _zoomAmount += zoomAmount;

            int oldWidth = zoomedImageBox.Width;

            if (_zoomAmount < 10)
                _zoomAmount = 10;

            if (_zoomAmount > 400)
                _zoomAmount = 400;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (File.Exists(_fileToLoad))
            {
                File.Delete(_fileToLoad);
            }

            string output = JsonConvert.SerializeObject(_images, Formatting.Indented);

            File.WriteAllText(_fileToLoad, output);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        private void LoadNextImage()
        {
            _index++;

            _firstClickedPoint = new Point(-1, -1);
            lblFirstPoint.Text = "First point not selected";
            btnClearFirstPoint.Visible = false;

            if (!_loadedFromJSON)
            {
                if (_currentImage != null)
                {
                    if (_primaryColour != Color.Empty)
                    {
                        _currentImage.PrimaryColourRed = Convert.ToInt32(_primaryColour.R);
                        _currentImage.PrimaryColourBlue = Convert.ToInt32(_primaryColour.B);
                        _currentImage.PrimaryColourGreen = Convert.ToInt32(_primaryColour.G);
                    }
                    else
                    {
                        _currentImage.PrimaryColourRed = -1;
                        _currentImage.PrimaryColourGreen = -1;
                        _currentImage.PrimaryColourBlue = -1;
                    }

                    _images.Add(_currentImage);
                }

                _currentImage = new ImageTestData();
                _currentImage.WidgetAreaList = new List<WidgetArea>();
            }
            else
            {
                _loadedFromJSON = false;
            }

            if (_index > _imagePaths.Count - 1)
            {
                MessageBox.Show("No more images");
                return;
            }

            try
            {
                _image = new Bitmap(_imagePaths[_index]);
                zoomedImageBox.BackgroundImage = _image;
                zoomedImageBox.Width = zoomedImageBox.BackgroundImage.Width;
                zoomedImageBox.Height = zoomedImageBox.BackgroundImage.Height;
                zoomedImageBox.Location = new Point(100, 10);
                _currentImage.FilePath = _imagePaths[_index];
            }
            catch (Exception)
            {

            }

            lblCurrentImageIndex.Text = (_index + 1).ToString();

            _primaryColour = Color.Empty;
            _backgroundColour = Color.Empty;

            UpdateLabels();
        }

        private void btnClearFirstPoint_Click(object sender, EventArgs e)
        {
            _firstClickedPoint = new Point(-1, -1);
            lblFirstPoint.Text = "First point not selected";
            btnClearFirstPoint.Visible = false;
        }

        private void btnBackgroundColour_Click(object sender, EventArgs e)
        {
            BackgroundColour();
        }

        private void BackgroundColour()
        {
            _backgroundColourSelectionMode = !_backgroundColourSelectionMode;

            if (_backgroundColourSelectionMode)
            {
                _primaryColourSelectionMode = false;
            }

            UpdateLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrimaryColour();
        }

        private void PrimaryColour()
        {
            _primaryColourSelectionMode = !_primaryColourSelectionMode;

            if (_primaryColourSelectionMode)
            {
                _backgroundColourSelectionMode = false;
            }

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            if (_primaryColourSelectionMode)
            {
                btnPrimaryColour.Text = "Select Background Colour";
            }
            else
            {
                btnPrimaryColour.Text = "";
                btnPrimaryColour.BackColor = _primaryColour;
            }

            if (_backgroundColourSelectionMode)
            {
                btnBackgroundColour.Text = "Select Background Colour";
            }
            else
            {
                btnBackgroundColour.Text = "";
                btnBackgroundColour.BackColor = _backgroundColour;
            }
        }
    }
}
