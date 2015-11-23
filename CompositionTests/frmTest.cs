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
    /// Form Test
    /// Form used to automate the testing of widgets
    /// </summary>
    public partial class frmTest : Form
    {
        private List<ImageTestData> _images;

        private List<Result> _result = new List<Result>();

        private string _fileToLoad = "testdate_";
        private string _fileToSave = "results_";

        private int _widgetCount = 0;

        private bool _loadedFromJSON = false;

        private WidgetType _type;

        public frmTest(WidgetType type)
        {
            _type = type;

            InitializeComponent();

            _fileToLoad += type.ToString() + ".json";
            _fileToSave += type.ToString() + ".json";

            if (File.Exists(_fileToLoad))
            {
                string file = File.ReadAllText(_fileToLoad);
                _images = JsonConvert.DeserializeObject<List<ImageTestData>>(file);

                foreach (ImageTestData item in _images)
                {
                    _widgetCount += item.WidgetAreaList.Count;
                }

                _loadedFromJSON = true;
            }

            lblFile.Text = _fileToLoad;
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Result result;
            Image<Bgr, Byte> image;
            Color backgroundColour;
            Color primaryColour;

            for (int i = 0; i < _images.Count; i++)
            {
                image = new Image<Bgr, Byte>(_images[i].FilePath);
                if (_images[i].PrimaryColourRed != -1)
                {
                    primaryColour = Color.FromArgb(255, _images[i].PrimaryColourRed, _images[i].PrimaryColourGreen, _images[i].PrimaryColourBlue);
                    Colour.AddPrimaryColour(primaryColour);
                }

                for (int w = 0; w < _images[i].WidgetAreaList.Count; w++ )
                {
                    result = new Result();
                    result.WidgetType = _type.ToString();
                    result.ImagePath = _images[i].FilePath;
                    result.WidgetIndexInImage = w;

                    backgroundColour = Color.FromArgb(255, _images[i].WidgetAreaList[w].BackgroundColourRed, _images[i].WidgetAreaList[w].BackgroundColourBlue, _images[i].WidgetAreaList[w].BackgroundColourGreen);

                    Rectangle rect = new Rectangle(_images[i].WidgetAreaList[w].X1, _images[i].WidgetAreaList[w].Y1,
                        _images[i].WidgetAreaList[w].X2 - _images[i].WidgetAreaList[w].X1,
                        _images[i].WidgetAreaList[w].Y2 - _images[i].WidgetAreaList[w].Y1);

                    double gini;
                    Bitmap preview;

                    try
                    {
                        Views.View processingResult = WidgetAnalyser.AnalyseImageSegment(image.GetSubRect(rect).ToBitmap(), backgroundColour, out gini, out preview);

                        if (processingResult != null && processingResult.WidgetType == _type)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                        if (processingResult != null)
                        {
                            result.AnalsisResultWidgetType = processingResult.WidgetType.ToString();
                        }
                        else
                        {
                            result.AnalsisResultWidgetType = "null";
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        Console.WriteLine(ex.StackTrace);

                        result.Correct = false;
                        result.AnalsisResultWidgetType = "exception";
                    }

                    _result.Add(result);
                }

                Colour.Clear();

                backgroundWorker.ReportProgress((int)(((i + 1) / (float)_images.Count) * 100));

                image.Dispose();
            }

            if (File.Exists(_fileToSave))
            {
                File.Delete(_fileToSave);
            }

            string output = JsonConvert.SerializeObject(_result, Formatting.Indented);

            File.WriteAllText(_fileToSave, output);

            int count = 0;

            for (int i = 0; i < _result.Count; i++)
            {
                if (_result[i].Correct)
                {
                    count++;
                }
            }

            if (this.lblIndex.InvokeRequired)
            {
                this.lblIndex.BeginInvoke((MethodInvoker)delegate() { this.lblIndex.Text = count.ToString() + " out of " + _result.Count.ToString() + " was correct."; });
            }
            else
            {
                this.lblIndex.Text = count.ToString() + " out of " + _result.Count.ToString() + " was correct.";
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbProgress.Value = e.ProgressPercentage;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }
    }
}
