using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AoC.Day1.Interfaces;

namespace AoC.Day1.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly string[] _lines;

        public CalculationService(string day)
        {
            _lines = File.ReadAllLines($"Files\\{day}.txt");
        }

        public string DoPart1()
        {
            var sum = _lines.Sum(int.Parse);

            return sum.ToString();
        }

        public string DoPart2()
        {
            var intLines = _lines.Select(int.Parse).ToList();
            int segmentLength = intLines.Count;

            bool hasDuplicate = false;

            List<int> ints = new List<int>();
            List<int> sums;

            Console.Write("Looping...");

            do
            {
                Console.Write("..");

                ints.AddRange(intLines);
                sums = CumulativeSum(ints).ToList();
                var distincts = sums.Distinct().ToList();

                if (sums.Count != distincts.Count)
                {
                    hasDuplicate = true;
                }

            } while (!hasDuplicate);

            Console.WriteLine();

            var dups = Duplicates(sums, segmentLength);
            return dups.FirstOrDefault().ToString();
        }

        private IEnumerable<int> CumulativeSum(IEnumerable<int> seq)
        {
            int sum = 0;
            foreach (var item in seq)
            {
                sum += item;
                yield return sum;
            }
        }

        private IEnumerable<int> Duplicates(IList<int> seq, int segmentLength)
        {
            var newSeq = seq.Skip(seq.Count() - segmentLength).Take(segmentLength).Concat(seq.Take(seq.Count() - segmentLength));

            var dups = newSeq.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key);

            return dups;
        }
    }
}