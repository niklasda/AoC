using System;
using System.Collections.Generic;

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
        public IList<Event> Events { get; set; }

        public int TotalSleepMinutes
        {
            get
            {
                int accMin = 0;
                DateTime _tempSleepStart = DateTime.MinValue;
                foreach (var evt in Events)
                {
                    if (evt.EventType == EventType.FallAsleep)
                    {
                        _tempSleepStart = evt.EventTime;
                    }
                    else if (evt.EventType == EventType.WakeUp)
                    {
                        accMin += (int)(evt.EventTime - _tempSleepStart).TotalMinutes;
                        _tempSleepStart = DateTime.MinValue;

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