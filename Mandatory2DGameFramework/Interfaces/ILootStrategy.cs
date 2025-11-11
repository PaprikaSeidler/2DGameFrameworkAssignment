using Mandatory2DGameFramework.Models.Creatures;
using Mandatory2DGameFramework.worlds;

namespace Mandatory2DGameFramework.Interfaces
{
    public interface ILootStrategy
    {
        void Loot(Creature looter, WorldObject lootObj); 
    }
}
