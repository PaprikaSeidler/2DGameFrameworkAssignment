using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.Logger;
using Mandatory2DGameFramework.Models.Creatures;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Worlds
{
    /// <summary>
    /// Represents a world with defined boundaries and collections of objects and creatures.
    /// </summary>
    public class World : IWorld
    {
        /// <summary>
        /// Gets or sets the maximum X-coordinate value.
        /// </summary>
        public int MaxX { get; set; }
        /// <summary>
        /// Gets or sets the maximum Y-coordinate value.
        /// </summary>
        public int MaxY { get; set; }

        /// <summary>
        /// Gets the difficulty level of the current context.
        /// </summary>
        public string Difficulty { get; private set; }

        /// <summary>
        /// Gets the collection of world objects currently managed by the system.
        /// </summary>
        public List<WorldObject> WorldObjects { get; private set; }
        /// <summary>
        /// Gets the collection of creatures currently managed by this instance.
        /// </summary>
        public List<Creature> Creatures { get; private set; }


        /// <summary>
        /// Constructor for World, initializes MaxX and MaxY, and creates empty lists for world objects and creatures.
        /// </summary>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <param name="difficulty"></param>
        public World(int maxX, int maxY, string difficulty)
        {
            MaxX = maxX;
            MaxY = maxY;
            Difficulty = difficulty;
            WorldObjects = new List<WorldObject>();
            Creatures = new List<Creature>();
        }

        /// <summary>
        /// Returns a string representation of the object, including the values of the <see cref="MaxX"/> and <see
        /// cref="MaxY"/> properties.
        /// </summary>
        /// <returns>A string in the format "{MaxX=value, MaxY=value}", where "value" represents the respective property values.</returns>
        public override string ToString()
        {
            return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}, Difficulty={Difficulty}}}";
        }
    }
}
