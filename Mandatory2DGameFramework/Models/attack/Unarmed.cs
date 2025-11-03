using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandatory2DGameFramework.Interfaces;

namespace Mandatory2DGameFramework.Models.attack
{
    public class Unarmed : IAttackItem
    {
        public string Name => "Unarmed";
        public int Hit => 1;
        public int Range => 1;
        public int DealDamage() => Hit;
    }
}
