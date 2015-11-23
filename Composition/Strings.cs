using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Composition
{
    /// <summary>
    /// Strings Class
    /// Supository for all known strings found in the image design
    /// Can output XML string for output to disk
    /// </summary>
    public class Strings
    {
        private static List<string> _knownStrings = new List<string>();

        private static List<string> _knownStringIDs = new List<string>();

        private static Dictionary<string, string> _IDToString = new Dictionary<string, string>();

        public static string retrieveStringByID(string name)
        {
            return _IDToString[name];
        }

        public static bool existsStringID(string name)
        {
            return _IDToString.ContainsKey(name);
        }

        public static string AddActivityName(string activityName)
        {
            string id = activityName + "_activity_name";
            _knownStrings.Add(activityName);
            _knownStringIDs.Add(id);
            _IDToString.Add(id, activityName);

            return id;
        }

        public static string AddAppName(string appName)
        {
            string id = "app_name";
            _knownStrings.Add(appName);
            _knownStringIDs.Add(id);
            _IDToString.Add(id, appName);

            return id;
        }

        public static string AddString(string activityName, string text, WidgetType type)
        {
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] tokenData = new byte[4];
            rng.GetBytes(tokenData);
            string randomChars = Convert.ToBase64String(tokenData);

            string id = "";

            if (text != null || text != "")
            {
                id = activityName + "_" + type.ToString() + "_" + text.Replace(" ", "");
            }
            else
            {
                id = activityName + "_" + type.ToString();
            }

            var sb = new StringBuilder();

            foreach (char c in id)
            {
                if (char.IsLetterOrDigit(c))
                    sb.Append(c);
                else if (c == '_')
                    sb.Append(c);
            }

            id = sb.ToString();
            id = id.ToLower();

            string newText = text;

            sb = new StringBuilder();

            foreach (char c in newText)
            {
                if (c == '\'')
                    sb.Append("\\'");
                else
                    sb.Append(c);
            }

            newText = sb.ToString();

            if (!_knownStringIDs.Contains(id))
            {
                _knownStrings.Add(newText);
                _knownStringIDs.Add(id);
                _IDToString.Add(id, newText);
            }
            else
            {
                id += "_" + randomChars.ToLower();

                while (_knownStringIDs.Contains(id))
                {
                    rng.GetBytes(tokenData);
                    randomChars = Convert.ToBase64String(tokenData);

                    id += "_" + randomChars.ToLower();

                    foreach (char c in id)
                    {
                        if (char.IsLetterOrDigit(c))
                            sb.Append(c);
                        else if (c == '_')
                            sb.Append(c);
                    }

                    id = sb.ToString();
                    id = id.ToLower();
                }

                _knownStrings.Add(newText);
                _knownStringIDs.Add(id);
                _IDToString.Add(id, newText);
            }

            return id;
        }

        public static string XMLFilePathAndName
        {
            get
            {
                return XMLFilePath + XMLFileName;
            }
        }

        public static string XMLFilePath
        {
            get
            {
                return "app\\src\\main\\res\\values\\";
            }
        }

        public static string XMLFileName
        {
            get
            {
                return "strings.xml";
            }
        }

        public static string GenerateXML()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<resources>");

            foreach (string id in _knownStringIDs)
            {
                string text = _IDToString[id];
                sb.Append("    <string name=\"");
                sb.Append(id);
                sb.Append("\">");
                sb.Append(text);
                sb.Append("</string>");
                sb.Append(Environment.NewLine);
            }

            sb.AppendLine("</resources>");

            return sb.ToString();
        }
    }
}
