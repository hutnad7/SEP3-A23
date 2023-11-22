package group7.Restful.Controller;


import java.util.List;
import java.util.Optional;

import group7.Restful.entity.Event;
import group7.Restful.service.EventService;
import group7.Restful.service.GrpcClientService;
import group7.protobuf.EventRequest;
import group7.protobuf.EventResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@CrossOrigin(
        origins = {"*"},
        allowedHeaders = {"*"},
        methods = {RequestMethod.GET, RequestMethod.POST, RequestMethod.PUT, RequestMethod.DELETE}
)
@RestController
@RequestMapping({"/api/events"})
public class EventController {
    private final EventService eventService;

    @Autowired
    private GrpcClientService grpcClientService; // Assuming you have a GrpcClientService to interact with gRPC

    @Autowired
    public EventController(EventService eventService) {
        this.eventService = eventService;
    }
//
//    @PostMapping
//    public ResponseEntity<Event> createEvent(@RequestBody Event event) {
//        return ResponseEntity.ok(this.eventService.createEvent(event));
//    }
    @PostMapping
    public ResponseEntity<Event> createEvent(@RequestBody Event event) {
    // Convert your Event entity to EventRequest (gRPC message)
    EventRequest grpcRequest = EventRequest.newBuilder()
            .setName(event.getName())
            .setDescription(event.getDescription())
            // other fields
            .build();

    // Call the gRPC service
    EventResponse grpcResponse = grpcClientService.createEvent(grpcRequest);

    // Process the response and create your entity to be returned
    Event createdEvent = new Event(
            // extract fields from grpcResponse or event
    );

    return ResponseEntity.ok(createdEvent);
}

    @GetMapping({"/{id}"})
    public ResponseEntity<Event> getEventById(@PathVariable Long id) {
        Optional<Event> eventOpt = this.eventService.getEventById(id);
        return eventOpt.isPresent() ? ResponseEntity.ok((Event)eventOpt.get()) : ResponseEntity.notFound().build();
    }

    @GetMapping
    public ResponseEntity<List<Event>> getAllEvents() {
        return ResponseEntity.ok(this.eventService.getAllEvents());
    }

    @PutMapping({"/{id}"})
    public ResponseEntity<Event> updateEvent(@PathVariable Long id, @RequestBody Event event) {
        Optional<Event> updatedEventOpt = this.eventService.updateEvent(id, event);
        return updatedEventOpt.isPresent() ? ResponseEntity.ok((Event)updatedEventOpt.get()) : ResponseEntity.notFound().build();
    }

    @DeleteMapping({"/{id}"})
    public ResponseEntity<Void> deleteEvent(@PathVariable Long id) {
        this.eventService.deleteEvent(id);
        return ResponseEntity.noContent().build();
    }
}
