using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition.Views
{
    /// <summary>
    /// Label View Class
    /// Model for the Label UI element
    /// Is able to generate an XML representation of itself for output to disk
    /// </summary>
    public class LabelView : View
    {
        public string LabelText { get; set; }

        public string LabelTextStringID { get; set; }

        public void RegisterLabelTextWithStringsClass(Design design)
        {
            LabelTextStringID = Strings.AddString(design.ActivityName, LabelText, this.WidgetType);
        }

        public string TextColour { get; set; }

        public override string CreateActivityLayoutXML(int indentationLevel)
        {
            string indentation = "";

            for (int i = 0; i < indentationLevel * 4; i++)
                indentation += " ";

            StringBuilder sb = new StringBuilder();


            sb.AppendLine(indentation + "<TextView");
            sb.AppendLine(indentation + "        android:layout_width=\"wrap_content\"");
            sb.AppendLine(indentation + "        android:layout_height=\"wrap_content\"");
            sb.Append(indentation + string.Format("        android:text=\"@string/{0}\" />", LabelTextStringID));

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
