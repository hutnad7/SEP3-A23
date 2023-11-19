 package group7.Grpc.DataService;

import group7.protobuf.EventRequest;
import group7.protobuf.EventResponse;
import io.grpc.stub.StreamObserver;
import group7.protobuf.EventServiceGrpc;
import net.devh.boot.grpc.server.service.GrpcService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import java.util.List;

@GrpcService
public class EventServiceImpl extends EventServiceGrpc.EventServiceImplBase {
    private final static Logger LOG =
            LoggerFactory.getLogger(EventServiceImpl.class);

    private final static List<EventRequest> EVENTS = List.of(
            EventRequest.newBuilder()
                    .setName("Full Chicken")
                    .setDescription("Description for Full Chicken")
                    .setEntertainer("Full Chicken from Poland")
                    .setCafeOwner("CafeOwner1") // Example CafeOwner
                    .setDate("2023-11-07 16:08:17.932232") // Example Date
                    .build(),
            EventRequest.newBuilder()
                    .setName("Chicken Breast")
                    .setDescription("Description for Chicken Breast")
                    .setEntertainer("Chicken Breast from Poland")
                    .setCafeOwner("CafeOwner2") // Example CafeOwner
                    .setDate("2023-11-08 17:09:18.933333") // Example Date
                    .build()
    );


    @Override
    public void createEvent(EventRequest request,
                            StreamObserver<EventResponse> responseObserver) {
        LOG.info("Received request to create event with name: {}", request.getName());
        EventRequest isEventPresent = EVENTS.stream()
                .filter(findEvent -> findEvent.getName().equals(request.getName()))
                .findFirst()
                .orElseThrow(() -> new RuntimeException("Event not found"));
        LOG.info(isEventPresent.toString());
    }
}