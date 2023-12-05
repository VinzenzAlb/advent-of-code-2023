
using System.Globalization;

namespace adventofcode2023
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            int solution = 0;

            foreach (string line in lines)
            {
                int winCount = 0;
                string input = line.Split(":")[1];
                List<int> win = getNumbers(input.Split("|")[0]);
                List<int> myNum = getNumbers(input.Split("|")[1]);
                foreach (int num in myNum)
                {
                    if (win.Contains(num)) winCount++;
                }
                int score = winCount == 0 ? 0 : (int)Math.Pow(2, (winCount - 1));
                solution += score;
            }

            return solution.ToString();
        }

        private List<int> getNumbers(string winningNumbers)
        {
            List<int> numbers = new();
            int currentNum = 0;
            for (int c = 0; c < winningNumbers.Length; c++)
            {
                if (char.IsNumber(winningNumbers[c]))
                {
                    currentNum = currentNum == 0 ? winningNumbers[c] : currentNum * 10 + winningNumbers[c];
                }
                else
                {
                    if (currentNum != 0)
                    {
                        numbers.Add(currentNum);
                        currentNum = 0;
                    }
                }
            }
            if (currentNum != 0)
            {
                numbers.Add(currentNum);
                currentNum = 0;
            }
            return numbers;
        }

        public string SolutionOfSecondPart(string[] lines)
        {
            int[] solution = initArray(lines.Length, 1);

            // Hier kommt die Logik für den zweiten Teil hin

            return solution.Sum;
        }

        private int[] initArray(int length, int value)
        {
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = value;
            }
            return result;
        }
    }
}
