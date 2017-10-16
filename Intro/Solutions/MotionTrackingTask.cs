using OpenCvSharp;

namespace Intro.Solutions
{
    public class MotionTrackingTask
    {
        private OpenCvSharp.BackgroundSubtractorMOG2 mog2;
        private Mat currentForegroundMask;

        public void Init(Scalar trackedColor)
        {
            mog2 = OpenCvSharp.BackgroundSubtractorMOG2.Create();
            mog2.DetectShadows = false;
            mog2.BackgroundRatio = 1.0;
            mog2.History = 2;
            mog2.NMixtures = 1;
            currentForegroundMask = new Mat();
        }

        public void TrackNextFrame(Mat frame)
        {
            mog2.Apply(frame, currentForegroundMask);
        }

        public Point GetCurrentPosition()
        {
            // returns the center of the bounding box
            Rect bbox = Cv2.BoundingRect(this.currentForegroundMask);
            return new Point(bbox.Left+bbox.Width/2, bbox.Top+bbox.Height/2);
        }
    }
}
