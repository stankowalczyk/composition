using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace CompositionHelp
{
    /// <summary>
    /// Form Main Class
    /// Form which plays MP4 help videos for users
    /// </summary>
    public partial class fmrMain : Form
    {
        public fmrMain(string video)
        {
            InitializeComponent();

            wmp.uiMode = "none";

            string location = System.Reflection.Assembly.GetEntryAssembly().Location;
            location = Path.GetDirectoryName(location);

            if (video == "1")
            {
                wmp.URL = location + "\\Videos\\CompositionStep1.mp4";
            }
            else if (video == "2")
            {
                wmp.URL = location + "\\Videos\\CompositionStep2.mp4";
            }
            else if (video == "3")
            {
                wmp.URL = location + "\\Videos\\CompositionStep3.mp4";
            }
            else if (video == "4")
            {
                wmp.URL = location + "\\Videos\\CompositionStep4.mp4";
            }
            else if (video == "intro")
            {
                wmp.URL = location + "\\Videos\\CompositionIntroductionVideo.mp4";
            }
            else
            {
                Environment.Exit(0);
            }

            
        }

        private void wmp_Enter(object sender, EventArgs e)
        {

        }

        private void wmp_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            if (wmp.Ctlcontrols.currentPosition > wmp.currentMedia.duration - 3)
            {
                wmp.Ctlcontrols.stop();
                wmp.Ctlcontrols.play();
                tmr.Interval = (int)((wmp.currentMedia.duration - 4) * 1000);
                tmr.Enabled = true;
                tmr.Start();
            }
        }

        private void wmp_PositionChange(object sender, AxWMPLib._WMPOCXEvents_PositionChangeEvent e)
        {
            if (wmp.Ctlcontrols.currentPosition > wmp.currentMedia.duration - 1)
            {
                wmp.Ctlcontrols.pause();
            }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            while (wmp.Ctlcontrols.currentPosition < wmp.currentMedia.duration - 0.4)
            {
                Thread.Sleep(100);
            }

            wmp.Ctlcontrols.pause();
        }

        private void wmp_CurrentMediaItemAvailable(object sender, AxWMPLib._WMPOCXEvents_CurrentMediaItemAvailableEvent e)
        {
            
        }

        private void wmp_StatusChange(object sender, EventArgs e)
        {
            if (wmp.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                tmr.Interval = (int)((wmp.currentMedia.duration - 4) * 1000);
                tmr.Enabled = true;
                tmr.Start();
            }
        }
    }
}
