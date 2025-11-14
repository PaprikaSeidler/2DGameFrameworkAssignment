using Mandatory2DGameFramework.Models.Creatures;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Interfaces
{
    public interface ILootStrategy
    {
        void Loot(Creature looter, WorldObject lootObj); 
    }
}
