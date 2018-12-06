using System;
using System.Drawing;
using System.IO;
using System.Linq;
using AoC.Common.Interfaces;

namespace AoC.Day6.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly Point[] _points;

        public CalculationService(string day)
        {
            var lines = File.ReadAllLines($"Files\\{day}.txt");

            _points = lines.Select(l => new Point(int.Parse(l.Split(',')[0]), int.Parse(l.Split(',')[1]))).ToArray();
        }

        public string DoPart1()
        {
            Console.WriteLine($"Original: {_points.Length}");


            return 0.ToString();
        }

        public string DoPart2()
        {

            return 0.ToString();
        }
    }
}