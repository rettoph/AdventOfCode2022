using AdventOfCode2022.Common;
using AdventOfCode2022.Common.Entities;
using AdventOfCode2022.Common.Enums;
using AdventOfCode2022.Common.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace AdventOfCode2022.Solvers
{
    internal class DayTwoSolver : ISolver
    {
        private enum RpsResult
        {
            Win,
            Lose,
            Draw
        }

        private static readonly IReadOnlyDictionary<char, RpsMove> ElfMap = new Dictionary<char, RpsMove>()
        {
            ['A'] = RpsMove.Rock,
            ['B'] = RpsMove.Paper,
            ['C'] = RpsMove.Scissors
        };

        private static readonly IReadOnlyDictionary<char, RpsMove> PartOneUserMap = new Dictionary<char, RpsMove>()
        {
            ['X'] = RpsMove.Rock,
            ['Y'] = RpsMove.Paper,
            ['Z'] = RpsMove.Scissors
        };

        private static readonly IReadOnlyDictionary<char, RpsResult> PartTwoUserMap = new Dictionary<char, RpsResult>()
        {
            ['X'] = RpsResult.Lose,
            ['Y'] = RpsResult.Draw,
            ['Z'] = RpsResult.Win
        };

        public object PartOne(IEnumerable<string> input)
        {
            return LoadGamePartOne(input).GetTotalScore(RpsPlayer.User);
        }

        public object PartTwo(IEnumerable<string> input)
        {
            return LoadGamePartTwo(input).GetTotalScore(RpsPlayer.User);
        }

        private static RockPaperScissorsGame LoadGamePartOne(IEnumerable<string> input)
        {
            RockPaperScissorsGame game = new();

            foreach(string match in input)
            {
                if(match == string.Empty)
                {
                    continue;
                }

                game.AddMatch(
                    elf: ElfMap[match[0]],
                    user: PartOneUserMap[match[2]]);
            }

            return game;
        }

        private static RockPaperScissorsGame LoadGamePartTwo(IEnumerable<string> input)
        {
            RockPaperScissorsGame game = new();

            foreach (string match in input)
            {
                if (match == string.Empty)
                {
                    continue;
                }

                RpsMove elfMove = ElfMap[match[0]];
                RpsMove userMove = PartTwoUserMap[match[2]] switch
                {
                    RpsResult.Win => RockPaperScissorsMatch.WinningHands[elfMove],
                    RpsResult.Lose => RockPaperScissorsMatch.WinningHands[RockPaperScissorsMatch.WinningHands[elfMove]],
                    RpsResult.Draw => elfMove,
                    _ => throw new UnreachableException()
                };

                game.AddMatch(
                    elf: elfMove,
                    user: userMove);
            }

            return game;
        }
    }
}