using AdventOfCode2022.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Common.Entities
{
    public class RockPaperScissorsMatch
    {
        private const int VictoryPoints = 6;

        public static readonly IDictionary<RpsMove, RpsMove> WinningHands = new Dictionary<RpsMove, RpsMove>()
        {
            [RpsMove.Scissors] = RpsMove.Rock,
            [RpsMove.Rock] = RpsMove.Paper,
            [RpsMove.Paper] = RpsMove.Scissors,
        };

        public IReadOnlyDictionary<RpsPlayer, RpsMove> Moves { get; }
        public IReadOnlyDictionary<RpsPlayer, int> Points { get; }
        public RpsPlayer Winner { get; }

        public RockPaperScissorsMatch(RpsMove elfMove, RpsMove userMove)
        {
            this.Moves = new Dictionary<RpsPlayer, RpsMove>()
            {
                [RpsPlayer.Elf] = elfMove,
                [RpsPlayer.User] = userMove,
            };

            this.Winner = this.CalculateWinner();

            this.Points = new Dictionary<RpsPlayer, int>()
            {
                [RpsPlayer.Elf] = this.CalculatePoints(RpsPlayer.Elf),
                [RpsPlayer.User] = this.CalculatePoints(RpsPlayer.User),
            };
        }

        private int CalculatePoints(RpsPlayer player)
        {
            int points = (int)this.Moves[player];

            if(player == this.Winner)
            {
                points += VictoryPoints;
            }

            if(this.Winner == RpsPlayer.None)
            {
                points += VictoryPoints / 2;
            }

            return points;
        }

        private RpsPlayer CalculateWinner()
        {
            if (WinningHands[this.Moves[RpsPlayer.User]] == this.Moves[RpsPlayer.Elf])
            {
                return RpsPlayer.Elf;
            }

            if (WinningHands[this.Moves[RpsPlayer.Elf]] == this.Moves[RpsPlayer.User])
            {
                return RpsPlayer.User;
            }

            return RpsPlayer.None;
        }
    }
}
