using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intro.Solutions;
using Intro.TestImageGenerators;
using OpenCvSharp;

namespace Tests
{
    /// <summary>
    /// Summary description for TestMotionTracking
    /// </summary>
    [TestClass]
    public class TestMotionTracking
    {
        public TestMotionTracking()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        //[Ignore]
        public void MotionTrackingTrivialJump()
        {
            // Assemble trivial motion
            var anim = GenerateSingleMotion_Line();
            assertDetection(anim);
        }

        private void assertDetection(MotionTrackingAnimation anim, int animationIndex=0)
        {
            const int frameNumberForInitialStabilization = 5;
            var task = new MotionTrackingTask();
            task.Init(anim.GetTargetColor(animationIndex));
            for (int frameIndex = 0; frameIndex < anim.GetFrameCount(animationIndex); frameIndex++)
            {
                Mat frame = anim.GetFrame(frameIndex);
                task.TrackNextFrame(frame);

                if (frameIndex > frameNumberForInitialStabilization)
                {
                    Point currentPos = task.GetCurrentPosition();
                    Point correctLocation = anim.GetCorrectLocation(animationIndex, frameIndex);
                    Assert.IsTrue(areNear(currentPos, correctLocation));
                }
            }
        }

        private bool areNear(Point a, Point b)
        {
            int maxDistance = 5;
            return (Math.Abs(a.X - b.X) < maxDistance
                && Math.Abs(a.Y - b.Y) < maxDistance);
        }

        private List<Point> GenerateRectangleAsPolygon()
        {
            List<Point> rect = new List<Point>();
            rect.Add(new Point(-20, -20));
            rect.Add(new Point(20, -20));
            rect.Add(new Point(20, 20));
            rect.Add(new Point(-20, 20));
            return rect;
        }

        #region Generate test motions
        private MotionTrackingAnimation GenerateSingleMotion_Line()
        {
            // Shape is staying for 10 frames and then jumps to a new location.
            var anim = InitAnimation();
            Point A = new Point(100, 100);
            Point B = new Point(200, 200);
            anim.AddLine(A, B, 100);
            int motionIndex = anim.FinishMotion();
            Assert.AreEqual(0, motionIndex);
            return anim;
        }

        private MotionTrackingAnimation InitAnimation()
        {
            var gen = new MotionTrackingAnimation();
            var shape = GenerateRectangleAsPolygon();
            var targetColor = new Scalar(255, 255, 255);
            gen.Init(new Size(800, 600), new Scalar(0, 0, 0));
            gen.InitMotion(shape, targetColor);
            return gen;
        }
        #endregion
    }
}
