using System;
using System.IO;
using System.Text;
using AoC.Common.Interfaces;

namespace AoC.Day5.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly string _line;

        public CalculationService(string day)
        {
            _line = File.ReadAllText($"Files\\{day}.txt");
        }

        public string DoPart1()
        {
            StringBuilder sb = new StringBuilder(_line);
            Console.WriteLine($"Original: {sb.Length}");

            bool isFinished;
            do
            {
                int lengthBefore = sb.Length;

                for (int i = 0; i < sb.Length - 1; i++)
                {
                    if (sb.ToString(i, 1).Equals(sb.ToString(i + 1, 1), StringComparison.InvariantCultureIgnoreCase)
                        && !sb.ToString(i, 1).Equals(sb.ToString(i + 1, 1), StringComparison.InvariantCulture))
                    {
                        sb.Remove(i, 2);
                    }
                }

                Console.WriteLine($"Remaining: {sb.Length}");

                int lengthAfter = sb.Length;
                isFinished = lengthBefore == lengthAfter;
            } while (!isFinished);

            Console.WriteLine($"Final: {sb.Length}");

            return sb.Length.ToString();
        }

        public string DoPart2()
        {
            return 0.ToString();
        }
    }
}