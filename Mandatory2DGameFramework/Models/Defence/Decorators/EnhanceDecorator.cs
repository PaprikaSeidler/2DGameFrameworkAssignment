using Mandatory2DGameFramework.Interfaces;

namespace Mandatory2DGameFramework.Models.Defence.Decorators
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
