using OpenCvSharp;

namespace Intro.TestImageGenerators
{
    public class DistanceMapTestImages
    {
        public Mat OneRectanglesImage()
        {
            Mat result = new Mat(600, 800, MatType.CV_8UC1, new Scalar(0));
            Scalar color = new Scalar(255);
            Cv2.Rectangle(result, new Rect(100, 100, 300, 200), color, -1);
            return result;
        }

        public Mat ThreeRectanglesImage()
        {
            Mat result = new Mat(600, 800, MatType.CV_8UC1, new Scalar(0));
            Scalar color = new Scalar(255);
            Cv2.Rectangle(result, new Rect(100, 100, 300, 200), color, -1);
            Cv2.Rectangle(result, new Rect(100, 400, 300, 100), color, -1);
            Cv2.Rectangle(result, new Rect(500, 300, 200, 100), color, -1);
            return result;
        }
    }
}
