
namespace adventofcode2023
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            int solution = 0;
            List<MyHand> hands = new();

            foreach (string line in lines)
            {
                hands.Add(new(line.Split(" ")[0], int.Parse(line.Split(" ")[1])));
            }
            hands.Sort();
            int i = 1;
            foreach (MyHand hand in hands)
            {
                solution += i * hand.Bid;
                i++;
            }
            return solution.ToString();
        }

        public string SolutionOfSecondPart(string[] lines)
        {
            string solution = "";

            // Hier kommt die Logik für den zweiten Teil hin

            return solution;
        }
    }

    internal class MyHand : IComparable<MyHand?>
    {
        public MyHand(string cards, int bid)
        {
            Cards = cards;
            Bid = bid;
            Type = GenerateType(cards);
        }

        private HandType GenerateType(string cards)
        {
            Dictionary<char, int> cardCount = new();
            foreach (char c in cards)
            {
                if (cardCount.ContainsKey(c))
                    cardCount[c]++;
                else cardCount[c] = 1;
            }
            switch (cardCount.Values.Max())
            {
                case 5:
                    return HandType.FifeOfAKind;
                case 4:
                    return HandType.FourOfAKind;
                case 3:
                    return cardCount.Values.Contains(2) ? HandType.FullHouse : HandType.ThreeOfAKind;
                case 2:
                    return cardCount.Values.Count(value => value == 2) > 1 ? HandType.TwoPair : HandType.OnePair;
                case 1:
                    return HandType.HighCard;
                default:
                    throw new Exception("invalid card count");
            }
        }

        public int CompareTo(MyHand? otherHand)
        {
            if (otherHand == null) throw new Exception("cant compare with a null object");
            if (Type != otherHand.Type) return Type.CompareTo(otherHand.Type);
            for (int i = 0; i < 5; i++)
            {
                if (Cards[i] == otherHand.Cards[i]) continue;
                if (char.IsNumber(Cards[i]) || char.IsNumber(otherHand.Cards[i]))
                    return Cards[i].CompareTo(otherHand.Cards[i]);
                //All letters but J are in reverse order of their value
                if (!(Cards[i] == 'J' || otherHand.Cards[i] == 'J'))
                    return otherHand.Cards[i].CompareTo(Cards[i]);
                if (Cards[i] == 'J')
                    if (otherHand.Cards[i] == 'T') return 1;
                    else return -1;
                else
                    if (Cards[i] == 'T')
                    return -1;
                else return 1;
            }
            return 0;
        }

        public string Cards { get; }
        public HandType Type { get; }
        public int Bid { get; }
    }
    enum HandType : int
    {
        HighCard = 0,
        OnePair = 1,
        TwoPair = 2,
        ThreeOfAKind = 3,
        FullHouse = 4,
        FourOfAKind = 5,
        FifeOfAKind = 6
    }
}
