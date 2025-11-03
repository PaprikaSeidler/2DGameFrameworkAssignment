using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.Logger;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.worlds;

namespace Mandatory2DGameFramework.Models.Cretures.States
{
    public class DeadState : ICreatureState
    {
        public bool IsAlive => false;

        public void Loot(Creature creature, WorldObject lootObj)
        {
            MyLogger.Instance.LogInfo($"{creature.Name} is dead and cannot loot {lootObj.Name}.");
        }

        public void ReceiveHit(Creature creature, int damage)
        {
            MyLogger.Instance.LogInfo($"{creature.Name} is already dead and cannot receive more hits.");
        }

        public void TakeTurn(Creature creature, Creature? opponent = null, WorldObject? lootObj = null)
        {
            MyLogger.Instance.LogInfo($"{creature.Name} is dead and cannot take a turn.");
        }
    }
}
