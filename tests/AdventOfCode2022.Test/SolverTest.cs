using AdventOfCode.Common;

namespace AdventOfCode2022.Test
{
    [TestClass]
    public class SolverTest
    {
        [DataTestMethod()]
        [DataRow(Day.One, Part.One, "input/input_day01.txt", "68467")]
        [DataRow(Day.One, Part.Two, "input/input_day01.txt", "203420")]
        public void TestSolver(Day day, Part part, string input, string solution)
        {
            string result = Solver.Solve(day, part, File.ReadAllText(input));

            Assert.AreEqual(result, solution);
        }
    }
}