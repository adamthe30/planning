using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intro.Helpers;
using Intro.TestImageGenerators;
using OpenCvSharp;

namespace Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            IntroHelper helper = new IntroHelper();
            Mat image = helper.CreateEmptyGreenImage();
            var color = helper.GetPixelColor(image, new Point(10, 10));
            Console.WriteLine("Mizu?");

            // Save all test images into PNG files.
            ConnectedComponentsTestImages genCC = new ConnectedComponentsTestImages();
            int dummy;
            Cv2.ImWrite("TrivialImage.png", genCC.TrivialImage(out dummy));
            Cv2.ImWrite("SingleRectImage.png", genCC.SingleRectImage(out dummy));
            Cv2.ImWrite("ComplexShapeImage.png", genCC.ComplexShapeImage(out dummy));
            Cv2.ImWrite("ThinLineShapeImage.png", genCC.ThinLineShapeImage(out dummy));
            Cv2.ImWrite("CirclesInGridSkipDiagonalImage.png", genCC.CirclesInGridSkipDiagonalImage(out dummy));
            Cv2.ImWrite("ImageWithText.png", genCC.ImageWithText(out dummy));
            Cv2.ImWrite("ThinLinksAndGapsImage.png", genCC.ThinLinksAndGapsImage());

            BoundingBoxTestImages genBBox = new BoundingBoxTestImages();
            int d1, d2, d3, d4; // Dummy variables
            Cv2.ImWrite("SimpleRectangleImage.png", genBBox.SimpleRectangleImage(out d1, out d2, out d3, out d4));
            Cv2.ImWrite("RandomPolygonImage.png", genBBox.RandomPolygonImage(out d1, out d2, out d3, out d4));

            BlobSizeHistogramTestImages genBlobSizeHist = new BlobSizeHistogramTestImages();
            Cv2.ImWrite("RandomBlobs.png", genBlobSizeHist.RandomBlobs(100,200,out dummy));




            // Show window until keypress or max. 5 seconds
            Mat img = genCC.CirclesInGridSkipDiagonalImage(out dummy);
            Cv2.ImShow("CirclesInGridSkipDiagonalImage", img);
            Cv2.WaitKey(5000);
        }
    }
}
