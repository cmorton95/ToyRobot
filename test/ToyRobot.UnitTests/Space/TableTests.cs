using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Application.Space;
using ToyRobot.Core.Space;

namespace ToyRobot.UnitTests.Space 
{
    [TestClass]
    public class TableTests 
    {
        [TestMethod]
        public void Table_IsInBounds_Success()
        {
            var table = new Table();

            var location = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns((2.0, 2.0));

            var maxX = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns((5.0, 0.0));

            var maxY = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns((0.0, 5.0));

            var maxBoth = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns((5.0, 5.0));

            var minBoth = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns((0.0, 0.0));

            Assert.IsTrue(table.IsInBounds(location.Object));
            Assert.IsTrue(table.IsInBounds(maxX.Object));
            Assert.IsTrue(table.IsInBounds(maxY.Object));
            Assert.IsTrue(table.IsInBounds(maxBoth.Object));
            Assert.IsTrue(table.IsInBounds(minBoth.Object));
        }

        [TestMethod]
        public void Table_IsInBounds_Fail()
        {
            var table = new Table();

            var location = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns((6.0, 6.0));

            var negLocation = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns((-1.0, -1.0));

            Assert.IsFalse(table.IsInBounds(location.Object));
        }
    }
}