package group7.Restful.entity;

import lombok.Data;

import java.util.UUID;

@Data
public class User {
    private String FirstName;
    private String LastName;
    private String Username;

    private String Email;
    private String Description;
    private String Role;
    private UUID Id;

    public User() {
    }

<<<<<<< Updated upstream
    public String getFirstName() {
        return FirstName;
    }
    public String getLastName() {
        return LastName;
    }
    public String getUsername() {
        return Username;
    }
    public String getEmail() {
        return Email;
    }
    public String getRole() {
        return Role;
    }
    public UUID getId() {
        return Id;
    }
    public void setFirstName(String FirstName) {
        this.FirstName = FirstName;
    }
    public void setLastName(String LastName) {
        this.LastName = LastName;
    }
    public void setUsername(String Username) {
        this.Username = Username;
    }
    public void setEmail(String Email) {
        this.Email = Email;
    }
    public void setRole(String Role) {
        this.Role = Role;
    }
    public void setId(UUID Id) {
        this.Id = Id;
    }
=======


>>>>>>> Stashed changes
}
