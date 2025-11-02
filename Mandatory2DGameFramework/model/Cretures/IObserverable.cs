using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    public interface IObservable<T>
    {
        void AddObserver(T observer);
        void RemoveObserver(T observer);
    }
}
