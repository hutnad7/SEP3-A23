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

    public Booking() {
    }

    public Booking(UUID id, UUID UserId, UUID EventId, String CreationDate, int NumberOfPeople) {
        this.id = id;
        this.UserId = UserId;
        this.EventId = EventId;
        this.CreationDate = CreationDate;
        this.NumberOfPeople = NumberOfPeople;
    }
}
