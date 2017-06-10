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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void MotionTrackingTrivial()
        {
            // Assemble trivial motion
            var gen = new MotionTrackingAnimation();
            var shape = GenerateRectangleAsPolygon();
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
            List<Point> polygon = new List<Point>();

            throw new NotImplementedException();
        }
    }
}
