using System;
using AoC.Day1.Interfaces;
using AoC.Day1.Services;

namespace AoC.Day1
{
    public class Program
    {
        private static void Main()
        {
            const string day = "day1";
            ICalculationService calc = new CalculationService(day);

            var result1 = calc.DoPart1();

            Console.WriteLine(result1);
            Console.WriteLine("------------- Press any key to continue");
            Console.ReadKey();

            var result2 = calc.DoPart2();

            Console.WriteLine(result2);

            Console.WriteLine("------------- Press any other key to close");
            Console.ReadKey();

        }
    }
}
