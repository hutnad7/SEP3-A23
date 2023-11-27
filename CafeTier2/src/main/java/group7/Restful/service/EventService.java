//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by FernFlower decompiler)
//

package group7.Restful.service;

import group7.Grpc.service.EventClientService;
import group7.Restful.entity.Event;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;


import group7.protobuf.CreateEventRequest;
import group7.protobuf.CreateEventResponse;
import org.springframework.stereotype.Service;

@Service
public class EventService {


    private final List<Event> events = new ArrayList<>();
    private final EventClientService eventClientService;

    public EventService(EventClientService eventClientService) {
        this.eventClientService = eventClientService;
    }

//    public Event createEvent(Event event) {
//        this.events.add(event);
//
//        return event;


    public Event createEvent(Event event) {
        CreateEventRequest request = CreateEventRequest.newBuilder().setAvailablePlaces(event.getAvailablePlaces()).setCafeOwner(event.getCafeOwnerId().toString()).setEntertainer(event.getEntertainerId().toString()).setDate(event.getDate()).setName(event.getName()).setDescription(event.getDescription()).build();
        CreateEventResponse response = eventClientService.createEvent(request);
        Event e = new Event(){
            {
                setId(UUID.fromString(response.getId()));
                setName(response.getName());
                setDescription(response.getDescription());
                setEntertainerId(UUID.fromString(response.getEntertainer()));
            }
        };
        System.out.println("Event sent to gRPC server");
        return e;
    }


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
