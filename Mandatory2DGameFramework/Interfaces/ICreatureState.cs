using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Interfaces
{
    public interface ICreatureState
    {
        void TakeTurn(Creature creature, Creature? opponent = null, WorldObject? lootObj = null);
        void ReceiveHit(Creature creature, int damage);
        void Loot(Creature creature, WorldObject lootObj);
        bool IsAlive { get; }
    }
}
