using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Application.Commands;
using ToyRobot.Application.Exceptions;
using ToyRobot.Core.Entities;

namespace ToyRobot.UnitTests.Commands
{
    [TestClass]
    public class ReportCommandTests
    {
        [TestMethod]
        public void ReportCommand_Executes_Success()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Report()).Returns("Test");
            entity.Setup(e => e.Direction).Returns(90);
            entity.Setup(e => e.IsPlaced).Returns(true);

            var command = new ReportCommand();
            Assert.AreEqual("Test", command.Execute(entity.Object, new string[0]));
        }

        [TestMethod]
        public void ReportCommand_Executes_Fail_ArgNull()
        {
            var command = new ReportCommand();
            Assert.ThrowsException<ArgumentNullException>(() => command.Execute(null!, new string[0]));
        }

        [TestMethod]
        public void ReportCommand_Executes_Fail_ArgCount()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Report()).Returns("Test");

            var command = new ReportCommand();
            var ex = Assert.ThrowsException<ArgumentCountException>(() => command.Execute(entity.Object, new string[1] { "Test" } ));
            Assert.AreEqual("Expected 0 arguments but got 1", ex.Message);
        }

        [TestMethod]
        public void ReportCommand_Executes_Fail_NotPlaced()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Report()).Returns("Test");
            entity.Setup(e => e.IsPlaced).Returns(false);

            var command = new ReportCommand();
            var ex = Assert.ThrowsException<CommandException>(() => command.Execute(entity.Object, new string[0]));
            Assert.AreEqual("Command not valid: You must first place the Robot", ex.Message);
        }
    }
}