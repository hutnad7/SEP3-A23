package group7.Restful.entity;

import lombok.Data;
import java.util.UUID;
@Data
public class Booking {
    private UUID UserId;
    private UUID EventId;
    private String CreationDate;
    private int NumberOfPeople;
    private UUID id;
    private String FirstName;
    private String LastName;

    public Booking() {
    }

    public Booking(UUID UserId, UUID EventId, String CreationDate, int NumberOfPeople){
        this.UserId = UserId;
        this.EventId = EventId;
        this.CreationDate = CreationDate;
        this.NumberOfPeople = NumberOfPeople;
    }
}
