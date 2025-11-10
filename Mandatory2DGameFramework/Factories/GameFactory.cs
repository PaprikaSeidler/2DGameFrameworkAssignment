using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandatory2DGameFramework.Interfaces;
using Mandatory2DGameFramework.Logger;
using Mandatory2DGameFramework.model.Cretures;


namespace Mandatory2DGameFramework.Factories
{
    public class GameFactory<T> : IFactory<T>
    {
        private readonly Func<T> _creator;

        public GameFactory(Func<T> creator)
        {
            
            _creator = creator;
            
            if (_creator == null)
            { 
                MyLogger.Instance.LogError("Creator function is null!");
                throw new ArgumentNullException(nameof(creator), "Creator function cannot be null.");
            }
        }

        public T Create()
        {
            return _creator();
        }
    }
}
