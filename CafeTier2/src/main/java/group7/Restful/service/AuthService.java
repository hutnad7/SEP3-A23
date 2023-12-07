package group7.Restful.service;


import group7.Grpc.service.AuthClientService;
import group7.Restful.dto.UserLoginDto;
import group7.Restful.entity.User;
import group7.protobuf.*;
import org.springframework.stereotype.Service;

import java.util.UUID;

@Service
public class AuthService {

    private final AuthClientService authClientService;

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
}
