using System.Text.RegularExpressions;

namespace AdventOfCode_2023
{
    public class Day_2 : Day
    {
        public override long FirstPart()
        {
            int maxRed = 12;
            int maxGreen = 13;
            int maxBlue = 14;

            int gameIdsSum = 0;

            foreach (string input in inputs)
            {
                bool keepGameId = true;
                Match match = Regex.Match(input, @"Game (\d{1,}): (.*)");
                int gameId = int.Parse(match.Groups[1].Value);

                string gameSets = match.Groups[2].Value;
                foreach (string set in gameSets.Split(';'))
                {
                    List<string> cubes = set.Split(',').Select(c => c.Trim()).ToList();

                    foreach (string c in cubes)
                    {
                        Match cubeInformations = Regex.Match(c, @"(\d{1,}) (\D*)");
                        int number = int.Parse(cubeInformations.Groups[1].Value);
                        switch (cubeInformations.Groups[2].Value.ToLowerInvariant().Trim())
                        {
                            case "red":
                                keepGameId = keepGameId && number <= maxRed;
                                break;
                            case "green":
                                keepGameId = keepGameId && number <= maxGreen;
                                break;
                            case "blue":
                                keepGameId = keepGameId && number <= maxBlue;
                                break;
                        }
                    }
                }

                if (keepGameId)
                {
                    gameIdsSum += gameId;
                }
            }

            return gameIdsSum;
        }

        public override long SecondPart()
        {
            int powerSum = 0;

            foreach (string input in inputs)
            {
                int minRed = 0;
                int minGreen = 0;
                int minBlue = 0;
                                
                Match match = Regex.Match(input, @"Game (\d{1,}): (.*)");
                
                string gameSets = match.Groups[2].Value;
                foreach (string set in gameSets.Split(';'))
                {
                    List<string> cubes = set.Split(',').Select(c => c.Trim()).ToList();

                    foreach (string c in cubes)
                    {
                        Match cubeInformations = Regex.Match(c, @"(\d{1,}) (\D*)");
                        int number = int.Parse(cubeInformations.Groups[1].Value);

                        switch (cubeInformations.Groups[2].Value.ToLowerInvariant().Trim())
                        {
                            case "red":
                                minRed = Math.Max(minRed, number);
                                break;
                            case "green":
                                minGreen = Math.Max(minGreen, number);
                                break;
                            case "blue":
                                minBlue = Math.Max(minBlue, number);
                                break;
                        }
                    }
                }

                int gamePower = minRed * minGreen * minBlue;
                powerSum += gamePower;
            }

            return powerSum;
        }
    }
}
