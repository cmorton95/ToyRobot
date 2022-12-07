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
        /// <summary>
        /// Convert a cardinal direction to degrees
        /// </summary>
        /// <param name="cardinal">The cardinal to convert</param>
        /// <returns>A multiple of 90 degrees dependent on the cardinal direction</returns>
        public static double ToDegrees(this Cardinal cardinal) 
        {
            return (double)cardinal * 45;
        }
    } 

    public static class CardinalHelper 
    {
        /// <summary>
        /// Convert a multiple of 90 degrees to a cardinal direction
        /// </summary>
        /// <param name="degrees">The degrees of rotation</param>
        /// <returns>The cardinal direction associated with this degree of rotation</returns>
        public static Cardinal GetCardinalByDegrees(double degrees) 
        {
            //Modulo 8 works nicely for converting 0-270 to a cardinal
            return (Cardinal)(degrees % 8);
        }
    }
}