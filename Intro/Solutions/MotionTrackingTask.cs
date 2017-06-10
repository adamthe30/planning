using OpenCvSharp;

namespace Intro.Solutions
{
    public class MotionTrackingTask
    {
        public void Init(Scalar trackedColor)
        {
        }

        public void TrackNextFrame(Mat frame)
        {
        }

        public Point GetCurrentPosition()
        {
            // returns the center of the bounding box
            return new Point(0, 0);
        }
    }
}
