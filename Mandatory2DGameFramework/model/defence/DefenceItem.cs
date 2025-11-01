using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.defence
{
    /// <summary>
    /// Defence item that can reduce hit points from attacks. Inherits from WorldObject.
    /// </summary>
    public class DefenceItem: WorldObject, IDefenceItem
    {
        public int ReduceHitPoint { get; set; }

        public DefenceItem()
        {
            Name = string.Empty;
            ReduceHitPoint = 0;
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

        public int GetReduceHitPoint()
        {
            return ReduceHitPoint;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(ReduceHitPoint)}={ReduceHitPoint.ToString()}}}";
        }
    }
}
