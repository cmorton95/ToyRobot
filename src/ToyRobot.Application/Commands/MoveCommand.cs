using ToyRobot.Application.Exceptions;
using ToyRobot.Core.Entities;
using ToyRobot.Core.Commands;

namespace ToyRobot.Application.Commands
{
    public class MoveCommand : BaseCommand
    {
        public override string Name => "MOVE";

        public override string Description => "Move the Robot one square in its facing direction";

        public override string Execute(IEntity entity, params string[] args)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (args.Length != 0)
                throw new ArgumentCountException(args.Length, 0);

            if (!entity.IsPlaced)
                throw new CommandException("You must first place the Robot");

            return entity.Move() ? $"Successfully moved to: {entity.Location.ToString()}" : $"Failed to move";
        }
    }
}