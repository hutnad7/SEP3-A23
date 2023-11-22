//package group7.Grpc.DataService;
//
//import group7.protobuf.*;
//import net.devh.boot.grpc.server.service.GrpcService;
//import org.slf4j.Logger;
//import org.slf4j.LoggerFactory;
//import io.grpc.stub.StreamObserver;
//
//import java.time.format.DateTimeFormatter;
//import java.util.List;
//
//@GrpcService
//public class EventServiceImpl extends EventServiceGrpc.EventServiceImplBase {
//    private final static Logger LOG = LoggerFactory.getLogger(EventServiceImpl.class);
//    private final static DateTimeFormatter DATE_FORMATTER = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss.SSSSSS");
//
//    private final static List<EventRequest> EVENTS = List.of(
//            EventRequest.newBuilder()
//                    .setName("Full Chicken")
//                    .setDescription("Description for Full Chicken")
//                    .setEntertainer("2ef5bf7b-11a9-41cc-aed0-fe37e3b46e62")
//                    .setCafeOwner("0d8d4874-3b70-445c-98ef-eb9c2306ba55") // Example CafeOwner
//                    .setDate("2023-11-07 16:08:17.932232") // Example Date
//                    .build()
////    );
//
//    @Override
//    public void createEvent(EventRequest request,
//                            StreamObserver<EventResponse> responseObserver) {
//        LOG.info("Received request to create event with name: {}", request.getName());
//        EventRequest isEventPresent = EVENTS.stream()
//                .filter(findEvent -> findEvent.getName().equals(request.getName()))
//                .findFirst()
//                .orElseThrow(() -> new RuntimeException("Event not found"));
//        LOG.info(isEventPresent.toString());
//        responseObserver.onCompleted();
//    }
//}
package group7.Grpc.DataService;

import group7.protobuf.*;
import net.devh.boot.grpc.server.service.GrpcService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import io.grpc.stub.StreamObserver;

import java.time.format.DateTimeFormatter;
import java.util.List;

@GrpcService
public class EventServiceImpl extends EventServiceGrpc.EventServiceImplBase {
    private final static Logger LOG = LoggerFactory.getLogger(EventServiceImpl.class);

    @Override
    public void createEvent(EventRequest request, StreamObserver<EventResponse> responseObserver) {
        LOG.info("Received request to create event: {}", request.getName());

        // Here you would typically handle the request, such as saving the event to a database.
        // For demonstration, we're just echoing back the received information.

        EventResponse response = EventResponse.newBuilder()
                .setId("1") // Assuming an ID is generated for the new event
                .setName(request.getName())
                .setDescription(request.getDescription())
                .setEntertainer(request.getEntertainer())
                .build();

        responseObserver.onNext(response);
        responseObserver.onCompleted();
    }
}