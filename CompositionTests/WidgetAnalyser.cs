using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text.RegularExpressions;

using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;

namespace CompositionTests
{
    public enum WidgetType
    {
        Label,
        Button,
        Map,
        Image,
        ProductImageOrIcon,
        ActionBar,
        TextField
    }

    /// <summary>
    /// Widget Analyser Class
    /// Used to analyse and classify the type of widget which resides within an image segment, also extracts styling data
    /// </summary>
    public class WidgetAnalyser
    {
        private static Tesseract _ocr;

        private static bool _setup = false;

        private static readonly string[] _mapHexColours =
            new string[] {"#b3d1ff","#a2c5fe","#faf2c7","#d5d4c8","#3878c7","#cadfaa","#453e33","#e9e5dc","#352e22","#c9ccd8",
                "#ffe168","#00afff","#b9d2b9","#34681c","#fa9e25","#6c9f43","#e8ddbd","#dfdbd4","#c0c0c0","#736648","#c0c0c0","#ebd2cf"};

        private static List<Color> _mapColours = new List<Color>();

        private static void Setup()
        {
            if (!_setup)
            {
                _ocr = new Tesseract("", "eng", Tesseract.OcrEngineMode.OEM_TESSERACT_CUBE_COMBINED);

                // If this is not done cost for any letters recognised which are not letters (i.e. false positives) will be zero
                _ocr.Recognize(new Image<Gray, Byte>("tessdata/OCR initialise data.jpg"));

                for (int i = 0; i < _mapHexColours.Length; i++ )
                {
                    _mapColours.Add(ColorTranslator.FromHtml((_mapHexColours[i])));
                }

                _setup = true;
            }
        }

        private static double CalculateGini(Bitmap segment)
        {
            List<Double> data = new List<double>();

            Graphics resultGraphics = Graphics.FromImage(segment);

            for (int x = 0; x < segment.Width; x++)
            {
                for (int y = 0; y < segment.Height; y++)
                {
                    Color c = segment.GetPixel(x, y);
                    string hex = ColorTranslator.ToHtml(c);
                    hex = hex.Substring(1, hex.Length - 1);
                    double v = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                    data.Add(v);
                }
            }

            data.Sort();

            return Gini.Calculate(data);
        }

        public static Image<Bgr, Byte> RemoveBackgroundColour(Bitmap canvas, Color BackgroundColour)
        {
            int cropX1 = 0;
            int cropX2 = canvas.Width;
            int cropY1 = 0;
            int cropY2 = canvas.Height;

            int count = 0;
            bool breakLoop = false;

            // Top Y Crop
            for (int y = 0; y < (canvas.Height / 2); y++)
            {
                for (int x = 0; x < canvas.Width; x += 2)
                {
                    if (Colour.IsColourSimilar(canvas.GetPixel(x, y), BackgroundColour))
                    {
                        count = y;
                    }
                    else
                    {
                        breakLoop = true;
                        break;
                    }
                }

                if (breakLoop)
                {
                    breakLoop = false;
                    break;
                }
            }

            cropY1 = count;

            // Bottom Y Crop
            for (int y = 0; y < (canvas.Height / 2); y++)
            {
                for (int x = 0; x < canvas.Width; x += 2)
                {
                    if (Colour.IsColourSimilar(canvas.GetPixel(x, canvas.Height - (y + 1)), BackgroundColour))
                    {
                        count = y;
                    }
                    else
                    {
                        breakLoop = true;
                        break;
                    }
                }

                if (breakLoop)
                {
                    breakLoop = false;
                    break;
                }
            }

            cropY2 = count;

            // Left X Crop
            for (int x = 0; x < (canvas.Width / 2); x++)
            {
                for (int y = 0; y < canvas.Height; y += 2)
                {
                    if (Colour.IsColourSimilar(canvas.GetPixel(x, y), BackgroundColour))
                    {
                        count = x;
                    }
                    else
                    {
                        breakLoop = true;
                        break;
                    }
                }

                if (breakLoop)
                {
                    breakLoop = false;
                    break;
                }
            }

            cropX1 = count;

            // Right X Crop
            for (int x = 0; x < (canvas.Width / 2); x++)
            {
                for (int y = 0; y < canvas.Height; y += 2)
                {
                    if (Colour.IsColourSimilar(canvas.GetPixel(canvas.Width - (x + 1), canvas.Height - (y + 1)), BackgroundColour))
                    {
                        count = x;
                    }
                    else
                    {
                        breakLoop = true;
                        break;
                    }
                }

                if (breakLoop)
                {
                    breakLoop = false;
                    break;
                }
            }

            cropX2 = count;

            Image<Bgr, Byte> newImage = new Image<Bgr, byte>(canvas);

            if (cropX1 > 0 || cropX2 < newImage.Width || cropY1 > 0 || cropY2 < newImage.Height)
            {
                if (cropX1 + cropX2 < newImage.Width && cropY1 + cropY2 < newImage.Height)
                {
                    int x, y, newWidth, newHeight;

                    x = cropX1;
                    y = cropY1;

                    newWidth = newImage.Width - cropX2 - cropX1;
                    newHeight = newImage.Height - cropY2 - cropY1;

                    newImage = newImage.GetSubRect(new Rectangle(x, y, newWidth, newHeight));
                }
            }

            return newImage;
        }

