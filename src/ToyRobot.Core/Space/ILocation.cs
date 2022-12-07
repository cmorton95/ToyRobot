namespace ToyRobot.Core.Space 
{
    public interface ILocation 
    {
        /// <summary>
        /// Return the current location coordinates
        /// </summary>
        /// <returns>A tuple of the current coordinates</returns>
        (double, double) GetLocation();

        /// <summary>
        /// Transform this location using a direction and distance
        /// </summary>
        /// <param name="distance">The distance to transform the location by</param>
        /// <param name="direction">The direction to transform the location in</param>
        /// <returns>A new location transformed from this location</returns>
        ILocation Transform(double distance, double direction);
    }
}