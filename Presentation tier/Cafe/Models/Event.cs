namespace Cafe.Models;

public class Event
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid EntertainerId { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime Date { get; set; }
}