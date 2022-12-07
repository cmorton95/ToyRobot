using ToyRobot.Application.Space;
using ToyRobot.Core.Entities;
using ToyRobot.Core.Space;

namespace ToyRobot.Application.Entities 
{
    public class Robot : IEntity
    {
        public string Name => "Robot";
        public double Direction { get; private set; } = 0.0;
        public bool IsPlaced { get; private set; }
        public ILocation Location { get; private set; } = new Location(0,0);
        private ISpace Space { get; set; }
        
        private readonly double _pace = 1.0;

        public Robot(ISpace space) {
            if (space == null)
                throw new ArgumentNullException();
                
            Space = space;
        }

        public bool Place(ILocation location, double direction)
        {
            if (!Space.IsInBounds(location)) {
                return false;
            }
            Location = location;
            Direction = direction;
            IsPlaced = true;
            return true;
        }

        public bool Move()
        {
            var nextLocation = Location.Transform(_pace, Direction);

            //Only allow movement if the next location is in bounds
            if (Space.IsInBounds(nextLocation)) {
                Location = nextLocation;
                return true;
            }
            return false;
        }

        public bool Left() {
            Direction -= 90.0;

            if (Direction < 0)
                Direction += 360.0;
            
            return true;
        }

        public bool Right()
        {
            Direction += 90;

            if (Direction >= 360.0)
                Direction -= 360.0;
                
            return true;
        }

        public string Report()
        {
            return $"{Location.ToString()},{CardinalHelper.GetCardinalByDegrees(Direction)}";
        }
    }
}