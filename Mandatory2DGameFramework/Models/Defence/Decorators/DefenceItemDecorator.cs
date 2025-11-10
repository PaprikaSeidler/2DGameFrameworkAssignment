using Mandatory2DGameFramework.Interfaces;

namespace Mandatory2DGameFramework.Models.Defence.Decorators
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
