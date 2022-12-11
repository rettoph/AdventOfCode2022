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

        public string Name { get; }

        public Elf()
        {
            this.Name = Guid.NewGuid().ToString();

            this.Food = new FoodInventory();
        }
    }
}
