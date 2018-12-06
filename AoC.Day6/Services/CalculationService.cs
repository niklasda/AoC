using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AoC.Common.Interfaces;

namespace AoC.Day6.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly string _line;

        public CalculationService(string day)
        {
            _line = File.ReadAllText($"Files\\{day}.txt");
        }

        public string DoPart1()
        {
            StringBuilder sb = new StringBuilder(_line);
            Console.WriteLine($"Original: {sb.Length}");


            Console.WriteLine($"Final: {sb.Length}");

            return sb.Length.ToString();
        }

        public string DoPart2()
        {
            var results = new Dictionary<string, int>();


            return results.Values.Min().ToString();
        }
    }
}