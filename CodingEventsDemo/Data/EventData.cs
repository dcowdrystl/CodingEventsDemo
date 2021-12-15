using CodingEventsDemo.Models;
using System;
using System.Collections.Generic;

namespace CodingEventsDemo.Data
{
    public class EventData
    {
        // store events
        private static Dictionary<int, Event> Events = new Dictionary<int, Event>();

        //add events
        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.Id, newEvent);
        }

        //retreive events
        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }

        //retreive a single event
        public static Event GetById(int id)
        {
            return Events[id];
        }

        // removve an event
        public static void Remove(int id)
        {
            Events.Remove(id);
        }



    }
}
