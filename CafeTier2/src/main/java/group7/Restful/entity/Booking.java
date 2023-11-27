package group7.Restful.entity;

import java.util.UUID;

public class Booking {
    private UUID UserId;
    private UUID EventId;
    private String CreationDate;

    private int NumberOfPeople;

    public Booking() {
    }

    public Booking(UUID UserId, UUID EventId, String CreationDate, int NumberOfPeople) {
        this.UserId = UserId;
        this.EventId = EventId;
        this.CreationDate = CreationDate;
        this.NumberOfPeople = NumberOfPeople;
    }

    public UUID getUserId() {
        return UserId;
    }

    public void setUserId(UUID userId) {
        UserId = userId;
    }

    public UUID getEventId() {
        return EventId;
    }

    public void setEventId(UUID eventId) {
        EventId = eventId;
    }

    public String getCreationDate() {
        return CreationDate;
    }

    public void setCreationDate(String creationDate) {
        CreationDate = creationDate;
    }

    public int getNumberOfPeople() {
        return NumberOfPeople;
    }

    public void setNumberOfPeople(int numberOfPeople) {
        NumberOfPeople = numberOfPeople;
    }
}
