using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.Models.Attack;
using Mandatory2DGameFramework.Models.defence;
using Mandatory2DGameFramework.worlds;

namespace Mandatory2DGameFramework.Models.Cretures.Strategies
{
    public class LootAllStrategy : ILootStrategy
    {
        public void Loot(Creature looter, WorldObject lootObj)
        {
            if (looter == null || lootObj == null) 
                return;

            if (lootObj is DefenceItem lootDefence)
            {
                looter.Defence.Add(lootDefence);
                lootObj.Lootable = false;
                lootObj.Removeable = true; 
            }
            if (lootObj is AttackItem lootWeapon)
            {
                looter.Weapon = lootWeapon;
                lootObj.Lootable = false; 
                lootObj.Removeable = true; 
            }
        }
    }
}
