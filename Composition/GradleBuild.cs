using System;
using System.Text;

namespace Composition
{
    /// <summary>
    /// Gradle Build Class
    /// Model representing the Gradle build file
    /// Can generate string representation for output to disk
    /// </summary>
    public class GradleBuild
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
                return "app\\";
            }
        }

        public static string FileName
        {
            get
            {
                return "build.gradle";
            }
        }

        public static string WriteGradleBuildString(Design design)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("// This XML should only be used as a reference for what to add to an existing project");
            sb.AppendLine();
            sb.AppendLine("apply plugin: 'com.android.application'");
            sb.AppendLine("apply plugin: 'android-apt'");
            sb.AppendLine("// Replace with current version");
            sb.AppendLine("def AAVersion = '3.3.2'");
            sb.AppendLine();
            sb.AppendLine("buildscript {");
            sb.AppendLine("    repositories {");
            sb.AppendLine("        mavenCentral()");
            sb.AppendLine("    }");
            sb.AppendLine("    dependencies {");
            sb.AppendLine("        // replace with the current version of the Android plugin");
            sb.AppendLine("        classpath 'com.android.tools.build:gradle:1.3.0'");
            sb.AppendLine("        // replace with the current version of the android-apt plugin");
            sb.AppendLine("        classpath 'com.neenbedankt.gradle.plugins:android-apt:1.4'");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            sb.AppendLine();
            sb.AppendLine("repositories {");
            sb.AppendLine("    mavenCentral()");
            sb.AppendLine("    mavenLocal()");
            sb.AppendLine("}");
            sb.AppendLine();
            sb.AppendLine("android {");
            sb.AppendLine("    compileSdkVersion 22");
            sb.AppendLine("    buildToolsVersion \"22.0.1\"");
            sb.AppendLine();
            sb.AppendLine("    defaultConfig {");
            sb.AppendLine(string.Format("        applicationId \"{0}.{1}\"", design.OrgURL, design.AppName));
            sb.AppendLine("        minSdkVersion 22");
            sb.AppendLine("        targetSdkVersion 22");
            sb.AppendLine("        versionCode 1");
            sb.AppendLine("        versionName \"1.0\"");
            sb.AppendLine("    }");
            sb.AppendLine("    buildTypes {");
            sb.AppendLine("        release {");
            sb.AppendLine("            minifyEnabled false");
            sb.AppendLine("            proguardFiles getDefaultProguardFile('proguard-android.txt'), 'proguard-rules.pro'");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            sb.AppendLine();
            sb.AppendLine("dependencies {");
            sb.AppendLine("    // Some of these dependencies are needed, others are just good to have, check them out");
            sb.AppendLine("    apt \"org.androidannotations:androidannotations:$AAVersion\"");
            sb.AppendLine("    compile \"org.androidannotations:androidannotations-api:$AAVersion\"");
            sb.AppendLine("    compile fileTree(dir: 'libs', include: ['*.jar'])");
            sb.AppendLine("    compile 'com.android.support:design:22.2.1'");
            sb.AppendLine("    compile 'com.rengwuxian.materialedittext:library:2.1.4'");
            sb.AppendLine("    compile 'com.afollestad:material-dialogs:0.7.6.0'");
            sb.AppendLine("}");
            sb.AppendLine();
            sb.AppendLine("// YOU NEED TO COPY THIS - Required for Android Annotations");
            sb.AppendLine("apt {");
            sb.AppendLine("    arguments {");
            sb.AppendLine("        androidManifestFile variant.outputs[0].processResources.manifestFile");
            sb.AppendLine("        // if you have multiple outputs (when using splits), you may want to have other index than 0");
            sb.AppendLine();
            sb.AppendLine("        // you should set your package name here if you are using different application IDs");
            sb.AppendLine("        // resourcePackageName \"your.package.name\"");
            sb.AppendLine();
            sb.AppendLine("        // You can set optional annotation processing options here, like these commented options:");
            sb.AppendLine("        // logLevel 'INFO'");
            sb.AppendLine("        // logFile '/var/log/aa.log'");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
