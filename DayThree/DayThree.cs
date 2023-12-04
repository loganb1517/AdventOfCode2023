using AdventOfCode2023.DayTwo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.DayThree
{
    public class DayThree
    {
        public string FolderName { get; } = "DayThree";

        public List<string> Input { get; }

        public int rowLength { get; set; }

        public int columnLength { get; set; }

        public char[,]? ParsedInput { get; set; }

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
            var test = Input;
            var test2 = ParsedInput;

            return 0;
        }
    }
}
