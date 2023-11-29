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
import group7.protobuf.GetEventResponse;
import group7.protobuf.GetEventsResponse;
import org.springframework.stereotype.Service;

@Service
public class EventService {
    private final EventClientService eventClientService;

    public EventService(EventClientService eventClientService) {
        this.eventClientService = eventClientService;
    }

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

        return e;
    }

    public List<Event> getAllEvents() {
        GetEventsResponse response = eventClientService.getAllEvents();

        List<Event> events = new ArrayList<>();
        for (GetEventResponse grpcEvent : response.getEventList()) {
            // Assuming you have a method to convert from EventProtoMessage to Event
            Event event = convertToEvent(grpcEvent);
            events.add(event);
        }

        return events;
    }

//    public Optional<Event> getEventById(UUID id) {
//        return this.events.stream().filter((e) -> {
//            return e.getId().equals(id);
//        }).findFirst();
//    }

//    public Optional<Event> updateEvent(UUID id, Event event) {
//        Optional<Event> existingEventOpt = this.getEventById(id);
//        if (existingEventOpt.isPresent()) {
//            Event existingEvent = (Event)existingEventOpt.get();
//            existingEvent.setName(event.getName());
//            existingEvent.setDescription(event.getDescription());
//            existingEvent.setEntertainerId(event.getEntertainerId());
//            return Optional.of(existingEvent);
//        } else {
//            return Optional.empty();
//        }
//    }
//
//    public void deleteEvent(UUID id) {
//        this.events.removeIf((e) -> {
//            return e.getId().equals(id);
//        });
//    }

    // Method to convert from generated proto message to your Event class
    private Event convertToEvent(GetEventResponse event) {
        return new Event(
                UUID.fromString(event.getId()),
                event.getName(),
                event.getDescription(),
                UUID.fromString(event.getEntertainer()),
                UUID.fromString(event.getCafeOwner()),
                event.getDate(),
                event.getAvailablePlaces()
        );
    }
}
