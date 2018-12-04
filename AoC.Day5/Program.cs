using System;
using AoC.Common.Tools;
using AoC.Day5.Services;

namespace AoC.Day5
{
    public static class Program
    {
        private static void Main()
        {
            const string day = "day5";
            Console.WriteLine(day);

            CalcRunner.Run(new CalculationService(day));
        }
    }
}
