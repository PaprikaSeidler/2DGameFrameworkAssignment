using Mandatory2DGameFramework.Interfaces;

namespace Mandatory2DGameFramework.Models.Attack
{
    public class Unarmed : IAttackItem
    {
        public string Name => "Unarmed";
        public int Hit => 1;
        public int Range => 1;
        public int DealDamage() => Hit;
    }
}
