using System;
using System.Text;

namespace Composition
{
    /// <summary>
    // Activity Files Class
    // Model for a screen, also can generate XML / Java representation of self for output to disk.
    /// </summary>
    public class ActivityFiles
    {
        public static string ActivityXMLFilePathAndName(Design design)
        {
            return ActivityXMLFilePath + ActivityXMLFileName(design);
        }

        public static string ActivityXMLFilePath
        {
            get
            {
                return "app\\src\\main\\res\\layout\\";
            }
        }

        public static string ActivityXMLFileName(Design design)
        {
            return design.LayoutName + ".xml";
        }

        public static string ActivityXML(Design design)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<LinearLayout xmlns:android=\"http://schemas.android.com/apk/res/android\"");
            sb.AppendLine("    xmlns:tools=\"http://schemas.android.com/tools\"");
            sb.AppendLine("    android:orientation=\"vertical\"");
            sb.AppendLine("    android:layout_width=\"match_parent\"");
            sb.AppendLine("    android:layout_height=\"match_parent\"");
            sb.AppendLine(string.Format("    tools:context=\"{0}.activity.{1}\">", design.OrgURL, design.ActivityName));
            sb.AppendLine();

            if (design.ActionBar != null)
            {
                string actionbarXML = design.ActionBar.CreateActivityLayoutXML(1);
                sb.AppendLine(actionbarXML);
            }

            sb.AppendLine();

            if (design.Widgets != null)
            {
                for (int i = 0; i < design.Widgets.Count; i++)
                {
                    string widgetXML = design.Widgets[i].CreateActivityLayoutXML(1);
                    sb.AppendLine(widgetXML);
                    sb.AppendLine();
                }
            }

            sb.AppendLine("</LinearLayout>");

            return sb.ToString();
        }

        public static string ActivityJavaFilePathAndName(Design design)
        {
            return ActivityJavaFilePath(design) + ActivityJavaFileName(design);
        }

        public static string ActivityJavaFilePath(Design design)
        {
            string activityLocation = design.OrgURL.Replace(".","\\");
            return string.Format("app\\src\\main\\java\\{0}\\{1}\\activity\\", activityLocation, design.AppName);
        }

        public static string ActivityJavaFileName(Design design)
        {
            return design.ActivityName + ".java";
        }

        public static string ActivityJavaCode(Design design)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("package {0}.{1}.activity;", design.OrgURL, design.AppName));
            sb.AppendLine();
            sb.AppendLine("import android.support.v7.app.AppCompatActivity;");
            if (design.ActionBar != null)
                sb.AppendLine("import android.support.v7.widget.Toolbar;");
            sb.AppendLine();
            if (design.ActionBar != null)
                sb.AppendLine("import org.androidannotations.annotations.AfterViews;");
            sb.AppendLine(string.Format("import {0}.{1}.R;", design.OrgURL, design.AppName));
            if (design.ActionBar != null)
                sb.AppendLine("import org.androidannotations.annotations.ViewById;");
            sb.AppendLine();
            sb.AppendLine("import org.androidannotations.annotations.EActivity;");
            sb.AppendLine();
            sb.AppendLine(string.Format("@EActivity (R.layout.{0})", design.LayoutName));
            sb.AppendLine(string.Format("public class {0} extends AppCompatActivity ", design.ActivityName) + "{");
            if (design.ActionBar != null)
            {
                sb.AppendLine("    @ViewById");
                sb.AppendLine("    Toolbar toolbar;");
                sb.AppendLine();
                sb.AppendLine("    @AfterViews");
                sb.AppendLine("    void init() {");
                sb.AppendLine("        setSupportActionBar(toolbar);");
                sb.AppendLine("    }");
            }
            sb.AppendLine("}");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
