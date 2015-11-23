using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition
{
    /// <summary>
    /// Styles Class
    /// Generates an XML string representation for output to disk
    /// </summary>
    public class Styles
    {
        // Note:
        // Style 21 is for android versions 21 and newer
        // Style is for android versions 20 and older

        public static string Style21XMLFilePathAndName
        {
            get
            {
                return Style21XMLFilePath + Style21XMLFileName;
            }
        }

        public static string Style21XMLFilePath
        {
            get
            {
                return "app\\src\\main\\res\\values-v21\\";
            }
        }

        public static string Style21XMLFileName
        {
            get
            {
                return "styles.xml";
            }
        }

        public static string Style21XML()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<resources>");
            sb.AppendLine("    <style name=\"AppTheme.Base\" parent=\"Theme.AppCompat.Light.NoActionBar\">");
            if (Colour.existsColour("colorPrimary"))
                sb.AppendLine("        <item name=\"colorPrimary\">@color/colorPrimary</item>");
            if (Colour.existsColour("colorPrimaryDark"))
                sb.AppendLine("        <item name=\"colorPrimaryDark\">@color/colorPrimaryDark</item>");
            if (Colour.existsColour("colorAccent"))
                sb.AppendLine("        <item name=\"colorAccent\">@color/colorAccent</item>");
            sb.AppendLine("    </style>");
            sb.AppendLine("</resources>");
            sb.AppendLine();

            return sb.ToString();
        }

        public static string StyleXMLFilePathAndName
        {
            get
            {
                return StyleXMLFilePath + StyleXMLFileName;
            }
        }

        public static string StyleXMLFilePath
        {
            get
            {
                return "app\\src\\main\\res\\values\\";
            }
        }

        public static string StyleXMLFileName
        {
            get
            {
                return "styles.xml";
            }
        }

        public static string StyleXML()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<resources>");
            sb.AppendLine("    <!-- Base application theme -->");
            sb.AppendLine("    <style name=\"AppTheme\" parent=\"AppTheme.Base\" />");
            sb.AppendLine();
            sb.AppendLine("    <!-- Base application theme -->");
            sb.AppendLine("    <style name=\"AppTheme.Base\" parent=\"Theme.AppCompat.Light.NoActionBar\">");
            if (Colour.existsColour("colorPrimary"))
                sb.AppendLine("        <item name=\"colorPrimary\">@color/colorPrimary</item>");
            if (Colour.existsColour("colorPrimaryDark"))
                sb.AppendLine("        <item name=\"colorPrimaryDark\">@color/colorPrimaryDark</item>");
            if (Colour.existsColour("colorAccent"))
                sb.AppendLine("        <item name=\"colorAccent\">@color/colorAccent</item>");
            sb.AppendLine("    </style>");
            sb.AppendLine("</resources>");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
