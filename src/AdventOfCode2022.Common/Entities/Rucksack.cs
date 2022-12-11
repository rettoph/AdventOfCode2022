using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Common.Entities
{
    public class Rucksack
    {
        public record Item
        {
            private static readonly IList<char> PrioritizedChars = "_abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();

            public required char Character { get; init; }
            public required int Priority { get; init; }

            public static Item Create(char character)
            {
                return new Item()
                {
                    Character = character,
                    Priority = PrioritizedChars.IndexOf(character)
                };
            }
        }

        private readonly List<Item> Items;
        private readonly List<Item>[] Compartments;

        public Rucksack()
        {
            this.Items = new List<Item>();

            this.Compartments = new[]
            {
                new List<Item>(),
                new List<Item>()
            };
        }

        public void Add(Item item)
        {
            this.Items.Add(item);

            this.Compartments[0].Clear();
            this.Compartments[1].Clear();

            int compartmentSize = this.Items.Count / 2;

            this.Compartments[0].AddRange(this.Items.Take(compartmentSize));
            this.Compartments[1].AddRange(this.Items.Skip(compartmentSize));
        }

        public void Add(char item)
        {
            this.Add(Item.Create(item));
        }

        public void Add(string items)
        {
            foreach(char item in items)
            {
                this.Add(item);
            }
        }

        public IEnumerable<Item> Intersects()
        {
            return this.Compartments[0].IntersectBy(
                second: Compartments[1].Select(x => x.Character), 
                keySelector: x => x.Character);
        }

        public IEnumerable<Item> Intersects(params Elf[] elves)
        {
            IEnumerable<Item> output = this.Items;

            foreach(Elf elf in elves)
            {
                output = output.IntersectBy(
                    second: elf.Rucksack.Items.Select(x => x.Character),
                    keySelector: x => x.Character);
            }

            return output;
        }
    }
}
