using System;
using OpenCvSharp;

namespace Intro.Solutions
{
    public class ConnectedComponentsTask
    {
        public int CountConnectedComponents(Mat image)
        {
            //return -1;
            Mat imageCopy = image.Clone();
            Rect rect = new Rect();
            int count = 0;
            byte currentcolor = 1;
            for (int i = 0; i < imageCopy.Cols; i++)
            {
                for (int j = 0; j < imageCopy.Rows; j++)
                {
                    Vec3b c = imageCopy.At<Vec3b>(j, i);
                    if (c.Item0 != currentcolor)
                    {
                        Cv2.FloodFill(imageCopy, new Point(i, j), new Scalar(currentcolor), out rect, null, null, FloodFillFlags.Link8);

                        count++;
                    }
                }
            }
            return count;
        }

        public Mat Dilate(Mat image, int v)
        {
            //return image.Clone();
            Mat imageCopy = image.Clone();
            Cv2.Dilate(imageCopy, imageCopy, new Mat(), null, v);
            return imageCopy;
        }

        public Mat Erode(Mat image, int v)
        {
            //return image.Clone();
            Mat imageCopy = image.Clone();
            Cv2.Erode(imageCopy, imageCopy, new Mat(), null, v);
            return imageCopy;
        }
    }
}
