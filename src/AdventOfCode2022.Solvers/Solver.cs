using AdventOfCode2022.Common.Enums;
using AdventOfCode2022.Common.Interfaces;
using System.Diagnostics;

namespace AdventOfCode2022.Solvers
{
    public class Solver
    {
        private static Dictionary<Day, ISolver> _solvers = new();

        public static string Solve(Day day, Part part, string input)
        {
            switch (part)
            {
                case Part.One:
                    return Solver.SolvePartOne(day, input);
                case Part.Two:
                    return Solver.SolvePartTwo(day, input);
                default:
                    throw new UnreachableException();
            }
        }

        public static string SolvePartOne(Day day, string input)
        {
            return _solvers[day].PartOne(SplitToLines(input)).ToString() ?? string.Empty;
        }

        public static string SolvePartTwo(Day day, string input)
        {
            return _solvers[day].PartTwo(SplitToLines(input)).ToString() ?? string.Empty;
        }

        static Solver()
        {
            Solver.Register<DayOneSolver>(Day.One);
            Solver.Register<DayTwoSolver>(Day.Two);
        }

        public static void Register<TSolver>(Day day)
            where TSolver : ISolver, new()
        {
            _solvers.Add(day, new TSolver());
        }

        public static IEnumerable<string> SplitToLines(string input)
        {
            if (input == null)
            {
                yield break;
            }

            using (System.IO.StringReader reader = new System.IO.StringReader(input))
            {
                string? line;
                while ((line = reader.ReadLine()) is not null)
                {
                    yield return line;
                }
            }
        }
    }
}
