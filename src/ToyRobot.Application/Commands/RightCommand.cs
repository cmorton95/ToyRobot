using ToyRobot.Application.Exceptions;
using ToyRobot.Application.Space;
using ToyRobot.Core.Commands;
using ToyRobot.Core.Entities;

namespace ToyRobot.Application.Commands
{
    public class RightCommand : BaseCommand
    {
        public override string Name => "RIGHT";

        public override string Description => "Rotate the Robot right 90 degrees";

        public override bool Verbose { get; }

        public RightCommand(bool verbose)
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

            return entity.Right() 
                ? $"Successfully rotated right to facing direction: {CardinalHelper.GetCardinalByDegrees(entity.Direction)}" 
                : $"Failed to rotate";
        }
    }
}