        private static Dictionary<Color, int> SampleColours(Image<Bgr, Byte> image, out List<Color> colours)
        {
            Bitmap canvas = image.ToBitmap();

            int increment  = 1;
            if (canvas.Width > 20)
            {
                increment = canvas.Width / 20;
            }

            Dictionary<Color, int> result = new Dictionary<Color, int>();
            colours = new List<Color>();

            for (int x = 0; x < canvas.Width - increment - 1; x += increment)
            {
                for (int y = 0; y < canvas.Height - increment - 1; y += increment)
                {
                    Color tempColour = canvas.GetPixel(x, y);

                    bool matchFound = false;

                    for (int i = 0; i < colours.Count; i++)
                    {
                        if (Colour.IsColourSimilar(colours[i], tempColour))
                        {
                            result[colours[i]]++;
                            matchFound = true;
                            break;
                        }
                    }

                    if (!matchFound)
                    {
                        colours.Add(tempColour);
                        result.Add(tempColour, 1);
                    }
                }
            }

            return result;
        }

        private static bool AreSampleColoursCloseToAnotherSampleSetOfColours(Dictionary<Color, int> colourCount, List<Color> colourList, List<Color> comparisonColourList)
        {
            int similarColourCount = 0;
            int dissimilarColourCount = 0;

            for (int i = 0; i < colourList.Count; i++)
            {
                bool matchFound = false;

                for (int x = 0; x < comparisonColourList.Count; x++)
                {
                    if (Colour.IsColourSimilar(colourList[i], comparisonColourList[x]))
                    {
                        similarColourCount += colourCount[colourList[i]];
                        matchFound = true;

                        break;
                    }
                }

                if (!matchFound)
                {
                    dissimilarColourCount += colourCount[colourList[i]];
                }
            }

            double ratio = (double)similarColourCount / (similarColourCount + dissimilarColourCount);

            if (ratio > 0.5)
            {
                return true;
            }

            return false;
        }

        private static bool AreSampleColoursCloseToMapColours(Dictionary<Color, int> colourCount, List<Color> colourList)
        {
            return AreSampleColoursCloseToAnotherSampleSetOfColours(colourCount, colourList, _mapColours);
        }

        private static void getPrimaryAndSecondaryColours(Image<Bgr, Byte> image, out Color primary, out Color secondary)
        {
            List<Color> coloursList = new List<Color>();
            Dictionary<Color, int> coloursDict = SampleColours(image, out coloursList);

            Color primaryColor = Color.Empty;
            Color secondaryColor = Color.Empty;

            int primaryCount = 0;
            int secondaryCount = 0;

            foreach(Color c in coloursList)
            {
                if (primaryCount < coloursDict[c])
                {
                    primaryColor = c;
                    primaryCount = coloursDict[c];
                }
                else if (secondaryCount < coloursDict[c])
                {
                    secondaryColor = c;
                    secondaryCount = coloursDict[c];
                }
            }

            if (primaryColor == Color.Empty)
            {
                throw new Exception("Wow something really went wrong, apparently there was no colours what so ever in that image segment :S");
            }

            primary = primaryColor;
            secondary = secondaryColor;
        }

