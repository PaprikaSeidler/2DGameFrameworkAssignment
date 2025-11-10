using Mandatory2DGameFramework.Interfaces;

namespace Mandatory2DGameFramework.Models.Defence.Decorators
{
    public class CursedDecorator : DefenceItemDecorator
    {
        public CursedDecorator(IDefenceItem defenceItem) : base(defenceItem)
        {
        }

        public override int GetReduceHitPoint()
        {
            return 0;
        }
    }
}