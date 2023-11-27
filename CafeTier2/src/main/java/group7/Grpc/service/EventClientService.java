package group7.Grpc.service;

import group7.protobuf.*;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import org.springframework.stereotype.Service;

@Service
public class EventClientService {

    private final ManagedChannel channel;
    private final EventServiceGrpc.EventServiceBlockingStub stub;

    public EventClientService() {
        String host = "localhost"; // Specify the host
        int port = 5144;           // Specify the port

        this.channel = ManagedChannelBuilder.forAddress(host, port)
                .usePlaintext()
                .build();
        this.stub = EventServiceGrpc.newBlockingStub(channel);
    }
    public BookEventResponse bookEvent(BookEventRequest request) {
        return stub.bookEvent(request);
    }
   public CreateEventResponse createEvent(CreateEventRequest request) {
        return stub.createEvent(request);
    }

    public void shutdown() {
        channel.shutdown();
    }
}