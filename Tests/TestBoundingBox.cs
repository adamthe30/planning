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
    /// Summary description for TestBoundingBox
    /// </summary>
    [TestClass]
    public class TestBoundingBox
    {
        public TestBoundingBox()
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
        public void BoundingBoxSimpleRectangleImage()
        {
            // Note: if the left side of a rectangle is in column 10 and its width is 10,
            //  then the right side will be in column 19 (and not 20)!
            BoundingBoxTestImages genBBox = new BoundingBoxTestImages();
            int minX, minY, maxX, maxY;
            Mat image = genBBox.SimpleRectangleImage(out minX, out minY, out maxX, out maxY);
            BoundingBoxTask bboxTask = new BoundingBoxTask();
            Rect bbox = bboxTask.GetBoundingBox(image);
            Assert.AreEqual(minX, bbox.X);
            Assert.AreEqual(minY, bbox.Y);
            Assert.AreEqual(maxX, bbox.X + bbox.Width - 1);
            Assert.AreEqual(maxY, bbox.Y + bbox.Height - 1);
        }

        [TestMethod]
        public void BoundingBoxRandomPolygonImage()
        {
            BoundingBoxTestImages genBBox = new BoundingBoxTestImages();
            int minX, minY, maxX, maxY;
            Mat image = genBBox.RandomPolygonImage(out minX, out minY, out maxX, out maxY);
            BoundingBoxTask bboxTask = new BoundingBoxTask();
            Rect bbox = bboxTask.GetBoundingBox(image);
            Assert.AreEqual(minX, bbox.X);
            Assert.AreEqual(minY, bbox.Y);
            Assert.AreEqual(maxX, bbox.X + bbox.Width - 1);
            Assert.AreEqual(maxY, bbox.Y + bbox.Height - 1);
        }
    }
}
