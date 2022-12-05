using ToyRobot.Core.Space;

namespace ToyRobot.Core.Entities 
{
    public interface IEntity 
    {
        string Name { get; }
        bool IsPlaced { get; }
        ILocation Location { get; }
        double Direction { get; }
        bool Move();
        bool Left();
        bool Right();
        bool Place(ILocation location, double direction);
        string Report();
    }
}