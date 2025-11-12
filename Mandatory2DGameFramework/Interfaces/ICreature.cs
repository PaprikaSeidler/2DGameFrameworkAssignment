using Mandatory2DGameFramework.Models.Creatures;
using Mandatory2DGameFramework.worlds;

namespace Mandatory2DGameFramework.Interfaces
{
    public interface ICreature
    {
        void TakeTurn(Creature? opponent = null, WorldObject? lootObj = null);
    }
}
