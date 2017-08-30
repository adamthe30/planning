using System;
using System.Text;
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
        [Ignore]
        public void MotionTrackingTrivial()
        {
            // Assemble trivial motion
            var gen = new MotionTrackingAnimation();
            var shape = GenerateRectangleAsPolygon();
            Assert.IsNotNull(shape);
            var targetColor = new Scalar(255, 255, 255);
            gen.Init(new Size(800, 600), new Scalar(0, 0, 0));
            gen.InitMotion(shape, targetColor);

            Point initialLocation = new Point(10, 10);
            gen.AddPoint(initialLocation);
            int motionIndex = gen.FinishMotion();
            Assert.AreEqual(motionIndex, 0);

            // Generate first frame
            Mat frame = gen.GetFrame(0);

            // Track the object
            var task = new MotionTrackingTask();
            task.Init(targetColor);
            task.TrackNextFrame(frame);
            Point currentPos = task.GetCurrentPosition();

            // Check position
            Assert.IsTrue(areNear(currentPos, initialLocation));
        }

        private bool areNear(Point a, Point b)
        {
            int maxDistance = 2;
            return (Math.Abs(a.X - b.X) < maxDistance
                && Math.Abs(a.Y - b.Y) < maxDistance);
        }

        private List<Point> GenerateRectangleAsPolygon()
        {
            return null;
        }
    }
}
