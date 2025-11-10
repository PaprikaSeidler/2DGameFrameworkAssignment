using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
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
