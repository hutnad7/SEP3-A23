using System.Runtime.InteropServices.JavaScript;

namespace Shared.Models;

public class Booking
{
    public Guid EventId { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public Guid userId { get; set; }
    public String CreationDate { get; set; }
    public int numberOfPeople { get; set; }
}