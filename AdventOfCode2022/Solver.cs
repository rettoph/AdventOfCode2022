using AdventOfCode2022.Day01;
using System.Diagnostics;

namespace AdventOfCode.Common
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
            return _solvers[day].PartOne(input).ToString() ?? string.Empty;
        }

        public static string SolvePartTwo(Day day, string input)
        {
            return _solvers[day].PartTwo(input).ToString() ?? string.Empty;
        }

        static Solver()
        {
            Solver.Register<DayOneSolver>(Day.One);
        }

        public static void Register<TSolver>(Day day)
            where TSolver : ISolver, new()
        {
            _solvers.Add(day, new TSolver());
        }
    }
}
