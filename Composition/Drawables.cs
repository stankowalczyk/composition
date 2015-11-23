using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace Composition
{
    /// <summary>
    /// Drawables Class
    /// Stores all of the drawables (i.e. images) scraped from a design.
    /// Can output to disk
    /// </summary>
    public class Drawables
    {
        private static List<Bitmap> _knownImages = new List<Bitmap>();

        private static List<string> _knownIDs = new List<string>();

        private static Dictionary<string, Bitmap> _IDToBitmap = new Dictionary<string, Bitmap>();

        public static Bitmap retrieveBitmapByID(string name)
        {
            return _IDToBitmap[name];
        }

        public static bool existsStringID(string name)
        {
            return _IDToBitmap.ContainsKey(name);
        }

        public static string AddBitmap(string activityName, Bitmap image, WidgetType type)
        {
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] tokenData = new byte[4];
            rng.GetBytes(tokenData);
            string randomChars = Convert.ToBase64String(tokenData);

            string id = "";

            id = activityName + "_" + type.ToString() + "_" + randomChars;
            id = id.ToLower();

            while (_knownIDs.Contains(id))
            {
                tokenData = new byte[4];
                rng.GetBytes(tokenData);
                randomChars = Convert.ToBase64String(tokenData);

                id += "_" + randomChars;
                id = id.ToLower();
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

            _knownImages.Add(image);
            _knownIDs.Add(id);
            _IDToBitmap.Add(id, image);

            return id;
        }

        public static string DrawableFilePath
        {
            get
            {
                return "app\\src\\main\\res\\drawable\\";
            }
        }

        public static void WriteBitmapsToDisk(string fullPath)
        {
            foreach (string id in _knownIDs)
            {
                Bitmap temp = _IDToBitmap[id];

                temp.Save(fullPath + id + ".bmp");
            }
        }
    }
}
