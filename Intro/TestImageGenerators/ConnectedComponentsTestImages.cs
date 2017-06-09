using System;
using Intro.Helpers;
using OpenCvSharp;

namespace Intro.TestImageGenerators
{
    public class ConnectedComponentsTestImages
    {
        public Mat TrivialImage(out int correctNumber)
        {
            Mat result = new Mat(600, 800, MatType.CV_8UC1);
            correctNumber = 1;
            return result;
        }

        public Mat SingleRectImage(out int correctNumber)
        {
            Mat result = new Mat(600, 800, MatType.CV_8UC1);
            Cv2.Rectangle(result, new Rect(100, 100, 400, 200), new Scalar(255), -1);
            correctNumber = 2;
            return result;
        }

        public Mat ComplexShapeImage(out int correctNumber)
        {
            Mat result = new Mat(600, 700, MatType.CV_8UC1);
            Scalar color = new Scalar(255);
            Cv2.Rectangle(result, new Rect(100, 100, 100, 400), color, -1);
            Cv2.Rectangle(result, new Rect(300, 100, 100, 400), color, -1);
            Cv2.Rectangle(result, new Rect(500, 100, 100, 400), color, -1);
            Cv2.Line(result, 200, 150, 500, 150, color, 3);
            Cv2.Line(result, 200, 450, 500, 450, color, 3);
            correctNumber = 4;
            return result;
        }

        public Mat ThinLineShapeImage(out int correctNumber)
        {
            Mat result = new Mat(600, 800, MatType.CV_8UC1);
            Scalar color = new Scalar(255);
            Cv2.Line(result, 400, 100, 500, 200, color, 1);
            Cv2.Line(result, 400, 100, 300, 200, color, 1);
            Cv2.Line(result, 300, 200, 500, 200, color, 1);
            correctNumber = 2;
            return result;
        }

        public Mat CirclesInGridSkipDiagonalImage(out int correctNumber)
        {
            Scalar color = new Scalar(255);
            int radius = 10;
            int step = 40;
            int nX = 10;
            int nY = 10;
            Mat result = new Mat((nY + 2) * step, (nX+2)*step, MatType.CV_8UC1);

            for (int i = 0; i < nX; i++)
            {
                for (int j = 0; j < nY; j++)
                {
                    if (i == j)
                        continue;   // Skip the circles in the diagonal
                    Point center = new Point((i + 1) * step, (j + 1) * step);
                    Cv2.Circle(result, center, radius, color, -1);
                }
            }

            correctNumber = nX * nY - Math.Min(nX, nY);
            return result;
        }

        public Mat ImageWithText(out int correctNumber)
        {
            Scalar color = new Scalar(255);
            HersheyFonts font = HersheyFonts.HersheyPlain;
            double fontScale = 1.0;
            int thickness = 1;
            LineTypes lineType = LineTypes.Link4;
            string text = "Mizu?";

            Size textSize = GraphicsHelper.GetTextSize("Mizu?", font, fontScale);
            Mat result = new Mat(textSize.Height+10, textSize.Width+20, MatType.CV_8UC1);
            GraphicsHelper.PutTextWithCenter(result, new Point(result.Cols / 2, result.Rows / 2),
                text, color, font, fontScale, thickness, lineType);

            correctNumber = 8;
            return result;
        }

        public Mat ThinLinksAndGapsImage()
        {
            Scalar color = new Scalar(255);
            Mat result = new Mat(600, 800, MatType.CV_8UC1);
            Cv2.Rectangle(result, new Rect(100,100,100,100), color, -1);
            Cv2.Rectangle(result, new Rect(205,100,495,100), color, -1);
            Cv2.Rectangle(result, new Rect(100,210,100,290), color, -1);
            Cv2.Rectangle(result, new Rect(205,210,495,290), color, -1);
            Cv2.Line(result, 200, 150, 205, 150, color);

            // Correct connected component numbers (including background):
            // Without processing: 4
            // With dilation (radius 3): 3
            // With dilation (radius 8): 2
            // With erosion (radius 1): 5
            return result;
        }

    }
}
