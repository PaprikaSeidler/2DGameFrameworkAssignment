using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Models.defence
{
    /// <summary>
    /// Defence item that can reduce hit points from attacks. Inherits from WorldObject.
    /// </summary>
    public class DefenceItem: WorldObject, IDefenceItem
    {
        /// <summary>
        /// The amount of hit points this defence item can reduce.
        /// </summary>
        public int ReduceHitPoint { get; set; }

        /// <summary>
        /// Constructor for DefenceItem, initializes Name to empty string and ReduceHitPoint to 0 - To be set later.
        /// </summary>
        public DefenceItem()
        {
            Name = string.Empty;
            ReduceHitPoint = 0;
            Lootable = true;
        }

        /// <summary>
        /// Combine two DefenceItems with combined ReduceHitPoint.
        /// </summary>
        /// <param name="DefenceItem a">first DefenceItem</param>
        /// <param name="DefenceItem b">second DefenceItem</param>
        /// <returns>combined item with ReduceHitPoint corrolating with the combined ReduceHitPoints of DefenceItem a + b.</returns>
        public static DefenceItem operator +(DefenceItem a, DefenceItem b)
        {
            DefenceItem result = new DefenceItem();
            result.Name = a.Name + "+" + b.Name;
            result.ReduceHitPoint = a.ReduceHitPoint + b.ReduceHitPoint;
            return result;
        }

        /// <summary>
        /// Gets the value of the reduced hit points.
        /// </summary>
        /// <returns>The amount by which the hit points are reduced.</returns>
        public int GetReduceHitPoint()
        {
            return ReduceHitPoint;
        }

        /// <summary>
        /// ToString override for DefenceItem. 
        /// </summary>
        /// <returns>Returns a string representation of the DefenceItem (Name and ReduceHitPoint).</returns>
        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(ReduceHitPoint)}={ReduceHitPoint.ToString()}}}";
        }
    }
}
