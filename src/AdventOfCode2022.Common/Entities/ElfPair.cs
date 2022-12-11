using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Common.Entities
{
    public class ElfPair
    {
        public Elf First { get; }
        public Elf Second { get; }

        public ElfPair()
        {
            this.First = new Elf();
            this.Second = new Elf();
        }

        public bool SelfContainedClearAssigments()
        {
            bool result = this.First.ClearAssigment.Contains(this.Second.ClearAssigment);
            result |= this.Second.ClearAssigment.Contains(this.First.ClearAssigment);

            return result;
        }

        public bool OverlappingClearAssigments()
        {
            bool result = this.First.ClearAssigment.Overlaps(this.Second.ClearAssigment);
            result |= this.Second.ClearAssigment.Overlaps(this.First.ClearAssigment);

            return result;
        }
    }
}
