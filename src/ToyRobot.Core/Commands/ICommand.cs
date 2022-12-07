using ToyRobot.Core.Entities;

namespace ToyRobot.Core.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// Command name used as the command input
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Description of the command
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Short help summary
        /// </summary>
        string Help { get; }

        /// <summary>
        /// Detailed help summary
        /// </summary>
        string LongHelp { get; }

        /// <summary>
        /// A flag to determine whether a command should be printed
        /// </summary>
        bool Verbose { get; }

        /// <summary>
        /// Execute the target command
        /// </summary>
        /// <param name="entity">Entity to act on</param>
        /// <param name="args">Arguments for the comand</param>
        /// <returns>A string response for output</returns>
        string Execute(IEntity entity, string[] args);
    }
}