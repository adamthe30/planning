using System;
using OpenCvSharp;

namespace Intro.Solutions
{
    public class TurkmeszTask
    {
        // Init (reset) everything, clear the image and move the turkmesz into the center.
        // Initial orientation is upwards, towards relative position (0;-1).
        public void Init(Size imageSize)
        {
        }

        public void SimulateSingleStep()
        {
        }

        // Continue the simulation with given number of steps
        public void SimulateMultipleSteps(int numberOfSteps)
        {
        }

        // Current position relative to the starting point
        public Point GetCurrentRelativePosition()
        {
            return new Point(0,0);
        }

        public byte GetCurrentColor(Point relativePosition)
        {
            return 0;
        }

        public Mat GetImage()
        {
            return new Mat();
        }
    }
}
