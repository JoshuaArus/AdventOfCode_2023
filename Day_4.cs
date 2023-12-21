using System.Text.RegularExpressions;

namespace AdventOfCode_2023
{
    public class Day_4 : Day
    {
        public override long FirstPart()
        {
            double result = 0;

            foreach (string input in inputs)
            {
                Match match = Regex.Match(input, @"Card[ ]*(\d{1,}): (.*)");
                int cardId = int.Parse(match.Groups[1].Value);

                string[] cardNumbers = match.Groups[2].Value.Split(" | ");
                List<string> winningNumbers = cardNumbers[0].Split(" ").Select(n => n.Trim()).Where(n => !string.IsNullOrWhiteSpace(n)).ToList();
                List<string> ownedNumbers = cardNumbers[1].Split(" ").Select(n => n.Trim()).Where(n => !string.IsNullOrWhiteSpace(n)).ToList();
                
                int matchingNumbers = ownedNumbers.Count(n => winningNumbers.Contains(n));

                if (matchingNumbers > 0)
                {
                    result += Math.Pow(2, matchingNumbers - 1);
                }

            }

            return (long) result;
        }

        public override long SecondPart()
        {
            double result = 0;

            IDictionary<int, int> cardCopiesById = Enumerable.Range(1, inputs.Length).ToDictionary(i => i, i => 1);

            foreach (string input in inputs)
            {
                Match match = Regex.Match(input, @"Card[ ]*(\d{1,}): (.*)");
                int cardId = int.Parse(match.Groups[1].Value);

                string[] cardNumbers = match.Groups[2].Value.Split(" | ");
                List<string> winningNumbers = cardNumbers[0].Split(" ").Select(n => n.Trim()).Where(n => !string.IsNullOrWhiteSpace(n)).ToList();
                List<string> ownedNumbers = cardNumbers[1].Split(" ").Select(n => n.Trim()).Where(n => !string.IsNullOrWhiteSpace(n)).ToList();

                int matchingNumbers = ownedNumbers.Count(n => winningNumbers.Contains(n));

                if (matchingNumbers > 0)
                {
                    for (int i = 1; i <= matchingNumbers; i++)
                    {
                        cardCopiesById[cardId + i] = cardCopiesById[cardId + i] + cardCopiesById[cardId];
                    }
                }
            }

            foreach(var kvp in cardCopiesById)
            {
                result += kvp.Value;
            }

            return (long)result;
        }
    }
}
