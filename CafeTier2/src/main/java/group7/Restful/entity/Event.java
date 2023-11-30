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
}
