using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Common.Interfaces
{
    public interface ISolver
    {
        public object PartOne(IEnumerable<string> input);
        public object PartTwo(IEnumerable<string> input);
    }
}
