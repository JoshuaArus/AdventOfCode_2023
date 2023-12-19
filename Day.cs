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
                FirstPart();
                SecondPart();
            } catch (FileNotFoundException e)
            {
                Console.WriteLine($"Input {inputName} doesn't exist");
            } catch (NotSupportedException)
            {
                //nvm, FirstPart or SecondPart not implemented yet
            }
        }

        public abstract void SecondPart();
        public abstract void FirstPart();
    }
}
