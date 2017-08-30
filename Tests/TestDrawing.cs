using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCvSharp;
using Intro.Solutions;

namespace Tests
{
    /// <summary>
    /// Summary description for TestDrawing
    /// </summary>
    [TestClass]
    public class TestDrawing
    {
        public TestDrawing()
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
        public void DrawingInit()
        {
            DrawerTask task = new DrawerTask();
            var color = new Scalar(128, 192, 255);
            var imageSize = new Size(800, 600);
            task.StartDrawing(imageSize, color);
            Mat image = task.GetImage();
            Vec3b currentColor = image.Get<Vec3b>(1, 1);
            Assert.AreEqual(currentColor, color);
            Assert.AreEqual(image.Size(), imageSize);
        }

        [TestMethod]
        [Ignore]
        public void TestDrawingSimpleDrawing()
        {
            DrawerTask task = new DrawerTask();
            var background = new Scalar(0, 0, 0);
            var pen1 = new Scalar(0, 0, 255);
            var pen2 = new Scalar(0, 255, 0);
            task.StartDrawing(new Size(800, 600), background);

            Point a = new Point(100, 100);
            Point b = new Point(700, 100);
            Point c = new Point(700, 500);
            Point d = new Point(400, 500);
            Point e = new Point(400, 300);
            Point f = new Point(100, 300);
            Point g = new Point(600, 550);
            Point h = new Point(600, 200);

            task.SetColor(pen1);
            task.MoveTo(a, false);
            task.MoveTo(b, true);
            task.MoveTo(c, true);
            task.MoveTo(d, false);
            task.SetColor(pen2);
            task.MoveTo(e, true);
            task.MoveTo(f, true);

            Mat image = task.GetImage();
            Assert.IsTrue(image.Cols > 0 && image.Rows > 0);
            Assert.IsTrue(IsLinePresent(image, a, b, pen1));
            Assert.IsTrue(IsLinePresent(image, b, c, pen1));
            Assert.IsTrue(IsLinePresent(image, d, e, pen2));
            Assert.IsTrue(IsLinePresent(image, e, f, pen2));
            Assert.IsTrue(IsLinePresent(image, g, h, background));
        }

        private bool IsLinePresent(Mat image, Point start, Point end, Scalar color)
        {
            LineIterator it = new LineIterator(image, start, end);
            Vec3b rc = color.ToVec3b(); // required color
            foreach (var p in it)
            {
                var cc = p.GetValue<Vec3b>();
                if (cc.Item0 != rc.Item0 || cc.Item1 != rc.Item1 || cc.Item2 != rc.Item2)
                    return false;
            }
            return true;
        }
    }
}
