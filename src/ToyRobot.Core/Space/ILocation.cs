namespace ToyRobot.Core.Space 
{
    public interface ILocation 
    {
        (double, double) GetLocation();
        ILocation Transform(double distance, double direction);
    }
}