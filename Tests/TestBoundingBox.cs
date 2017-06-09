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
        public void TestBoundingBoxSimpleRectangleImage()
        {
            // Note: if the left side of a rectangle is in column 10 and its width is 10,
            //  then the right side will be in column 19 (and not 20)!
            BoundingBoxTestImages genBBox = new BoundingBoxTestImages();
            int minX, minY, maxX, maxY;
            Mat image = genBBox.SimpleRectangleImage(out minX, out minY, out maxX, out maxY);
            BoundingBoxTask bboxTask = new BoundingBoxTask();
            Rect bbox = bboxTask.GetBoundingBox(image);
            Assert.AreEqual(bbox.X, minX);
            Assert.AreEqual(bbox.Y, minY);
            Assert.AreEqual(bbox.X + bbox.Width - 1, maxX);
            Assert.AreEqual(bbox.Y + bbox.Height - 1, maxY);
        }

        [TestMethod]
        public void TestBoundingBoxRandomPolygonImage()
        {
            BoundingBoxTestImages genBBox = new BoundingBoxTestImages();
            int minX, minY, maxX, maxY;
            Mat image = genBBox.RandomPolygonImage(out minX, out minY, out maxX, out maxY);
            BoundingBoxTask bboxTask = new BoundingBoxTask();
            Rect bbox = bboxTask.GetBoundingBox(image);
            Assert.AreEqual(bbox.X, minX);
            Assert.AreEqual(bbox.Y, minY);
            Assert.AreEqual(bbox.X + bbox.Width, maxX);
            Assert.AreEqual(bbox.Y + bbox.Height, maxY);
        }
    }
}
