using AdventOfCode.Common;
using System.CommandLine;

var dayOption = new Option<Day>(
    name: "--day",
    description: "Which day you wish to solve")
{
    IsRequired = true
};

var partOption = new Option<Part>(
    name: "--part",
    description: "Which part you wish to solve")
{
    IsRequired = true
};

var inputOption = new Option<FileInfo>(
    name: "--input",
    description: "Path to the file input.")
{
    IsRequired = true
};

var root = new RootCommand();
root.AddOption(dayOption);
root.AddOption(partOption);
root.AddOption(inputOption);

root.SetHandler(Solve, dayOption, partOption, inputOption);

root.Invoke(args);

Task Solve(Day day, Part part, FileInfo input)
{
    string solution = Solver.Solve(
        day: day, 
        part: part, 
        input: File.ReadAllText(input.FullName));

    Console.WriteLine($"Day {day} - Part {part} Solution: \"{solution}\"");

    return Task.CompletedTask;
}