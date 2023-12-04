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
            var parsedInput = new ParsedInput();

            foreach (var game in Input)
            {
                var parsedGame = new Game { Id = int.Parse(Regex.Match(game, @"(\d+)").Value) };
                var parsedSets = game.Split(new char[] { ';', ':' }).Skip(1);


                foreach (var set in parsedSets)
                {
                    var parsedSet = new Set();

                    var matches = Regex.Matches(set, @"(\d+)\s+(\w+)");

                    int red = 0;
                    int green = 0;
                    int blue = 0;

                    foreach (Match setMatch in matches)
                    {
                        string count = setMatch.Groups[1].Value;
                        string color = setMatch.Groups[2].Value;

                        switch (color)
                        {
                            case "red":
                                red = int.Parse(count);
                                break;
                            case "green":
                                green = int.Parse(count);
                                break;
                            case "blue":
                                blue = int.Parse(count);
                                break;
                        }
                    }

                    parsedSet.RGBValues = new List<int> { red, green, blue };

                    parsedGame.Sets.Add(parsedSet);
                }

                parsedInput.Games.Add(parsedGame);
            }

            ParsedInput = parsedInput;
        }

        public int GetPartOneResult()
        {
            var counter = 0;

            var maxRed = 12;
            var maxGreen = 13;
            var maxBlue = 14;

            foreach (var game in ParsedInput.Games)
            {
                bool isGamePossible = true;

                foreach (var set in game.Sets)
                {
                    if (set.RGBValues[0] > maxRed || set.RGBValues[1] > maxGreen || set.RGBValues[2] > maxBlue)
                    {
                        isGamePossible = false;
                    }

                    if (!isGamePossible)
                    {
                        break;
                    }
                }

                if (isGamePossible)
                {
                    counter += game.Id;
                }
            }

            return counter;
        }

        public int GetPartTwoResult()
        {
            var counter = 0;

            foreach (var game in ParsedInput.Games)
            {
                var minRed = 0;
                var minGreen = 0;
                var minBlue = 0;

                foreach (var set in game.Sets)
                {
                    if (set.RGBValues[0] > minRed)
                    {
                        minRed = set.RGBValues[0];
                    }
                    if (set.RGBValues[1] > minGreen)
                    {
                        minGreen = set.RGBValues[1];
                    }
                    if (set.RGBValues[2] > minBlue)
                    {
                        minBlue = set.RGBValues[2];
                    }
                }

                var power = minRed * minGreen * minBlue;

                counter += power;
            }

            return counter;
        }

        public void BetterFurtherParsing()
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

        public int BetterGetPartOneResult()
        {
            return ParsedInput.Games
                .Where(game => game.Sets.All(set => set.RGBValues[0] <= 12 && set.RGBValues[1] <= 13 && set.RGBValues[2] <= 14))
                .Sum(game => game.Id);
        }

        public int BetterGetPartTwoResult()
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