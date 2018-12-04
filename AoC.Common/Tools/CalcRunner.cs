using System;
using AoC.Common.Interfaces;

namespace AoC.Common.Tools
{
    public static class CalcRunner
    {
        public static void Run(ICalculationService calc)
        {
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
