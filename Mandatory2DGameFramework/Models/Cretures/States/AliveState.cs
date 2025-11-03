using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mandatory2DGameFramework.Models.Cretures.States
{
    public class AliveState : ICreatureState
    {
        public bool IsAlive => true;

        public void TakeTurn(Creature creature, Creature? opponent = null, WorldObject? lootObj = null)
        {
            int damage = creature.Hit();

            if (opponent != null && damage > 0)
                opponent.ReceiveHit(damage);

            if (lootObj != null)
                creature.Loot(lootObj);
        }

        public void ReceiveHit(Creature creature, int damage)
        {
            int totalDefence = creature.Defence.Sum(d => d.GetReduceHitPoint());
            int totalDamage = Math.Max(0, damage - totalDefence);
            creature.HitPoint -= totalDamage;
            if (creature.HitPoint <= 0)
            {
                creature.HitPoint = 0;
                creature.CurrentState = new DeadState();
            }
            creature.NotifyHitObservers(totalDamage);
        }

        public void Loot(Creature creature, WorldObject lootObj)
        {
            creature.LootStrategy?.Loot(creature, lootObj);
        }
    }
}
