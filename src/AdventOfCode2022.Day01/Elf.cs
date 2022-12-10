using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day01
{
    public class Elf
    {
        public IList<Food> Foods { get; }

        public int TotalCalories => this.Foods.Sum(x => x.Calories);

        public Elf(IEnumerable<int> foodCaloriesValues)
        {
            this.Foods = new List<Food>();

            foreach(int foodCaloriesValue in foodCaloriesValues)
            {
                this.Foods.Add(new Food()
                {
                    Calories = foodCaloriesValue
                });
            }
        }

        public static IList<Elf> Load(string input)
        {
            List<Elf> elves = new();
            List<int> foodCaloriesValues = new();

            foreach (string line in input.Split(Environment.NewLine))
            {
                if (line == string.Empty)
                { // New elf delim, add elf
                    elves.Add(new Elf(foodCaloriesValues));
                    foodCaloriesValues.Clear();

                    continue;
                }

                if (int.TryParse(line, out int foodCaloriesValue))
                {
                    foodCaloriesValues.Add(foodCaloriesValue);
                }
            }

            if (foodCaloriesValues.Any())
            {
                elves.Add(new Elf(foodCaloriesValues));
                foodCaloriesValues.Clear();
            }

            return elves;
        }
    }
}
