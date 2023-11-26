package group7.Restful.entity;

import java.io.Serializable;
import java.util.UUID;

public class Event implements Serializable {
    private UUID id;
    private String name;
    private String description;
    private UUID entertainerId;
    private UUID cafeOwnerId;
    private String date;
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

    public UUID getId() {
        return this.id;
    }

    public void setId(UUID id) {
        this.id = id;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return this.description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public UUID getEntertainerId() {
        return this.entertainerId;
    }

    public void setEntertainerId(UUID entertainerId) {
        this.entertainerId = entertainerId;
    }

    public UUID getCafeOwnerId() {return this.cafeOwnerId;}

    public void setCafeOwnerId(UUID cafeOwnerId) {this.cafeOwnerId = cafeOwnerId;}

    public String getDate() {return this.date;}

    public void setDate(String date) {this.date = date;}

    public int getAvailablePlaces() {
        return availablePlaces;
    }

    public void setAvailablePlaces(int availablePlaces) {
        this.availablePlaces = availablePlaces;
    }
}
