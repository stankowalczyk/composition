using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition.Views
{
    /// <summary>
    /// Image View Class
    /// Model representing an image UI element
    /// Is able to generate an XML representation of itself for output to disk
    /// </summary>
    public class ImageView : View
    {
        public string ImageID { get; set; }

        public override string CreateActivityLayoutXML(int indentationLevel)
        {
            string indentation = "";

            for (int i = 0; i < indentationLevel * 4; i++)
                indentation += " ";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(indentation + "<ImageView");
            sb.AppendLine(indentation + "    android:layout_width=\"wrap_content\"");
            sb.AppendLine(indentation + "    android:layout_height=\"wrap_content\"");
            sb.Append(indentation + string.Format("    android:src=\"@drawable/{0}\" />", ImageID));

            return sb.ToString();
        }

        public override string CreateStyleXML(int indentationLevel)
        {
            throw new NotImplementedException();
        }

        public override string CreateLayoutFileXML()
        {
            throw new NotImplementedException();
        }
    }
}
