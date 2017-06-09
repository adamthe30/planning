using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Intro.Solutions
{
    public class BoundingBoxTask
    {
        public Rect GetBoundingBox(Mat image)
        {
            return new Rect(0, 0, image.Cols, image.Rows);
        }
    }
}