        private static Views.ActionBar AnalyseActionBar(Image<Bgr, Byte> image, Color BackgroundColour)
        {
            ActionBarText title = new ActionBarText();
            bool currentTextIsTitle = true;

            List<ActionBarText> textualButtons = new List<ActionBarText>();

            _ocr.Recognize(image.Convert<Gray, Byte>());
            Tesseract.Charactor[] charactors = _ocr.GetCharactors();

            bool[] alreadyScannedXCoord = new bool[image.Width];

            ActionBarText button = new ActionBarText();
            button.Text = "";

            if (charactors.Length > 0)
            {
                int startCharactor = 0;

                string completeString = "";

                for (int i = 0; i < charactors.Length; i++)
                {
                    completeString += charactors[i].Text;
                }

                Regex regex = new Regex(@"^((?=[a-zA-Z][a-zA-Z])[a-zA-Z]|[0-9]).+$");

                for (int i = 0; i < completeString.Length; i++)
                {
                    if (regex.IsMatch(completeString.Substring(i)))
                    {
                        startCharactor = i;
                        break;
                    }
                }

                Regex isWord = new Regex(@"^[a-zA-Z]*$");

                int startX = charactors[startCharactor].Region.X;
                int endX = startX + charactors[startCharactor].Region.Width;

                int indexOfStartTextRegion = startCharactor;

                if (startX > image.Width / 4)
                {
                    currentTextIsTitle = false;
                }
                else
                {
                    title.Text += charactors[startCharactor].Text;
                }

                for (int i = startCharactor + 1; i < charactors.Length; i++)
                {
                    if (currentTextIsTitle && (endX + 5 > charactors[i].Region.X || charactors[i].Text == ""))
                    {
                        title.Text += charactors[i].Text;
                        title.UpdateStartPoint(charactors[i].Region.X, charactors[i].Region.Y);
                        title.UpdateFurthestPoint(charactors[i].Region.X + charactors[i].Region.Width, charactors[i].Region.Y + charactors[i].Region.Height);

                        if (charactors[i].Text == " ")
                        {
                            endX += 10;
                        }
                        else
                        {
                            endX = charactors[i].Region.X + charactors[i].Region.Width;
                        }
                    }
                    else if (endX + 5 > charactors[i].Region.X && charactors[i].Text != " ")
                    {
                        button.Text += charactors[i].Text;
                        button.UpdateStartPoint(charactors[i].Region.X, charactors[i].Region.Y);
                        button.UpdateFurthestPoint(charactors[i].Region.X + charactors[i].Region.Width, charactors[i].Region.Y + charactors[i].Region.Height);

                        endX = charactors[i].Region.X + charactors[i].Region.Width;
                    }
                    else
                    {
                        if (currentTextIsTitle)
                        {
                            currentTextIsTitle = false;
                            title.Text = title.Text.Trim();

                            break;
                        }
                        else
                        {
                            if (isWord.IsMatch(button.Text.Trim()))
                            {
                                textualButtons.Add(button);
                            }
                            button = new ActionBarText();
                            button.Text = "";
                        }

                        for (int x = startX; x <= endX; x++)
                        {
                            alreadyScannedXCoord[x] = true;
                        }

                        if (charactors[i].Text == " ")
                        {
                            i++;
                        }

                        startX = charactors[i].Region.X;
                        endX = startX + charactors[i].Region.Width;

                        indexOfStartTextRegion = i;
                    }
                }
            }

            Views.ActionBar result = new Views.ActionBar();
            result.WidgetType = WidgetType.ActionBar;
            result.TitleText = title.Text;

            //Background colour and text colour detection

            Color backgroundColor;
            Color textColor;

            getPrimaryAndSecondaryColours(image, out backgroundColor, out textColor);

            string backgroundColourName = Colour.AddPrimaryColour(backgroundColor);
            string textColourName = Colour.AddColour(textColor, result.WidgetType, result.TitleText);

            return result;
        }

        public static Views.ImageView IsProductImageOrIcon(Image<Bgr, Byte> image, Color BackgroundColour)
        {
            double gini = CalculateGini(image.ToBitmap());

            List<Color> colourList;
            Dictionary<Color, int> result = SampleColours(image, out colourList);

            if (gini <= 0.6 && AreSampleColoursCloseToAnotherSampleSetOfColours(result, colourList, new List<Color>(new Color[]{BackgroundColour})))
            {
                Views.ImageView resultView = new Views.ImageView();
                resultView.WidgetType = WidgetType.Image;
                return resultView;
            }

            return null;
        }

