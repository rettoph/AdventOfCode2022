using AdventOfCode2022.Common.Entities;
using AdventOfCode2022.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers
{
    internal sealed class DayThreeSolver : ISolver
    {
        public object PartOne(StringReader input)
        {
            return LoadRucksacks(input)
                .Select(x => x.Rucksack.Intersects())
                .SelectMany(x => x)
                .Sum(x => x.Priority);
        }

        public object PartTwo(StringReader input)
        {
            var elves = LoadRucksacks(input).ToArray();
            List<Rucksack.Item> items = new List<Rucksack.Item>();

            for(int i=0; i<elves.Length; i+=3)
            {
                var group = elves[i].Rucksack.Intersects(elves[i + 1], elves[i + 2]);

                if(group.Count() == 0)
                {
                    throw new Exception();
                }

                items.AddRange(group);
            }

            return items.Sum(x => x.Priority);
        }

        private static IEnumerable<Elf> LoadRucksacks(StringReader input)
        {
            string? line;

            while((line = input.ReadLine()) is not null)
            {
                Elf elf = new();
                elf.Rucksack.Add(line);

                yield return elf;
            }
        }
    }
}
