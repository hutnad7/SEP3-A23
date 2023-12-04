package group7.Restful.entity;

import lombok.Data;

import java.io.Serializable;
import java.util.UUID;
@Data
public class Event implements Serializable {
    private UUID id;
    private String name;
    private String description;
    private UUID entertainerId;
    private UUID cafeOwnerId;
    private String startDate;
    private String endDate;
    private String Status;
    private int availablePlaces;


    public Event() {
    }

    public Event(UUID id, String name, String description, UUID entertainerId, UUID cafeOwnerId, String startDate, String endDate, String status, int availablePlaces) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.entertainerId = entertainerId;
        this.cafeOwnerId = cafeOwnerId;
        this.startDate = startDate;
        this.endDate = endDate;
        Status = status;
        this.availablePlaces = availablePlaces;
    }
}
