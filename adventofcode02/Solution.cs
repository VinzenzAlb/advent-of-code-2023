
using System.Collections.ObjectModel;
using System.Drawing;

namespace adventofcode2023
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            int solution = 0;

            foreach (string line in lines)
            {
                string[] lineSplit = line.Split(":");
                int gameID = int.Parse((lineSplit[0].Split(" "))[1]);
                if (validGame(lineSplit[1].Split(";")))
                {
                    solution += gameID;
                }
            }

            return solution.ToString();
        }

        private bool validGame(string[] cubegrabs)
        {
            foreach (string grab in cubegrabs)
            {
                string[] colors = grab.Split(",");
                foreach (string color in colors)
                {
                    string[] parts = color.Split(" ");
                    switch (parts[2])
                    {
                        case "red":
                            if (int.Parse(parts[1]) > 12)
                                return false;
                            break;
                        case "green":
                            if (int.Parse(parts[1]) > 13)
                                return false;
                            break;
                        case "blue":
                            if (int.Parse(parts[1]) > 14)
                                return false;
                            break;
                    }
                }
            }
            return true;
        }

        public string SolutionOfSecondPart(string[] lines)
        {
            int solution = 0;

            foreach (string game in lines)
            {
                int red = 0;
                int green = 0;
                int blue = 0;
                foreach (string grab in game.Split(":")[1].Split(";"))
                {
                    foreach (string color in grab.Split(","))
                    {
                        string[] parts = color.Split(" ");
                        switch (parts[2])
                        {
                            case "red":
                                red = int.Parse(parts[1]) > red ? int.Parse(parts[1]) : red;
                                break;
                            case "green":
                                green = int.Parse(parts[1]) > green ? int.Parse(parts[1]) : green;
                                break;
                            case "blue":
                                blue = int.Parse(parts[1]) > blue ? int.Parse(parts[1]) : blue;
                                break;
                        }
                    }
                }
                solution += red * green * blue;

            }

            return solution.ToString();
        }
    }
}
