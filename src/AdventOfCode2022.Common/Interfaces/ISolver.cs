using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Common.Interfaces
{
    public interface ISolver
    {
        public object PartOne(StringReader input);
        public object PartTwo(StringReader input);
    }
}
