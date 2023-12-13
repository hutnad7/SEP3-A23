package group7.Grpc.service;
import com.google.protobuf.Empty;
import group7.protobuf.*;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import net.devh.boot.grpc.client.inject.GrpcClient;
import org.springframework.stereotype.Service;

@Service
public class UserClientService {
    private final ManagedChannel channel;

    @GrpcClient("UserProto")
    UserServiceGrpc.UserServiceBlockingStub stub;

    public UserClientService() {
        String host = "localhost"; // Specify the host
        int port = 5144;           // Specify the port

        this.channel = ManagedChannelBuilder.forAddress(host, port)
                .usePlaintext()
                .build();
        this.stub = UserServiceGrpc.newBlockingStub(channel);
    }

    public GetUsersResponse getAllEntertainers() {
        return stub.getAllEntertainers(Empty.getDefaultInstance());
    }
    public void shutdown() {
        channel.shutdown();
    }
}
