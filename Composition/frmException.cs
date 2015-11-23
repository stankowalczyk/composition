using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Composition
{
    /// <summary>
    /// Form Exception Class
    /// Used to show the user / the developers detailed messages about what went wrong
    /// </summary>
    public partial class frmException : Form
    {
        private Exception _exception;

        public frmException(Exception e)
        {
            InitializeComponent();
            _exception = e;
        }

        private void frmException_Load(object sender, EventArgs e)
        {
            rtbMessage.Text = _exception.Message;
            rtbStackTrace.Text = _exception.StackTrace;
        }
    }
}
