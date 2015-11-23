using System;
using System.IO;
using System.Threading.Tasks;

namespace Composition
{
    /// <summary>
    /// Project Writer Class
    /// Responsible for writing project to disk
    /// </summary>
    public class ProjectWriter
    {
        public static string ProjectPath { get { return "C:\\Users\\" + Environment.UserName + "\\Desktop\\CompositionAndroidProject\\"; } }

        public static void WriteProjectToDisk(Design design)
        {
            Directory.CreateDirectory(ProjectPath);

            Directory.CreateDirectory(ProjectPath + AndroidManifest.FilePath);
            File.AppendAllText(ProjectPath + AndroidManifest.FilePathAndName, AndroidManifest.WriteManifestString(design));

            Directory.CreateDirectory(ProjectPath + GradleBuild.FilePath);
            File.AppendAllText(ProjectPath + GradleBuild.FilePathAndName, GradleBuild.WriteGradleBuildString(design));

            Directory.CreateDirectory(ProjectPath + ActivityFiles.ActivityJavaFilePath(design));
            File.AppendAllText(ProjectPath + ActivityFiles.ActivityJavaFilePathAndName(design), ActivityFiles.ActivityJavaCode(design));

            Directory.CreateDirectory(ProjectPath + ActivityFiles.ActivityXMLFilePath);
            File.AppendAllText(ProjectPath + ActivityFiles.ActivityXMLFilePathAndName(design), ActivityFiles.ActivityXML(design));

            Directory.CreateDirectory(ProjectPath + Colour.XMLFilePath);
            File.AppendAllText(ProjectPath + Colour.XMLFilePathAndName, Colour.GenerateXML());

            Directory.CreateDirectory(ProjectPath + Strings.XMLFilePath);
            File.AppendAllText(ProjectPath + Strings.XMLFilePathAndName, Strings.GenerateXML());

            Directory.CreateDirectory(ProjectPath + Styles.Style21XMLFilePath);
            File.AppendAllText(ProjectPath + Styles.Style21XMLFilePathAndName, Styles.Style21XML());

            Directory.CreateDirectory(ProjectPath + Styles.StyleXMLFilePath);
            File.AppendAllText(ProjectPath + Styles.StyleXMLFilePathAndName, Styles.StyleXML());

            Directory.CreateDirectory(ProjectPath + Drawables.DrawableFilePath);
            Drawables.WriteBitmapsToDisk(ProjectPath + Drawables.DrawableFilePath);

            Directory.CreateDirectory(ProjectPath + "app\\src\\main\\res\\");
            DirectoryCopy("AndroidProjectResources\\Icons\\mipmap-hdpi\\", ProjectPath + "app\\src\\main\\res\\mipmap-hdpi\\", true);
            DirectoryCopy("AndroidProjectResources\\Icons\\mipmap-mdpi\\", ProjectPath + "app\\src\\main\\res\\mipmap-mdpi\\", true);
            DirectoryCopy("AndroidProjectResources\\Icons\\mipmap-xhdpi\\", ProjectPath + "app\\src\\main\\res\\mipmap-xhdpi\\", true);
            DirectoryCopy("AndroidProjectResources\\Icons\\mipmap-xxhdpi\\", ProjectPath + "app\\src\\main\\res\\mipmap-xxhdpi\\", true);

            if (design.ActionBar != null)
            {
                Directory.CreateDirectory(ProjectPath + design.ActionBar.LayoutXMLFilePath);
                File.AppendAllText(ProjectPath + design.ActionBar.LayoutXMLFilePathAndName, design.ActionBar.CreateLayoutFileXML());
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            try
            {
                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
                DirectoryInfo[] dirs = dir.GetDirectories();

                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + sourceDirName);
                }

                // If the destination directory doesn't exist, create it. 
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, false);
                }

                // If copying subdirectories, copy them and their contents to new location. 
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }
            catch (Exception)
            {
                //Do Nothing, cause its probably a "File alreadyy exists" exception
            }
        }
    }
}
