
namespace adventofcode2023
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            int sum = 0;
            char first = 'f';
            char second = 'f';
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    if (char.IsDigit(c))
                    {
                        if (first == 'f')
                            first = c;
                        second = c;
                    }
                }
                sum += int.Parse(first.ToString() + second.ToString());
                first = 'f';
            }


            return sum.ToString();
        }

        public string SolutionOfSecondPart(string[] lines)
        {
            int sum = 0;
            char first = 'f';
            char second = 'f';
            string current = "";
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    current += c;
                    if (StringIsDigit(current, out char digit))
                    {
                        if (first == 'f')
                            first = digit;
                        second = digit;
                    }
                }
                sum += int.Parse(first.ToString() + second.ToString());
                first = 'f';
                current = "";
            }


            return sum.ToString();
        }

        private bool StringIsDigit(string current, out char digit)
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
                    bool tmp = StringIsDigit(current.Substring(1), out char c);
                    digit = c;
                    return tmp;
            }

        }
    }
}
