using AdventOfCode2022.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Common.Entities
{
    public sealed class RockPaperScissorsGame
    {
        private readonly IList<RockPaperScissorsMatch> _matches;
        public IEnumerable<RockPaperScissorsMatch> Matchs => _matches;

        public RockPaperScissorsGame()
        {
            _matches = new List<RockPaperScissorsMatch>();
        }

        public int GetTotalScore(RpsPlayer player)
        {
            return this.Matchs.Select(x => x.Points[player]).Sum();
        }

        public void AddMatch(RpsMove elf, RpsMove user)
        {
            var match = new RockPaperScissorsMatch(elf, user);
            _matches.Add(match);
        }
    }
}
