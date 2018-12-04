using System;
using System.Collections.Generic;

namespace AoC.Day4.Models
{
    public class Entry
    {
        public Entry()
        {
            Events=new List<Event>();
        }

        public DateTime EntryDate { get; set; }
        public int Id { get; set; }
        public IList<Event> Events { get; set; }
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
    };
}