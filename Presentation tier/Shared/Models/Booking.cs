namespace Shared.Models;

public class Booking
{
    public Guid EventId { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public int numberOfPeople { get; set; }
}