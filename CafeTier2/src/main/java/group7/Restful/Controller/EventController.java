package group7.Restful.Controller;


import java.text.ParseException;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

import group7.Grpc.dto.EventDto;
import group7.Restful.entity.Event;
import group7.Restful.service.EventService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@CrossOrigin(
        origins = {"*"},
        allowedHeaders = {"*"},
        methods = {RequestMethod.GET, RequestMethod.POST, RequestMethod.PUT, RequestMethod.DELETE, RequestMethod.PATCH}
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

    @GetMapping({"/{id}"})
    public ResponseEntity<EventDto> getEventById(@PathVariable UUID id) {
        Optional<EventDto> eventOpt = this.eventService.getEventById(id);
        return eventOpt.isPresent() ? ResponseEntity.ok((EventDto)eventOpt.get()) : ResponseEntity.notFound().build();
    }

    @GetMapping({"/users/{id}"})
    public ResponseEntity<ArrayList<EventDto>> getEventByUserId(@PathVariable UUID id) {
        try {
            ArrayList<EventDto> eventOpt = this.eventService.getEventByUserId(id);
            return eventOpt!=null ? ResponseEntity.ok(eventOpt) : ResponseEntity.notFound().build();
        }
        catch (ParseException e){
            throw new IllegalArgumentException(e.toString());
        }
    }
    @GetMapping
    public ResponseEntity<List<Event>> getAllEvents() {
        return ResponseEntity.ok(this.eventService.getAllEvents());
    }

//    @PutMapping({"/{id}"})
//    public ResponseEntity<Event> updateEvent(@PathVariable UUID id, @RequestBody Event event) {
//        Optional<Event> updatedEventOpt = this.eventService.updateEvent(id, event);
//        return updatedEventOpt.isPresent() ? ResponseEntity.ok((Event)updatedEventOpt.get()) : ResponseEntity.notFound().build();
//    }

//    @DeleteMapping({"/{id}"})
//    public ResponseEntity<Void> deleteEvent(@PathVariable UUID id) {
//        this.eventService.deleteEvent(id);
//        return ResponseEntity.noContent().build();
//    }
    @PutMapping({"/{id}"})
    public ResponseEntity<Event> updateEvent(@PathVariable UUID id, @RequestBody Event event) {
//        Optional<Event> updatedEventOpt = this.eventService.updateEvent(id, event);
//        return updatedEventOpt.isPresent() ? ResponseEntity.ok((Event)updatedEventOpt.get()) : ResponseEntity.notFound().build();
        return null;
    }
    @CrossOrigin(
            origins = {"*"},
            allowedHeaders = {"*"},
            allowCredentials = "false",
            methods = {RequestMethod.PUT, RequestMethod.PATCH}
    )
    @GetMapping({"/state/{id}/{state}"})
    public ResponseEntity<Event> changeState(@PathVariable UUID id, @PathVariable String state){
        Event updatedEventOpt = null;
        switch (state){
            case "accepted":
                updatedEventOpt =  this.eventService.acceptState(id);
                break;
            case "refused":
                updatedEventOpt =  this.eventService.refuseEvent(id);
                break;
            case "reversed":
                updatedEventOpt =  this.eventService.reverseState(id);
                break;
        }
        return updatedEventOpt!=null ? ResponseEntity.ok(updatedEventOpt) : ResponseEntity.notFound().build();
    }

    @DeleteMapping({"/{id}"})
    public ResponseEntity<Void> deleteEvent(@PathVariable UUID id) {
//        this.eventService.deleteEvent(id);
//        return ResponseEntity.noContent().build();
        return null;
    }
}