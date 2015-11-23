using System;
using System.Text;

namespace Composition
{
    /// <summary>
    /// Android Manifest Class
    /// Model representing the Android Manifest XML file, can generate XML representation of self for disk output
    /// </summary>
    public class AndroidManifest
    {
        public static string FilePathAndName
        {
            get
            {
                return FilePath + FileName;
            }
        }

        public static string FilePath
        {
            get
            {
                return "app\\src\\main\\";
            }
        }

        public static string FileName
        {
            get
            {
                return "AndroidManifest.xml";
            }
        }

        public static string WriteManifestString(Design design)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.AppendLine("<!-- This should only be used as a reference or guide, please copy the relevant parts out to your actual manifest file -->");
            sb.AppendLine("<manifest xmlns:android=\"http://schemas.android.com/apk/res/android\"");
            sb.AppendLine(string.Format("    package=\"{0}.{1}\" >", design.OrgURL, design.AppName));
            sb.AppendLine();
            sb.AppendLine("    <application");
            sb.AppendLine("        android:allowBackup=\"true\"");
            sb.AppendLine("        android:icon=\"@mipmap/ic_launcher\"");
            sb.AppendLine("        android:label=\"@string/app_name\"");
            sb.AppendLine("        android:theme=\"@style/AppTheme\">");
            sb.AppendLine();
            sb.AppendLine("        <!-- THIS IS THE PART YOU SHOULD COPY -->");
            sb.AppendLine("        <activity");
            sb.AppendLine(string.Format("            android:name=\".activity.{0}_\"", design.ActivityName));
            if (design.ActionBar != null)
            {
                sb.AppendLine(string.Format("            android:label=\"@string/{0}\">", design.ActionBar.TitleTextStringID));
            }
            else
            {
                sb.AppendLine(string.Format("            android:label=\"@string/{0}\">", design.ActivityNameStringID));
            }
            sb.AppendLine("            <intent-filter>");
            sb.AppendLine("                <action android:name=\"android.intent.action.MAIN\" />");
            sb.AppendLine("                <category android:name=\"android.intent.category.LAUNCHER\" />");
            sb.AppendLine("            </intent-filter>");
            sb.AppendLine("        </activity>");
            sb.AppendLine("    </application>");
            sb.AppendLine();
            sb.AppendLine("</manifest>");

            return sb.ToString();
        }
    }
}
