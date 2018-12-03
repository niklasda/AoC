using System.IO;
using AoC.Day3.Interfaces;

namespace AoC.Day3.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly string[] _lines;

        public CalculationService(string day)
        {
            _lines = File.ReadAllLines($"Files\\{day}.txt");
        }

        public string DoPart1()
        {
            return "";
        }

        public string DoPart2()
        {
            return "";
        }
    }
}