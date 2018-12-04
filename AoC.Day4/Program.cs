using System;
using AoC.Day4.Interfaces;
using AoC.Day4.Services;

namespace AoC.Day4
{
    public static class Program
    {
        private static void Main()
        {
            const string day = "day4";
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
