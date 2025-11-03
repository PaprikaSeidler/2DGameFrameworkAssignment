using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Interfaces
{
    public interface ILootStrategy
    {
        void Loot(Creature looter, WorldObject lootObj); 
    }
}
