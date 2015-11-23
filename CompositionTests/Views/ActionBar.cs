using System;
using System.Text;
using CompositionTests;

namespace CompositionTests.Views
{
    public class ActionBar : View
    {
        public string TitleText { get; set; }

        public string TitleTextStringID { get; set; }

        public string BackgroundColour { get; set; }

        public string TextColour { get; set; }

        public override string CreateActivityLayoutXML(int indentationLevel)
        {
            string result = "";

            for (int i = 0; i < indentationLevel * 4; i++)
                result += " ";

            result += "<include layout=\"@layout/toolbar_plain\" />";

            return result;
        }

        public override string CreateStyleXML(int indentationLevel)
        {
            // As of yet, no styles are required for the action bar
            return "";
        }

        public string LayoutXMLFilePathAndName
        {
            get
            {
                return LayoutXMLFilePath + LayoutXMLFileName;
            }
        }

        public string LayoutXMLFilePath
        {
            get
            {
                return "app\\src\\main\\res\\layout\\";
            }
        }

        public string LayoutXMLFileName
        {
            get
            {
                return "toolbar_plain.xml";
            }
        }

        public override string CreateLayoutFileXML()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.AppendLine("<android.support.v7.widget.Toolbar xmlns:android=\"http://schemas.android.com/apk/res/android\"");
            sb.AppendLine("    xmlns:app=\"http://schemas.android.com/apk/res-auto\"");
            sb.AppendLine("    android:id=\"@+id/toolbar\"");
            sb.AppendLine("    android:layout_width=\"match_parent\"");
            sb.AppendLine("    android:layout_height=\"wrap_content\"");
            if (Colour.existsColour("colorPrimary"))
                sb.AppendLine("    android:background=\"?attr/colorPrimary\"");
            sb.AppendLine("    android:minHeight=\"?attr/actionBarSize\"");
            sb.AppendLine("    app:popupTheme=\"@style/ThemeOverlay.AppCompat.Light\"");
            sb.Append("    app:theme=\"@style/ThemeOverlay.AppCompat.Dark.ActionBar\" />");

            return sb.ToString();
        }
    }
}
