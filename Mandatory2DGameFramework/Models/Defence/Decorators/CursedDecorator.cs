using Mandatory2DGameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Models.Defence.Decorators
{
    public class CursedDecorator : DefenceItemDecorator
    {
        public CursedDecorator(IDefenceItem defenceItem) : base(defenceItem)
        {
        }
        public override int GetReduceHitPoint()
        {
            return Math.Max(0, base.GetReduceHitPoint() - 5);
        }
    }
}