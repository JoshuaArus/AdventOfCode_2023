namespace AdventOfCode_2023
{
    public abstract class Day
    {
        protected string[] inputs;

        public Day()
        {
            string inputName = this.GetType().Name.Replace("Day", "Input") + ".txt";
            try
            {
                //read string from file
                inputs = File.ReadAllLines(inputName);
                Console.WriteLine($"FirstPart  : {FirstPart()}");
                Console.WriteLine($"SecondPart : {SecondPart()}");
            } catch (FileNotFoundException e)
            {
                Console.WriteLine($"Input {inputName} doesn't exist");
            } catch (NotSupportedException)
            {
                //nvm, FirstPart or SecondPart not implemented yet
            }
        }

        public abstract long SecondPart();
        public abstract long FirstPart();
    }
}
