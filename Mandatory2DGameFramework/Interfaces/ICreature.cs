using Mandatory2DGameFramework.worlds;

namespace Mandatory2DGameFramework.Interfaces
{
    public interface ICreature
    {
        void TakeTurn(ICreature? opponent = null, WorldObject? lootObj = null);
        int Hit();
        void ReceiveHit(int hit);
        void Loot(WorldObject lootObj);
    }
}
