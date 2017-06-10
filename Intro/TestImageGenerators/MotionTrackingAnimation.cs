using System;
using System.Collections.Generic;
using OpenCvSharp;

namespace Intro.TestImageGenerators
{
    public class MotionTrackingAnimation
    {
        #region Defining motions
        private class Motion
        {
            // The shape to draw
            public List<Point> Polygon;

            public Scalar Color;

            public List<Point> MotionAnchorLocations;

            public Point GetAnchorPosition(int frameIndex)
            {
                return MotionAnchorLocations[frameIndex];
            }

            public void Draw(Mat image, int frameIndex)
            {
                Point pos = GetAnchorPosition(frameIndex);
                List<List<Point>> posListList = new List<List<Point>>();
                posListList.Add(this.Polygon);
                Cv2.FillPoly(image, posListList, this.Color, LineTypes.Link8, 0, pos);
            }
        }

        private Motion currentMotion;
        private List<Motion> allMotions;

        public void InitMotion(List<Point> polygon, Scalar color)
        {
            currentMotion = new Motion() { Polygon = polygon, Color = color };
            currentMotion.MotionAnchorLocations = new List<Point>();
        }

        public void AddPoint(Point anchorLocation)
        {
            currentMotion.MotionAnchorLocations.Add(anchorLocation);
        }

        public void AddLine(Point from, Point to, int steps)
        {
            double weightStep = 1.0 / ((double)steps - 1.0);
            for (int i = 0; i <= steps; i++)
            {
                double weight = weightStep * (double)i;
                Point p = new Point(
                    weight * (double)from.X + (1.0 - weight) * (double)to.X,
                    weight * (double)from.Y + (1.0 - weight) * (double)to.Y);
                AddPoint(p);
            }
        }

        public void AddCircle(Point center, double radius, double startAngle, int steps)
        {
            double angleStep = Math.PI * 2.0 / (double)steps;
            for (int i = 0; i <= steps; i++)
            {
                double angle = startAngle + (double)i * angleStep;
                Point p = new Point(
                    center.X + radius * Math.Cos(angle),
                    center.Y + radius * Math.Sin(angle));
                AddPoint(p);
            }
        }

        public int FinishMotion()   // Returns index of added motion
        {
            allMotions.Add(currentMotion);
            currentMotion = null;
            return allMotions.Count - 1;
        }
        #endregion

        #region Creating the animation frames
        private Size frameSize;
        private Scalar backgroundColor;
        public void Init(Size frameSize, Scalar backgroundColor)
        {
            this.frameSize = frameSize;
            this.backgroundColor = backgroundColor;

        }

        public Mat GetFrame(int index)
        {
            Mat frame = new Mat(frameSize, MatType.CV_8UC3, backgroundColor);
            foreach (var m in allMotions)
                m.Draw(frame, index);
            return frame;
        }
        #endregion

        public Point GetCorrectLocation(int motionIndex, int frameIndex)
        {
            return allMotions[motionIndex].GetAnchorPosition(frameIndex);
        }
    }
}
