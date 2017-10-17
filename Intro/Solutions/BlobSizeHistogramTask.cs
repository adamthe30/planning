using OpenCvSharp;
using System.Collections.Generic;

namespace Intro.Solutions
{
    public class BlobSizeHistogramTask
    {
        public int GetBlobNumberInAreaRange(Mat image, int minArea, int maxArea)
        {
            var areas = CollectBlobSizesGetBlobNumberInAreaRange(image);
            return areas.FindAll(a => (a >= minArea && a <= maxArea)).Count;
        }

        public List<int> CollectBlobSizesGetBlobNumberInAreaRange(Mat image)
        {
            // Assumes CV_8UC1 images, 0 background, 255 blob
            var result = new List<int>();
            Mat img = image.Clone();
            var indexer = img.GetGenericIndexer<byte>();
            byte backgoundColor = 0;
            byte tempColor = 1;
            for (int i = 0; i < img.Cols; i++)
                for (int j = 0; j < img.Rows; j++)
                {
                    byte c = indexer[j, i];
                    if (c != backgoundColor)
                    {
                        Rect rect = new Rect();
                        Cv2.FloodFill(img, new Point(i, j), tempColor, out rect, null, null, FloodFillFlags.Link4);
                        int area = 0;
                        for (int y = rect.Top; y <= rect.Bottom; y++)
                            for (int x = rect.Left; x <= rect.Right; x++)
                                if (indexer[y,x]== tempColor)
                            {
                                    area++;
                                    indexer[y, x] = backgoundColor;
                            }
                        result.Add(area);
                    }
                }
            return result;
        }
    }
}
