using AdventOfCode2022.Common;
using AdventOfCode2022.Common.Interfaces;
using AdventOfCode2022.Common.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers
{
    internal sealed class DayOneSolver : ISolver
    {
        public object PartOne(StringReader input)
        {
            return LoadFood(input).Max(x => x.Food.TotalCalories);
        }

        public object PartTwo(StringReader input)
        {
            return LoadFood(input).OrderByDescending(x => x.Food.TotalCalories)
                .Take(3)
                .Sum(x => x.Food.TotalCalories);
        }

        public static IList<Elf> LoadFood(StringReader input)
        {
            List<Elf> elves = new();

            while(input.Peek() != -1)
            {
                Elf elf = new();
                elf.Food.Read(input);
                elves.Add(elf);
            }

            return elves;
        }
    }
}
