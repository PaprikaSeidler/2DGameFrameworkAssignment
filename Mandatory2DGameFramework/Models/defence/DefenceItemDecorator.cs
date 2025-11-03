using Mandatory2DGameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.defence
{
    public abstract class DefenceItemDecorator : IDefenceItem
    {
        protected readonly IDefenceItem _defenceItem;
        protected DefenceItemDecorator(IDefenceItem defenceItem)
        {
            _defenceItem = defenceItem;
        }

        public virtual int GetReduceHitPoint()
        {
            return _defenceItem.GetReduceHitPoint();
        }
    }
}
