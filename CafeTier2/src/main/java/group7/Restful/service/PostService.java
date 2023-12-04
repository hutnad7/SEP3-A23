package group7.Restful.service;

import group7.Grpc.service.EventClientService;
import group7.Grpc.service.PostClientService;
import group7.Restful.entity.Post;
import group7.protobuf.CreatePostRequest;
import group7.protobuf.CreatePostResponse;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

@Service
public class PostService {

    private final List<Post> posts = new ArrayList();

    private final PostClientService postClientService;

    public PostService(PostClientService postClientService) {
        this.postClientService = postClientService;
    }

    public List<Post> getAllPosts() {
        return this.posts;
    }

    public Post createPost(Post post) {
        CreatePostRequest request = CreatePostRequest.newBuilder().setAuthor(post.getAuthor()).setTitle(post.getTitle()).setContent(post.getContent()).build();
        Post p = new Post(){
            {
                setId(UUID.fromString(post.getId().toString()));
                setAuthor(post.getAuthor());
                setTitle(post.getTitle());
                setContent(post.getContent());
            }
        };
        System.out.println("Post sent to gRPC server");
        return post;
    }

    public Optional<Post> getPostById(UUID id) {
        return this.posts.stream().filter((e) -> {
            return e.getId().equals(id);
        }).findFirst();
    }

    public List<Post> getPostsByAuthor(String author) {
        return this.posts.stream().filter((e) -> {
            return e.getAuthor().equals(author);
        }).toList();
    }

}
