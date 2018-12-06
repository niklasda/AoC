using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            sb = Reduce(sb);

            Console.WriteLine($"Final: {sb.Length}");

            return sb.Length.ToString();
        }

        private StringBuilder Reduce(StringBuilder sb)
        {
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

                Console.Write(".");

                int lengthAfter = sb.Length;
                isFinished = lengthBefore == lengthAfter;
            } while (!isFinished);

            return sb;
        }

        public string DoPart2()
        {
            var results = new Dictionary<string, int>();

            string[] chars = _line.Select(c => c.ToString().ToLower()).Distinct().OrderBy(c => c).ToArray();

            Console.WriteLine($"Distinct: {string.Join(',', chars)}");

            foreach (var c in chars)
            {
                StringBuilder sb = new StringBuilder(_line);
                sb.Replace(c, "").Replace(c.ToUpper(), "");
                sb = Reduce(sb);

                Console.WriteLine($"For {c}: {sb.Length}");

                results.Add(c, sb.Length);
            }

            return results.Values.Min().ToString();
        }
    }
}