package group7.Restful.service;

import group7.Grpc.service.UserClientService;
import group7.Grpc.dto.UserDto;
import group7.Restful.entity.User;
import group7.protobuf.GetUserResponse;
import group7.protobuf.GetUsersResponse;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;
import java.util.stream.Collectors;


@Service
public class UserService {

    private final List<User> users = new ArrayList();
    private final UserClientService userClientService;

    public UserService(UserClientService userClientService){this.userClientService = userClientService;}

    public List<User> getAllEntertainers() {
        GetUsersResponse response = userClientService.getAllEntertainers();
        List<User> users = new ArrayList<>();
        for(GetUserResponse getUserResponse : response.getUserList()){
            User user = new User();
            user.setId(UUID.fromString(getUserResponse.getId()));
            user.setFirstName(getUserResponse.getFirstName());
            user.setLastName(getUserResponse.getLastName());
            user.setDescription(getUserResponse.getDescription());
            user.setRole(getUserResponse.getRole());
            user.setUsername(getUserResponse.getUsername());
            users.add(user);
        }
        return users;
    }




    public List<User> getAllCafeOwners() {
        return this.users.stream()
                .filter(e -> e.getRole().equals("cafeOwner"))
                .collect(Collectors.toList());
    }

}
