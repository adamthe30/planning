using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intro.Solutions;
using OpenCvSharp;

namespace Tests
{
    /// <summary>
    /// Summary description for TestTurkmesz
    /// </summary>
    [TestClass]
    public class TestTurkmesz
    {
        public TestTurkmesz()
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
        public void TurkmeszTrivial()
        {
            var task = new TurkmeszTask();
            var colorA = (byte)0;
            task.Init(new Size(400, 400));
            Assert.IsTrue(task.GetCurrentRelativePosition() == new Point(0, 0));    // Step 0
            Assert.IsTrue(task.GetCurrentColor(new Point(0, 0)) == colorA);
        }

        [TestMethod]
        public void TurkmeszDetails()
        {
            var task = new TurkmeszTask();
            var colorA = (byte)0;
            var colorB = (byte)255;
            task.Init(new Size(400, 400));
            task.SimulateSingleStep();
            Assert.IsTrue(checkPositionAndColor(task, new Point(-1, 0), colorA));   // Step 1
            task.SimulateSingleStep();
            Assert.IsTrue(checkPositionAndColor(task, new Point(-1, 1), colorA));   // Step 2
            task.SimulateSingleStep();
            Assert.IsTrue(checkPositionAndColor(task, new Point(0, 1), colorA));   // Step 3
            task.SimulateSingleStep();
            Assert.IsTrue(checkPositionAndColor(task, new Point(0, 0), colorB));   // Step 4
            task.SimulateSingleStep();
            Assert.IsTrue(checkPositionAndColor(task, new Point(1, 0), colorA));   // Step 5
            task.SimulateMultipleSteps(5);
            Assert.IsTrue(checkPositionAndColor(task, new Point(1, 1), colorA));   // Step 10
            task.SimulateMultipleSteps(5);
            Assert.IsTrue(checkPositionAndColor(task, new Point(0, 1), colorB));   // Step 15
            task.SimulateMultipleSteps(5);
            Assert.IsTrue(checkPositionAndColor(task, new Point(2, 2), colorA));   // Step 20
        }

        private bool checkPositionAndColor(TurkmeszTask task, Point expectedRelativePosition, Scalar expectedColor)
        {
            if (task.GetCurrentRelativePosition() != expectedRelativePosition)
                return false;
            if (task.GetCurrentColor(expectedRelativePosition) != expectedColor)
                return false;
            return true;
        }
    }
}
