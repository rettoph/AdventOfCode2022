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
            using(StringReader reader = new StringReader(input))
            {
                return _solvers[day].PartOne(reader).ToString() ?? string.Empty;
            }
        }

        public static string SolvePartTwo(Day day, string input)
        {
            using (StringReader reader = new StringReader(input))
            {
                return _solvers[day].PartTwo(reader).ToString() ?? string.Empty;
            }
        }

        static Solver()
        {
            Solver.Register<DayOneSolver>(Day.One);
            Solver.Register<DayTwoSolver>(Day.Two);
            Solver.Register<DayThreeSolver>(Day.Three);
            Solver.Register<DayFourSolver>(Day.Four);
        }

        public static void Register<TSolver>(Day day)
            where TSolver : ISolver, new()
        {
            _solvers.Add(day, new TSolver());
        }
    }
}
