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
        public object PartOne(IEnumerable<string> input)
        {
            return LoadFood(input).Max(x => x.Food.TotalCalories);
        }

        public object PartTwo(IEnumerable<string> input)
        {
            return LoadFood(input).OrderByDescending(x => x.Food.TotalCalories)
                .Take(3)
                .Sum(x => x.Food.TotalCalories);
        }

        public static IList<Elf> LoadFood(IEnumerable<string> input)
        {
            List<Elf> elves = new();
            List<int> foodCaloriesValues = new();

            foreach (string line in input)
            {
                if (line == string.Empty)
                { // New elf delim, add elf
                    CreateElf(elves, foodCaloriesValues);

                    continue;
                }

                if (int.TryParse(line, out int foodCaloriesValue))
                {
                    foodCaloriesValues.Add(foodCaloriesValue);
                }
            }

            if (foodCaloriesValues.Any())
            { // There was a final elf at EOF
                CreateElf(elves, foodCaloriesValues);
            }

            return elves;
        }

        private static void CreateElf(IList<Elf> elves, IList<int> calories)
        {
            var elf = new Elf();
            elf.Food.Load(calories);
            calories.Clear();

            elves.Add(elf);
        }
    }
}
