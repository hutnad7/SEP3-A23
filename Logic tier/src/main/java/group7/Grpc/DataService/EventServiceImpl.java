package group7.Grpc.DataService;

import group7.protobuf.EventServiceGrpc;
import net.devh.boot.grpc.server.service.GrpcService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import group7.protobuf.Event;
import java.util.List;

@GrpcService
public class EventServiceImpl extends EventServiceGrpc.EventServiceImplBase {
    private final static Logger LOG =
            LoggerFactory.getLogger(EventServiceImpl.class);

    private final static List<Event> Events = List.of(
        Event.newBuilder().setId(1).setName("the shit").setDescription("").setEntertainer("the shitty guy").build()
    );


@Override
public void createEvent(com.google.protobuf.Int32Value request,
                        io.grpc.stub.StreamObserver<group7.protobuf.Event> responseObserver){
    LOG.info("Received request for event with id: {}", request.getValue());
    Event isEventPresent = Events.stream()
            .filter(findProduct -> findProduct.getId() == request.getValue())
            .findFirst()
            .orElseThrow(() -> new RuntimeException("Product not found"));
    LOG.info(isEventPresent.toString());
    responseObserver.onNext(isEventPresent);
    responseObserver.onCompleted();
}
}