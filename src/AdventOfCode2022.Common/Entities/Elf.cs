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

        public Elf()
        {
            this.Food = new FoodInventory();
        }
    }
}
