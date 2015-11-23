using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

using Emgu.CV;
using Emgu.CV.Structure;

namespace CompositionTests
{
    /// <summary>
    /// Form Refine
    /// Form used to check that test data (i.e. image segment co-ordinands) are good
    /// </summary>
    public partial class frmRefine : Form
    {
        private List<ImageTestData> _images;

        private List<Result> _result = new List<Result>();

        private string _fileToLoad = "testdate_refined_";
        private string _fileToSave = "testdate_refined_removed_";

        private WidgetType _type;

        private int _index = 0;
        private int _widgetIndex = 0;

        public frmRefine()
        {
            InitializeComponent();

            _type = WidgetType.TextField;

            _fileToLoad += _type.ToString() + ".json";
            _fileToSave += _type.ToString() + ".json";

            if (File.Exists(_fileToLoad))
            {
                string file = File.ReadAllText(_fileToLoad);
                _images = JsonConvert.DeserializeObject<List<ImageTestData>>(file);
            }
        }

        private void IncrementIndex()
        {
            if (_index < _images.Count)
            {
                if (_widgetIndex >= _images[_index].WidgetAreaList.Count - 1)
                {
                    _index++;
                    _widgetIndex = 0;
                }
                else
                {
                    _widgetIndex++;
                }
            }
        }

        private void LoadNextImage()
        {
            if (_index < _images.Count && _widgetIndex < _images[_index].WidgetAreaList.Count)
            {
                Bitmap pic = new Bitmap(_images[_index].FilePath);
                Graphics resultGraphics = Graphics.FromImage(pic);

                int x1 = _images[_index].WidgetAreaList[_widgetIndex].X1;
                int x2 = _images[_index].WidgetAreaList[_widgetIndex].X2;
                int y1 = _images[_index].WidgetAreaList[_widgetIndex].Y1;
                int y2 = _images[_index].WidgetAreaList[_widgetIndex].Y2;
                int width = x2 - x1;
                int height = y2 - y1;

                resultGraphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.Red)), x1, y1, width, height);
                resultGraphics.Flush();
                
                pb.BackgroundImage = pic;
                pb.Invalidate();
            }
            else
            {
                MessageBox.Show("Done");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_images[_index].WidgetAreaList.Count == 1)
            {
                _images.RemoveAt(_index);
            }
            else
            {
                _images[_index].WidgetAreaList.RemoveAt(_widgetIndex);
            }

            LoadNextImage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            IncrementIndex();
            
            try
            {
                while (_images[_index].WidgetAreaList.Count == 0)
                {
                    _images.RemoveAt(_index);
                }
            }
            catch (Exception)
            {

            }
            LoadNextImage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string output = JsonConvert.SerializeObject(_images, Formatting.Indented);

            File.WriteAllText(_fileToSave, output);
        }

        private void frmRefine_Load(object sender, EventArgs e)
        {
            LoadNextImage();
        }
    }
}
