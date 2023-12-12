package group7.Restful.service;

import group7.Grpc.service.UserClientService;
import group7.Restful.dto.UserDto;
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

    public List<UserDto> getAllUsers() {
        GetUsersResponse response = userClientService.getAllUsers();
        List<UserDto> users = new ArrayList<>();
        for(GetUserResponse getUserResponse : response.getUserList()){
            UserDto user = new UserDto();
            user.setId(UUID.fromString(getUserResponse.getId()));
            user.setFirstName(getUserResponse.getFirstName());
            user.setLastName(getUserResponse.getLastName());
            user.setDescription(getUserResponse.getDescription());
            user.setAddress(getUserResponse.getAddress());
            user.setRole(getUserResponse.getRole());
            users.add(user);
        }
        return users;
    }

    public List<User> getAllEntertainers() {
        return this.users.stream()
                .filter(e -> e.getRole().equals("entertainer"))
                .collect(Collectors.toList());
    }


    public List<User> getAllCafeOwners() {
        return this.users.stream()
                .filter(e -> e.getRole().equals("cafeOwner"))
                .collect(Collectors.toList());
    }

}
