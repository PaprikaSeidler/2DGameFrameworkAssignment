using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.Logger;
using Mandatory2DGameFramework.Models.Attack;
using Mandatory2DGameFramework.Models.Creatures.Observer;
using Mandatory2DGameFramework.worlds;


namespace Mandatory2DGameFramework.Models.Creatures
{
    public abstract class Creature : WorldObject, ICreature
    {
        private readonly HitNotifier _notifier;

        public string Name { get; set; }
        public int HitPoint { get; set; }


        // allow multiple defence items but only one attack item
        public IAttackItem? Weapon { get; set; }
        public List<IDefenceItem> Defence { get; set; }

        public ILootStrategy? LootStrategy { get; set; }

        public Creature(HitNotifier notifier)
        {
            Name = string.Empty;
            HitPoint = 100; 

            Defence = new List<IDefenceItem>();
            Weapon = new Unarmed(); // default weapon

            _notifier = notifier;
        }


        /// <summary>
        /// Take turn for the creature
        /// </summary> 
        /// <param name="opponent">deal damage to this creature</param>
        /// <param name="lootObj">loot this object</param>
        public void TakeTurn(Creature? opponent = null, WorldObject? lootObj = null)
        {
            int damage = Hit();
            if (opponent != null)
            {
                opponent.ReceiveHit(damage);
            }
            if (lootObj != null && lootObj.Lootable)
            {
                Loot(lootObj);
            }
        }

        protected abstract int Hit();

        protected virtual void ReceiveHit(int hit)
        {
            int totalDefence = Defence.Sum(d => d.GetReduceHitPoint());
            int totalDamage = Math.Max(0, hit - totalDefence);
            HitPoint -= totalDamage;
            if (HitPoint <= 0)
            {
                HitPoint = 0;
            }
            _notifier.Notify(totalDamage, HitPoint);
        }

        protected virtual void Loot(WorldObject obj)
        {
            LootStrategy?.Loot(this, obj);
        }
        
        
        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint.ToString()}, {nameof(Weapon)}={Weapon}, {nameof(Defence)}={Defence}}}";
        }

    }
}
