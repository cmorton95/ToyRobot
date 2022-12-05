namespace ToyRobot.Core.Space 
{
    public interface ISpace 
    {
        (double Min, double Max) BoundsX { get; } 
        (double Min, double Max) BoundsY { get; }
        bool IsInBounds(ILocation location);
    }
}