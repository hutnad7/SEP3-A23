namespace Cafe.dto;

public class EventDto {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid EntertainerId { get; set; }
    public string EntertainerName { get; set; }
    public Guid CafeOwnerId { get; set; }
    public string CafeOwnerName { get; set; }
    public DateTime Date { get; set; }
        
    public int AvailablePlaces { get; set; }
    public string Status { get; set; }

}
