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
    private String date;
    private String Status;
    private int availablePlaces;


    public Event() {
    }

    public Event(String name, String description, UUID entertainerId, UUID cafeOwnerId, String date, int availablePlaces) {
        this.name = name;
        this.description = description;
        this.entertainerId = entertainerId;
        this.cafeOwnerId = cafeOwnerId;
        this.date = date;
        this.availablePlaces = availablePlaces;
    }

    public Event(UUID id, String name, String description, UUID entertainerId, UUID cafeOwnerId, String date, int availablePlaces) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.entertainerId = entertainerId;
        this.cafeOwnerId = cafeOwnerId;
        this.date = date;
        this.availablePlaces = availablePlaces;
    }




}
