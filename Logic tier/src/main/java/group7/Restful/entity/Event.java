package group7.Restful.entity;

import java.io.Serializable;
import java.util.UUID;

public class Event implements Serializable {
    private UUID id;
    private String name;
    private String description;
    private UUID entertainerId;

    public Event() {
    }

    public Event(String name, String description, UUID entertainerId) {
        this.name = name;
        this.description = description;
        this.entertainerId = entertainerId;
    }

    public Event(UUID id, String name, String description, UUID entertainerId) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.entertainerId = entertainerId;
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
}
