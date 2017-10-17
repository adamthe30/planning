using OpenCvSharp;

namespace Intro.Solutions
{
    public class DrawerTask
    {
        private Mat image;
        private Scalar currentColor;
        private Point currentPosition;

        // Initializes the image we are going to draw on.
        public void StartDrawing(Size imageSize, Scalar backgroundColor)
        {
            image = new Mat(imageSize, MatType.CV_8UC3, backgroundColor);
            currentColor = new Scalar(255.0 - backgroundColor.Val0,
                255.0 - backgroundColor.Val1, 255.0 - backgroundColor.Val2);
            currentPosition = new Point(imageSize.Width / 2, imageSize.Height / 2);
        }

        public void SetColor(Scalar color)
        {
            currentColor = color;
        }

        // Moves the pen. If it is down, it will also draw a line.
        public void MoveTo(Point p, bool isPenDown)
        {
            if (isPenDown)
                Cv2.Line(image, currentPosition, p, currentColor);
            currentPosition = p;
        }

        // Returns the image the drawer is currently drawing on.
        public Mat GetImage()
        {
            return image.Clone();
        }
    }
}
