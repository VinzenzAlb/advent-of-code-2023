

using System.Data;

namespace adventofcode2023
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            long solution = 1;
            List<int> time = ReadNumbers(lines[0]);
            List<int> distance = ReadNumbers(lines[1]);

            for (int race = 0; race < time.Count; race++)
            {
                solution *= GetWinningTimes(time[race], distance[race]);
            }

            return solution.ToString();
        }

        private long GetWinningTimes(int raceTime, int timeToBeat)
        {
            int wins = 0;
            for (int speed = 0; speed < raceTime; speed++)
            {
                int distance = speed * (raceTime - speed);
                if (distance > timeToBeat) wins++;
            }
            return wins;
        }

        private List<int> ReadNumbers(string line)
        {
            List<int> result = new();
            string numbersText = line.Split(":")[1];
            string current = "";
            for (int c = 0; c < numbersText.Length; c++)
            {
                if (char.IsNumber(numbersText[c]))
                    current += numbersText[c];
                else if (current != "")
                {
                    result.Add(int.Parse(current));
                    current = "";
                }
            }
            if (current != "")
            {
                result.Add(int.Parse(current));
            }
            return result;
        }

        public string SolutionOfSecondPart(string[] lines)
        {
            long solution;
            int raceTime = 49877895;
            long record = 356137815021882;

            long speed = 1;
            while (speed * (raceTime - speed) <= record)
            {
                speed++;
            }
            solution = raceTime - (2 * speed) + 1; // +1 because we already found the first one


            return solution.ToString();
        }
    }
}
