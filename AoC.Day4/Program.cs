using System;
using AoC.Common.Tools;
using AoC.Day4.Services;

namespace AoC.Day4
{
    public static class Program
    {
        private static void Main()
        {
            const string day = "day4";
            Console.WriteLine(day);

            CalcRunner.Run(new CalculationService(day));
        }
    }
}
