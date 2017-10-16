using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intro.Solutions;
using Intro.TestImageGenerators;
using OpenCvSharp;

namespace Tests
{
    /// <summary>
    /// Summary description for TestConnectedComponents
    /// </summary>
    [TestClass]
    public class TestConnectedComponents
    {
        public TestConnectedComponents()
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
        public void ConnectedComponentsTrivialImage()
        {
            var cc = new ConnectedComponentsTask();
            var gen = new ConnectedComponentsTestImages();
            int correctAnswer;
            Mat image = gen.TrivialImage(out correctAnswer);
            int answer = cc.CountConnectedComponents(image);
            Assert.AreEqual(correctAnswer, answer);
        }

        [TestMethod]
        //[Ignore]
        public void ConnectedComponentsSingleRectImage()
        {
            var cc = new ConnectedComponentsTask();
            var gen = new ConnectedComponentsTestImages();
            int correctAnswer;
            Mat image = gen.SingleRectImage(out correctAnswer);
            int answer = cc.CountConnectedComponents(image);
            Assert.AreEqual(correctAnswer, answer);
        }

        [TestMethod]
        //[Ignore]
        public void ConnectedComponentsComplexShapeImage()
        {
            var cc = new ConnectedComponentsTask();
            var gen = new ConnectedComponentsTestImages();
            int correctAnswer;
            Mat image = gen.ComplexShapeImage(out correctAnswer);
            int answer = cc.CountConnectedComponents(image);
            Assert.AreEqual(correctAnswer, answer);
        }

        [TestMethod]
        //[Ignore]
        public void ConnectedComponentsThinLineShapeImage()
        {
            var cc = new ConnectedComponentsTask();
            var gen = new ConnectedComponentsTestImages();
            int correctAnswer;
            Mat image = gen.ThinLineShapeImage(out correctAnswer);
            int answer = cc.CountConnectedComponents(image);
            Assert.AreEqual(correctAnswer, answer);
        }

        [TestMethod]
        //[Ignore]
        public void ConnectedComponentsCirclesInGridSkipDiagonalImage()
        {
            var cc = new ConnectedComponentsTask();
            var gen = new ConnectedComponentsTestImages();
            int correctAnswer;
            Mat image = gen.CirclesInGridSkipDiagonalImage(out correctAnswer);
            int answer = cc.CountConnectedComponents(image);
            Assert.AreEqual(correctAnswer, answer);
        }

        [TestMethod]
        //[Ignore]
        public void ConnectedComponentsImageWithText()
        {
            var cc = new ConnectedComponentsTask();
            var gen = new ConnectedComponentsTestImages();
            int correctAnswer;
            Mat image = gen.ImageWithText(out correctAnswer);
            int answer = cc.CountConnectedComponents(image);
            Assert.AreEqual(correctAnswer, answer);
        }

        [TestMethod]
        //[Ignore]
        public void ConnectedComponentsThinLinksAndGapsImage()
        {
            var cc = new ConnectedComponentsTask();
            var gen = new ConnectedComponentsTestImages();
            Mat image = gen.ThinLinksAndGapsImage();

            int originalAnswer = cc.CountConnectedComponents(image);
            Assert.AreEqual(4, originalAnswer);

            Mat dilated3 = cc.Dilate(image, 3);
            int dilated3Answer = cc.CountConnectedComponents(dilated3);
            Assert.AreEqual(3, dilated3Answer);

            Mat dilated8 = cc.Dilate(image, 8);
            int dilated8Answer = cc.CountConnectedComponents(dilated8);
            Assert.AreEqual(2, dilated8Answer);

            Mat eroded1 = cc.Erode(image, 1);
            int eroded1Answer = cc.CountConnectedComponents(eroded1);
            Assert.AreEqual(5, eroded1Answer);
        }
    }
}
