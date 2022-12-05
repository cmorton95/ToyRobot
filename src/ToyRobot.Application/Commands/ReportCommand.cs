using ToyRobot.Application.Exceptions;
using ToyRobot.Core.Entities;
using ToyRobot.Core.Commands;

namespace ToyRobot.Application.Commands
{
    public class ReportCommand : BaseCommand
    {
        public override string Name => "REPORT";

        public override string Description => "Report the Robot's current location and facing direction";

        public override string Execute(IEntity entity, params string[] args)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (args.Length != 0)
                throw new ArgumentCountException(args.Length, 0);

            if (!entity.IsPlaced)
                throw new CommandException("You must first place the Robot");

            return entity.Report();
        }
    }
}