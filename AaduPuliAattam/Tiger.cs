﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal interface Tiger
    {
        int Treshold { get; set; }
        int CapturedCount { get; set; }
        List<int> OccupiedIndicesT { get; set; }
    }
}
