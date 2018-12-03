using System;
using AoC.Day3.Interfaces;
using AoC.Day3.Services;

namespace AoC.Day3
{
    public static class Program
    {
        private static void Main()
        {
            const string day = "day3";
            ICalculationService calc = new CalculationService(day);
            Console.WriteLine(day);

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
