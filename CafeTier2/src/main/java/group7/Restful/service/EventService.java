//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by FernFlower decompiler)
//

package group7.Restful.service;

import group7.Restful.entity.Event;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

import org.springframework.stereotype.Service;

@Service
public class EventService {
    private final List<Event> events = new ArrayList<>();

    public EventService() {
    }

    public Event createEvent(Event event) {
        this.events.add(event);

        return event;
    }

//    public Event createEvent(Event event) {
//        EventRequestService eventRequestService = new EventRequestService();
//        eventRequestService.createEvent(event.getName(), event.getDescription(), event.getEntertainerId().toString(), event.getCafeOwnerId().toString(), event.getDate());
//        System.out.println("Event sent to gRPC server");
//        this.events.add(event);
//        return event;
//    }


    public Optional<Event> getEventById(UUID id) {
        return this.events.stream().filter((e) -> {
            return e.getId().equals(id);
        }).findFirst();
    }

    public List<Event> getAllEvents() {
        return this.events;
    }

    public Optional<Event> updateEvent(UUID id, Event event) {
        Optional<Event> existingEventOpt = this.getEventById(id);
        if (existingEventOpt.isPresent()) {
            Event existingEvent = (Event)existingEventOpt.get();
            existingEvent.setName(event.getName());
            existingEvent.setDescription(event.getDescription());
            existingEvent.setEntertainerId(event.getEntertainerId());
            return Optional.of(existingEvent);
        } else {
            return Optional.empty();
        }
    }

    public void deleteEvent(UUID id) {
        this.events.removeIf((e) -> {
            return e.getId().equals(id);
        });
    }
}
