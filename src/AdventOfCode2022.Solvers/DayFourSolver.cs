using AdventOfCode2022.Common.Entities;
using AdventOfCode2022.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers
{
    internal sealed class DayFourSolver : ISolver
    {
        public object PartOne(StringReader input)
        {
            return LoadPairs(input).Count(x => x.SelfContainedClearAssigments());
        }

        public object PartTwo(StringReader input)
        {
            return LoadPairs(input).Count(x => x.OverlappingClearAssigments());
        }

        private static IEnumerable<ElfPair> LoadPairs(StringReader input)
        {
            string? line;

            while((line = input.ReadLine()) is not null)
            {
                var pairData = line.Split(',')
                    .Select(x => x.Split('-'))
                    .SelectMany(x => x)
                    .Select(int.Parse)
                    .ToArray();

                var pair = new ElfPair();

                pair.First.ClearAssigment.SetRange(pairData[0], pairData[1]);
                pair.Second.ClearAssigment.SetRange(pairData[2], pairData[3]);

                yield return pair;
            }
        }
    }
}
