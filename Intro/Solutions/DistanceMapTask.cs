using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Intro.Solutions
{
    public class DistanceMapTask
    {
        public List<Point> GetMaxDistancePoints(Mat image)
        {
            //return new List<Point>();
            Mat distanceMap = new Mat(image.Size(), MatType.CV_32FC1, new Scalar(0));
            Cv2.DistanceTransform(image, distanceMap, DistanceTypes.L2, DistanceMaskSize.Mask3);
            return GetMaximalDistancePointsForLabel(distanceMap);
        }

        private List<Point> GetMaximalDistancePointsForLabel(Mat image)
        {
            List<Point> result = new List<Point>();
            var distIndexer = image.GetGenericIndexer<float>();
            double maxValue = 0.0;
            for (int x = 0; x < image.Cols; x++)
                for (int y = 0; y < image.Rows; y++)
                {
                    double currentDist = distIndexer[y, x];
                    if (currentDist > maxValue)
                    {
                        result.Clear();
                        maxValue = currentDist;
                    }
                    if (currentDist == maxValue)
                        result.Add(new Point(x, y));
                }
            return result;
        }
    }
}
