
namespace adventofcode2023
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            int sum = 0;
            char first = '0';
            char second = '0';
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    if (char.IsDigit(c))
                    {
                        if (first == '0')
                            first = c;
                        second = c;
                    }
                }
                sum += int.Parse(first.ToString() + second.ToString());
                first = '0';
            }


            return sum.ToString();
        }

        public string SolutionOfSecondPart(string[] lines)
        {
            int sum = 0;
            char first = '0';
            char second = '0';
            string current = "";
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    current += c;
                    if (StringisDigit(current, out char digit))
                    {
                        if (first == '0')
                            first = digit;
                        second = digit;
                    }
                }
                sum += int.Parse(first.ToString() + second.ToString());
                first = '0';
                current = "";
            }


            return sum.ToString();
        }

        private bool StringisDigit(string current, out char digit)
        {
            if (current.Length < 1)
            {
                digit = 'f';
                return false;
            }
            if (current.Length == 1)
            {
                digit = current[0];
                return char.IsDigit(current[0]);
            }
            switch (current)
            {
                case "one":
                    digit = '1';
                    return true;
                case "two":
                    digit = '2';
                    return true;
                case "three":
                    digit = '3';
                    return true;
                case "four":
                    digit = '4';
                    return true;
                case "five":
                    digit = '5';
                    return true;
                case "six":
                    digit = '6';
                    return true;
                case "seven":
                    digit = '7';
                    return true;
                case "eight":
                    digit = '8';
                    return true;
                case "nine":
                    digit = '9';
                    return true;
                default:
                    bool tmp = StringisDigit(current.Substring(1), out char c);
                    digit = c;
                    return tmp;
            }

        }
    }
}
