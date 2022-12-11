using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Common.Entities
{
    public class Elf
    {
        public FoodInventory Food { get; }
        public Rucksack Rucksack { get; }
        public ClearAssignment ClearAssigment { get; }

        public string Name { get; }

        public Elf()
        {
            this.Name = Guid.NewGuid().ToString();

            this.Food = new FoodInventory();
            this.Rucksack = new Rucksack();
            this.ClearAssigment= new ClearAssignment();
        }
    }
}
