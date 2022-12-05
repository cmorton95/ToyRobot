using ToyRobot.Core.Space;

namespace ToyRobot.Application.Space 
{
    public abstract class Space : ISpace
    {
        public abstract (double Min, double Max) BoundsX { get; }

        public abstract (double Min, double Max) BoundsY { get; }

        public bool IsInBounds(ILocation location)
        {
            var (x, y) = location.GetLocation();
            
            return (BoundsX.Min <= x && BoundsX.Max >= x)
                && (BoundsY.Min <= y && BoundsY.Max >= y);
        }
    }
}