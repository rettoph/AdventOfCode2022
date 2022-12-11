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

        public object PartOne(StringReader input)
        {
            return LoadGame(input, PartOneMoveSelector).GetTotalScore(RpsPlayer.User);
        }

        public object PartTwo(StringReader input)
        {
            return LoadGame(input, PartTwoMoveSelector).GetTotalScore(RpsPlayer.User);
        }

        private static RockPaperScissorsGame LoadGame(StringReader input, Func<RpsMove, char, RpsMove> userMoveSelector)
        {
            RockPaperScissorsGame game = new();

            string? line;
            while((line = input.ReadLine()) is not null)
            {
                RpsMove elfMove = ElfMap[line[0]];
                RpsMove userMove = userMoveSelector(elfMove, line[2]);

                game.AddMatch(elfMove, userMove);
            }

            return game;
        }

        private RpsMove PartOneMoveSelector(RpsMove elf, char input)
        {
            return PartOneUserMap[input];
        }

        private RpsMove PartTwoMoveSelector(RpsMove elf, char input)
        {
            return PartTwoUserMap[input] switch
            {
                RpsResult.Win => RockPaperScissorsMatch.WinningHands[elf],
                RpsResult.Lose => RockPaperScissorsMatch.WinningHands[RockPaperScissorsMatch.WinningHands[elf]],
                RpsResult.Draw => elf,
                _ => throw new UnreachableException()
            };
        }
    }
}