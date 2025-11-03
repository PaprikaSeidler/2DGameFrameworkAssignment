using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Models.Cretures.Strategies
{
    public class WeaponSwapStrategy : ILootStrategy
    {
        public void Loot(Creature looter, WorldObject lootObj)
        {
            if (looter == null || lootObj == null) 
                return;

            if (lootObj is AttackItem lootWeapon)
            {
                var currentWeapon = looter.Weapon;
                if (currentWeapon == null || lootWeapon.Hit > currentWeapon.Hit)
                {
                    looter.Weapon = lootWeapon;
                    lootObj.Lootable = false; // mark as looted
                    lootObj.Removeable = true; // mark as removable
                }
            }
        }
    }
}
