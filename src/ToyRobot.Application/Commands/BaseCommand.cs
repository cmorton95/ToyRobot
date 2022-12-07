using ToyRobot.Core.Entities;
using ToyRobot.Core.Commands;

namespace ToyRobot.Application.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public abstract string Name { get; }

        public abstract string Description { get; }

        public virtual string Help => $"{Name} - {Description}";

        public virtual string LongHelp => $"{Help}";

        public abstract bool Verbose { get; }

        public abstract string Execute(IEntity entity, string[] args);
    }
}