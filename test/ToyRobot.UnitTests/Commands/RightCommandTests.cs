using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Application.Commands;
using ToyRobot.Application.Exceptions;
using ToyRobot.Core.Entities;

namespace ToyRobot.UnitTests.Commands
{
    [TestClass]
    public class RightCommandTests
    {
        [TestMethod]
        public void RightCommand_Executes_Success()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Right()).Returns(true);
            entity.Setup(e => e.Direction).Returns(90);
            entity.Setup(e => e.IsPlaced).Returns(true);

            var command = new RightCommand();
            Assert.AreEqual("Successfully rotated right to facing direction: EAST", command.Execute(entity.Object, new string[0]));
        }

        [TestMethod]
        public void RightCommand_Executes_Fail()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Right()).Returns(false);
            entity.Setup(e => e.IsPlaced).Returns(true);

            var command = new RightCommand();
            Assert.AreEqual("Failed to rotate", command.Execute(entity.Object, new string[0]));
        }

        [TestMethod]
        public void RightCommand_Executes_Fail_ArgNull()
        {
            var command = new RightCommand();
            Assert.ThrowsException<ArgumentNullException>(() => command.Execute(null!, new string[0]));
        }

        [TestMethod]
        public void RightCommand_Executes_Fail_ArgCount()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Right()).Returns(true);

            var command = new RightCommand();
            var ex = Assert.ThrowsException<ArgumentCountException>(() => command.Execute(entity.Object, new string[1] { "Test" } ));
            Assert.AreEqual("Expected 0 arguments but got 1", ex.Message);
        }

        [TestMethod]
        public void RightCommand_Executes_Fail_NotPlaced()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Right()).Returns(true);
            entity.Setup(e => e.IsPlaced).Returns(false);

            var command = new RightCommand();
            var ex = Assert.ThrowsException<CommandException>(() => command.Execute(entity.Object, new string[0]));
            Assert.AreEqual("Command not valid: You must first place the Robot", ex.Message);
        }
    }
}