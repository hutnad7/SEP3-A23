package group7.Restful.service;

import group7.Grpc.service.EventClientService;
import group7.Grpc.service.PostClientService;
import group7.Restful.dto.PostDto;
import group7.Restful.entity.Post;
import group7.protobuf.*;
import org.springframework.stereotype.Service;

import java.security.Guard;
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
                setEvent(response.getEvent());
            }
        };
        return post;
    }

    public Optional<Post> getPostById(UUID id) {
        return this.posts.stream().filter((e) -> {
            return e.getId().equals(id);
        }).findFirst();
    }

    public List<PostDto> getPostsByAuthor(UUID author) {
        GetRequest request = GetRequest.newBuilder().setId(author.toString()).build();
        GetPostsResponse response = postClientService.GetPostByAuthorId(request);
        List<PostDto> posts = new ArrayList<>();
        for (GetPostResponse getPostsResponse : response.getPostsList()) {
            PostDto post = new PostDto();
            post.setId(UUID.fromString(getPostsResponse.getId()));
            post.setAuthor(getPostsResponse.getAuthor());
            post.setTitle(getPostsResponse.getTitle());
            post.setContent(getPostsResponse.getContent());
            post.setAuthorName(getPostsResponse.getAuthorName());
            posts.add(post);
        }
        return posts;
    }
    public List<PostDto> getPosts() {
        GetPostsResponse response = postClientService.GetAllPost();
        List<PostDto> posts = new ArrayList<>();
        for (GetPostResponse getPostsResponse : response.getPostsList()) {
            PostDto post = new PostDto();
            post.setId(UUID.fromString(getPostsResponse.getId()));
            post.setAuthor(getPostsResponse.getAuthor());
            post.setTitle(getPostsResponse.getTitle());
            post.setContent(getPostsResponse.getContent());
            post.setAuthorName(getPostsResponse.getAuthorName());
            posts.add(post);
        }
        return posts;
    }
    public List<PostDto> getPostsByEvent(UUID event) {
        GetRequest request = GetRequest.newBuilder().setId(event.toString()).build();
        GetPostsResponse response = postClientService.GetAllPostsByEventId(request);
        List<PostDto> posts = new ArrayList<>();
        for (GetPostResponse getPostsResponse : response.getPostsList()) {
            PostDto post = new PostDto();
            post.setId(UUID.fromString(getPostsResponse.getId()));
            post.setAuthor(getPostsResponse.getAuthor());
            post.setTitle(getPostsResponse.getTitle());
            post.setContent(getPostsResponse.getContent());
            post.setAuthorName(getPostsResponse.getAuthorName());
            posts.add(post);
        }
        return posts;
    }

}
