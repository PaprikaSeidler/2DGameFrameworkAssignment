using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Models.Creatures.Observer
{
    public class HitNotifier : IObserverable<IHitObserver>
    {
        private readonly List<IHitObserver> _observers = new List<IHitObserver>();

        public void AddObserver(IHitObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IHitObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public void Notify(int damage, int currentHP)
        {
            try
            {
                foreach (var observer in _observers)
                {
                    observer.OnHit(damage, currentHP);
                }
            }
            catch (Exception ex)
            {
                MyLogger.Instance.LogError("Error notifying hit observers: " + ex.Message);
            }
        }
    }
}
