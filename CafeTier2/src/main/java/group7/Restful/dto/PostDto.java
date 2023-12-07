package group7.Restful.dto;

import lombok.Data;

import java.util.UUID;
@Data
public class PostDto {
    private UUID id;
    private String title;
    private String content;
    private String author;
    private String authorName;
}