        public static Views.ImageView IsImage(Image<Bgr, Byte> image, Color BackgroundColour)
        {
            double gini = CalculateGini(image.ToBitmap());

            List<Color> colourList;
            Dictionary<Color, int> result = SampleColours(image, out colourList);

            if (gini <= 0.7 && !AreSampleColoursCloseToMapColours(result, colourList))
            {
                Views.ImageView resultView = new Views.ImageView();
                resultView.WidgetType = WidgetType.Image;
                return resultView;
            }

            return null;
        }

        public static Views.MapView IsMap(Image<Bgr, Byte> image, Color BackgroundColour)
        {
            double gini = CalculateGini(image.ToBitmap());

            List<Color> colourList;
            Dictionary<Color, int> result = SampleColours(image, out colourList);

            if (gini >= 0.05 && AreSampleColoursCloseToMapColours(result, colourList))
            {
                Views.MapView resultView = new Views.MapView();
                resultView.WidgetType = WidgetType.Map;
                return resultView;
            }

            return null;
        }

        public static Views.ButtonView IsTextualButton(Image<Bgr, Byte> image, Color BackgroundColour)
        {
            string buttonText = "";

            _ocr.Recognize(image.Convert<Gray, Byte>());
            Tesseract.Charactor[] charactors = _ocr.GetCharactors();

            if (charactors.Length == 0)
            {
                return null;
            }

            int leftMostXCoord = charactors[0].Region.X;
            int rightMostXCoord = charactors[0].Region.Right;
            int topMostYCoord = charactors[0].Region.Y;
            int BottomMostYCoord = charactors[0].Region.Bottom;

            float minCost = charactors[0].Cost;
            float maxCost = charactors[0].Cost;

            buttonText += charactors[0].Text.ToString();

            for (int i = 1; i < charactors.Length; i++)
            {
                if (charactors[i].Text != " ")
                {
                    if (charactors[i].Region.X < leftMostXCoord)
                    {
                        leftMostXCoord = charactors[i].Region.X;
                    }
                    if (charactors[i].Region.Right > rightMostXCoord)
                    {
                        rightMostXCoord = charactors[i].Region.Right;
                    }
                    if (charactors[i].Region.Y < topMostYCoord)
                    {
                        topMostYCoord = charactors[i].Region.Y;
                    }
                    if (charactors[i].Region.Bottom > BottomMostYCoord)
                    {
                        BottomMostYCoord = charactors[i].Region.Bottom;
                    }
                }

                buttonText += charactors[i].Text.ToString();

                if (charactors[i].Cost > maxCost)
                {
                    maxCost = charactors[i].Cost;
                }

                if (charactors[i].Cost < minCost)
                {
                    minCost = charactors[i].Cost;
                }
            }

            int width = rightMostXCoord - leftMostXCoord;
            int height = BottomMostYCoord - topMostYCoord;

            int textArea = width * height;
            int canvasArea = image.Width * image.Height;

            double gini = CalculateGini(image.ToBitmap());

            Color primary;
            Color secondary;
            getPrimaryAndSecondaryColours(image, out primary, out secondary);

            //First part
            // If there arn't many characters, and OCR is condifent, and the text occupies more than half of the canvas area
            // - OR -
            // Otherwise might be a large area
            // If the gini is evenly distributed, and the max cost was less than 200
            if ((charactors.Length < 10 && maxCost < 150 && textArea / canvasArea > 0.5)  ||
                (leftMostXCoord > 30 && rightMostXCoord < image.Width - 30 && gini < 0.1))
            {
                Views.ButtonView result = new Views.ButtonView();
                result.WidgetType = WidgetType.Button;

                result.FlatButton = false;

                string backgroundColor = Colour.AddColour(primary, WidgetType.Button, buttonText);
                string textColor = Colour.AddColour(secondary, WidgetType.Button, buttonText);

                result.ButtonColour = backgroundColor;
                result.TextColour = textColor;
                result.ButtonText = buttonText;

                return result;
            }

            // Is it a flat button?

            bool isFlatButton = false;
            Color flatButtonColour = Color.Empty;

            if (Colour.existsColour(Colour.PrimaryColourName) && (Colour.IsColourSimilar(primary, Colour.retrieveColour(Colour.PrimaryColourName)) || Colour.IsColourSimilar(secondary, Colour.retrieveColour(Colour.PrimaryColourName))))
            {
                isFlatButton = true;
                flatButtonColour = Colour.retrieveColour(Colour.PrimaryColourName);
            }
            else if (Colour.existsColour(Colour.PrimaryDarkColourName) && (Colour.IsColourSimilar(primary, Colour.retrieveColour(Colour.PrimaryDarkColourName)) || Colour.IsColourSimilar(secondary, Colour.retrieveColour(Colour.PrimaryDarkColourName))))
            {
                isFlatButton = true;
                flatButtonColour = Colour.retrieveColour(Colour.PrimaryDarkColourName);
            }
            else if (Colour.existsColour(Colour.AccentColourName) && (Colour.IsColourSimilar(primary, Colour.retrieveColour(Colour.AccentColourName)) || Colour.IsColourSimilar(secondary, Colour.retrieveColour(Colour.AccentColourName))))
            {
                isFlatButton = true;
                flatButtonColour = Colour.retrieveColour(Colour.AccentColourName);
            }

            if (isFlatButton)
            {
                Views.ButtonView result = new Views.ButtonView();
                result.WidgetType = WidgetType.Button;

                result.FlatButton = true;

                string textColor = Colour.AddColour(flatButtonColour, WidgetType.Button, buttonText);

                result.TextColour = textColor;
                result.ButtonText = buttonText;

                return result;
            }

            return null;
        }

