using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.Models.Attack;
using Mandatory2DGameFramework.Models.defence;
using Mandatory2DGameFramework.Worlds;
using Mandatory2DGameFramework.Logger;

namespace Mandatory2DGameFramework.Models.Creatures.Strategies
{
    public class LootAllStrategy : ILootStrategy
    {
        public void Loot(Creature looter, WorldObject lootObj)
        {
            if (looter == null || lootObj == null) 
                return;

            if (lootObj is IDefenceItem lootDefence)
            {
                looter.Defence.AddDefenceItem(lootDefence);
                lootObj.Lootable = false;
                lootObj.Removeable = true; 

                MyLogger.Instance.LogInfo($"{looter.Name} looted defence item: {lootDefence.ToString()}");
            }
            if (lootObj is IAttackItem lootWeapon)
            {
                looter.Weapon = lootWeapon;
                lootObj.Lootable = false; 
                lootObj.Removeable = true;
                
                MyLogger.Instance.LogInfo($"{looter.Name} looted weapon: {lootWeapon.ToString()}");
            }
        }
    }
}
