package group7.Grpc.service;

import group7.protobuf.BookEventRequest;
import group7.protobuf.EventServiceGrpc;
import net.devh.boot.grpc.client.inject.GrpcClient;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Service;

@Service
public class BookEventService {
    private final static Logger LOG = LoggerFactory.getLogger(EventRequestService.class);

    @GrpcClient("wo")
    EventServiceGrpc.EventServiceBlockingStub clientServiceStub; //syncronous communication

    public BookEventRequest bookEvent(String id, String firstName, String lastName, String sits){
        LOG.info("Received request to book event with name: {}", firstName);
        BookEventRequest bookEventRequest;
        try {
            bookEventRequest = BookEventRequest.newBuilder()
                    .setId(id)
                    .setFirstName(firstName)
                    .setLastName(lastName)
                    .setSits(sits)
                    .build();
        } catch (Exception e) {
            LOG.error("Error in communication");
            return null;
        }

        LOG.debug("Received response: {}", bookEventRequest.toString());
        return bookEventRequest;
    }
}
