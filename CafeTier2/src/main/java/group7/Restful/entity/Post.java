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

    public Post() {
    }
    public Post(UUID id, String title, String content, String author) {
        this.id = id;
        this.title = title;
        this.content = content;
        this.author = author;
    }
}
