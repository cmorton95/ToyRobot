using ToyRobot.Core.Space;

namespace ToyRobot.Application.Space 
{
    public class Location : ILocation
    {
        private double _x;
        private double _y;

        public Location(double x, double y) {
            _x = x;
            _y = y;
        }

        public (double, double) GetLocation()
        {
            return (_x, _y);
        }

        public ILocation Transform(double distance, double direction)
        {
            if (direction % 90 != 0)
                throw new ArgumentException("Direction must be a multiple of 90", nameof(direction));

            var dirRad = Math.PI * direction / 180.0;

            var newX = Math.Round(_x + distance * Math.Sin(dirRad));
            var newY = Math.Round(_y + distance * Math.Cos(dirRad));

            return new Location(newX, newY);
        }

        public override string ToString()
        {
            return $"{_x},{_y}";
        }
    }
}