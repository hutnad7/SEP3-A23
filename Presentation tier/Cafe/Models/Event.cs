﻿namespace Cafe.Models;

public class Event
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EntertainerId { get; set; }
        public DateTime Date { get; set; }
}