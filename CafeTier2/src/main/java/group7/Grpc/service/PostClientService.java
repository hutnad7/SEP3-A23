package group7.Grpc.service;

import group7.protobuf.CreatePostRequest;
import group7.protobuf.CreatePostResponse;
import group7.protobuf.PostServiceGrpc;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import net.devh.boot.grpc.client.inject.GrpcClient;
import org.springframework.stereotype.Service;

@Service
public class PostClientService {
    private final ManagedChannel channel;

    @GrpcClient("EventProto")
    PostServiceGrpc.PostServiceBlockingStub stub;

    public PostClientService() {
        String host = "localhost"; // Specify the host
        int port = 5144;           // Specify the port

        this.channel = ManagedChannelBuilder.forAddress(host, port)
                .usePlaintext()
                .build();
        this.stub = PostServiceGrpc.newBlockingStub(channel);
    }

    public CreatePostResponse createPost(CreatePostRequest request) {
        return stub.createPost(request);
    }

    public void shutdown() {
        channel.shutdown();
    }


}
