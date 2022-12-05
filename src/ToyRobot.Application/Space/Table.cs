namespace ToyRobot.Application.Space 
{
    public class Table : Space
    {
        public override (double Min, double Max) BoundsX => (0,5);

        public override (double Min, double Max) BoundsY => (0,5);
    }
}