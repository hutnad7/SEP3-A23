package group7.Grpc.dto;

import lombok.Data;

import java.util.UUID;

@Data
public class UserDto {
    private UUID id;
    private String firstName;
    private String lastName;
    private String username;
    private String role;
    private String address;
    private String description;
}
