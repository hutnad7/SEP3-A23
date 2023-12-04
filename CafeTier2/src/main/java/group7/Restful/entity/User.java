package group7.Restful.entity;

import java.util.UUID;

public class User {
    private String FirstName;
    private String LastName;
    private String Username;

    private String Email;
    private String Role;
    private UUID Id;

    private String Password;

    public User() {
    }

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

    public String getPassword() {
        return Password;
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

    public void setPassword(String Password) {
        this.Password = Password;
    }


}
