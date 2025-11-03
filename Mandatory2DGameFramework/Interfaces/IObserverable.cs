using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Interfaces
{
    public interface IObserverable<T>
    {
        void AddObserver(T observer);
        void RemoveObserver(T observer);
    }
}
