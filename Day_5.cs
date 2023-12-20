
using System.Globalization;

namespace AdventOfCode_2023
{
    public class Day_5 : Day
    {
        public class MapLine
        {
            public long DestinationStart { get; set; }
            public long SourceStart { get; set; }
            public long RangeLength { get; set; }
        }

        private List<long> getNeededSeeds()
        {
            return inputs[0].Split(":")[1].Trim().Split(" ").Select(s => long.Parse(s)).ToList();
        }

        private List<MapLine> buildMap(string mapName)
        {
            List<MapLine> map = new List<MapLine>();

            int currentLine = 0;

            while (!inputs[currentLine].StartsWith($"{mapName} map:"))
                currentLine++;

            currentLine++;

            while (currentLine < inputs.Length && !string.IsNullOrWhiteSpace(inputs[currentLine]))
            {

                string[] datas = inputs[currentLine].Split(" ");

                MapLine mapLine = new MapLine
                {
                    DestinationStart = long.Parse(datas[0]),
                    SourceStart = long.Parse(datas[1]),
                    RangeLength = long.Parse(datas[2])
                };

                map.Add(mapLine);
                currentLine++;
            }

            return map.OrderByDescending(m => m.SourceStart).ToList();            
        }

        private long searchValueInMap(long searchedValue, List<MapLine> map)
        {
            long res = searchedValue;

            foreach (MapLine line in map)
            {
                if (searchedValue >= line.SourceStart && searchedValue < line.SourceStart  + line.RangeLength) 
                { 
                    return line.DestinationStart + (searchedValue - line.SourceStart);
                }
            }

            return res;
        }

        public override void FirstPart()
        {
            long lowestLocation = long.MaxValue;

            List<long> neededSeeds = getNeededSeeds();

            List<MapLine> seedToSoilMap = buildMap("seed-to-soil");
            List<MapLine> soilToFertilizerMap = buildMap("soil-to-fertilizer");
            List<MapLine> fertilizerToWaterMap = buildMap("fertilizer-to-water");
            List<MapLine> waterToLightMap = buildMap("water-to-light");
            List<MapLine> lightToTemperatureMap = buildMap("light-to-temperature");
            List<MapLine> temperatureToHumidityMap = buildMap("temperature-to-humidity");
            List<MapLine> humidityToLocationMap = buildMap("humidity-to-location");

            foreach (var seed in neededSeeds)
            {
                long soil = searchValueInMap(seed, seedToSoilMap);
                long fertilizer = searchValueInMap(soil, soilToFertilizerMap);
                long water = searchValueInMap(fertilizer, fertilizerToWaterMap);
                long light = searchValueInMap(water, waterToLightMap);
                long temperature = searchValueInMap(light, lightToTemperatureMap);
                long humidity = searchValueInMap(temperature, temperatureToHumidityMap);
                long location = searchValueInMap(humidity, humidityToLocationMap);

                if (location < lowestLocation)
                    lowestLocation = location;
            }
            
            Console.WriteLine($"FirstPart : {lowestLocation}");
        }

        public override void SecondPart()
        {
            
        }
    }
}
