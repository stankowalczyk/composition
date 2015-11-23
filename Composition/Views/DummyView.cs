using System;
using System.Text;

namespace Composition.Views
{
    /// <summary>
    /// Dummy View
    /// Models a "dummy" view (just an empty image UI element) allowing the user to replace it later.
    /// Generates string representation of self for disk output
    /// </summary>
    public class DummyView : View
    {
        public override string CreateActivityLayoutXML(int indentationLevel)
        {
            string indentation = "";

            for (int i = 0; i < indentationLevel * 4; i++)
                indentation += " ";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(indentation + "<ImageView");
            sb.AppendLine(indentation + "    android:layout_width=\"wrap_content\"");
            sb.Append(indentation + "    android:layout_height=\"wrap_content\" />");

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
