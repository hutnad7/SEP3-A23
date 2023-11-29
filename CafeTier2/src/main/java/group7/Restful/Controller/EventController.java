package group7.Restful.Controller;


import java.util.List;
import java.util.Optional;
import java.util.UUID;

import group7.Restful.entity.Event;
import group7.Restful.service.EventService;
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
    public EventController(EventService eventService) {
        this.eventService = eventService;
    }

    @PostMapping
    public ResponseEntity<Event> createEvent(@RequestBody Event event) {
        return ResponseEntity.ok(this.eventService.createEvent(event));
    }

//    @GetMapping({"/{id}"})
//    public ResponseEntity<Event> getEventById(@PathVariable UUID id) {
//        Optional<Event> eventOpt = this.eventService.getEventById(id);
//        return eventOpt.isPresent() ? ResponseEntity.ok((Event)eventOpt.get()) : ResponseEntity.notFound().build();
//    }

    @GetMapping
    public ResponseEntity<List<Event>> getAllEvents() {
        return ResponseEntity.ok(this.eventService.getAllEvents());
    }

//    @PutMapping({"/{id}"})
//    public ResponseEntity<Event> updateEvent(@PathVariable UUID id, @RequestBody Event event) {
//        Optional<Event> updatedEventOpt = this.eventService.updateEvent(id, event);
//        return updatedEventOpt.isPresent() ? ResponseEntity.ok((Event)updatedEventOpt.get()) : ResponseEntity.notFound().build();
//    }
//
//    @DeleteMapping({"/{id}"})
//    public ResponseEntity<Void> deleteEvent(@PathVariable UUID id) {
//        this.eventService.deleteEvent(id);
//        return ResponseEntity.noContent().build();
//    }
}