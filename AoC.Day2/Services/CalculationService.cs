using System.IO;
using System.Linq;
using AoC.Day2.Interfaces;

namespace AoC.Day2.Services
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
            var sum = CheckSum(_lines);

            return sum.ToString();
        }

        private int CheckSum(string[] ids)
        {
            int accTwos = 0;
            int accThrees = 0;

            foreach (var id in ids)
            {
                var twos = id.GroupBy(x => x)
                    .Where(g => g.Count() == 2)
                    .Select(y => y.Key).Any();
                accTwos += twos?1:0;

                var threes = id.GroupBy(x => x)
                    .Where(g => g.Count() == 3)
                    .Select(y => y.Key).Any();
                accThrees += threes?1:0;

            }

            return accTwos * accThrees;
        }

        public string DoPart2()
        {
            var diffComm = FindOneDiffers(_lines);

            return diffComm;
        }

        private string FindOneDiffers(string[] ids)
        {
            var simis = ids.Where(id => ids.Any(i => Similar(id, i))).ToArray();

            var over = simis[0].Zip(simis[1], InterSec).Where(c => c != ' ');

            return new string(over.ToArray());
        }

        private char InterSec(char id1, char id2)
        {
            if (id1 == id2)
                return id1;

            return ' ';
        }

        private bool Similar(string id1, string id2)
        {
            int differs=0;
            for (int i = 0; i < id1.Length; i++)
            {
                if (id1[i] != id2[i])
                {
                    differs++;
                }
            }

            if (differs == 1)
            {
                return true;
            }
            return false;
        }
    }
}