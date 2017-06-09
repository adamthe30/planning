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
            ConnectedComponentsTestImages gen = new ConnectedComponentsTestImages();
            int dummy;
            Cv2.ImWrite("TrivialImage.png", gen.TrivialImage(out dummy));
            Cv2.ImWrite("SingleRectImage.png", gen.SingleRectImage(out dummy));
            Cv2.ImWrite("ComplexShapeImage.png", gen.ComplexShapeImage(out dummy));
            Cv2.ImWrite("ThinLineShapeImage.png", gen.ThinLineShapeImage(out dummy));
            Cv2.ImWrite("CirclesInGridSkipDiagonalImage.png", gen.CirclesInGridSkipDiagonalImage(out dummy));
            Cv2.ImWrite("ImageWithText.png", gen.ImageWithText(out dummy));
            Cv2.ImWrite("ThinLinksAndGapsImage.png", gen.ThinLinksAndGapsImage());



            // Show window until keypress or max. 5 seconds
            Mat img = gen.CirclesInGridSkipDiagonalImage(out dummy);
            Cv2.ImShow("CirclesInGridSkipDiagonalImage", img);
            Cv2.WaitKey(5000);
        }
    }
}
