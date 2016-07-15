﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Generators.Interface
{
    public interface IGenerator
    {
        IEnumerable<int> Generate();
    }
}