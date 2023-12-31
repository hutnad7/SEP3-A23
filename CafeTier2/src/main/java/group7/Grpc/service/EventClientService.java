package group7.Grpc.service;

import com.google.protobuf.Empty;
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

    public GetEventResponse getEventById(GetRequest request) {
        return stub.getEvent(request);
    }
   public group7.protobuf.GetEventResponse createEvent(group7.protobuf.CreateEventRequest request) {
        return stub.createEvent(request);
    }
    public GetEventsByUserResponse getEventsByUserId(GetRequest request) {
        return stub.getEventsByUser(request);
    }
   public GetEventResponse acceptEvent(GetRequest request) {
        return stub.acceptEvent(request);
    }
    public GetEventResponse refuseEvent(GetRequest request) {
        return stub.refuseEvent(request);
    }
    public GetEventResponse reverseState(GetRequest request) {

        return stub.reverseState(request);
    }


    public GetEventsResponse getAllEvents() {
        return stub.getAllEvents(Empty.getDefaultInstance());
    }

    public void shutdown() {
        channel.shutdown();
    }
}