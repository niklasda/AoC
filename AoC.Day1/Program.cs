using System;
using AoC.Common.Tools;
using AoC.Day1.Services;

namespace AoC.Day1
{
    public static class Program
    {
        private static void Main()
        {
            const string day = "day1";
            Console.WriteLine(day);

            CalcRunner.Run(new CalculationService(day));
        }
    }
}
