using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    public abstract class Creature
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }


        // allow multiple defence items but only one attack item
        public AttackItem? Attack { get; set; }
        public List<DefenceItem> Defence { get; set; }

        public Creature()
        {
            Name = string.Empty; 
            HitPoint = 100; // default hit points

            Attack = null; // allow no attack item by default
            Defence = new List<DefenceItem>(); // enable multiple defence items

        }

        protected abstract int Hit();

        protected abstract void ReceiveHit(int hit);

        protected abstract void Loot(WorldObject obj);


        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint.ToString()}, {nameof(Attack)}={Attack}, {nameof(Defence)}={Defence}}}";
        }
    }
}
