using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionTests.Views
{
    public class ButtonView : View
    {
        public string ButtonText { get; set; }

        public string ButtonTextStringID { get; set; }

        public bool FlatButton { get; set; }

        public string TextColour { get; set; }

        public string ButtonColour { get; set; }

        public override string CreateActivityLayoutXML(int indentationLevel)
        {
            string indentation = "";

            for (int i = 0; i < indentationLevel * 4; i++)
                indentation += " ";

            StringBuilder sb = new StringBuilder();

            //sb.AppendLine(indentation + "<Button");
            sb.AppendLine(indentation + "<android.support.v7.widget.AppCompatButton");
            sb.AppendLine(indentation + "    android:layout_width=\"wrap_content\"");
            sb.AppendLine(indentation + "    android:layout_height=\"wrap_content\"");
            
            if (FlatButton)
                sb.AppendLine(indentation + "    style=\"?android:attr/borderlessButtonStyle\"");
            else
                sb.AppendLine(indentation + string.Format("    android:backgroundTint=\"@color/{0}\"", ButtonColour));

            sb.AppendLine(indentation + string.Format("    android:textColor=\"@color/{0}\"", TextColour));
            sb.Append(indentation + string.Format("    android:text=\"@string/{0}\" />", ButtonTextStringID));

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
