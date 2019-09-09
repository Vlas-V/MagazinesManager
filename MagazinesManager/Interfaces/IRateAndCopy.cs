using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagazinesManager
{
    public interface IRateAndCopy
    {
        double Rating { get;}
        object DeepCopy();
    }
}