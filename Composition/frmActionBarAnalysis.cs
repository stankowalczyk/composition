using System;
using System.Drawing;
using System.Windows.Forms;

namespace Composition
{
    /// <summary>
    /// Form Action Bar Analysis (Result) Class
    /// A screen showing the results of an analysis of the action bar
    /// </summary>
    public partial class frmActionBarAnalysis : Form
    {
        private frmActionBarSelection _senderForm;

        private Design _design;

        private Bitmap _segment;
        private Color _backgroundColour;

        private Views.ActionBar _actionbar;

        public frmActionBarAnalysis(Bitmap segment, Color backgroundColour, frmActionBarSelection sender, Design design)
        {
            InitializeComponent();

            _segment = segment;
            _backgroundColour = backgroundColour;

            _senderForm = sender;
            _design = design;

            double gini;

            try
            {
                Bitmap preview;
                Views.ActionBar result = WidgetAnalyser.AnalyseActionBar(_segment, _backgroundColour, out gini, out preview);

                segmentPictureBox.BackgroundImage = preview;

                if (result != null)
                {
                    lblGini.Text = gini.ToString();
                    lblType.Text = result.WidgetType.ToString();

                    txtActionBarLabel.Text = result.TitleText;

                    _actionbar = result;
                }
                else
                {
                    lblGini.Text = "";
                    lblType.Text = "I'm not sure this is an action bar. If it is, enter its title.";
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Background colour must be selected!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                _senderForm.Show();
                return;
            }
        }

        private void frmActionBarAnalysis_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (_actionbar == null)
            {
                if (MessageBox.Show("Are you sure you want to proceed without setting an actionbar?","",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            if (txtActionBarLabel.Text == "")
            {
                if (MessageBox.Show("Actionbar text is blank, continue?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            if (_actionbar != null)
            {
                _actionbar = new Views.ActionBar();
                _actionbar.TitleText = txtActionBarLabel.Text;
                _actionbar.RegisterTitleTextWithStringsFile(_design);
            }

            _design.ActionBar = _actionbar;

            this.Close();
            _senderForm.Show();
            _senderForm.IncrementStep();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            _senderForm.Show();
        }
    }
}
