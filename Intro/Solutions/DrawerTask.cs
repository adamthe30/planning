using OpenCvSharp;

namespace Intro.Solutions
{
    public class DrawerTask
    {
        // Initializes the image we are going to draw on.
        public void StartDrawing(Size imageSize, Scalar backgroundColor)
        {
        }

        public void SetColor(Scalar color)
        {
        }

        // Moves the pen. If it is down, it will also draw a line.
        public void MoveTo(Point p, bool isPenDown)
        {
        }

        // Returns the image the drawer is currently drawing on.
        public Mat GetImage()
        {
            return new Mat();
        }
    }
}
