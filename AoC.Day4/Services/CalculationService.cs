﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AoC.Common.Interfaces;
using AoC.Day4.Models;

namespace AoC.Day4.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly IList<Entry> _entries;

        public CalculationService(string day)
        {
            string[] lines = File.ReadAllLines($"Files\\{day}.txt");
            var orderedLines = lines.OrderBy(l => l);
            _entries = Parse(orderedLines);
        }

        private IList<Entry> Parse(IEnumerable<string> lines)
        {
            IList<Entry> entries = new List<Entry>();

            foreach (var line in lines)
            {
                var parts = line.Split(']');

                string dateString = parts[0].Replace("[", "");

                var dateTime = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm", null);
                DateTime date;
                if (dateTime.Hour >= 23)
                {
                    date = dateTime.AddHours(1).Date;
                }
                else
                {
                    date = dateTime.Date;
                }

                var entry = entries.FirstOrDefault(e => e.EntryDate.Equals(date));
                if (entry == null)
                {
                    string text = parts[1].Trim();
                    string guardId = text.Replace("Guard #", "").Replace(" begins shift", "");

                    var e = new Entry();
                    e.EntryDate = date;
                    e.Id = int.Parse(guardId);

                    entries.Add(e);
                }
                else
                {
                    string text = parts[1].Trim();
                    if (text.StartsWith("falls", StringComparison.InvariantCultureIgnoreCase))
                    {
                        entry.Events.Add(new Event { EventTime = dateTime, EventType = EventType.FallAsleep });
                    }
                    else if (text.StartsWith("wakes", StringComparison.InvariantCultureIgnoreCase))
                    {
                        entry.Events.Add(new Event { EventTime = dateTime, EventType = EventType.WakeUp });
                    }
                }
            }

            return entries;
        }

        /* [1518-11-01 00:00] Guard #10 begins shift
           [1518-11-01 00:05] falls asleep
           [1518-11-01 00:25] wakes up
           [1518-11-01 00:30] falls asleep
           [1518-11-01 00:55] wakes up
           [1518-11-01 23:58] Guard #99 begins shift
           [1518-11-02 00:40] falls asleep
           [1518-11-02 00:50] wakes up
           [1518-11-03 00:05] Guard #10 begins shift
           [1518-11-03 00:24] falls asleep
           [1518-11-03 00:29] wakes up
           [1518-11-04 00:02] Guard #99 begins shift
           [1518-11-04 00:36] falls asleep
           [1518-11-04 00:46] wakes up
           [1518-11-05 00:03] Guard #99 begins shift
           [1518-11-05 00:45] falls asleep
           [1518-11-05 00:55] wakes up */

        public string DoPart1()
        {
            IGrouping<int, Entry> sleepGroup = _entries.GroupBy(e => e.Id).OrderByDescending(e => e.Sum(y => y.TotalSleepMinutes)).First();

            IList<Entry> list = sleepGroup.Select(s => s).ToList();
            IList<int> minutes = list.SelectMany(l => l.SleepMinutes).ToList();
            var topRankingMinute = minutes.GroupBy(e => e).OrderByDescending(e => e.Count()).First().Key;
            var guardId = sleepGroup.Key;

            Console.WriteLine($"#{guardId} - {topRankingMinute}");
            return (topRankingMinute * guardId).ToString();
        }

        public string DoPart2()
        {
            var sleepGroups = _entries.GroupBy(e => e.Id);

            foreach (var grp in sleepGroups)
            {
                var guardId = grp.Key;

                var groupLead = grp.SelectMany(l => l.SleepMinutes).GroupBy(e => e).OrderByDescending(e => e.Count()).FirstOrDefault();
                if (groupLead != null)
                {
                    var topRankingMinute = groupLead.Key;
                    var topRankingCount = groupLead.Count();

                    if (topRankingCount >= 19)
                    {
                        Console.WriteLine($"#{guardId} - {topRankingMinute} - {topRankingCount} = {guardId * topRankingMinute}");
                        return (guardId * topRankingMinute).ToString();
                    }
                }
            }

            /* #859 - 43 - 12 = 36937
               #2383 - 29 - 7 = 69107
               #997 - 38 - 19 = 37886
               #1367 - 43 - 12 = 58781
            */
            
            return 0.ToString();
        }
    }
}