using AdventOfCode2023.DayTwo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.DayThree
{
    public class DayThree
    {
        public string FolderName { get; } = "DayThree";

        public List<string> Input { get; }

        public int rowLength { get; set; }

        public int columnLength { get; set; }

        public char[,] ParsedInput { get; set; }

        public DayThree()
        {
            Input = FileHelper.ReadInputs(FolderName)[1];
            ParsedInput = FurtherParsing();
        }

        public char[,] FurtherParsing()
        {
            rowLength = Input.Count();
            columnLength = Input[0].Length;

            char[,] inputAs2DArray = new char[rowLength, columnLength];

            for (var i = 0; i < rowLength; i++)
            {
                var row = Input[i];

                for (var j = 0; j < columnLength; j++)
                {
                    inputAs2DArray[i, j] = row[j];
                }
            }

            return inputAs2DArray;
        }

        public int GetPartOneResult()
        {
            //step 1: gather list of coordinates where symbols appear
            List<List<int>> symbolCoordinates = new List<List<int>>();

            for (var i = 0; i < rowLength; i++)
            {
                for (var j = 0; j < columnLength; j++)
                {
                    var character = ParsedInput[i, j];

                    if (!char.IsDigit(character) && character != '.')
                    {
                        symbolCoordinates.Add(new List<int> { i, j });
                    }
                }
            }

            //step 2: check indexes around coordinate for numbers
            List<List<int>> partNumbers = new List<List<int>>();

            foreach (var coordinate in symbolCoordinates)
            {
                for (var i = coordinate[0] - 1; i <= coordinate[0] + 1; i++)
                {
                    for (var j = coordinate[1] - 1; j <= coordinate[1] + 1; j++)
                    {

                    }
                }
            }

            //step 3: if number is there, add the number to a list

            //step 4: sum all of the numbers that touched a symbol

            //edge case?: will there be a number that is touching two symbols? in that case it may be counted twice.

            return 0;
        }
    }
}
