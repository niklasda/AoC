using System.IO;
using AoC.Common.Interfaces;

namespace AoC.Day5.Services
{
    public class CalculationService : ICalculationService
    {
        public CalculationService(string day)
        {
            string[] lines = File.ReadAllLines($"Files\\{day}.txt");
        }

        public string DoPart1()
        {
            return 0.ToString();
        }

        public string DoPart2()
        {
            return 0.ToString();
        }
    }
}