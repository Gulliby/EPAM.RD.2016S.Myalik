using System;
using System.Collections.Generic;

namespace Generator.Generators.Interface
{
    public interface IGenerator : IEnumerator<int>, ICloneable
    {
        int Prev { get;  }

    }
}
