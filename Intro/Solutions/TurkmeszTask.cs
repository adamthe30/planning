using OpenCvSharp;

namespace Intro.Solutions
{
    public class TurkmeszTask
    {
        // Init (reset) everything, clear the image with colorA and move the turkmesz into the starting position.
        // Initial orientation is upwards, towards relative position (0;-1).
        public void Init(Size imageSize, Point startingPoint, Scalar colorA, Scalar colorB)
        {
        }

        public void SimulateSingleStep()
        {
            // If current color is colorA, paint it colorB, turn left and go forward.
            // If current color is colorB, paint it colorA, turn right and go forward.
        }

        // Continue the simulation with given number of steps
        public void SimulateMultipleSteps(int numberOfSteps)
        {
        }

        // Current position relative to the starting point
        public Point GetCurrentRelativePosition()
        {
            return new Point(0, 0);
        }

        public Scalar GetCurrentColor(Point relativePosition)
        {
            return new Scalar(0, 0, 0);
        }

        public Mat GetImage()
        {
            return new Mat();
        }
    }
}
