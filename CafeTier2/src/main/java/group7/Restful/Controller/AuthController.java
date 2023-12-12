package group7.Restful.Controller;
import group7.Grpc.dto.UserLoginDto;
import group7.Restful.entity.User;
import group7.Restful.service.AuthService;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;


import javax.crypto.spec.SecretKeySpec;
import java.security.Key;
import java.util.Base64;
import java.util.Date;

@CrossOrigin(
        origins = {"*"},
        allowedHeaders = {"*"},
        methods = {RequestMethod.GET, RequestMethod.POST, RequestMethod.PUT, RequestMethod.DELETE}
)
@RestController
@RequestMapping("/api/auth")
public class AuthController {
//    @Value("${jwt.secret}")

    private final AuthService authService;

    @Autowired
    public AuthController(AuthService authService) {
        this.authService = authService;
    }

    @PostMapping("/register")
    public ResponseEntity<String> registerUser(@RequestBody User user) {
        User createdUser = authService.createUser(user);

        String jwt = authService.generateJwtToken(createdUser);

        return ResponseEntity.ok(jwt);
    }

    @PostMapping("/login")
    public ResponseEntity<?> loginUser(@RequestBody UserLoginDto userLoginDto) {
        try {
            User foundUser = authService.loginUser(userLoginDto);

            String jwt = authService.generateJwtToken(foundUser);

            return ResponseEntity.ok(jwt);
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("User not found");
        }
    }


}

