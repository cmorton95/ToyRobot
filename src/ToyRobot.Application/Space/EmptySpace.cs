using ToyRobot.Core.Space;

namespace ToyRobot.Application.Space 
{
    public class EmptySpace : Space
    {
        public override (double Min, double Max) BoundsX => (0,0);

        public override (double Min, double Max) BoundsY => (0,0);
    }
}