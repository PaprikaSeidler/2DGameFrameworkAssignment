using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Interfaces
{
    public interface ICreature
    {
        string Name { get; }
        int HitPoint { get; }
        IAttackItem? Weapon { get; set; }
        List<IDefenceItem> Defence { get; }  
        ILootStrategy? LootStrategy { get; set; }
    }
}
