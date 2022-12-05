namespace ToyRobot.Application.Space 
{
    public enum Cardinal 
    {
        NORTH = 0,
        EAST = 2,
        SOUTH = 4,
        WEST = 6
    }

    public static class CardinalExtensions 
    {
        public static double ToDegrees(this Cardinal cardinal) 
        {
            return (double)cardinal * 45;
        }
    } 

    public static class CardinalHelper 
    {
        public static Cardinal GetCardinalByDegrees(double degrees) 
        {
            return (Cardinal)(degrees % 8);
        }
    }
}