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
    /// Summary description for TestBlobSizeHistogram
    /// </summary>
    [TestClass]
    public class TestBlobSizeHistogram
    {
        public TestBlobSizeHistogram()
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
        public void TestBlobSizeHistogramEmptyImage()
        {
            var gen = new BlobSizeHistogramTestImages();
            Mat image = gen.EmptyImage();
            var hist = new BlobSizeHistogramTask();
            var blobCount = hist.GetBlobNumberInAreaRange(0, 100);
            Assert.AreEqual(blobCount, 0);
        }

        [TestMethod]
        public void TestBlobSizeHistogramRandomBlobs()
        {
            var gen = new BlobSizeHistogramTestImages();
            int correctNumber;
            int minArea = 100;
            int maxArea = 350;
            Mat image = gen.RandomBlobs(minArea,maxArea,out correctNumber);
            var hist = new BlobSizeHistogramTask();
            var blobCount = hist.GetBlobNumberInAreaRange(minArea, maxArea);
            Assert.AreEqual(blobCount, correctNumber);
        }
    }
}
