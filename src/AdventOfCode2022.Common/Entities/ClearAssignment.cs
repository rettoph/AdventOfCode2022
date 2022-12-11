using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Common.Entities
{
    public class ClearAssignment
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public void SetRange(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }

        public bool Contains(ClearAssignment assignment)
        {
            return this.Min <= assignment.Min && this.Max >= assignment.Max;
        }

        public bool Overlaps(ClearAssignment assignment)
        {
            bool result = this.Min <= assignment.Min && this.Max >= assignment.Min;
            result |= this.Min <= assignment.Max && this.Max >= assignment.Max;

            return result;
        }
    }
}
