using System;
using System.Drawing;
using System.IO;
using System.Linq;
using AoC.Day4.Interfaces;
using AoC.Day4.Models;

namespace AoC.Day4.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly Claim[] _claims;

        public CalculationService(string day)
        {
            string[] lines = File.ReadAllLines($"Files\\{day}.txt");
            _claims = lines.Select(Parse).ToArray();
        }

        private Claim Parse(string line)
        {
            var parts = line.Split(' ');

            var c = new Claim
            {
                Id = int.Parse(parts[0].Replace("#", "")),
                Position = new Point(int.Parse(parts[2].Split(",")[0]), int.Parse(parts[2].Split(",")[1].Replace(":", ""))),
                Area = new Size(int.Parse(parts[3].Split("x")[0]), int.Parse(parts[3].Split("x")[1])),
            };
            c.Rect = new Rectangle(c.Position, c.Area);
            return c;
        }

        /* #1 @ 1,3: 4x4
           #2 @ 3,1: 4x4
           #3 @ 5,5: 2x2 */

        public string DoPart1()
        {
            foreach (var c in _claims)
            {

            }
            return "";
        }

        public string DoPart2()
        {
            return "";
        }
    }
}