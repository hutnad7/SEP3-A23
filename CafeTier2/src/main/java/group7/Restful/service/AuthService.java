package group7.Restful.service;


import group7.Grpc.service.AuthClientService;
import group7.Grpc.dto.UserLoginDto;
import group7.Restful.entity.User;
import group7.protobuf.*;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import org.springframework.stereotype.Service;

import javax.crypto.spec.SecretKeySpec;
import java.security.Key;
import java.util.Base64;
import java.util.Date;
import java.util.UUID;

@Service
public class AuthService {

    private final AuthClientService authClientService;
    private String jwtSecret = "7KB9b5NLCZ5yZ1rV3I2hM9EvygH5EM8c6K2E7CQqOAm48B9+pX78Upgm7YL8Nk+JKUp7SbJkObiN9VZ7mpRxuWU6+uZOjpA9ZS5YDfn3Z2vhYH3QYh9PrB2UTh88Df";

    public AuthService (AuthClientService authClientService) {
        this.authClientService = authClientService;
    }

    public User createUser(User user){
        CreateUserRequest request= CreateUserRequest
                .newBuilder()
                .setFisrtName(user.getFirstName())
                .setLastName(user.getLastName())
                .setUsername(user.getUsername())
                .setEmail(user.getEmail())
                .setRole(user.getRole())
                .setPassword(user.getPassword())
                .build();

        CreateUserResponse response = authClientService.createUser(request);

        return new User(){
            {
                setId(UUID.fromString(response.getId()));
                setFirstName(response.getFisrtName());
                setLastName(response.getLastName());
                setUsername(response.getUsername());
                setEmail(response.getEmail());
                setRole(response.getRole());
            }
        };
    }


    public User loginUser(UserLoginDto loginDto){
        LoginRequest request = LoginRequest
                .newBuilder()
                .setEmail(loginDto.getEmail())
                .setPassword(loginDto.getPassword())
                .build();

        CreateUserResponse response = authClientService.loginUser(request);

        return new User(){
            {
                setId(UUID.fromString(response.getId()));
                setFirstName(response.getFisrtName());
                setLastName(response.getLastName());
                setUsername(response.getUsername());
                setEmail(response.getEmail());
                setRole(response.getRole());
            }
        };
    }
    public String generateJwtToken(User user) {
        long expirationMs = 604800000; // 7 days
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
