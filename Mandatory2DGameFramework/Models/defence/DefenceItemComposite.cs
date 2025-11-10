using Mandatory2DGameFramework.Interfaces;

namespace Mandatory2DGameFramework.Models.defence
{
    public class DefenceItemComposite : IDefenceItem
    {
        

        private List<IDefenceItem> _defenceItems = new List<IDefenceItem>();

        public void AddDefenceItem(IDefenceItem defenceItem)
        {
            _defenceItems.Add(defenceItem);
        }

        public void RemoveDefenceItem(IDefenceItem defenceItem)
        {
            _defenceItems.Remove(defenceItem);
        }
        public int GetReduceHitPoint()
        {
            return _defenceItems.Sum(item => item.GetReduceHitPoint());
        }

    }
}
