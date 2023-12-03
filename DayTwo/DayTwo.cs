using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.DayTwo
{
    public class ParsedInput
    {
        public List<Game> Games { get; set; } = new List<Game>();
    }

    public class Game
    {
        public List<Set> Sets { get; set; } = new List<Set>();
    }

    public class Set
    {
        public List<int> RGBValues { get; set; } = new List<int>();
    }

    public class DayTwo
    {
        private readonly string folderName = "DayTwo";

        public List<string> input = new List<string>();

        public ParsedInput parsedInput = new ParsedInput();

        public DayTwo()
        {
            input = FileHelper.ReadInputs(folderName)[1];

            FurtherParsing();
        }

        private void FurtherParsing()
        {
            var parsedInput = new ParsedInput();

            foreach (var game in input)
            {
                var sets = game.Split(";").ToList();

                var parsedGame = new Game();

                foreach (var set in sets)
                {
                    var parsedSet = new Set();

                    //TODO: we are not counting for if it is a two or three digit number
                    if (set.Contains("red")) 
                    {
                        parsedSet.RGBValues.Add(int.Parse(set[set.IndexOf("red") - 2].ToString()));
                    }
                    else
                    {
                        parsedSet.RGBValues.Add(0);
                    }
                    if (set.Contains("green"))
                    {
                        parsedSet.RGBValues.Add(int.Parse(set[set.IndexOf("green") - 2].ToString()));
                    }
                    else
                    {
                        parsedSet.RGBValues.Add(0);
                    }
                    if (set.Contains("blue"))
                    {
                        parsedSet.RGBValues.Add(int.Parse(set[set.IndexOf("blue") - 2].ToString()));
                    }
                    else
                    {
                        parsedSet.RGBValues.Add(0);
                    }

                    parsedGame.Sets.Add(parsedSet);
                }

                parsedInput.Games.Add(parsedGame);
            }

            this.parsedInput = parsedInput;
        }

        public int GetPartOneResult()
        {
            var counter = 0;

            var maxRed = 12;
            var maxGreen = 13;
            var maxBlue = 14;

            //look at each set, determine if red, green, or blue is higher than the max
            foreach (var game in parsedInput.Games)
            {
                foreach (var set in game.Sets)
                {
                    //if any of the values are higher than the max, counter += index of game + 1
                    foreach (var color in set.RGBValues)
                    {
                        if (color > maxRed || color > maxGreen || color > maxBlue) 
                        {
                            counter += parsedInput.Games.IndexOf(game) + 1;
                        }
                    }
                }
            }

            return counter;
        }
    }
}