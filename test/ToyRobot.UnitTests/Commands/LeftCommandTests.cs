using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Application.Commands;
using ToyRobot.Application.Exceptions;
using ToyRobot.Core.Entities;

namespace ToyRobot.UnitTests.Commands
{
    [TestClass]
    public class LeftCommandTests
    {
        [TestMethod]
        public void LeftCommand_Executes_Success()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Left()).Returns(true);
            entity.Setup(e => e.Direction).Returns(90);
            entity.Setup(e => e.IsPlaced).Returns(true);

            var command = new LeftCommand(true);
            Assert.AreEqual("Successfully rotated left to facing direction: EAST", command.Execute(entity.Object, new string[0]));
        }

        [TestMethod]
        public void LeftCommand_Executes_Fail()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Left()).Returns(false);
            entity.Setup(e => e.IsPlaced).Returns(true);

            var command = new LeftCommand(true);
            Assert.AreEqual("Failed to rotate", command.Execute(entity.Object, new string[0]));
        }

        [TestMethod]
        public void LeftCommand_Executes_Fail_ArgNull()
        {
            var command = new LeftCommand(true);
            Assert.ThrowsException<ArgumentNullException>(() => command.Execute(null!, new string[0]));
        }

        [TestMethod]
        public void LeftCommand_Executes_Fail_ArgCount()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Left()).Returns(true);

            var command = new LeftCommand(true);
            var ex = Assert.ThrowsException<ArgumentCountException>(() => command.Execute(entity.Object, new string[1] { "Test" } ));
            Assert.AreEqual("Expected 0 arguments but got 1", ex.Message);
        }

        [TestMethod]
        public void LeftCommand_Executes_Fail_NotPlaced()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Left()).Returns(true);
            entity.Setup(e => e.IsPlaced).Returns(false);

            var command = new LeftCommand(true);
            var ex = Assert.ThrowsException<CommandException>(() => command.Execute(entity.Object, new string[0]));
            Assert.AreEqual("Command not valid: You must first place the Robot", ex.Message);
        }
    }
}