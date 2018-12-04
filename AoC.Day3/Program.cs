﻿using System;
using AoC.Common.Tools;
using AoC.Day3.Services;

namespace AoC.Day3
{
    public static class Program
    {
        private static void Main()
        {
            const string day = "day3";
            Console.WriteLine(day);

            CalcRunner.Run(new CalculationService(day));
        }
    }
}
