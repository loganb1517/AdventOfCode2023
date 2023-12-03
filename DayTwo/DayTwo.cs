using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.DayTwo
{
    public class DayTwo
    {
        private readonly string folderName = "DayTwo";

        public List<string> input;

        public DayTwo()
        {
            input = FileHelper.ReadInputs(folderName)[1];
        }
    }
}
