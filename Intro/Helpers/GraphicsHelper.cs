using OpenCvSharp;

namespace Intro.Helpers
{
    public class GraphicsHelper
    {
        public static void PutTextWithCenter(Mat img, Point textCenter, string text,
            Scalar textColor, HersheyFonts font, double fontScale,
            int thickness, LineTypes lineType)
        {
            Size textSize = GetTextSize(text, font, fontScale);
            Point textLocation = new Point(textCenter.X - textSize.Width / 2, textCenter.Y + textSize.Height / 2);
            Cv2.PutText(img, text, textLocation, font, fontScale, textColor, thickness, lineType);
        }

        public static Size GetTextSize(string text, HersheyFonts font, double fontScale)
        {
            int baseline = 0;
            return Cv2.GetTextSize(text, font, fontScale, 1, out baseline);
        }
    }
}
