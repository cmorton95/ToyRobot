using ToyRobot.Core.Space;

namespace ToyRobot.Core.Entities 
{
    public interface IEntity 
    {
        /// <summary>
        /// The name of the entity
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Is the entity placed?
        /// </summary>
        bool IsPlaced { get; }

        /// <summary>
        /// The entity's current location
        /// </summary>
        ILocation Location { get; }

        /// <summary>
        /// The facing direction in degrees of the entity
        /// </summary>
        double Direction { get; }

        /// <summary>
        /// Move the entity
        /// </summary>
        /// <returns>True if successful</returns>
        bool Move();

        /// <summary>
        /// Rotate the entity left
        /// </summary>
        /// <returns>True if successful</returns>
        bool Left();

        /// <summary>
        /// Rotate the entity right
        /// </summary>
        /// <returns>True if successful</returns>
        bool Right();

        /// <summary>
        /// Place the entity at a location
        /// </summary>
        /// <returns>True if successful</returns>
        bool Place(ILocation location, double direction);

        /// <summary>
        /// Report the entity's current state
        /// </summary>
        /// <returns>The entity's current state</returns>
        string Report();
    }
}