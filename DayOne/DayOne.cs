namespace AdventOfCode2023.DayOne
{
    public class DayOne
    {
        private readonly string folderName = "DayOne";

        List<string> input;

        public DayOne()
        {
            input = FileHelper.ReadInputs(folderName)[0];
        }

        public int GetPartOneResult()
        {
            var counter = 0;

            foreach (var calibrationLine in input)
            {
                var firstNumber = calibrationLine.First(char.IsDigit);
                var lastNumber = calibrationLine.Last(char.IsDigit);

                var calibrationValue = firstNumber.ToString() + lastNumber.ToString();

                counter += int.Parse(calibrationValue);
            }

            return counter;
        }

        public int GetPartTwoResult()
        {
            var counter = 0;

            foreach (var calibrationLine in input)
            {
                var convertedLine = calibrationLine
                    .Replace("one", "o1e")
                    .Replace("two", "t2o")
                    .Replace("three", "thr3e")
                    .Replace("four", "fo4r")
                    .Replace("five", "f5ve")
                    .Replace("six", "s6x")
                    .Replace("seven", "sev7n")
                    .Replace("eight", "ei8ht")
                    .Replace("nine", "n9ne");

                var firstNumber = convertedLine.First(char.IsDigit);
                var lastNumber = convertedLine.Last(char.IsDigit);

                var calibrationValue = firstNumber.ToString() + lastNumber.ToString();

                counter += int.Parse(calibrationValue);
            }

            return counter;
        }
    }
}