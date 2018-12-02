using System.IO;
using AoC.Day2.Interfaces;

namespace AoC.Day2.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly string _day;

        public CalculationService(string day)
        {
            _day = day;
        }

        public string DoPart1()
        {
            var lines = File.ReadAllLines($"Files\\{_day}.txt");

            var sum = CheckSum(lines);

            return sum.ToString();
        }

        private int CheckSum(string[] ids)
        {
            return 0;
        }









        public string DoPart2()
        {
            return "";
        }
    }
}