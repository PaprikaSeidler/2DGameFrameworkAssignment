using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Interfaces
{
    public interface IWorld
    {
        int MaxX { get; }
        int MaxY { get; }
        string Difficulty { get; }
    }
}
