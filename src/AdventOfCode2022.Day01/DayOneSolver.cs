using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day01
{
    public class DayOneSolver : ISolver
    {
        public object PartOne(string input)
        {
            return Elf.Load(input).Max(x => x.TotalCalories);
        }

        public object PartTwo(string input)
        {
            return Elf.Load(input).OrderByDescending(x => x.TotalCalories)
                .Take(3)
                .Sum(x => x.TotalCalories);
        }
    }
}
