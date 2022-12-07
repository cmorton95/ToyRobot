using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Application.Commands;
using ToyRobot.Application.Exceptions;
using ToyRobot.Core.Commands;
using ToyRobot.Core.Entities;
using ToyRobot.Core.Space;

namespace ToyRobot.UnitTests.Commands
{
    [TestClass]
    public class CommandHandlerTests
    {
        [TestMethod]
        public void CommandHandler_RegisterSpace_Success()
        {
            var space = new Mock<ISpace>();
            var handler = new CommandHandler();
            Assert.AreEqual(handler, handler.RegisterSpace(space.Object));
        }

        [TestMethod]
        public void CommandHandler_RegisterSpace_ArgNull() 
        {
            var handler = new CommandHandler();
            Assert.ThrowsException<ArgumentNullException>(() => handler.RegisterSpace(null!));
        }

        [TestMethod]
        public void CommandHandler_RegisterEntity_Success() 
        {
            var entity = new Mock<IEntity>();
            var handler = new CommandHandler();
            Assert.AreEqual(handler, handler.RegisterEntity(entity.Object));
        }

        [TestMethod]
        public void CommandHandler_RegisterEntity_ArgNull() 
        {
            var handler = new CommandHandler();
            Assert.ThrowsException<ArgumentNullException>(() => handler.RegisterEntity(null!));
        }

        [TestMethod]
        public void CommandHandler_RegisterCommand_Success() 
        {
            var command = new Mock<ICommand>();
            command.Setup(c => c.Name).Returns("Test");
            var handler = new CommandHandler();
            Assert.AreEqual(handler, handler.RegisterCommand(command.Object));
        }

        [TestMethod]
        public void CommandHandler_RegisterCommand_ArgNull() 
        {
            var handler = new CommandHandler();
            Assert.ThrowsException<ArgumentNullException>(() => handler.RegisterCommand(null!));
        }

        [TestMethod]
        public void CommandHandler_RegisterCommand_AlreadyRegistered() 
        {
            var command = new Mock<ICommand>();
            command.Setup(c => c.Name).Returns("Test");
            var handler = new CommandHandler();
            Assert.AreEqual(handler, handler.RegisterCommand(command.Object));
            var ex = Assert.ThrowsException<InvalidOperationException>(() => handler.RegisterCommand(command.Object));
            Assert.AreEqual("Only one command by name 'Test' may be registered", ex.Message);
        }

        [TestMethod]
        public void CommandHandler_ExecuteCommand_Success()
        {
            var commandName = "Test";

            var space = new Mock<ISpace>();
            var entity = new Mock<IEntity>();

            var command = new Mock<ICommand>();
            command.Setup(c => c.Name).Returns(commandName);
            command.Setup(c => c.Execute(It.IsAny<IEntity>(), It.IsAny<string[]>())).Returns("Test result");

            var handler = new CommandHandler()
                .RegisterSpace(space.Object)
                .RegisterEntity(entity.Object) 
                .RegisterCommand(command.Object);
            Assert.AreEqual("Test result", handler.ExecuteCommand(commandName));
        }

        [TestMethod]
        public void CommandHandler_ExecuteCommand_EmptyCommand()
        {
            var commandName = "Test";

            var space = new Mock<ISpace>();
            var entity = new Mock<IEntity>();

            var command = new Mock<ICommand>();
            command.Setup(c => c.Name).Returns(commandName);
            command.Setup(c => c.Execute(It.IsAny<IEntity>(), It.IsAny<string[]>())).Returns("Test result");

            var handler = new CommandHandler()
                .RegisterSpace(space.Object)
                .RegisterEntity(entity.Object) 
                .RegisterCommand(command.Object);
            Assert.ThrowsException<CommandException>(() => handler.ExecuteCommand(""));
        }

        [TestMethod]
        public void CommandHandler_ExecuteCommand_EntityNull()
        {
            var commandName = "Test";

            var space = new Mock<ISpace>();

            var command = new Mock<ICommand>();
            command.Setup(c => c.Name).Returns(commandName);
            command.Setup(c => c.Execute(It.IsAny<IEntity>(), It.IsAny<string[]>())).Returns("Test result");

            var handler = new CommandHandler()
                .RegisterSpace(space.Object)
                .RegisterCommand(command.Object);
            var ex = Assert.ThrowsException<InvalidOperationException>(() => handler.ExecuteCommand(commandName));
            Assert.AreEqual("Entity not registered", ex.Message);
        }

        [TestMethod]
        public void CommandHandler_ExecuteCommand_SpaceNull()
        {
            var commandName = "Test";

            var entity = new Mock<IEntity>();

            var command = new Mock<ICommand>();
            command.Setup(c => c.Name).Returns(commandName);

            var handler = new CommandHandler()
                .RegisterEntity(entity.Object) 
                .RegisterCommand(command.Object);
            var ex = Assert.ThrowsException<InvalidOperationException>(() => handler.ExecuteCommand(commandName));
            Assert.AreEqual("Space not registered", ex.Message);
        }

        [TestMethod]
        public void CommandHandler_ExecuteCommand_CommandsEmpty()
        {
            var commandName = "Test";

            var space = new Mock<ISpace>();
            var entity = new Mock<IEntity>();

            var command = new Mock<ICommand>();
            command.Setup(c => c.Name).Returns(commandName);

            var handler = new CommandHandler()
                .RegisterEntity(entity.Object)
                .RegisterSpace(space.Object);
            var ex = Assert.ThrowsException<InvalidOperationException>(() => handler.ExecuteCommand(commandName));
            Assert.AreEqual("Commands not registered", ex.Message);
        }

        [TestMethod]
        public void CommandHandler_GetHelp_Success()
        {
            var commandName = "Test";
            var helpCommand = "Help";
            var helpText = "Help text";

            var space = new Mock<ISpace>();
            var entity = new Mock<IEntity>();

            var command = new Mock<ICommand>();
            command.Setup(c => c.Name).Returns(commandName);
            command.Setup(c => c.Help).Returns(helpText);

            var handler = new CommandHandler()
                .RegisterSpace(space.Object)
                .RegisterEntity(entity.Object) 
                .RegisterCommand(command.Object);
            Assert.AreEqual(helpText, handler.ExecuteCommand(helpCommand));
        }

        [TestMethod]
        public void CommandHandler_GetHelp_SuccessLongHelp()
        {
            var commandName = "Test";
            var helpCommand = "Help test";
            var helpText = "Help text";

            var space = new Mock<ISpace>();
            var entity = new Mock<IEntity>();

            var command = new Mock<ICommand>();
            command.Setup(c => c.Name).Returns(commandName);
            command.Setup(c => c.LongHelp).Returns(helpText);

            var handler = new CommandHandler()
                .RegisterSpace(space.Object)
                .RegisterEntity(entity.Object) 
                .RegisterCommand(command.Object);
            Assert.AreEqual(helpText, handler.ExecuteCommand(helpCommand));
        }

        [TestMethod]
        public void CommandHandler_GetHelp_FailNotFound()
        {
            var commandName = "Test";
            var helpCommand = "Help notacommand";
            var returnText = "Command not found";

            var space = new Mock<ISpace>();
            var entity = new Mock<IEntity>();

            var command = new Mock<ICommand>();
            command.Setup(c => c.Name).Returns(commandName);

            var handler = new CommandHandler()
                .RegisterSpace(space.Object)
                .RegisterEntity(entity.Object) 
                .RegisterCommand(command.Object);
            Assert.AreEqual(returnText, handler.ExecuteCommand(helpCommand));
        }
    }
}