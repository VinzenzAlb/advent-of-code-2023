
namespace adventofcode2023
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            List<(int, int)> symbols = new();
            Dictionary<(int, int), MyNumber> numbers = new(); ;

            // Hier kommt die Logik für den ersten Teil hin

            for (int lineNumber = 0; lineNumber < lines.Length; lineNumber++)
            {
                string currentNumber = "";
                for (int c = 0; c < lines[lineNumber].Length; c++)
                {
                    if (char.IsNumber(lines[lineNumber][c]))
                        currentNumber += lines[lineNumber][c];
                    else
                    {
                        if (currentNumber != "")
                        {
                            int val = int.Parse(currentNumber);
                            MyNumber curr = new(val, (lineNumber, c - 1));
                            numbers.Add((lineNumber, c - 1), curr);
                            if (val > 9) numbers.Add((lineNumber, c - 2), curr);
                            if (val > 99) numbers.Add((lineNumber, c - 3), curr);
                            currentNumber = "";
                        }
                        if (lines[lineNumber][c] != '.')
                            symbols.Add((lineNumber, c));
                    }
                }

            }

            List<MyNumber> validNumbers = new();
            foreach ((int, int) sym in symbols)
            {
                for (int x = -1; x <= 1; x++)
                    for (int y = -1; y <= 1; y++)
                    {
                        if (x == 0 && y == 0) continue;
                        if (numbers.ContainsKey((sym.Item1 + x, sym.Item2 + y)))
                            validNumbers.Add(numbers[(sym.Item1 + x, sym.Item2 + y)]);
                    }
            }

            validNumbers = validNumbers.Distinct().ToList();

            return MySum(validNumbers).ToString();
        }

        private int MySum(List<MyNumber> validNumbers)
        {
            int result = 0;
            foreach (MyNumber item in validNumbers)
            {
                result += item.value;
            }
            return result;
        }

        public string SolutionOfSecondPart(string[] lines)
        {
            List<(int, int)> symbols = new();
            Dictionary<(int, int), MyNumber> numbers = new(); ;

            // Hier kommt die Logik für den ersten Teil hin

            for (int lineNumber = 0; lineNumber < lines.Length; lineNumber++)
            {
                string currentNumber = "";
                for (int c = 0; c < lines[lineNumber].Length; c++)
                {
                    if (char.IsNumber(lines[lineNumber][c]))
                        currentNumber += lines[lineNumber][c];
                    else
                    {
                        if (currentNumber != "")
                        {
                            int val = int.Parse(currentNumber);
                            MyNumber curr = new(val, (lineNumber, c - 1));
                            numbers.Add((lineNumber, c - 1), curr);
                            if (val > 9) numbers.Add((lineNumber, c - 2), curr);
                            if (val > 99) numbers.Add((lineNumber, c - 3), curr);
                            currentNumber = "";
                        }
                        if (lines[lineNumber][c] == '*')
                            symbols.Add((lineNumber, c));
                    }
                }

            }
            int result = 0;
            foreach ((int, int) sym in symbols)
            {
                List<MyNumber> adjacentNumbers = new();
                for (int x = -1; x <= 1; x++)
                    for (int y = -1; y <= 1; y++)
                    {
                        if (x == 0 && y == 0) continue;
                        if (numbers.ContainsKey((sym.Item1 + x, sym.Item2 + y)))
                            adjacentNumbers.Add(numbers[(sym.Item1 + x, sym.Item2 + y)]);
                    }
                adjacentNumbers = adjacentNumbers.Distinct().ToList();
                if (adjacentNumbers.Count == 2)
                    result += adjacentNumbers.ElementAt(0).value * adjacentNumbers.ElementAt(1).value;
            }

            return result.ToString();
        }
    }

    internal class MyNumber
    {
        public List<(int, int)> positions = new();

        public MyNumber(int val, (int, int) startPosition)
        {
            value = val;
            positions.Add(startPosition);
            if (value > 9) positions.Add((startPosition.Item1, startPosition.Item2 - 1));
            if (value > 99) positions.Add((startPosition.Item1, startPosition.Item2 - 2));
        }

        public int value;
    }
}
