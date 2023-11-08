package group7.Restful.entity;

import java.io.Serializable;

public class Event implements Serializable {
    private Long id;
    private String name;
    private String description;
    private int entertainerId;

    public Event() {
    }

    public Event(String name, String description, int entertainerId) {
        this.name = name;
        this.description = description;
        this.entertainerId = entertainerId;
    }

    public Event(Long id, String name, String description, int entertainerId) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.entertainerId = entertainerId;
    }

    public Long getId() {
        return this.id;
    }

    public void setId(Long id) {
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

    public int getEntertainerId() {
        return this.entertainerId;
    }

    public void setEntertainerId(int entertainerId) {
        this.entertainerId = entertainerId;
    }
}
