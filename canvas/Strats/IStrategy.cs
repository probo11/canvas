﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    interface IStrategy
    {
        void Execute(Figure f, bool ean);
    }
}
