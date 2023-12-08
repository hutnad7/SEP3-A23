package group7.Restful.Controller;

import group7.Restful.entity.User;
import group7.Restful.service.UserService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@CrossOrigin(
        origins = {"*"},
        allowedHeaders = {"*"},
        methods = {RequestMethod.GET, RequestMethod.POST}
)
@RestController
@RequestMapping({"/api/users"})
public class UserController {
    private final UserService userService;

    public UserController(UserService userService){
        this.userService = userService;
    }

    @GetMapping
    public ResponseEntity<List<User>> getAllEntertainers(){
        return ResponseEntity.ok(this.userService.getAllEntertainers());
    }

    @GetMapping()
    public ResponseEntity<List<User>> getAllCafeOwners(){
        return ResponseEntity.ok(this.userService.getAllCafeOwners());
    }
}
