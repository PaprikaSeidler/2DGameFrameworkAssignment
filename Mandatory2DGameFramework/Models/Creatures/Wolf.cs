
namespace Mandatory2DGameFramework.Models.Cretures
{
    public class Wolf : Creature
    {
        public Wolf() : base()
        {
        }

        protected override int Hit()
        {
            int biteDamage = 5;
            return biteDamage;
        }
    }
}
