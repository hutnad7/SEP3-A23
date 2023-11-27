using System;

namespace Cafe.Models;

public class Event
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid EntertainerId { get; set; }
        
        public Guid CafeOwnerId { get; set; }
        public DateTime Date { get; set; }
        
        public int AvailablePlaces { get; set; }

}