package group7.Grpc.service;

import group7.protobuf.CreateEventRequest;
import group7.protobuf.EventServiceGrpc;
import net.devh.boot.grpc.client.inject.GrpcClient;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Service;

import java.util.Date;
@Service
public class EventRequestService {
    private final static Logger LOG = LoggerFactory.getLogger(EventRequestService.class);

    @GrpcClient("wo")
    EventServiceGrpc.EventServiceBlockingStub clientServiceStub; //syncronous communication

    public CreateEventRequest createEvent(String name, String description, String entertainer, String cafeOwner, String date) {
        LOG.info("Received request to create event with name: {}", name);
        CreateEventRequest eventRequest;
        try {
            eventRequest = CreateEventRequest.newBuilder()
                    .setName(name)
                    .setDescription(description)
                    .setEntertainer(entertainer)
                    .setCafeOwner(cafeOwner)
                    .setDate(date)
                    .build();
        } catch (Exception e) {
            LOG.error("Error in communication");
            return null;
        }

        LOG.debug("Received response: {}", eventRequest.toString());
        return eventRequest;
    }
}