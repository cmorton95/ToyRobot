using ToyRobot.Application.Exceptions;
using ToyRobot.Application.Space;
using ToyRobot.Core.Entities;

namespace ToyRobot.Application.Commands
{
    public class LeftCommand : BaseCommand
    {
        public override string Name => "LEFT";

        public override string Description => "Rotate the Robot left 90 degrees";

        public override bool Verbose { get; }

        public LeftCommand(bool verbose)
        {
            Verbose = verbose;
        }

        public override string Execute(IEntity entity, params string[] args)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (args.Length != 0)
                throw new ArgumentCountException(args.Length, 0);

            if (!entity.IsPlaced)
                throw new CommandException("You must first place the Robot");

            return entity.Left() 
                ? $"Successfully rotated left to facing direction: {CardinalHelper.GetCardinalByDegrees(entity.Direction)}" 
                : $"Failed to rotate";
        }
    }
}