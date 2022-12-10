using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Common
{
    public interface ISolver
    {
        public object PartOne(string input);
        public object PartTwo(string input);
    }
}
