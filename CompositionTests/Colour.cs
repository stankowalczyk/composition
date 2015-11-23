using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace CompositionTests
{
    /// <summary>
    /// Colour Class
    /// Used as the supository of all known colours gathered from the input design
    /// Can ouput the required XML string for output to disk
    /// </summary>
    class Colour
    {
        public static readonly string PrimaryColourName = "colorPrimary";
        public static readonly string PrimaryDarkColourName = "colorPrimaryDark";
        public static readonly string AccentColourName = "colorAccent";

        public static bool IsColourSimilar(Color first, Color second)
        {
            return IsColourSimilar(first, second, 20, 20);
        }

        public static bool IsColourSimilar(Color first, Color second, int acceptableUpperRange, int acceptableLowerRange)
        {
            // The tolerance range - useful for JPEG compression which is highly lossy

            int rUpper = second.R + acceptableUpperRange;
            int rLower = second.R - acceptableLowerRange;
            int gUpper = second.G + acceptableUpperRange;
            int gLower = second.G - acceptableLowerRange;
            int bUpper = second.B + acceptableUpperRange;
            int bLower = second.B - acceptableLowerRange;

            return first.R < rUpper && first.R > rLower
                && first.B < bUpper && first.B > bLower
                && first.G < gUpper && first.G > gLower;
        }

        private static List<Color> _knownColours = new List<Color>();

        private static List<string> _knownColourDesignations = new List<string>();

        private static Dictionary<string, Color> _stringToColor = new Dictionary<string, Color>();

        private static Dictionary<Color, string> _colorToString = new Dictionary<Color, string>();

        public static void Clear()
        {
            _knownColours = new List<Color>();

            _knownColourDesignations = new List<string>();

            _stringToColor = new Dictionary<string, Color>();

            _colorToString = new Dictionary<Color, string>();
        }

        public static Color retrieveColour(string name)
        {
            return _stringToColor[name];
        }

        public static bool existsColour(string name)
        {
            return _stringToColor.ContainsKey(name);
        }

        public static string AddPrimaryColour(Color colour)
        {
            string colourName = PrimaryColourName;

            return AddPrimaryPrimaryDarkOrAccentColour(colour, colourName);
        }

        public static string AddPrimaryDarkColour(Color colour)
        {
            string colourName = PrimaryDarkColourName;

            return AddPrimaryPrimaryDarkOrAccentColour(colour, colourName);
        }

        public static string AddAccentColour(Color colour)
        {
            string colourName = AccentColourName;

            return AddPrimaryPrimaryDarkOrAccentColour(colour, colourName);
        }

        private static string AddPrimaryPrimaryDarkOrAccentColour(Color colour, string colourName)
        {
            if (!_stringToColor.ContainsKey(colourName))
            {
                _knownColours.Add(colour);
                _knownColourDesignations.Add(colourName);

                _colorToString.Add(colour, colourName);
                _stringToColor.Add(colourName, colour);
            }
            else
            {
                Color c = _stringToColor[colourName];
                _knownColours.Remove(c);

                _knownColours.Add(colour);

                _colorToString.Remove(c);
                _colorToString.Add(colour, colourName);

                _stringToColor[colourName] = colour;
            }

            return colourName;
        }

        public static string AddColour(Color colour, WidgetType type, string widgetText)
        {            
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] tokenData = new byte[4];
            rng.GetBytes(tokenData);
            string randomChars = Convert.ToBase64String(tokenData);

            string newWidgetText = widgetText;

            string colourName = "";

            // If we have already stored a colour like that...
            bool foundKnownColour = false;
            Color storedColour = Color.Empty;
            foreach (Color c in _knownColours)
            {
                if (IsColourSimilar(colour, c))
                {
                    foundKnownColour = true;
                    storedColour = c;
                    break;
                }
            }

            // ... return its name
            if (foundKnownColour)
            {
                return _colorToString[storedColour];
            }

            // If we haven't stored a colour like that, try and find its name
            string knownColourName = "Unknown";
            foreach (KnownColor kc in Enum.GetValues(typeof(KnownColor)))
            {
                Color known = Color.FromKnownColor(kc);
                if (IsColourSimilar(colour, known))
                {
                    knownColourName = known.Name;
                    break;
                }
            }

            // If it has a system designated name, create a new name
            if (knownColourName != "Unknown")
            {
                colourName = knownColourName.ToLower() + "_" + type.ToString().ToLower();

                while (_knownColourDesignations.Contains(colourName))
                {
                    rng.GetBytes(tokenData);
                    randomChars = Convert.ToBase64String(tokenData);

                    colourName += "_" + randomChars.ToLower();

                    StringBuilder sb = new StringBuilder();

                    foreach (char c in colourName)
                    {
                        if (char.IsLetterOrDigit(c))
                            sb.Append(c);
                        else if (c == '_')
                            sb.Append(c);
                    }

                    colourName = sb.ToString();
                    colourName = colourName.ToLower();
                }

                _knownColours.Add(colour);
                _knownColourDesignations.Add(colourName);

                _colorToString.Add(colour, colourName);
                _stringToColor.Add(colourName, colour);

                return colourName;
            }

            // Colour doesnt have a system defined name, create a different name
            if (newWidgetText != null && newWidgetText != "")
            {
                var sb = new StringBuilder();

                foreach (char c in newWidgetText)
                {
                    if (char.IsLetterOrDigit(c))
                        sb.Append(c);
                    else if (c == '_')
                        sb.Append(c);
                }

                newWidgetText = sb.ToString();
                newWidgetText = newWidgetText.ToLower();

                colourName = type.ToString().ToLower() + "_" + newWidgetText.ToLower().Replace(" ", "");

                while (_knownColourDesignations.Contains(colourName))
                {
                    rng.GetBytes(tokenData);
                    randomChars = Convert.ToBase64String(tokenData);

                    colourName += "_" + randomChars.ToLower();

                    sb = new StringBuilder();

                    foreach (char c in newWidgetText)
                    {
                        if (char.IsLetterOrDigit(c))
                            sb.Append(c);
                        else if (c == '_')
                            sb.Append(c);
                    }

                    colourName = sb.ToString();
                }

                _knownColours.Add(colour);
                _knownColourDesignations.Add(colourName);

                _colorToString.Add(colour, colourName);
                _stringToColor.Add(colourName, colour);

                return colourName;
            }
            
            // And if all else fails
            colourName = type.ToString().ToLower() + "_" + randomChars.ToLower();

            while (_knownColourDesignations.Contains(colourName))
            {
                rng.GetBytes(tokenData);
                randomChars = Convert.ToBase64String(tokenData);

                colourName += "_" + randomChars.ToLower();

                var sb = new StringBuilder();

                foreach (char c in newWidgetText)
                {
                    if (char.IsLetterOrDigit(c))
                        sb.Append(c);
                    else if (c == '_')
                        sb.Append(c);
                }

                colourName = sb.ToString();
            }

            _knownColours.Add(colour);
            _knownColourDesignations.Add(colourName);

            _colorToString.Add(colour, colourName);
            _stringToColor.Add(colourName, colour);

            return colourName;
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
                return "colors.xml";
            }
        }

        public static string GenerateXML()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<resources>");

            foreach (string colourName in _knownColourDesignations)
            {
                Color c = _stringToColor[colourName];
                sb.Append("    <color name=\"");
                sb.Append(colourName);
                sb.Append("\">#");
                sb.Append(c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2"));
                sb.Append("</color>");
                sb.Append(Environment.NewLine);
            }

            sb.AppendLine("</resources>");

            return sb.ToString();
        }

        public static Color ColourFromAhsb(int a, float h, float s, float b)
        {

            if (0 > a || 255 < a)
            {
                throw new ArgumentOutOfRangeException("a", a, "Alpha out of range");
            }
            if (0f > h || 360f < h)
            {
                throw new ArgumentOutOfRangeException("h", h, "Hue out of range");
            }
            if (0f > s || 1f < s)
            {
                throw new ArgumentOutOfRangeException("s", s, "Saturation out of range");
            }
            if (0f > b || 1f < b)
            {
                throw new ArgumentOutOfRangeException("b", b, "Brightness out of range");
            }

            if (0 == s)
            {
                return Color.FromArgb(a, Convert.ToInt32(b * 255),
                  Convert.ToInt32(b * 255), Convert.ToInt32(b * 255));
            }

            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;

            if (0.5 < b)
            {
                fMax = b - (b * s) + s;
                fMin = b + (b * s) - s;
            }
            else
            {
                fMax = b + (b * s);
                fMin = b - (b * s);
            }

            iSextant = (int)Math.Floor(h / 60f);
            if (300f <= h)
            {
                h -= 360f;
            }
            h /= 60f;
            h -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = h * (fMax - fMin) + fMin;
            }
            else
            {
                fMid = fMin - h * (fMax - fMin);
            }

            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            switch (iSextant)
            {
                case 1:
                    return Color.FromArgb(a, iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb(a, iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb(a, iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb(a, iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb(a, iMax, iMin, iMid);
                default:
                    return Color.FromArgb(a, iMax, iMid, iMin);
            }
        }

    }
}
