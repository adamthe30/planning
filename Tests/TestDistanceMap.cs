using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intro.TestImageGenerators;
using OpenCvSharp;
using Intro.Solutions;

namespace Tests
{
    /// <summary>
    /// Summary description for TestDistanceMap
    /// </summary>
    [TestClass]
    public class TestDistanceMap
    {
        public TestDistanceMap()
        {
            //
            // TODO: Add constructor logic here
            //
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
        public void DistanceMapThreeRectangles()
        {
            var gen = new DistanceMapTestImages();
            Mat image = gen.ThreeRectanglesImage();
            var task = new DistanceMapTask();
            List<Point> maxDistancePoints = task.GetMaxDistancePoints(image);

            // All returned points must be near the central line of one of the rectangles.
            foreach(var p in maxDistancePoints)
            {
                if (isPointNearHorizontalLine(p, 200, 300, 200)) continue;
                if (isPointNearHorizontalLine(p, 200, 300, 450)) continue;
                if (isPointNearHorizontalLine(p, 550, 650, 350)) continue;
                Assert.Fail("This point is too far from the central parts of the rectangles.");
            }

            // All points of the rectangle central lines must be near a returned "max distance point".
            Assert.IsTrue(allPointsAreNearListElements(200, 300, 200, maxDistancePoints));
            Assert.IsTrue(allPointsAreNearListElements(200, 300, 450, maxDistancePoints));
            Assert.IsTrue(allPointsAreNearListElements(550, 650, 350, maxDistancePoints));
        }

        private bool isPointNearHorizontalLine(Point p, int x0, int x1, int y)
        {
            // Note: due to implementation details, we allow for a 1px difference.
            int maxDistance = 1;
            if (Math.Abs(p.Y - y) > maxDistance) return false;
            if (p.X < x0 - maxDistance) return false;
            if (p.X > x1 + maxDistance) return false;
            return true;
        }

        private bool allPointsAreNearListElements(int x0, int x1, int y, List<Point> maxDistancePoints)
        {
            for(int x=x0; x<=x1; x++)
            {
                Point p = new Point(x, y);
                if (!isNearListElement(p, maxDistancePoints))
                    return false;
            }
            return true;
        }

        private bool isNearListElement(Point p, List<Point> maxDistancePoints)
        {
            int maxDistance = 1;
            foreach(var element in maxDistancePoints)
            {
                if (Math.Abs(p.X - element.X) > maxDistance) break;
                if (Math.Abs(p.Y - element.Y) > maxDistance) break;
                return true;
            }
            return false;
        }
    }
}
