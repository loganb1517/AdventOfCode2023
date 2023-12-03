namespace AdventOfCode2023
{
    public class FileHelper
    {
        private static readonly string BasePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", ".."));

        public static List<List<string>> ReadInputs(string folderName)
        {
            List<List<string>> listOfInputs = new List<List<string>>();

            string[] fileNames = { "Input.txt", "TestOne.txt", "TestTwo.txt" };

            foreach (string fileName in fileNames)
            {
                listOfInputs.Add(File.ReadAllText(Path.Combine(BasePath, folderName, fileName))
                    .Split(Environment.NewLine)
                    .ToList());
            }

            return listOfInputs;
        }
    }
}