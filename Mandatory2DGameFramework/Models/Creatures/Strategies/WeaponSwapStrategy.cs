using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.Models.Attack;
using Mandatory2DGameFramework.Worlds;
using Mandatory2DGameFramework.Logger;

namespace Mandatory2DGameFramework.Models.Creatures.Strategies
{
    public class WeaponSwapStrategy : ILootStrategy
    {
        public void Loot(Creature looter, WorldObject lootObj)
        {
            if (looter == null || lootObj == null) 
                return;

            if (lootObj is IAttackItem lootWeapon)
            {
                var currentWeapon = looter.Weapon;
                if (currentWeapon == null || lootWeapon.Hit > currentWeapon.Hit)
                {
                    looter.Weapon = lootWeapon;
                    lootObj.Lootable = false; // mark as looted
                    lootObj.Removeable = true; // mark as removable

                    MyLogger.Instance.LogInfo($"{looter.Name} swapped weapon to {lootWeapon.Name}.");
                }
                else
                {
                    MyLogger.Instance.LogInfo($"{looter.Name} found {lootWeapon.Name} but did not swap.");
                }
            }
        }
    }
}
