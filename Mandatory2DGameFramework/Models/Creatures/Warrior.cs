using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    public class Warrior : Creature
    {
        public Warrior() : base()
        {
        }

        protected override int Hit()
        {
            return Weapon.DealDamage();
        }
    }
}
