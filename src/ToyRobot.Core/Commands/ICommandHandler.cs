using ToyRobot.Core.Entities;
using ToyRobot.Core.Space;

namespace ToyRobot.Core.Commands 
{
    public interface ICommandHandler 
    {
        /// <summary>
        /// Register the entity to use with this command handler
        /// </summary>
        /// <param name="entity">The entity to register</param>
        /// <returns>This command handler</returns>
        ICommandHandler RegisterEntity(IEntity entity);

        /// <summary>
        /// Register the space to use with this command handler
        /// </summary>
        /// <param name="entity">The space to register</param>
        /// <returns>This command handler</returns>
        ICommandHandler RegisterSpace(ISpace space);

        /// <summary>
        /// Register a command to use with this command handler
        /// </summary>
        /// <param name="entity">The command to register</param>
        /// <returns>This command handler</returns>
        ICommandHandler RegisterCommand(ICommand command);

        /// <summary>
        /// Execute a registered command by string input
        /// </summary>
        /// <param name="command">The command string input</param>
        /// <returns>A string response</returns>
        string ExecuteCommand(string command);
    }
}