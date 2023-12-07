package group7.Restful.Controller;

<<<<<<< HEAD
import group7.Restful.dto.PostDto;
=======
>>>>>>> 7c9ab47a80f9de9bbbc95ddfb895efbd1f1b8823
import group7.Restful.entity.Post;
import group7.Restful.service.PostService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;
import java.util.Optional;
import java.util.UUID;

@CrossOrigin(
        origins = {"*"},
        allowedHeaders = {"*"},
        methods = {RequestMethod.GET, RequestMethod.POST}
)

@RestController
@RequestMapping({"/api/posts"})
public class PostController {
    private final PostService postService;

    @Autowired
    public PostController(PostService postService){
        this.postService = postService;
    }

    @PostMapping
    public ResponseEntity<Post> createPost(@RequestBody Post post){
        return ResponseEntity.ok(this.postService.createPost(post));
    }

    @GetMapping({"/{id}"})
    public ResponseEntity<Post> getPostById(@PathVariable UUID id){
        Optional<Post> postOpt = this.postService.getPostById(id);
        return postOpt.isPresent() ? ResponseEntity.ok((Post)postOpt.get()) : ResponseEntity.notFound().build();
    }

    @GetMapping({"/users/{author}"})
    public ResponseEntity<List<PostDto>> getAllPostsByAuthor(@PathVariable UUID author){
        return ResponseEntity.ok(this.postService.getPostsByAuthor(author));
    }
    @GetMapping({"/events/{event}"})
    public ResponseEntity<List<PostDto>> getAllPostsByEvent(@PathVariable UUID event){
        return ResponseEntity.ok(this.postService.getPostsByEvent(event));
    }
    @GetMapping
    public ResponseEntity<List<PostDto>> getAllPosts(){
        return ResponseEntity.ok(this.postService.getPosts());
    }
}

