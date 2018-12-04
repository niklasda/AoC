using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Day4.Models
{
    public class Entry
    {
        public Entry()
        {
            Events = new List<Event>();
        }

        public DateTime EntryDate { get; set; }
        public int Id { get; set; }
        public IList<Event> Events { get; }

        public int TotalSleepMinutes
        {
            get
            {
                int accMin = 0;
                DateTime tempSleepStart = DateTime.MinValue;
                foreach (var evt in Events)
                {
                    if (evt.EventType == EventType.FallAsleep)
                    {
                        tempSleepStart = evt.EventTime;
                    }
                    else if (evt.EventType == EventType.WakeUp)
                    {
                        accMin += (int)(evt.EventTime - tempSleepStart).TotalMinutes;
                        tempSleepStart = DateTime.MinValue;

                    }
                }

                return accMin;
            }
        }

        public IList<int> SleepMinutes
        {
            get
            {
                List<int> accMin = new List<int>();
                DateTime tempSleepStart = DateTime.MinValue;
                foreach (var evt in Events)
                {
                    if (evt.EventType == EventType.FallAsleep)
                    {
                        tempSleepStart = evt.EventTime;
                    }
                    else if (evt.EventType == EventType.WakeUp)
                    {
                        accMin.AddRange(Enumerable.Range(tempSleepStart.Minute, (int)(evt.EventTime - tempSleepStart).TotalMinutes));
                        tempSleepStart = DateTime.MinValue;
                    }
                }

                return accMin;
            }
        }
    }

    public class Event
    {
        public DateTime EventTime { get; set; }
        public EventType EventType { get; set; }
    }

    public enum EventType
    {
        FallAsleep,
        WakeUp
    }
}