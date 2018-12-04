using System;
using AoC.Common.Tools;
using AoC.Day2.Services;

namespace AoC.Day2
{
    public static class Program
    {
        private static void Main()
        {
            const string day = "day2";
            Console.WriteLine(day);

            CalcRunner.Run(new CalculationService(day));
        }
    }
}
