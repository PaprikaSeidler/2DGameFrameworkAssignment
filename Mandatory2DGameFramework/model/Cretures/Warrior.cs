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
        protected override int Hit();

        protected override void Loot(WorldObject obj)
        {
            throw new NotImplementedException();
        }

        protected override void ReceiveHit(int hit)
        {
            throw new NotImplementedException();
        }
    }
}
