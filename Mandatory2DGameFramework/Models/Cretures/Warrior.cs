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
        protected override int Hit()
        {
            const int unarmedHit = 2;
            if (Weapon != null)
                return Weapon.Hit;
            else
                return unarmedHit;
        }
    }
}
