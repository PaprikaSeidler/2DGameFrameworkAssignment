

namespace Mandatory2DGameFramework.Interfaces
{
    public interface IObserverable<T>
    {
        void AddObserver(T observer);
        void RemoveObserver(T observer);
    }
}
