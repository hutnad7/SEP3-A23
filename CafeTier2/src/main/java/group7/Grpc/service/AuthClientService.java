package group7.Grpc.service;

import group7.protobuf.*;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import org.springframework.boot.autoconfigure.integration.IntegrationProperties;
import org.springframework.stereotype.Service;

@Service
public class AuthClientService {
    private final ManagedChannel channel;
    private final UserServiceGrpc.UserServiceBlockingStub stub;

    public AuthClientService(){
        String host = "localhost";
        int port = 5144;

        this.channel = ManagedChannelBuilder.forAddress(host, port)
                .usePlaintext()
                .build();
        this.stub = UserServiceGrpc.newBlockingStub(channel);
    }

    public CreateUserResponse createUser(CreateUserRequest request){
        return stub.createUser(request);
    }

    public CreateUserResponse loginUser(LoginRequest request){
        return stub.loginUser(request);
    }

    public void shutdown() {
        channel.shutdown();
    }
}
