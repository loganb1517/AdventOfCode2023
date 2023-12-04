using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.DayTwo
{
    public class ParsedInput
    {
        public List<Game> Games { get; set; } = new List<Game>();
    }

    public class Game
    {
        public int Id { get; set; }

        public List<Set> Sets { get; set; } = new List<Set>();
    }

    public class Set
    {
        public List<int> RGBValues { get; set; } = new List<int>();
    }

    public class DayTwo
    {
        public string FolderName { get; } = "DayTwo";

        public List<string> Input { get; }

        public ParsedInput ParsedInput { get; set; } = new ParsedInput();

        public DayTwo()
        {
            Input = FileHelper.ReadInputs(FolderName)[0];
            FurtherParsing();
        }

        private void FurtherParsing()
        {
            ParsedInput = new ParsedInput
            {
                Games = Input.Select(game =>
                {
                    var parsedGame = new Game { Id = int.Parse(Regex.Match(game, @"(\d+)").Value) };

                    parsedGame.Sets.AddRange(game.Split(new[] { ';', ':' }).Skip(1)
                        .Select(set =>
                        {
                            var matches = Regex.Matches(set, @"(\d+)\s+(\w+)");
                            var (red, green, blue) = matches.Cast<Match>()
                                .Aggregate((0, 0, 0), (acc, setMatch) =>
                                {
                                    var count = int.Parse(setMatch.Groups[1].Value);
                                    var color = setMatch.Groups[2].Value;

                                    return color switch
                                    {
                                        "red" => (count, acc.Item2, acc.Item3),
                                        "green" => (acc.Item1, count, acc.Item3),
                                        "blue" => (acc.Item1, acc.Item2, count),
                                        _ => acc
                                    };
                                });

                            return new Set { RGBValues = new List<int> { red, green, blue } };
                        }));

                    return parsedGame;
                }).ToList()
            };
        }

        public int GetPartOneResult()
        {
            return ParsedInput.Games
                .Where(game => game.Sets.All(set => set.RGBValues[0] <= 12 && set.RGBValues[1] <= 13 && set.RGBValues[2] <= 14))
                .Sum(game => game.Id);
        }

        public int GetPartTwoResult()
        {
            return ParsedInput.Games
                .Select(game => game.Sets.Aggregate((R: 0, G: 0, B: 0), (acc, set) =>
                {
                    int maxRed = Math.Max(acc.R, set.RGBValues[0]);
                    int maxGreen = Math.Max(acc.G, set.RGBValues[1]);
                    int maxBlue = Math.Max(acc.B, set.RGBValues[2]);

                    return (maxRed, maxGreen, maxBlue);
                }))
                .Sum(result => result.R * result.G * result.B);
        }
    }
}