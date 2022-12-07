using ToyRobot.Core.Entities;

namespace ToyRobot.Core.Commands
{
    public interface ICommand
    {
        string Name { get; }
        string Description { get; }
        string Help { get; }
        string LongHelp { get; }
        bool Verbose { get; }
        string Execute(IEntity entity, string[] args);
    }
}