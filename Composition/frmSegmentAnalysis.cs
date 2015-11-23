using System;
using System.Drawing;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;

namespace Composition
{
    /// <summary>
    /// Form Segment Analysis
    /// Shows the user the results of an analysis on an image segment (i.e. was the result a button, image ect...)
    /// </summary>
    public partial class frmSegmentAnalysis : Form
    {
        private Bitmap _segment;
        private Color _backgroundColour;
        private Design _design;

        private Bitmap _updatePreview;

        private Views.View _result = null;

        private bool _analysisUnderway = true;

        private enum ViewType
        {
            Undetermined,
            Button,
            Image,
            Label,
            Map,
            TextField,
            DummyView
        }

        public frmSegmentAnalysis(Bitmap segment, Color backgroundColour, Design design)
        {
            InitializeComponent();

            _segment = segment;
            _backgroundColour = backgroundColour;
            _design = design;

            cmbType.Items.Add(((ViewType)0).ToString());
            cmbType.Items.Add(((ViewType)1).ToString());
            cmbType.Items.Add(((ViewType)2).ToString());
            cmbType.Items.Add(((ViewType)3).ToString());
            cmbType.Items.Add(((ViewType)4).ToString());
            cmbType.Items.Add(((ViewType)5).ToString());
            cmbType.Items.Add(((ViewType)6).ToString());

            Analyse();
        }

        private void frmSegmentAnalysis_Load(object sender, EventArgs e)
        {

        }

