namespace AdventOfCode_2023
{
    public class Day_3 : Day
    {
        public override long FirstPart()
        {
            int result = 0;

            for (int i = 0; i < inputs.Length; i++)
            {
                string line = inputs[i];
                for (int j = 0; j < line.Length; j++)
                {
                    char c= line[j];

                    if (c != '.' && !Char.IsDigit(c))
                    {
                        List<string> surroundingNumbers = getSurroundingNumbers(i, j);
                        
                        result += surroundingNumbers.Select(n => int.Parse(n)).Sum();
                    }
                }
            }

            return result;
        }

        private List<string> getSurroundingNumbers(int lineNumber, int colNumber)
        {
            List<string> res = new List<string>();
            string line = inputs[lineNumber];
            
            if (lineNumber > 0)
            {
                if (colNumber > 0)
                {
                    addPossibleNumberFromCoordinates(res, lineNumber - 1, colNumber - 1);//top left
                }
                
                addPossibleNumberFromCoordinates(res, lineNumber - 1, colNumber); //top
                
                if (colNumber < line.Length - 1)
                {
                    addPossibleNumberFromCoordinates(res, lineNumber - 1, colNumber + 1); //top right
                }
            }

            if (colNumber > 0) 
            {
                addPossibleNumberFromCoordinates(res, lineNumber, colNumber - 1);//left
            }

            if (colNumber < line.Length - 1) 
            {
                addPossibleNumberFromCoordinates(res, lineNumber, colNumber + 1);//right
            }

            if (lineNumber < inputs.Length - 1)
            {
                if (colNumber > 0)
                {
                    addPossibleNumberFromCoordinates(res, lineNumber + 1, colNumber - 1);// bottom left
                }

                addPossibleNumberFromCoordinates(res, lineNumber + 1, colNumber); //bottom
                
                if (colNumber < line.Length - 1)
                {
                    addPossibleNumberFromCoordinates(res, lineNumber + 1, colNumber + 1); //bottom right
                }
            }

            return res;
        }

        private void addPossibleNumberFromCoordinates(List<string> numbers, int lineNumber, int colNumber)
        {
            string line = inputs[lineNumber];
            
            if (Char.IsDigit(line[colNumber]))
            {
                int colNumberStart = colNumber;
                int colNumberEnd = colNumber;

                while (colNumberStart > 0 && Char.IsDigit(line[colNumberStart - 1]))
                    colNumberStart--;

                while (colNumberEnd < line.Length - 1 && Char.IsDigit(line[colNumberEnd + 1]))
                    colNumberEnd++;

                string number = line.Substring(colNumberStart, colNumberEnd - colNumberStart + 1);

                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                }
            }
        }

        public override long SecondPart()
        {
            int result = 0;

            for (int i = 0; i < inputs.Length; i++)
            {
                string line = inputs[i];
                for (int j = 0; j < line.Length; j++)
                {
                    char c = line[j];

                    if (c == '*')
                    {
                        List<string> surroundingNumbers = getSurroundingNumbers(i, j);
                        if (surroundingNumbers.Count == 2)
                        {
                            int gearRatio = surroundingNumbers.Select(n => int.Parse(n)).Aggregate(1, (x,y) => x * y);
                            result += gearRatio;
                        }
                    }
                }
            }

            return result;
        }
    }
}
