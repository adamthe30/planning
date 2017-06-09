using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.WriteLine("E");
        }
    }
}
