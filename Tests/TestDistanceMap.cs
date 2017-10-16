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
        public void DistanceMapOneRectangle()
        {
            var gen = new DistanceMapTestImages();
            Mat image = gen.OneRectanglesImage();
            var task = new DistanceMapTask();
            List<Point> maxDistancePoints = task.GetMaxDistancePoints(image);

            // All returned points must be near the central line of one of the rectangles.
            foreach (var p in maxDistancePoints)
                Assert.IsTrue(isPointNearHorizontalLine(p, 200, 300, 200));

            // All points of the rectangle central line must be near a returned "max distance point".
            Assert.IsTrue(allPointsAreNearListElements(200, 300, 200, maxDistancePoints));
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
            for (int x = x0; x <= x1; x++)
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
            foreach (var element in maxDistancePoints)
            {
                if (Math.Abs(p.X - element.X) > maxDistance) continue;
                if (Math.Abs(p.Y - element.Y) > maxDistance) continue;
                return true;
            }
            return false;
        }
    }
}
