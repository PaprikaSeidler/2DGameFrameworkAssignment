
namespace Mandatory2DGameFramework.Models.Cretures
{
    public class Warrior : Creature
    {
        public Warrior() : base()
        {
        }

        protected override int Hit()
        {
            return Weapon.DealDamage();
        }
    }
}
