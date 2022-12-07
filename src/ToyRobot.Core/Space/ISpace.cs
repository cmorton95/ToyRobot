namespace ToyRobot.Core.Space 
{
    public interface ISpace 
    {
        /// <summary>
        /// The bounds along the horizontal axis
        /// </summary>
        (double Min, double Max) BoundsX { get; } 

        /// <summary>
        /// The bounds along the vertical axis
        /// </summary>
        (double Min, double Max) BoundsY { get; }

        /// <summary>
        /// Is a given location within the bounds?
        /// </summary>
        /// <param name="location">The location to check</param>
        /// <returns>True if the location lies within the bounds</returns>
        bool IsInBounds(ILocation location);
    }
}