using System.Runtime.InteropServices;

namespace adventofcode2023
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            // Hier kommt die Logik für den ersten Teil hin

            List<long> seeds = new();
            List<long> locations = new();
            foreach (string seed in lines[0].Split(":")[1].Split(" ").Skip(1))
                seeds.Add(long.Parse(seed));

            foreach (long seed in seeds)
            {
                locations.Add(CalcLocation(lines, seed));
            }
            return locations.Min().ToString();
        }

        private long CalcLocation(string[] lines, long seed)
        {
            int lineCounter = 3;
            while (lineCounter < lines.Length)
            {
                seed = CalcNew(lines, ref lineCounter, seed);
                while (lineCounter < lines.Length && lines[lineCounter] != "")
                    lineCounter++;
                lineCounter += 2;
            }
            return seed;
        }

        private long CalcNew(string[] lines, ref int lineCounter, long seed)
        {
            long destinationRangeStart, sourceRangeStart, rangeLength;
            while (lineCounter < lines.Length && lines[lineCounter] != "")
            {
                destinationRangeStart = long.Parse(lines[lineCounter].Split(" ")[0]);
                sourceRangeStart = long.Parse(lines[lineCounter].Split(" ")[1]);
                rangeLength = long.Parse(lines[lineCounter].Split(" ")[2]);
                if (seed >= sourceRangeStart && seed < sourceRangeStart + rangeLength)
                    return seed - sourceRangeStart + destinationRangeStart;

                lineCounter++;
            }
            return seed;
        }

        public string SolutionOfSecondPart(string[] lines)
        {
            List<long> seeds = new();
            List<long> locations = new();
            string[] seedlist = lines[0].Split(":")[1].Split(" ");

            for (int i = 1; i < seedlist.Length - 1; i += 2)
            {
                for (long j = long.Parse(seedlist[i + 1]) - 1; j >= 0; j--)
                {
                    seeds.Add(long.Parse(seedlist[i]) + j);
                }
            }
            List<long[]> seedToSoil = GenerateMap("seed-to-soil map:", lines);
            List<long[]> soiLToFertilizer = GenerateMap("soil-to-fertilizer map:", lines);
            List<long[]> fertilizerToWater = GenerateMap("fertilizer-to-water map:", lines);
            List<long[]> waterToLight = GenerateMap("water-to-light map:", lines);
            List<long[]> lightToTemperature = GenerateMap("light-to-temperature map:", lines);
            List<long[]> temperatureToHumidity = GenerateMap("temperature-to-humidity map:", lines);
            List<long[]> humidityToLocation = GenerateMap("humidity-to-location map:", lines);


            long minLocation = long.MaxValue;
            long tmp;
            /*
            foreach (long seed in seeds)
            {
                tmp = CalcWithMap(seedToSoil, seed);
                tmp = CalcWithMap(soiLToFertilizer, tmp);
                tmp = CalcWithMap(fertilizerToWater, tmp);
                tmp = CalcWithMap(waterToLight, tmp);
                tmp = CalcWithMap(lightToTemperature, tmp);
                tmp = CalcWithMap(temperatureToHumidity, tmp);
                tmp = CalcWithMap(humidityToLocation, tmp);
                if (tmp < minLocation) minLocation = tmp;
            }
            */

            for (long i = 0; i < long.MaxValue; i++)
            {
                tmp = ReverseCalcWithMap(seedToSoil, i);
                tmp = ReverseCalcWithMap(soiLToFertilizer, tmp);
                tmp = ReverseCalcWithMap(fertilizerToWater, tmp);
                tmp = ReverseCalcWithMap(waterToLight, tmp);
                tmp = ReverseCalcWithMap(lightToTemperature, tmp);
                tmp = ReverseCalcWithMap(temperatureToHumidity, tmp);
                tmp = ReverseCalcWithMap(humidityToLocation, tmp);
                if (seeds.Contains(tmp)) return i.ToString();
            }

            return minLocation.ToString();
        }

        private long ReverseCalcWithMap(List<long[]> seedMap, long seed)
        {
            foreach (long[] rules in seedMap)
            {
                if (seed >= rules[0] && seed < rules[0] + rules[2])
                    return seed - rules[2] + rules[1];
            }
            return seed;
        }

        private long CalcWithMap(List<long[]> seedMap, long seed)
        {
            foreach (long[] rules in seedMap)
            {
                if (seed >= rules[1] && seed < rules[1] + rules[2])
                    return seed - rules[1] + rules[0];
            }
            return seed;
        }

        private List<long[]> GenerateMap(string startphrase, string[] lines)
        {
            List<long[]> result = new();
            int lineCounter = 0;
            long[] tmp;
            while (lines[lineCounter] != startphrase) lineCounter++;
            lineCounter++;
            while (lineCounter < lines.Length && lines[lineCounter] != "")
            {
                tmp = new long[3];
                tmp[0] = long.Parse(lines[lineCounter].Split(" ")[0]);
                tmp[1] = long.Parse(lines[lineCounter].Split(" ")[1]);
                tmp[2] = long.Parse(lines[lineCounter].Split(" ")[2]);
                result.Add(tmp);
                lineCounter++;
            }


            return result;
        }
    }
}
