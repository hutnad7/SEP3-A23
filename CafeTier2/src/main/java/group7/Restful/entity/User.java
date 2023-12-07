package group7.Restful.entity;

import lombok.Data;

import java.util.UUID;
@Data
public class User {
    private String FirstName;
    private String LastName;
    private String Username;
    private String Description;
    private String Email;
    private String Role;
    private UUID Id;
    private String Password;

    public User() {
    }
}
