using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Application.Commands;
using ToyRobot.Application.Exceptions;
using ToyRobot.Core.Entities;
using ToyRobot.Core.Space;

namespace ToyRobot.UnitTests.Commands
{
    [TestClass]
    public class PlaceCommandTests
    {
        [TestMethod]
        public void PlaceCommand_Executes_Success()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Place(It.IsAny<ILocation>(), It.IsAny<double>())).Returns(true);
            entity.Setup(e => e.Direction).Returns(90);

            var command = new PlaceCommand();
            Assert.AreEqual("Placed  at location 0,0 facing NORTH", command.Execute(entity.Object, new string[1] { "0,0,NORTH" }));
        }

        [TestMethod]
        public void PlaceCommand_Executes_Fail()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Place(It.IsAny<ILocation>(), It.IsAny<double>())).Returns(false);

            var command = new PlaceCommand();
            Assert.AreEqual("Failed to place", command.Execute(entity.Object, new string[1] { "0,0,NORTH" }));
        }

        [TestMethod]
        public void PlaceCommand_Executes_Fail_ArgNull()
        {
            var command = new PlaceCommand();
            Assert.ThrowsException<ArgumentNullException>(() => command.Execute(null!, new string[1] { "0,0,NORTH" }));
        }

        [TestMethod]
        public void PlaceCommand_Executes_Fail_ArgCount()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Place(It.IsAny<ILocation>(), It.IsAny<double>())).Returns(true);

            var command = new PlaceCommand();
            var ex = Assert.ThrowsException<ArgumentCountException>(() => command.Execute(entity.Object, new string[0] ));
            Assert.AreEqual("Expected 1 arguments but got 0", ex.Message);
        }

        [TestMethod]
        public void PlaceCommand_Executes_Fail_LocationFormat()
        {
            var entity = new Mock<IEntity>();
            entity.Setup(e => e.Place(It.IsAny<ILocation>(), It.IsAny<double>())).Returns(true);

            var command = new PlaceCommand();
            var ex = Assert.ThrowsException<CommandException>(() => command.Execute(entity.Object, new string[1] { "test" }));
            Assert.AreEqual("Command not valid: Location must be formatted X,Y,F", ex.Message);
        }
    }
}