        public static Views.LabelView IsLabel(Image<Bgr, Byte> image, Color BackgroundColour)
        {
            string labelText = "";

            _ocr.Recognize(image.Convert<Gray, Byte>());
            Tesseract.Charactor[] charactors = _ocr.GetCharactors();

            if (charactors.Length == 0)
            {
                return null;
            }

            int leftMostXCoord = charactors[0].Region.X;
            int rightMostXCoord = charactors[0].Region.Right;
            int topMostYCoord = charactors[0].Region.Y;
            int BottomMostYCoord = charactors[0].Region.Bottom;

            float minCost = charactors[0].Cost;
            float maxCost = charactors[0].Cost;

            labelText += charactors[0].Text.ToString();

            for (int i = 1; i < charactors.Length; i++)
            {
                if (charactors[i].Text != " ")
                {
                    if (charactors[i].Region.X < leftMostXCoord)
                    {
                        leftMostXCoord = charactors[i].Region.X;
                    }
                    if (charactors[i].Region.Right > rightMostXCoord)
                    {
                        rightMostXCoord = charactors[i].Region.Right;
                    }
                    if (charactors[i].Region.Y < topMostYCoord)
                    {
                        topMostYCoord = charactors[i].Region.Y;
                    }
                    if (charactors[i].Region.Bottom > BottomMostYCoord)
                    {
                        BottomMostYCoord = charactors[i].Region.Bottom;
                    }
                }

                labelText += charactors[i].Text.ToString();

                if (charactors[i].Cost > maxCost)
                {
                    maxCost = charactors[i].Cost;
                }

                if (charactors[i].Cost < minCost)
                {
                    minCost = charactors[i].Cost;
                }
            }

            Bitmap canvas = image.ToBitmap();

            int colourCountWidthMax = 0;
            int colourCountHeightMax = 0;

            int colourTempCount = 0;

            // Examine a subset of the pixels to determine if background colour is present throughout the image
            for (int y = 1; y < 3; y++)
            {
                for (int x = 0; x < canvas.Width; x++)
                {
                    if (Colour.IsColourSimilar(canvas.GetPixel(x, (int)(canvas.Height / 4 * y)), BackgroundColour))
                    {
                        colourTempCount++;
                    }
                }

                if (colourTempCount > colourCountWidthMax)
                {
                    colourCountWidthMax = colourTempCount;
                }

                colourTempCount = 0;
            }

            for (int x = 1; x < 3; x++)
            {
                for (int y = 0; y < canvas.Height; y++)
                {
                    if (Colour.IsColourSimilar(canvas.GetPixel((int)(canvas.Width / 4 * x), y), BackgroundColour))
                    {
                        colourTempCount++;
                    }
                }

                if (colourTempCount > colourCountHeightMax)
                {
                    colourCountHeightMax = colourTempCount;
                }

                colourTempCount = 0;
            }

            // FIRST
            float heightBackgroundColourRatio = colourCountHeightMax / (float)canvas.Height;
            float widthBackgroundColourRatio = colourCountWidthMax / (float)canvas.Width;

            // SECOND
            int width = rightMostXCoord - leftMostXCoord;
            int height = BottomMostYCoord - topMostYCoord;

            int textArea = width * height;
            int canvasArea = image.Width * image.Height;

            // THIRD
            double gini = CalculateGini(image.ToBitmap());

            bool preTestAPass = false;
            bool preTestBPass = false;

            // PRETEST A DATA: Characters like @ cost more, so lets test
            bool complexCharactersFound = false;

            foreach (char c in labelText)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    complexCharactersFound = true;
                    break;
                }
            }

