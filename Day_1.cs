using System.Text.RegularExpressions;

namespace AdventOfCode_2023
{
    public class Day_1 : Day
    {
        
        public override long FirstPart()
        {
            long sum = 0;

            foreach (string input in inputs)
            {
                string firstDigit = null;
                string lastDigit = null;

                string patternDouble = @"\D*(\d).*(\d).*";
                string patternSingle = @"\D*(\d).*";


                Match match = Regex.Match(input, patternDouble);

                if (match.Success)
                {
                    firstDigit = match.Groups[1].Value;
                    lastDigit = match.Groups[2].Value;
                }
                else
                {
                    match = Regex.Match(input, patternSingle);
                    firstDigit = match.Groups[1].Value;
                    lastDigit = firstDigit;
                }

                string inputNumber = $"{firstDigit}{lastDigit}";
                
                sum += long.Parse(inputNumber);
            }

            return sum;
        }

        public override long SecondPart()
        {
            long sum = 0;
            IDictionary<string, string> numbersString = new Dictionary<string, string> 
            {
                {"oneight", "18"},
                {"twone", "21"},
                {"threeight", "38"},
                {"fiveight", "58"},
                {"sevenine", "79"},
                {"eightwo", "82"},
                {"eighthree", "83"},
                {"nineight", "98"},

                {"one", "1"},
                {"two", "2"},
                {"three", "3"},
                {"four", "4"},
                {"five", "5"},
                {"six", "6"},
                {"seven", "7"},
                {"eight", "8"},
                {"nine" ,"9"},
            };

            foreach (string input in inputs)
            {
                string sanitizedInput = input;
                foreach(var kvp in numbersString)
                {
                    sanitizedInput = sanitizedInput.Replace(kvp.Key, kvp.Value);
                }
                
                string firstDigit = null;
                string lastDigit = null;

                string patternDouble = @"\D*(\d).*(\d).*";
                string patternSingle = @"\D*(\d).*";


                Match match = Regex.Match(sanitizedInput, patternDouble);

                if (match.Success)
                {
                    firstDigit = match.Groups[1].Value;
                    lastDigit = match.Groups[2].Value;
                }
                else
                {
                    match = Regex.Match(sanitizedInput, patternSingle);
                    firstDigit = match.Groups[1].Value;
                    lastDigit = firstDigit;
                }

                string inputNumber = $"{firstDigit}{lastDigit}";
                
                sum += long.Parse(inputNumber);
            }

            return sum;
        }
    }
}
