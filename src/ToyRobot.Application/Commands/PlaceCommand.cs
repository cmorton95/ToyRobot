using ToyRobot.Application.Exceptions;
using ToyRobot.Application.Space;
using ToyRobot.Core.Commands;
using ToyRobot.Core.Entities;
using ToyRobot.Core.Space;

namespace ToyRobot.Application.Commands 
{
    public class PlaceCommand : BaseCommand
    {
        public override string Name => "PLACE";

        public override string Description => "Place the Robot at a given coordinate";

        public override string Help => $"{Name} X,Y,F - {Description}";
        
        public override string LongHelp => $"{Help} - {Description}{Environment.NewLine}"
                                    + $"X is the east/west coordinate"
                                    + $"Y is the north/south coordinate"
                                    + $"F is the facing direction, NORTH, SOUTH, EAST or WEST";

        public override bool Verbose { get; }

        public PlaceCommand(bool verbose)
        {
            Verbose = verbose;
        }

        public override string Execute(IEntity entity, params string[] args)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
                
            if (args.Length != 1)
                throw new ArgumentCountException(args.Length, 1);

            var locationArg = args[0];
            var (location, facing) = ParseLocation(locationArg);

            return entity.Place(location, facing.ToDegrees()) 
                    ? $"Placed {entity.Name} at location {location.ToString()} facing {facing}" 
                    : $"Failed to place";
        }

        private (ILocation loc, Cardinal f) ParseLocation(string locationArg) 
        {
            //Split the location by its 3 points
            var locationSplit = locationArg.Split(",");

            if (locationSplit.Length != 3)
                throw new CommandException("Location must be formatted X,Y,F");

            var stringX = locationSplit[0];
            var stringY = locationSplit[1];
            var stringF = locationSplit[2];

            double x, y;
            Cardinal f;

            //Parse the string coordinates
            var resX = double.TryParse(stringX, out x);
            var resY = double.TryParse(stringY, out y);
            var resF = Enum.TryParse<Cardinal>(stringF, true, out f);

            //Check the input was valid
            if (!resX || !resY || (!resF || !Enum.IsDefined<Cardinal>(f)))
                throw new CommandException("Given coordinates not a valid location");

            return (new Location(x, y), f);
        }
    }
}