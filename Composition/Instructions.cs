using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition
{
    /// <summary>
    /// Instructions Class
    /// Stores the instructions found in the left panel in the GUI
    /// </summary>
    class Instructions
    {
        public static readonly Step[] Step = {
            new Step("Follow the instructions below to get started.",null),
            new Step("Here we will select the action bar.\r\n\r\n1. First let’s select the background colour. Using button at the bottom of this panel entitled 'Background Colour', select the background colour of the screen.\r\n\r\n2. Then select the action bar by clicking in one corner, and then the diagonally opposite corner. Do not include the status bar (the bar that has the time, batter level ect...) if its present.\r\nIf there is no action bar click the skip button.\r\n\r\nTip!\r\nUse the mouse wheel to zoom in or out of the design, use your mouse cursor on the edges to move the design, or WASD to move the design.", null),
            new Step("Here we will chose the primary colour, primary dark, and accent colours.\r\nYou can select these using the buttons below.\r\n\r\nI may have selected some automatically based on the action bar but feel free to update them.\r\n\r\nThe primary colour is usually the colour of the action bar, or a distinct colour which is used throughout the design\r\n\r\nThe primary dark colour is a colour that is slightly darker than the primary colour, usually found in the notification bar (the bar with the time and battery level) in Android 5.0+, this is optional\r\n\r\nThe accent colour is a colour that is not the primary or primary dark colour, but is still used throughout the design, for example, there may be a button that is a different colour to the other buttons or action bar colour on screen, this is the accent colour. This is optional.", null),
            new Step("Now we're up to selecting widgets.\r\n\r\nSelect individual widgets by themselves, do not highlight more than one widget at a time.\r\n\r\nSupported widgets are: buttons, labels, textboxes, images, and maps.\r\n\r\n1. First select the background colour using the button at the bottom of this panel entitled 'Background Colour', the background colour is a colour that is around the widget.\r\n2. Select widgets by clicking in two points diagonally opposite around the widget.\r\n\r\nRepeat the process until every widget has been analysed.\r\n\r\nYou can click outside the widget, and it will be cropped automatically using the background colour.", null)
        };
    }

    class Step
    {
        public string Text { get; set; }
        public string Image { get; set; }

        public Step(string Instructions, string Image)
        {
            this.Text = Instructions;
            this.Image = Image;
        }
    }
}
