using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition.Views
{
    /// <summary>
    /// Text Entry Field Class
    /// Models the text entry field UI element
    /// Is able to generate an XML representation of itself for output to disk
    /// </summary>
    public class TextField : View
    {
        public string HintText { get; set; }

        public string HintTextStringID { get; set; }

        public void RegisterTextWithStringsClass(Design design)
        {
            HintTextStringID = Strings.AddString(design.ActivityName, HintText, this.WidgetType);
        }

        public override string CreateActivityLayoutXML(int indentationLevel)
        {
            string indentation = "";

            for (int i = 0; i < indentationLevel * 4; i++)
                indentation += " ";

            StringBuilder sb = new StringBuilder();


            sb.AppendLine(indentation + "<EditText");
            sb.AppendLine(indentation + "        android:layout_width=\"match_parent\"");
            sb.AppendLine(indentation + "        android:layout_height=\"wrap_content\"");
            sb.Append(indentation + string.Format("        android:hint=\"@string/{0}\" />", HintTextStringID));

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
