package group7.Restful.service;

import com.google.protobuf.Empty;
import group7.Grpc.service.EventClientService;
import group7.Grpc.service.PostClientService;
import group7.Restful.entity.Post;
<<<<<<< Updated upstream
import group7.protobuf.CreatePostRequest;
import group7.protobuf.CreatePostResponse;
=======
import group7.protobuf.*;
>>>>>>> Stashed changes
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


    public Post createPost(Post post) {
        CreatePostRequest request = CreatePostRequest.newBuilder().setAuthor(post.getAuthor()).setTitle(post.getTitle()).setContent(post.getContent()).build();

       CreatePostResponse response = postClientService.createPost(request);
       Post p = new Post(){
            {
                setId(UUID.fromString(response.getId().toString()));
                setAuthor(response.getAuthor());
                setTitle(response.getTitle());
                setContent(response.getContent());
                setEvent(response.getEventId());
                setCreationDate(response.getDate());
            }
        };
        return p;
    }

    public Optional<Post> getPostById(UUID id) {
        return this.posts.stream().filter((e) -> {
            return e.getId().equals(id);
        }).findFirst();
    }

    public ArrayList<Post> getAllPosts() {
        GetPostsResponse response = postClientService.getAllPosts();
        ArrayList<Post> posts = new ArrayList<>();
        for (GetPostResponse p : response.getPostsList()) {
            Post post = new Post() {
                {
                    setId(UUID.fromString(p.getId()));
                    setAuthor(p.getAuthor());
                    setTitle(p.getTitle());
                    setContent(p.getContent());
                    setEvent(p.getEventId());
                    setCreationDate(p.getDate());
                }
            };
            posts.add(post);
        }
        return posts;
    }
    public ArrayList<Post> getPostsByAuthor(UUID id) {
        GetRequest request = GetRequest.newBuilder().setId(id.toString()).build();
        GetPostsResponse response = postClientService.getPostsByAuthor(request);
        ArrayList<Post> posts = new ArrayList<>();
        for (GetPostResponse p : response.getPostsList()) {
            Post post = new Post() {
                {
                    setId(UUID.fromString(p.getId()));
                    setAuthor(p.getAuthor());
                    setTitle(p.getTitle());
                    setContent(p.getContent());
                    setEvent(p.getEventId());
                    setCreationDate(p.getDate());
                }
            };
            posts.add(post);
        }
        return posts;
    }
    public ArrayList<Post> getPostsByEvent(UUID id) {
        GetRequest request = GetRequest.newBuilder().setId(id.toString()).build();
        GetPostsResponse response = postClientService.getPostsByEvent(request);
        ArrayList<Post> posts = new ArrayList<>();
        for (GetPostResponse p : response.getPostsList()) {
            Post post = new Post() {
                {
                    setId(UUID.fromString(p.getId()));
                    setAuthor(p.getAuthor());
                    setTitle(p.getTitle());
                    setContent(p.getContent());
                    setEvent(p.getEventId());
                    setCreationDate(p.getDate());
                }
            };
            posts.add(post);
        }
        return posts;    }
}
