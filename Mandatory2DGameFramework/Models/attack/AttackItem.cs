using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Models.Attack
{
    public class AttackItem : WorldObject, IAttackItem
    {
        public string  Name { get; set; }
        public int Hit { get; set; }
        public int Range { get; set; }

        public AttackItem()
        {
            Name = string.Empty;
            Hit = 0;
            Range = 0;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Hit)}={Hit.ToString()}, {nameof(Range)}={Range.ToString()}}}";
        }

        public int DealDamage()
        {
            return Hit;
        }
    }
}
