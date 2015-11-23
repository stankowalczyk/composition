using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionTests
{
    /// <summary>
    /// Result Class
    /// Model representing the result of a classification (including what a human classified the element to be)
    /// </summary>
    class Result
    {
        public string ImagePath { get; set; }

        public int WidgetIndexInImage { get; set; }

        public string WidgetType { get; set; }

        public string AnalsisResultWidgetType { get; set; }

        public bool Correct { get; set; }
    }
}
