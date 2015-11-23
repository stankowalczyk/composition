using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionTests.Views
{
    public class TextField : View
    {
        public string HintText { get; set; }

        public string HintTextStringID { get; set; }

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
