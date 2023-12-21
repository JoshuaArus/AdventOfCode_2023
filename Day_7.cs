namespace AdventOfCode_2023
{
    public class Day_7 : Day
    {                
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

        private abstract class Hand : IComparable<Hand>
        {
            protected abstract List<char> CardOrder { get; set; }
            public required string Cards { get; set; }
            public long Bid { get; set; }
            public abstract Strength Strength { get; }

            public int CompareTo(Hand? other)
            {
                if (other == null)
                    return -1;

                int res = this.Strength - other.Strength;

                int i = 0;
                while (res == 0 && i < Cards.Length)
                {
                    res = CardOrder.IndexOf(Cards[i]) - CardOrder.IndexOf(other.Cards[i]);
                    i++;
                }

                return res;
            }
        }

        private class FirstPartHand : Hand
        {
            protected override List<char> CardOrder { get; set; } = new List<char> { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };

            public override Strength Strength
            {
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
        }

        public override long FirstPart()
        {
            List<FirstPartHand> hands =
                inputs.Select(input => {
                    string[] strings = input.Split(" ");
                    return new FirstPartHand { Cards = strings[0], Bid = long.Parse(strings[1]) };
                }).ToList();

            hands.Sort();

            return hands.Select((hand, index) => hand.Bid * (index + 1)).Sum();
        }
        
        private class SecondPartHand : Hand
        {
            protected override List<char> CardOrder { get; set; } = new List<char> { 'J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A' };
            
            public override Strength Strength
            {
                get
                {
                    List<char> distinctCharsWithoutJokers = Cards.ToCharArray().Where(c => c != 'J').Distinct().ToList();
                    int jokers = Cards.Count(c => c == 'J');

                    switch (distinctCharsWithoutJokers.Count)
                    {
                        case 0:
                        case 1:
                            return Strength.FiveOfAKind;
                        case 2:
                            if (jokers > 1)
                            {
                                return Strength.FourOfAKind;
                            }

                            int firstCharOccurence = Cards.Count(c => c == distinctCharsWithoutJokers[0]);

                            if (jokers == 0)
                            {
                                return (firstCharOccurence == 2 || firstCharOccurence == 3) ? Strength.FullHouse : Strength.FourOfAKind;
                            }
                            else 
                            {
                                return (firstCharOccurence == 2) ? Strength.FullHouse : Strength.FourOfAKind;
                            }
                        case 3:
                            if (jokers > 0)
                            {
                                return Strength.ThreeOfAKind;
                            } 
                            else
                            {
                                int maxOccurence = 0;
                                foreach (char dc in distinctCharsWithoutJokers)
                                    maxOccurence = Math.Max(maxOccurence, Cards.Count(c => c == dc));

                                return maxOccurence == 3 ? Strength.ThreeOfAKind : Strength.TwoPair;
                            }
                        case 4: return Strength.OnePair;
                        default: return Strength.HighCard;
                    }
                }
            }
        }

        public override long SecondPart()
        {
            List<SecondPartHand> hands =
                inputs.Select(input => {
                    string[] strings = input.Split(" ");
                    return new SecondPartHand { Cards = strings[0], Bid = long.Parse(strings[1]) };
                }).ToList();

            hands.Sort();

            return hands.Select((hand, index) => hand.Bid * (index + 1)).Sum();
        }
    }
}
