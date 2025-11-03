using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.Logger;
using Mandatory2DGameFramework.Models.attack;
using Mandatory2DGameFramework.Models.Cretures.States;
using Mandatory2DGameFramework.worlds;



namespace Mandatory2DGameFramework.model.Cretures
{
    public abstract class Creature : IObserverable<IHitObserver>
    {
        private readonly List<IHitObserver> _hitObservers = new();

        public string Name { get; set; }
        public int HitPoint { get; set; }


        // allow multiple defence items but only one attack item
        public IAttackItem? Weapon { get; set; }
        public List<IDefenceItem> Defence { get; set; }

        public ILootStrategy? LootStrategy { get; set; }
        public ICreatureState CurrentState { get; set; }

        public Creature(String name)
        {
            Name = name;
            HitPoint = 100; 

            Defence = new List<IDefenceItem>();
            Weapon = new Unarmed(); // default weapon
            CurrentState = new AliveState();
        }

        public void TakeTurn(Creature? opponent = null, WorldObject? lootObj = null)
        {
            CurrentState.TakeTurn(this, opponent, lootObj);
        }

        public abstract int Hit(); 

        public virtual void ReceiveHit(int hit)
        {
            CurrentState.ReceiveHit(this, hit);
        }

        public virtual void Loot(WorldObject obj)
        {
            CurrentState.Loot(this, obj);
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint.ToString()}, {nameof(Weapon)}={Weapon}, {nameof(Defence)}={Defence}}}";
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

    }
}
