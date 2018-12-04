using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using AoC.Common.Interfaces;
using AoC.Day3.Models;

namespace AoC.Day3.Services
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
            IList<Rectangle> intersections = new List<Rectangle>();

            var orderedClaims = _claims.OrderBy(c => c.Id).ToList();
            foreach (var c1 in orderedClaims)
            {
                foreach (var c2 in orderedClaims.Where(c => c.Id > c1.Id))
                {
                    if (c1.Rect.IntersectsWith(c2.Rect))
                    {
                        var c0 = Rectangle.Intersect(c1.Rect, c2.Rect);

                        if (!intersections.Any(i => i.Contains(c0)))
                        {
                            Console.Write(".");

                            intersections.Add(c0);
                        }
                    }
                }
            }

            Console.WriteLine();

            int count = NbrOfUniquePointIn(intersections);
            return count.ToString();
        }

        private int NbrOfUniquePointIn(IList<Rectangle> intersections)
        {
            IList<Point> points = new List<Point>();
            foreach (var rect in intersections)
            {
                for (int x = rect.X; x < rect.Right; x++)
                {
                    for (int y = rect.Y; y < rect.Bottom; y++)
                    {
                        var p = new Point(x, y);
                        if (!points.Contains(p))
                        {
                            points.Add(p);
                        }
                    }
                }
            }

            return points.Count;
        }

        public string DoPart2()
        {
            IList<int> intersections = new List<int>();

            var orderedClaims = _claims.OrderBy(c => c.Id).ToList();
            foreach (var c1 in orderedClaims)
            {
                foreach (var c2 in orderedClaims.Where(c => c.Id > c1.Id))
                {
                    if (c1.Rect.IntersectsWith(c2.Rect))
                    {
                         Console.Write(".");

                        if (!intersections.Contains(c1.Id))
                        {
                            intersections.Add(c1.Id);
                        }

                        if (!intersections.Contains(c2.Id))
                        {
                            intersections.Add(c2.Id);
                        }
                    }
                }
            }

            Console.WriteLine();

            var nones = orderedClaims.Select(c => c.Id).Except(intersections);

            return nones.Single().ToString();
        }
    }
}