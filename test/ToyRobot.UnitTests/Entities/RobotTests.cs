using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Application.Entities;
using ToyRobot.Core.Entities;
using ToyRobot.Core.Space;

namespace ToyRobot.UnitTests.Entities
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void Robot_Constructor_ArgNull() 
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Robot(null!));
        }

        [TestMethod]
        public void Robot_Place_Success() 
        {
            var point = (0.0, 0.0);

            var space = new Mock<ISpace>();
            space.Setup(s => s.IsInBounds(It.IsAny<ILocation>())).Returns(true);

            var location = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns(point);

            var robot = new Robot(space.Object);
            Assert.IsTrue(robot.Place(location.Object, 0.0));
            Assert.IsTrue(robot.IsPlaced);
            Assert.AreEqual(location.Object, robot.Location);
        }

        [TestMethod]
        public void Robot_Place_OutOfBounds()
        {
            var point = (0.0, 0.0);

            var space = new Mock<ISpace>();
            space.Setup(s => s.IsInBounds(It.IsAny<ILocation>())).Returns(false);

            var location = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns(point);

            var robot = new Robot(space.Object);
            Assert.IsFalse(robot.Place(location.Object, 0.0));
            Assert.IsFalse(robot.IsPlaced);
            Assert.AreNotEqual(location.Object, robot.Location);
        }

        [TestMethod]
        public void Robot_Move_Success()
        {
            var space = new Mock<ISpace>();
            space.Setup(s => s.IsInBounds(It.IsAny<ILocation>())).Returns(true);

            var nextLocation = new Mock<ILocation>();
            nextLocation.Setup(n => n.GetLocation()).Returns((0.0, 1.0));

            var location = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns((0.0, 0.0));
            location.Setup(l => l.Transform(It.IsAny<double>(), It.IsAny<double>())).Returns(nextLocation.Object);

            var robot = new Robot(space.Object);
            Assert.IsTrue(robot.Move());
            Assert.AreEqual(nextLocation.Object.GetLocation(), robot.Location.GetLocation());
        }

        [TestMethod]
        public void Robot_Move_OutOfBounds()
        {
            var space = new Mock<ISpace>();
            space.Setup(s => s.IsInBounds(It.IsAny<ILocation>())).Returns(false);

            var nextLocation = new Mock<ILocation>();
            nextLocation.Setup(n => n.GetLocation()).Returns((0.0, 1.0));

            var location = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns((0.0, 0.0));
            location.Setup(l => l.Transform(It.IsAny<double>(), It.IsAny<double>())).Returns(nextLocation.Object);

            var robot = new Robot(space.Object);
            Assert.IsFalse(robot.Move());
            Assert.AreEqual(location.Object.GetLocation(), robot.Location.GetLocation());
        }

        [TestMethod]
        public void Robot_Left_Success()
        {
            var space = new Mock<ISpace>();
            space.Setup(s => s.IsInBounds(It.IsAny<ILocation>())).Returns(true);

            var location = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns((0.0, 0.0));

            var robot = new Robot(space.Object);
            Assert.IsTrue(robot.Place(location.Object, 90.0));
            Assert.IsTrue(robot.Left());
            Assert.AreEqual(0.0, robot.Direction);
        }

        [TestMethod]
        public void Robot_Left_SuccessOverflow()
        {
            var space = new Mock<ISpace>();
            space.Setup(s => s.IsInBounds(It.IsAny<ILocation>())).Returns(true);

            var location = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns((0.0, 0.0));

            var robot = new Robot(space.Object);
            Assert.IsTrue(robot.Place(location.Object, 0.0));
            Assert.IsTrue(robot.Left());
            Assert.AreEqual(270.0, robot.Direction);
        }

        [TestMethod]
        public void Robot_Right_Success()
        {
            var space = new Mock<ISpace>();
            space.Setup(s => s.IsInBounds(It.IsAny<ILocation>())).Returns(true);

            var location = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns((0.0, 0.0));

            var robot = new Robot(space.Object);
            Assert.IsTrue(robot.Place(location.Object, 0.0));
            Assert.IsTrue(robot.Right());
            Assert.AreEqual(90.0, robot.Direction);
        }

        [TestMethod]
        public void Robot_Right_SuccessOverflow()
        {
            var space = new Mock<ISpace>();
            space.Setup(s => s.IsInBounds(It.IsAny<ILocation>())).Returns(true);

            var location = new Mock<ILocation>();
            location.Setup(l => l.GetLocation()).Returns((0.0, 0.0));

            var robot = new Robot(space.Object);
            Assert.IsTrue(robot.Place(location.Object, 270.0));
            Assert.IsTrue(robot.Right());
            Assert.AreEqual(0.0, robot.Direction);
        }

        [TestMethod]
        public void Robot_Report_Success()
        {
            var space = new Mock<ISpace>();
            space.Setup(s => s.IsInBounds(It.IsAny<ILocation>())).Returns(true);

            var location = new Mock<ILocation>();
            location.Setup(l => l.ToString()).Returns("0.0,0.0");

            var robot = new Robot(space.Object);
            Assert.IsTrue(robot.Place(location.Object, 0.0));
            Assert.AreEqual("0.0,0.0,NORTH", robot.Report());
        }
    }
}