        private void Analyse()
        {
            _analysisUnderway = true;

            lblNotes.Text = "Calculating...";
            lblGini.Text = "";

            try
            {
                double gini;

                Views.View result = WidgetAnalyser.AnalyseImageSegment(_segment, _backgroundColour, out gini, out _updatePreview);

                segmentPictureBox.BackgroundImage = _updatePreview;

                if (result != null)
                {
                    lblGini.Text = gini.ToString();

                    if (result.GetType() == typeof(Views.ButtonView))
                    {
                        txtText.Text = ((Views.ButtonView)result).ButtonText;
                        cmbType.SelectedIndex = 1;
                    }
                    else if (result.GetType() == typeof(Views.ImageView))
                    {
                        lblText.Visible = false;
                        txtText.Visible = false;

                        cmbType.SelectedIndex = 2;
                    }
                    else if (result.GetType() == typeof(Views.LabelView))
                    {
                        txtText.Text = ((Views.LabelView)result).LabelText;
                        cmbType.SelectedIndex = 3;
                    }
                    else if (result.GetType() == typeof(Views.MapView))
                    {
                        lblText.Visible = false;
                        txtText.Visible = false;

                        cmbType.SelectedIndex = 4;
                    }
                    else if (result.GetType() == typeof(Views.TextField))
                    {
                        txtText.Text = ((Views.TextField)result).HintText;
                        cmbType.SelectedIndex = 5;
                    }

                    lblNotes.Text = "Analysis Complete";
                }
                else
                {
                    lblGini.Text = "";
                    lblNotes.Text = "I was unable to determine the widget type you have selected\r\nIf you click done now, I'll ignore the widget,\r\nif you change it to be a dummy widget I'll add it to my widget list";
                    lblText.Visible = false;
                    txtText.Visible = false;
                    cmbType.SelectedIndex = 0;
                }

                _result = result;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Background colour must be selected!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("Exception Caught - would you like to see the details?","",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    new frmException(ex).Show();
                }
            }

            _analysisUnderway = false;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (_result != null)
            {
                if (txtText.Visible == true)
                {
                    if (txtText.Text == "")
                    {
                        MessageBox.Show("Textbox cannot be blank with this type of widget");
                        return;
                    }

                    if (_result.GetType() == typeof(Views.ButtonView))
                    {
                        ((Views.ButtonView)_result).ButtonText = txtText.Text;
                        ((Views.ButtonView)_result).RegisterButtonTextWithStringsClass(_design);
                    }
                    else if (_result.GetType() == typeof(Views.LabelView))
                    {
                        ((Views.LabelView)_result).LabelText = txtText.Text;
                        ((Views.LabelView)_result).RegisterLabelTextWithStringsClass(_design);
                    }
                    else if (_result.GetType() == typeof(Views.TextField))
                    {
                        ((Views.TextField)_result).HintText = txtText.Text;
                        ((Views.TextField)_result).RegisterTextWithStringsClass(_design);
                    }
                }

                if (_result.GetType() == typeof(Views.MapView))
                {
                    ((Views.MapView)_result).ImageID = Drawables.AddBitmap(_design.ActivityName, _updatePreview, _result.WidgetType);
                }
                else if (_result.GetType() == typeof(Views.ImageView))
                {
                    ((Views.ImageView)_result).ImageID = Drawables.AddBitmap(_design.ActivityName, _updatePreview, _result.WidgetType);
                }

                _design.Widgets.Add(_result);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_analysisUnderway)
                return;

            Views.View result = null;
            txtText.Text = "";

            lblNotes.Text = "Calculating...";

            Image<Bgr, Byte> newImage = new Image<Bgr, Byte>(_segment);
            Image<Bgr, Byte> croppedImage = WidgetAnalyser.RemoveBackgroundColour(newImage.ToBitmap(), _backgroundColour);

            if (cmbType.SelectedIndex == 0)
            {
                lblText.Visible = false;
                txtText.Visible = false;

                _result = null;

                lblNotes.Text = "You have chosen 'Undetermined', if you proceed I'll ignore this widget,\r\nif you want a placeholder put into code select 'DummyView'";
            }
            else if (cmbType.SelectedIndex == 1)
            {
                lblText.Visible = true;
                txtText.Visible = true;

                result = WidgetAnalyser.IsTextualButton(croppedImage, _backgroundColour);

                if (result != null)
                {
                    _result = result;
                    txtText.Text = ((Views.ButtonView)_result).ButtonText;
                    lblNotes.Text = "You've chosen to insert a button, I've successfully analysed it";
                }

                result = WidgetAnalyser.IsTextualButton(newImage, _backgroundColour);

                if (result != null)
                {
                    _result = result;
                    txtText.Text = ((Views.ButtonView)_result).ButtonText;
                    lblNotes.Text = "You've chosen to insert a button, I've successfully analysed it";
                }
                else
                {
                    lblNotes.Text = "I was unable to verify that what you have chosen is a button\r\nPlease select dummy widget, otherwise I will ignore this entry";
                }
            }
            else if (cmbType.SelectedIndex == 2)
            {
                lblText.Visible = false;
                txtText.Visible = false;

                result = WidgetAnalyser.IsImage(croppedImage, _backgroundColour);

                if (result != null)
                {
                    _result = result;
                    lblNotes.Text = "You've chosen to insert an Image, I've successfully analysed it";
                }

                result = WidgetAnalyser.IsImage(newImage, _backgroundColour);

                if (result != null)
                {
                    _result = result;
                    lblNotes.Text = "You've chosen to insert an Image, I've successfully analysed it";
                }
                else
                {
                    _result = null;
                    lblNotes.Text = "I was unable to verify that what you have chosen is an image\r\nPlease select dummy widget, otherwise I will ignore this entry";
                }
            }
            else if (cmbType.SelectedIndex == 3)
            {
                lblText.Visible = true;
                txtText.Visible = true;

                result = WidgetAnalyser.IsLabel(croppedImage, _backgroundColour);

                if (result != null)
                {
                    _result = result;
                    txtText.Text = ((Views.LabelView)_result).LabelText;
                    lblNotes.Text = "You've chosen to insert a Label, I've successfully analysed it";
                }

                result = WidgetAnalyser.IsLabel(newImage, _backgroundColour);

                if (result != null)
                {
                    _result = result;
                    txtText.Text = ((Views.LabelView)_result).LabelText;
                    lblNotes.Text = "You've chosen to insert a Label, I've successfully analysed it";
                }
                else
                {
                    _result = null;
                    lblNotes.Text = "I was unable to verify that what you have chosen is a label\r\nPlease select dummy widget, otherwise I will ignore this entry";
                }
            }
            else if (cmbType.SelectedIndex == 4)
            {
                lblText.Visible = false;
                txtText.Visible = false;

                result = WidgetAnalyser.IsMap(croppedImage, _backgroundColour);

                if (result != null)
                {
                    _result = result;
                    lblNotes.Text = "You've chosen to insert a Map, I've successfully analysed it";
                }

                result = WidgetAnalyser.IsMap(newImage, _backgroundColour);

                if (result != null)
                {
                    _result = result;
                    lblNotes.Text = "You've chosen to insert a Map, I've successfully analysed it";
                }
                else
                {
                    _result = null;
                    lblNotes.Text = "I was unable to verify that what you have chosen is a map\r\nPlease select dummy widget, otherwise I will ignore this entry";
                }
            }
            else if (cmbType.SelectedIndex == 5)
            {
                lblText.Visible = true;
                txtText.Visible = true;

                result = WidgetAnalyser.IsTextField(croppedImage, _backgroundColour);

                if (result != null)
                {
                    _result = result;
                    txtText.Text = ((Views.TextField)_result).HintText;
                    lblNotes.Text = "You've chosen to insert a TextField, I've successfully analysed it";
                }

                result = WidgetAnalyser.IsTextField(newImage, _backgroundColour);

                if (result != null)
                {
                    _result = result;
                    txtText.Text = ((Views.TextField)_result).HintText;
                    lblNotes.Text = "You've chosen to insert a TextField, I've successfully analysed it";
                }
                else
                {
                    _result = null;
                    lblNotes.Text = "I was unable to verify that what you have chosen is a TextField\r\nPlease select dummy widget, otherwise I will ignore this entry";
                }
            }
            else if (cmbType.SelectedIndex == 6)
            {
                lblText.Visible = false;
                txtText.Visible = false;

                result = new Views.DummyView();

                _result = result;
                lblNotes.Text = "You've chosen to insert a dummy widget, a dummy widget is a placeholder so you can modify the code later";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            Analyse();
        }
    }
}
