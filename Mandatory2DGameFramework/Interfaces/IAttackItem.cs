

namespace Mandatory2DGameFramework.Interfaces
{
    public interface IAttackItem
    {
        string Name { get; }
        int Hit { get; }
        int Range { get; }

        int DealDamage();
    }
}
