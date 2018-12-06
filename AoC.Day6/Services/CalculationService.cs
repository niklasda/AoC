using System;
using System.Drawing;
using System.IO;
using System.Linq;
using AoC.Common.Interfaces;
using AoC.Day6.Models;

namespace AoC.Day6.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly Point[] _points;

        public CalculationService(string day)
        {
            var lines = File.ReadAllLines($"Files\\{day}.txt");

            _points = lines.Select(l => new Point(int.Parse(l.Split(',')[0]), int.Parse(l.Split(',')[1]))).ToArray();
        }

        public string DoPart1()
        {
            Console.WriteLine($"Original: {_points.Length}");

            var left = _points.Min(p => p.X);
            var right = _points.Max(p => p.X);
            var top = _points.Min(p => p.Y);
            var bottom = _points.Max(p => p.Y);

            var areal = new Coord[right + 2, bottom + 2];

            Console.WriteLine($"l:{left} r:{right} t:{top} b:{bottom}");

            int id = 1;
            foreach (var point in _points)
            {
                if (areal[point.X, point.Y] == null)
                {
                    id++;
                    areal[point.X, point.Y] = new Coord(id, id);
                }
                else
                {
                    Console.WriteLine("occupied");
                }
            }

            Console.WriteLine($"{_points.Length}");
            Console.WriteLine($"{--id}");

            for (int x = 1; x < right; x++)
            {
                for (int y = 1; y < bottom; y++)
                {
                    if (areal[x, y] != null)
                    {
                        // bebodd
                        int occupier = areal[x, y].OwnerId;

                        for (int dx = -1; dx < 2; dx++)
                        {
                            for (int dy = -1; dy < 2; dy++)
                            {
                                if (dx == 0 && dy == 0)
                                {
                                    // myself
                                }
                                else
                                {
                                    if (areal[x + dx, y + dy] == null)
                                    {
                                        areal[x + dx, y + dy] = new Coord(occupier);

                                    }
                                }
                            }
                        }
                    }
                }
            }

            return 0.ToString();
        }

        public string DoPart2()
        {

            return 0.ToString();
        }
    }
}