package group7.Restful.entity;

import java.util.UUID;

public class Book {

    private UUID id;
    private String Firstname;
    private String Lastname;
    private UUID sits;

    public Book() {
    }

    public Book(UUID id, String Firstname, String Lastname, UUID sits) {
        this.id = id;
        this.Firstname = Firstname;
        this.Lastname = Lastname;
        this.sits = sits;
    }

    public UUID getId() {
        return this.id;
    }
    public String getFirstname() {
        return this.Firstname;
    }

    public void setFirstname(String Firstname) {
        this.Firstname = Firstname;
    }

    public String getLastname() {
        return this.Lastname;
    }

    public void setLastname(String Lastname) {
        this.Lastname = Lastname;
    }

    public UUID getSits() {
        return this.sits;
    }

    public void setSits(UUID sits) {
        this.sits = sits;
    }

    public Book id(UUID id) {
        this.id = id;
        return this;
    }
}
