using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.Logger;
using Mandatory2DGameFramework.Models.Attack;
using Mandatory2DGameFramework.worlds;


namespace Mandatory2DGameFramework.Models.Cretures
{
    public abstract class Creature : ICreature, IObserverable<IHitObserver>
    {
        private readonly List<IHitObserver> _hitObservers = new();

        public string Name { get; set; }
        public int HitPoint { get; set; }


        // allow multiple defence items but only one attack item
        public IAttackItem? Weapon { get; set; }
        public List<IDefenceItem> Defence { get; set; }

        public ILootStrategy? LootStrategy { get; set; }

        public Creature()
        {
            Name = string.Empty;
            HitPoint = 100; 

            Defence = new List<IDefenceItem>();
            Weapon = new Unarmed(); // default weapon
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
            NotifyHitObservers(totalDamage);
        }

        protected virtual void Loot(WorldObject obj)
        {
            LootStrategy?.Loot(this, obj);
        }



        public void AddObserver(IHitObserver observer) => _hitObservers.Add(observer);
        public void RemoveObserver(IHitObserver observer) => _hitObservers.Remove(observer);
        public void NotifyHitObservers(int damage)
        {
            try
            {
                foreach (var observer in _hitObservers)
                {
                    observer.OnHit(damage, this.HitPoint);
                }
            }
            catch (Exception ex)
            {
                MyLogger.Instance.LogError("Error notifying hit observers: " + ex.Message);
            }

        }
        
        
        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint.ToString()}, {nameof(Weapon)}={Weapon}, {nameof(Defence)}={Defence}}}";
        }

    }
}
