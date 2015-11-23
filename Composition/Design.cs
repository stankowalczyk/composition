using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using Composition.Views;

using Emgu.CV;
using Emgu.CV.Structure;

namespace Composition
{
    /// <summary>
    /// Design Class
    /// Holds all the information about a screen, including the original design image, the magnifier pane preview image, as well as the representation of the screen in memory (Activity Class)
    /// </summary>
    public class Design
    {
        private int _sizeOfPixes = 4;
        private int _sizeOfPixelBorder = 1;
        private int _magicNumber;

        private Bitmap _designImage;
        private Bitmap _zoomPrecisionBitmap;
        private Image<Bgr, Byte> _zoomPrecisionImage;
        private Image<Bgr, Byte> _input;

        public Design()
        {
            _magicNumber = _sizeOfPixes + _sizeOfPixelBorder;
            Widgets = new List<View>();
        }

        public Bitmap ImageWithGrayedOutParts { get; set; }

        public string ActivityName { get; private set; }

        private string _friendlyActivityName;

        public string ActivityNameStringID { get; private set; }

        public void RegisterActivityNameWithStringsClass()
        {
            ActivityNameStringID = Strings.AddActivityName(ActivityName);
        }

        public void RegisterAppNameWithStringsClass()
        {
            Strings.AddAppName(AppName);
        }

        public string OrgURL { get; private set; }

        public void SetOrgURL(string url)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < url.Length; i++)
            {
                if (Char.IsLetterOrDigit(url[i]))
                    sb.Append(url[i]);
                else if (url[i] == '.')
                    sb.Append(url[i]);

            }

