using System;
using OpenCvSharp;

namespace Intro.Solutions
{
    public class TurkmeszTask
    {
        private Mat image;
        private Point basePosition;
        private Point relativePosition;
        int orientation;
        private Mat.Indexer<byte> indexer;

        Point imagePosition
        {
            get
            {
                return new Point(basePosition.X + relativePosition.X, basePosition.Y + relativePosition.Y);
            }
        }

        bool IsCurrentColorForeground
        {
            get
            {
                return indexer[imagePosition.Y, imagePosition.X] != 0;
            }
            set
            {
                indexer[imagePosition.Y, imagePosition.X] = value ? (byte)255 : (byte)0;
            }
        }

        // Init (reset) everything, clear the image and move the turkmesz into the center.
        // Initial orientation is upwards, towards relative position (0;-1).
        public void Init(Size imageSize)
        {
            this.image = new Mat(imageSize, MatType.CV_8UC1, new Scalar(0));
            basePosition = new Point(image.Cols/2, image.Rows/2);
            relativePosition = new Point(0, 0);
            orientation = 0;
            indexer = image.GetGenericIndexer<byte>();
        }

        public void SimulateSingleStep()
        {
            IsCurrentColorForeground = !IsCurrentColorForeground;
            int turn = IsCurrentColorForeground ? -1 : 1;
            orientation = (orientation + turn) % 4;
            if (orientation > 3) orientation -= 4;
            if (orientation < 0) orientation += 4;
            stepforward();
        }

        // Continue the simulation with given number of steps
        public void SimulateMultipleSteps(int numberOfSteps)
        {
            for (int i = 0; i < numberOfSteps; i++)
                SimulateSingleStep();
        }

        // Current position relative to the starting point
        public Point GetCurrentRelativePosition()
        {
            return relativePosition;
        }

        public byte GetCurrentColor(Point relativePosition)
        {
            return indexer[imagePosition.Y, imagePosition.X];
        }

        public Mat GetImage()
        {
            return image;
        }

        private void stepforward()
        {
            switch (orientation)
            {
                case 0:
                    relativePosition.Y--;
                    if (imagePosition.Y < 0) throw new InvalidOperationException("Turmite left the image.");
                    break;
                case 1:
                    relativePosition.X++;
                    if (imagePosition.X >= image.Cols) throw new InvalidOperationException("Turmite left the image.");
                    break;
                case 2:
                    relativePosition.Y++;
                    if (imagePosition.Y >= image.Rows) throw new InvalidOperationException("Turmite left the image.");
                    break;
                case 3:
                    relativePosition.X--;
                    if (imagePosition.X < 0) throw new InvalidOperationException("Turmite left the image.");
                    break;
            }
        }
    }
}
