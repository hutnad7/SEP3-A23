package group7.Restful.entity;

import lombok.Data;

import java.util.UUID;

@Data
public class Post {
    private UUID id;
    private String title;
    private String content;
    private String author;
    private String event;
    private String creationDate;

    public Post() {
    }

}
