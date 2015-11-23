using System;
using System.Collections.Generic;
using System.Drawing;

namespace CompositionTests
{
    /// <summary>
    /// Image Test Data Class
    /// Model used to represent each "test" data
    /// Stores a screen, as well as each widget ("WidgetArea" class) that is to be tested on it.
    /// Includes primary colour
    /// </summary>
    public class ImageTestData
    {
        public string FilePath { get; set; }

        public List<WidgetArea> WidgetAreaList { get; set; }

        public int PrimaryColourRed { get; set; }
        public int PrimaryColourBlue { get; set; }

        public int PrimaryColourGreen { get; set; }
    }
}
