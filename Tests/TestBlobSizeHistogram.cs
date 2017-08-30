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
        public void BlobSizeHistogramEmptyImage()
        {
            var gen = new BlobSizeHistogramTestImages();
            Mat image = gen.EmptyImage();
            var hist = new BlobSizeHistogramTask();
            var blobCount = hist.GetBlobNumberInAreaRange(0, 100);
            Assert.AreEqual(blobCount, 0);
        }

        [TestMethod]
        [Ignore]
        public void BlobSizeHistogramRandomBlobs()
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
