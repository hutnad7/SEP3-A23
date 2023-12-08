package group7.Restful.Controller;
import group7.Restful.dto.UserLoginDto;
import group7.Restful.entity.User;
import group7.Restful.service.AuthService;
import io.jsonwebtoken.Claims;
import java.lang.Object;
import io.jsonwebtoken.JwtBuilder;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import io.jsonwebtoken.security.Keys;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;


import javax.crypto.spec.SecretKeySpec;
import java.security.Key;
import java.util.ArrayList;
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
    private String jwtSecret = "7KB9b5NLCZ5yZ1rV3I2hM9EvygH5EM8c6K2E7CQqOAm48B9+pX78Upgm7YL8Nk+JKUp7SbJkObiN9VZ7mpRxuWU6+uZOjpA9ZS5YDfn3Z2vhYH3QYh9PrB2UTh88Df";

    private final AuthService authService;

    @Autowired
    public AuthController(AuthService authService) {
        this.authService = authService;
    }

    @PostMapping("/register")
    public ResponseEntity<String> registerUser(@RequestBody User user) {
        User createdUser = authService.createUser(user);

        String jwt = generateJwtToken(createdUser);

        return ResponseEntity.ok(jwt);
    }

    @PostMapping("/login")
    public ResponseEntity<?> loginUser(@RequestBody UserLoginDto userLoginDto) {
        try {
            User foundUser = authService.loginUser(userLoginDto);

            String jwt = generateJwtToken(foundUser);

            return ResponseEntity.ok(jwt);
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("User not found");
        }
    }

    private String generateJwtToken(User user) {
        long expirationMs = 360000000; // 1 hour
        Date now = new Date();
        Date expiration = new Date(now.getTime() + expirationMs);
        Key hmacKey = new SecretKeySpec(Base64.getDecoder().decode(jwtSecret),
                SignatureAlgorithm.HS512.getJcaName());
        return Jwts.builder()
                .setSubject(user.getEmail())
                .setHeaderParam("typ", "JWT")
                .claim("role", user.getRole())
                .claim("firstName", user.getFirstName())
                .claim("lastName", user.getLastName())
                .claim("id", user.getId())
                .setIssuedAt(now)
                .setExpiration(expiration)
                .signWith(hmacKey)
                .compact();
    }
}

