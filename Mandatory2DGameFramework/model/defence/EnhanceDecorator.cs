using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.defence
{
    public class EnhanceDecorator : DefenceItemDecorator
    {
        public EnhanceDecorator(IDefenceItem defenceItem) : base(defenceItem)
        {
        }

        public override int GetReduceHitPoint()
        {
            return base.GetReduceHitPoint() + 5;
        }
    }
}
