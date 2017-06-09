using System;
using OpenCvSharp;

namespace Intro.TestImageGenerators
{
    public class BlobSizeHistogramTestImages
    {
        public Mat EmptyImage()
        {
            Mat result = new Mat(330, 330, MatType.CV_8UC1);
            return result;
        }

        public Mat RandomBlobs(int minAreaToCount, int maxAreaToCount, out int blobNumberInAreaRange)
        {
            // Rectangle areas range between 25 and 625.
            Mat result = new Mat(330, 330, MatType.CV_8UC1);
            Scalar color = new Scalar(255);
            blobNumberInAreaRange = 0;
            Random random = new Random(20); // Define seed to make tests repeatable

            int step = 30;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var upperLeft = new Point(i * step+15, j * step+15);
                    var size = new Size();
                    size.Width = random.Next(5, 25);
                    size.Height = random.Next(5, 25);
                    Rect rect = new Rect(upperLeft, size);
                    Cv2.Rectangle(result, rect, color, -1);
                    int area = size.Width * size.Height;
                    if (area >= minAreaToCount && area <= maxAreaToCount)
                        blobNumberInAreaRange++;
                }
            }
            return result;
        }
    }
}