            OrgURL = sb.ToString();
        }

        private string _appName;

        public string AppName
        {
            get
            {
                return _appName;
            }
            set
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < value.Length; i++)
                {
                    if (Char.IsLetterOrDigit(value[i]))
                        sb.Append(value[i]);
                }

                _appName = sb.ToString();
            }
        }

        public string LayoutName { get; private set;  }

        public void SetActivityName(string name)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < name.Length; i++)
            {
                if (Char.IsLetter(name[i]))
                {
                    if (i == 0)
                        sb.Append(name[i].ToString().ToLower());
                    else if (name[i].ToString() == name[i].ToString().ToUpper())
                        sb.Append("_" + name[i].ToString().ToLower());
                    else
                        sb.Append(name[i]);
                }
            }

            ActivityName = sb.ToString();
            LayoutName = ActivityName;
        }

        public Views.ActionBar ActionBar { get; set; }

        public List<Views.View> Widgets { get; set; }

        public Bitmap DesignImage
        {
            get
            {
                return _designImage;
            }

            set
            {
                if (_designImage != null)
                {
                    _designImage.Dispose();
                }
                if (_zoomPrecisionBitmap != null)
                {
                    _zoomPrecisionBitmap.Dispose();
                }
                if (_input != null)
                {
                    _input.Dispose();
                }
                _designImage = value;
                Input = new Image<Bgr, Byte>(_designImage);
                _zoomPrecisionBitmap = null;
            }
        }

        private Image<Bgr, Byte> Input
        {
            get
            {
                return _input;
            }
            set
            {
                if (_designImage != null)
                {
                    _designImage.Dispose();
                }
                if (_zoomPrecisionBitmap != null)
                {
                    _zoomPrecisionBitmap.Dispose();
                }
                if (_input != null)
                {
                    _input.Dispose();
                }
                _input = value;
                _designImage = _input.ToBitmap();
                _zoomPrecisionBitmap = null;
            }
        }

        public Bitmap DesignWithHighlights()
        {
            return DesignImage;
        }

        public Bitmap ZoomPrecisionImage()
        {
            if (_zoomPrecisionBitmap == null)
            {
                _zoomPrecisionBitmap = new Bitmap(_designImage.Width * _magicNumber - _sizeOfPixelBorder, _designImage.Height * _magicNumber - _sizeOfPixelBorder);
                Graphics resultGraphics = Graphics.FromImage(_zoomPrecisionBitmap);
                resultGraphics.FillRectangle(Brushes.Black, 0, 0, _designImage.Width * _magicNumber, _designImage.Height * _magicNumber);

                for (int x = 0; x < _designImage.Width; x++)
                {
                    for (int y = 0; y < _designImage.Height; y++)
                    {
                        Color c = _designImage.GetPixel(x, y);
                        resultGraphics.FillRectangle(new SolidBrush(c), x * _magicNumber, y * _magicNumber, _sizeOfPixes, _sizeOfPixes);
                    }
                }

                _zoomPrecisionImage = new Image<Bgr, Byte>(_zoomPrecisionBitmap);
            }

            return _zoomPrecisionBitmap;
        }

        public void CreateImageWithAreaGrayedOut(int x1, int y1, int x2, int y2, int previewWidth, int previewHeight)
        {
            if (ImageWithGrayedOutParts != null)
            {
                ImageWithGrayedOutParts.Dispose();
                ImageWithGrayedOutParts = null;
            }

            if (_designImage != null)
            {
                double divisor = (double)_designImage.Width / previewWidth;

                ImageWithGrayedOutParts = new Bitmap(_designImage);
                Graphics resultGraphics = Graphics.FromImage(ImageWithGrayedOutParts);

                int width = (int)(x2 * divisor - x1 * divisor);
                int height = (int)(y2 *divisor - y1 * divisor);

                resultGraphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.Black)), (int)(x1 * divisor), (int)(y1 * divisor), width, height);

                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font(
                   fontFamily,
                   28,
                   FontStyle.Regular,
                   GraphicsUnit.Pixel);
                resultGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                resultGraphics.DrawString("already analysed", font, new SolidBrush(Color.FromArgb(100, Color.White)), new PointF((float)(x1 * divisor), (float)(y1 * divisor)));
            }
        }

        public Bitmap GetSegment(int x1, int y1, int x2, int y2, int previewWidth, int previewHeigh)
        {
            double divisor = previewWidth / (double)Input.Width;
            x1 = (int)(x1 / divisor);
            y1 = (int)(y1 / divisor);
            x2 = (int)(x2 / divisor);
            y2 = (int)(y2 / divisor);
            int width = x2 - x1;
            int height = y2 - y1;
            return Input.GetSubRect(new Rectangle(x1, y1, width, height)).ToBitmap();
        }

        public Color GetColourAt(int x, int y, int previewWidth, int previewHeigh)
        {
            double divisor = previewWidth / (double)Input.Width;
            return _designImage.GetPixel((int)(x / divisor), (int)(y / divisor));
        }

        public Bitmap GetPointPreview(int x, int y, int previewWidth, int previewHeight, int originalCanvasWidth, int originalCanvasHeight)
        {
            int width = previewWidth;
            int height = previewHeight;

            Bitmap result = new Bitmap(width, height);
            Graphics resultGraphics = Graphics.FromImage(result);

            resultGraphics.FillRectangle(Brushes.Gray, 0, 0, width, height);

            double divisor = originalCanvasWidth / (double)Input.Width;
            int centreX = (int)(x / divisor);
            int centreY = (int)(y / divisor);

            int x1 = centreX - (width / 2);
            int y1 = centreY - (height / 2);

            if (x1 < 0)
                x1 = 0;

            if (y1 < 0)
                y1 = 0;

            int x2 = x1 + width;
            int y2 = y1 + height;

            if (x2 > Input.Width)
                x2 = Input.Width;

            if (y2 > Input.Height)
                y2 = Input.Height;

            int recalculatedWidth = x2 - x1;
            int recaluclatedHeight = y2 - y1;

            Bitmap addition = Input.GetSubRect(new Rectangle(x1, y1, recalculatedWidth, recaluclatedHeight)).ToBitmap();

            int insertPosX = 0;
            int insertPosY = 0;

            if (centreX == 0)
                insertPosX = width / 2;
            else if (centreX < width / 2)
                insertPosX = (width / 2) - centreX;

            if (centreY == 0)
                insertPosY = height / 2;
            else if (centreY < height / 2)
                insertPosY = (height / 2) - centreY;

            resultGraphics.DrawImage(addition, new Point(insertPosX, insertPosY));

            resultGraphics.DrawLine(new Pen(Color.FromArgb(50, Color.Black), 2), new Point(width / 2, 0), new Point(width / 2, height));
            resultGraphics.DrawLine(new Pen(Color.FromArgb(50, Color.Black), 2), new Point(0, height / 2), new Point(width, height / 2));

            resultGraphics.DrawLine(new Pen(Color.FromArgb(50, Color.Black), 2), new Point(width / 2, height / 4), new Point(width / 2, height / 4 * 3));
            resultGraphics.DrawLine(new Pen(Color.FromArgb(75, Color.Black), 2), new Point(width / 4, height / 2), new Point(width / 4 * 3, height / 2));

            return result;
        }

        public Bitmap GetPointPreviewZoomed(int x, int y, int previewWidth, int previewHeight, int originalCanvasWidth, int originalCanvasHeight)
        {
            int width = previewWidth;
            int height = previewHeight;

            Bitmap result = new Bitmap(width, height);
            Graphics resultGraphics = Graphics.FromImage(result);

            resultGraphics.FillRectangle(Brushes.Gray, 0, 0, width, height);

            double divisor = originalCanvasWidth / (double)_zoomPrecisionImage.Width;
            int centreX = (int)(x / divisor);
            int centreY = (int)(y / divisor);

            int x1 = centreX - (width / 2);
            int y1 = centreY - (height / 2);

            if (x1 < 0)
                x1 = 0;

            if (y1 < 0)
                y1 = 0;

            int x2 = x1 + width;
            int y2 = y1 + height;

            if (x2 > _zoomPrecisionImage.Width)
                x2 = _zoomPrecisionImage.Width;

            if (y2 > _zoomPrecisionImage.Height)
                y2 = _zoomPrecisionImage.Height;

            int recalculatedWidth = x2 - x1;
            int recaluclatedHeight = y2 - y1;

            Bitmap addition = _zoomPrecisionImage.GetSubRect(new Rectangle(x1, y1, recalculatedWidth, recaluclatedHeight)).ToBitmap();

            int insertPosX = 0;
            int insertPosY = 0;

            if (centreX == 0)
                insertPosX = width / 2;
            else if (centreX < width / 2)
                insertPosX = (width / 2) - centreX;

            if (centreY == 0)
                insertPosY = height / 2;
            else if (centreY < height / 2)
                insertPosY = (height / 2) - centreY;

            resultGraphics.DrawImage(addition, new Point(insertPosX, insertPosY));

            resultGraphics.DrawLine(new Pen(Color.FromArgb(50, Color.Black), 3), new Point(width / 2, 0), new Point(width / 2, height));
            resultGraphics.DrawLine(new Pen(Color.FromArgb(50, Color.Black), 3), new Point(0, height / 2), new Point(width, height / 2));

            resultGraphics.DrawLine(new Pen(Color.FromArgb(100, Color.Black), 3), new Point(width / 2, height / 4), new Point(width / 2, height / 4 * 3));
            resultGraphics.DrawLine(new Pen(Color.FromArgb(100, Color.Black), 3), new Point(width / 4, height / 2), new Point(width / 4 * 3, height / 2));

            return result;
        }
    }
}