            // PRETEST A
            if (complexCharactersFound && maxCost < 350)
                preTestAPass = true;

            // PRETEST B
            if (maxCost < 200)
                preTestBPass = true;

            // PRETEST COMBINED
            if (preTestAPass == false && preTestBPass == false)
                return null;

            // First
            // If the max cost is low, and a large amount of the background pixels match the background colour
            // - OR -
            // Second
            // If there arn't many characters, and OCR is condifent, and the text occupies more than half of the canvas area
            // - OR -
            // Third
            // Otherwise might be a large area
            // If the gini is evenly distributed, and the max cost was less than 200

            if ((heightBackgroundColourRatio > 0.05 &&widthBackgroundColourRatio> 0.3) ||
                (charactors.Length < 10 && maxCost < 150 && textArea / canvasArea > 0.8 && heightBackgroundColourRatio > 0.05 && widthBackgroundColourRatio > 0.3) ||
                (gini < 0.05 && heightBackgroundColourRatio > 0.05 && widthBackgroundColourRatio > 0.3))
            {
                Views.LabelView result = new Views.LabelView();
                result.WidgetType = WidgetType.Label;

                result.LabelText = labelText;

                Color primary;
                Color secondary;

                getPrimaryAndSecondaryColours(image, out primary, out secondary);

                string textColour = Colour.AddColour(secondary, WidgetType.Label, labelText);

                result.TextColour = textColour;

                return result;
            }

