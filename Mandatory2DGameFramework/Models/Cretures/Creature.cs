using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.Logger;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    public abstract class Creature : IObserverable<IHitObserver>
    {
        private readonly List<IHitObserver> _hitObservers = new();

        public string Name { get; set; }
        public int HitPoint { get; set; }


        // allow multiple defence items but only one attack item
        public AttackItem? Weapon { get; set; }
        public List<IDefenceItem> Defence { get; set; }

        public Creature()
        {
            Name = string.Empty; 
            HitPoint = 100; // default hit points

            Weapon = null; // allow no attack item by default
            Defence = new List<IDefenceItem>(); 

        }

        public void TakeTurn(Creature? opponent = null, WorldObject? lootObj = null)
        {
            int damage = Hit();

            if (opponent != null && damage > 0)
                opponent.ReceiveHit(damage);

            if (lootObj != null)
                Loot(lootObj);
        }

        protected abstract int Hit();
        protected virtual void ReceiveHit(int hit)
        {
            int totalDefence = Defence.Sum(d => d.GetReduceHitPoint());
            int damage = hit - totalDefence;
            if (damage > 0)
            {
                HitPoint -= damage;
                if (HitPoint < 0)
                    HitPoint = 0;
            }
            NotifyHitObservers(damage);
        }
        protected virtual void Loot(WorldObject obj)
        {
            if (obj == null) return;

            if (obj is IDefenceItem defenceItem)
            {
                Defence.Add(defenceItem);
                obj.Lootable = false; // mark as looted
                obj.Removeable = true; // mark as removable
            }
            else if (obj is AttackItem attackItem)
            {
                Weapon = attackItem;
                obj.Lootable = false; 
                obj.Removeable = true;
            }
        }


        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint.ToString()}, {nameof(Weapon)}={Weapon}, {nameof(Defence)}={Defence}}}";
        }

        public void AddObserver(IHitObserver observer)
        {
            _hitObservers.Add(observer);
        }

        public void RemoveObserver(IHitObserver observer)
        {
            _hitObservers.Remove(observer);
        }

        protected void NotifyHitObservers(int damage)
        {
            try
            {
                foreach (var observer in _hitObservers)
                {
                    //observer.OnHit(damage);
                    observer.OnHit(damage, this.HitPoint);
                }
            }
            catch (Exception ex)
            {
                MyLogger.Instance.LogError("Error notifying hit observers: " + ex.Message);
            }

        }

    }
}
