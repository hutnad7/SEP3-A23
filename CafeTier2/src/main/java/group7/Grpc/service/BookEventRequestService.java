package group7.Grpc.service;

import group7.protobuf.BookEventRequest;
import group7.protobuf.EventServiceGrpc;
import net.devh.boot.grpc.client.inject.GrpcClient;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Service;

@Service
public class BookEventRequestService {
    private final static Logger LOG = LoggerFactory.getLogger(EventRequestService.class);

    @GrpcClient("EventProto")
    EventServiceGrpc.EventServiceBlockingStub clientServiceStub; //syncronous communication

    public BookEventRequest bookEvent(String userId, String eventId, String date, int numberOfPeople) {
        LOG.info("Received request to book event with userId: {}", userId);
        BookEventRequest bookEventRequest;
        try {
            bookEventRequest = BookEventRequest.newBuilder()
                    .setUserId(userId)
                    .setEventId(eventId)
                    .setDate(date)
                    .setNumerOfPeople(numberOfPeople)
                    .build();
        } catch (Exception e) {
            LOG.error("Error in communication");
            return null;
        }
        clientServiceStub.bookEvent(bookEventRequest);
        LOG.debug("Received response: {}", bookEventRequest.toString());
        return bookEventRequest;
    }
}