            return null;
        }

        public static Views.TextField IsTextField(Image<Bgr, Byte> image, Color BackgroundColour)
        {
            string hintText = "";

            _ocr.Recognize(image.Convert<Gray, Byte>());
            Tesseract.Charactor[] charactors = _ocr.GetCharactors();

            if (charactors.Length == 0)
            {
                return null;
            }

            int leftMostXCoord = charactors[0].Region.X;
            int rightMostXCoord = charactors[0].Region.Right;
            int topMostYCoord = charactors[0].Region.Y;
            int BottomMostYCoord = charactors[0].Region.Bottom;

            float minCost = charactors[0].Cost;
            float maxCost = charactors[0].Cost;

            hintText += charactors[0].Text.ToString();

            for (int i = 1; i < charactors.Length; i++)
            {
                if (charactors[i].Region.X < leftMostXCoord)
                {
                    leftMostXCoord = charactors[i].Region.X;
                }
                if (charactors[i].Region.Right > rightMostXCoord)
                {
                    rightMostXCoord = charactors[i].Region.Right;
                }
                if (charactors[i].Region.Y < topMostYCoord)
                {
                    topMostYCoord = charactors[i].Region.Y;
                }
                if (charactors[i].Region.Bottom > BottomMostYCoord)
                {
                    BottomMostYCoord = charactors[i].Region.Bottom;
                }

                hintText += charactors[i].Text.ToString();

                if (charactors[i].Cost > maxCost)
                {
                    maxCost = charactors[i].Cost;
                }

                if (charactors[i].Cost < minCost)
                {
                    minCost = charactors[i].Cost;
                }
            }

            bool testAResult = true;
            bool testBResult = true;

            // TEST A - Data
            int textHeight = ((BottomMostYCoord - topMostYCoord) / 4);

            // TEST B - Data
            int distanceFromTop = topMostYCoord;
            int distanceFromBottom = image.Height - BottomMostYCoord;

            // TEST A - Android ~2.3 has boxes around text fields, if there is a large distance to the edges of the widget we know its a text box
            if (topMostYCoord < textHeight || BottomMostYCoord < textHeight || leftMostXCoord < textHeight)
                testAResult = false;

            // PRETEST
            if (distanceFromBottom < 2)
            {
                testBResult = false;
            }
            else
            {
                // TEST B - Android 4.0+ Text fields only have an underline, therefor the distance to the bottom should be greater.
                if (distanceFromTop + (distanceFromTop * 0.1) > distanceFromBottom)
                    testBResult = false;
            }

            if (testAResult == false && testBResult == false)
                return null;

            // Characters like @ cost more, so lets test
            bool complexCharactersFound = false;

            foreach (char c in hintText)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    complexCharactersFound = true;
                    break;
                }
            }

            if (maxCost < 200 || (complexCharactersFound && maxCost < 350))
            {
                Views.TextField result = new Views.TextField();
                result.WidgetType = WidgetType.TextField;

                result.HintText = hintText;

                return result;
            }

            return null;
        }

        public static Views.ActionBar AnalyseActionBar(Bitmap segment, Color backgroundColour, out double gini, out Bitmap preview)
        {
            Setup();

            if (backgroundColour.IsEmpty)
            {
                throw new ArgumentNullException();
            } 

            Image<Bgr, Byte> newSegment = RemoveBackgroundColour(segment, backgroundColour);
            preview = newSegment.ToBitmap();
            gini = CalculateGini(newSegment.ToBitmap());

            return AnalyseActionBar(newSegment, backgroundColour);
        }

        public static Views.View AnalyseImageSegment(Bitmap segment, Color backgroundColour, out double gini, out Bitmap preview)
        {
            Setup();

            if (backgroundColour.IsEmpty)
            {
                throw new ArgumentNullException();
            }

            try
            {
                Image<Bgr, Byte> newSegment = RemoveBackgroundColour(segment, backgroundColour);
                gini = CalculateGini(newSegment.ToBitmap());
                preview = newSegment.ToBitmap();

                Views.ButtonView buttonView = IsTextualButton(newSegment, backgroundColour);
                if (buttonView != null)
                {
                    return buttonView;
                }

                Views.TextField textView = IsTextField(newSegment, backgroundColour);
                if (textView != null)
                {
                    return textView;
                }

                Views.LabelView labelView = IsLabel(newSegment, backgroundColour);
                if (labelView != null)
                {
                    return labelView;
                }

                Views.MapView mapView = IsMap(newSegment, backgroundColour);
                if (mapView != null)
                {
                    return mapView;
                }

                Views.ImageView imageView = IsProductImageOrIcon(newSegment, backgroundColour);
                if (imageView != null)
                {
                    return imageView;
                }

                imageView = IsImage(newSegment, backgroundColour);
                if (imageView != null)
                {
                    return imageView;
                }
            }
            catch (Exception)
            {

            }

            Image<Bgr, Byte> image = new Image<Bgr, Byte>(segment);
            gini = CalculateGini(image.ToBitmap());
            preview = image.ToBitmap();

            Views.LabelView labelViewReRun = IsLabel(image, backgroundColour);
            if (labelViewReRun != null)
            {
                return labelViewReRun;
            }

            Views.ImageView imageViewReRun = IsProductImageOrIcon(image, backgroundColour);
            if (imageViewReRun != null)
            {
                return imageViewReRun;
            }

            imageViewReRun = IsImage(image, backgroundColour);
            if (imageViewReRun != null)
            {
                return imageViewReRun;
            }

            gini = -1.0;
            preview = segment;
            return null;
        }
    }

    public class ActionBarText
    {
        public string Text { get; set; }

        public Point FirstPoint { get; set; }

        public Point SecondPoint { get; set; }

        public void UpdateStartPoint(int x, int y)
        {
            if (x < FirstPoint.X)
            {
                FirstPoint = new Point(x, FirstPoint.Y);
            }

            if (y < FirstPoint.Y)
            {
                FirstPoint = new Point(FirstPoint.X, y);
            }
        }

        public void UpdateFurthestPoint(int x, int y)
        {
            if (x > SecondPoint.X)
            {
                SecondPoint = new Point(x, SecondPoint.Y);
            }

            if (y > SecondPoint.Y)
            {
                SecondPoint = new Point(SecondPoint.X, y);
            }
        }
    }
}
