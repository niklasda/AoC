using System;
using AoC.Common.Tools;
using AoC.Day6.Services;

namespace AoC.Day6
{
    public static class Program
    {
        private static void Main()
        {
            const string day = "day6";
            Console.WriteLine(day);

            CalcRunner.Run(new CalculationService(day));
        }
    }
}
