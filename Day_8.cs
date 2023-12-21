
using System.Text.RegularExpressions;

namespace AdventOfCode_2023
{
    public class Day_8 : Day
    {
        private class Node
        {
            public string Label { get; set; }
            public string Left { get; set; }
            public string Right { get; set; }
        }

        private List<Node> BuildNetwork()
        {
            List<Node> network = new List<Node>();

            for (int i = 2; i < inputs.Length; i++)
            {
                Match regex = Regex.Match(inputs[i], @"([A-Z]{3}) = \(([A-Z]{3}), ([A-Z]{3})\)");

                network.Add(new Node
                {
                    Label = regex.Groups[1].Value,
                    Left = regex.Groups[2].Value,
                    Right = regex.Groups[3].Value
                });
            }
            return network;
        }

        public override long FirstPart()
        {
            string directions = inputs[0];

            List<Node> network = BuildNetwork();

            Node currentNode = network.First(n => n.Label == "AAA");

            long steps = 0;

            while (!currentNode.Label.Equals("ZZZ"))
            {
                char nextDirection = directions[(int)(steps % directions.Length)];
                switch (nextDirection)
                {
                    case 'R':
                        currentNode = network.First(n => n.Label == currentNode.Right);
                        break;
                    case 'L':
                        currentNode = network.First(n => n.Label == currentNode.Left);
                        break;
                }
                steps++;
            }

            return steps;
        }


        public override long SecondPart()
        {
            return -1;
        }
    }
}
