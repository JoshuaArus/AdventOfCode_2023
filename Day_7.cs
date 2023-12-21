namespace AdventOfCode_2023
{
    public class Day_7 : Day
    {
        private static readonly List<char> AllCards = new List<char> { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
                
        private enum Strength
        {
            HighCard,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            FullHouse,
            FourOfAKind,
            FiveOfAKind
        }

        private class Hand : IComparable<Hand>
        {
            public required string Cards { get; set; }
            public long Bid { get; set; }

            public Strength Strength { 
                get
                {
                    List<char> distinctChars = Cards.ToCharArray().Distinct().ToList();
                    switch (distinctChars.Count)
                    {
                        case 1: 
                            return Strength.FiveOfAKind;
                        case 2:
                            int firstCharOccurence = Cards.Count(c => c == distinctChars[0]);
                            if (firstCharOccurence == 4 || firstCharOccurence == 1)
                                return Strength.FourOfAKind;
                            else
                                return Strength.FullHouse;
                        case 3:
                            foreach (char dc in distinctChars)
                            {

                                if (Cards.Count(c => c == dc) == 3)
                                return Strength.ThreeOfAKind;
                            }
                            return Strength.TwoPair;

                        case 4: return Strength.OnePair;
                        default: return Strength.HighCard;
                    }
                } 
            }

            public int CompareTo(Hand? other)
            {
                if (other == null)
                    return 1;

                int res = this.Strength - other.Strength;

                int i = 0;
                while (res == 0 && i < Cards.Length)
                {
                    res = AllCards.IndexOf(Cards[i]) - AllCards.IndexOf(other.Cards[i]);
                    i++;
                }

                return res;
            }
        }

        public override long FirstPart()
        {
            long res = 0;

            List<Hand> hands = 
                inputs.Select(input => {
                    string[] strings = input.Split(" ");
                    return new Hand { Cards = strings[0], Bid = long.Parse(strings[1]) };
                }).ToList();

            hands.Sort();

            for (int i = 0; i < hands.Count; i++)
                res += hands[i].Bid * (i+1);

            return res;
        }

        public override long SecondPart()
        {
            long res = -1;

            return res;
        }
    }
}
