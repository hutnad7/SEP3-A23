package group7.Grpc.dto;

import lombok.Data;

import java.util.UUID;
@Data
public class EventDto {
    private UUID id;
    private String name;
    private String description;
    private UUID entertainerId;
    private UUID cafeOwnerId;
    private String entertainerName;
    private String cafeOwnerName;
    private String date;
    private String Status;
    private int availablePlaces;
}
