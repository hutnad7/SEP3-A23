package group7.Grpc.Controller;

import group7.Grpc.service.EventClientService;
import group7.Restful.entity.Event;
import group7.Restful.service.EventService;
import group7.protobuf.CreateEventRequest;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.bind.annotation.*;

import java.util.UUID;

@RestController
@RequestMapping("/grpc/api")
public class EventRequestController {
    private final static Logger LOG = LoggerFactory.getLogger(EventRequestController.class);
    private EventService eventRequestService;

    public EventRequestController(EventService eventRequestService) {
        this.eventRequestService = eventRequestService;
    }

    @PostMapping("/events/")
    public String createEvent(@RequestBody Event event) {
        LOG.info("Received request to create event with name: {}", event.getName());

        return eventRequestService.createEvent(event).toString();
    }
}
