//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by FernFlower decompiler)
//

package group7.Restful.service;

import com.google.type.DateTime;
import group7.Grpc.dto.EventDto;
import group7.Grpc.service.EventClientService;
import group7.Restful.entity.Event;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

import group7.protobuf.CreateEventRequest;
import group7.protobuf.*;
import org.springframework.stereotype.Service;

@Service
public class EventService {


    private final List<Event> Events = new ArrayList<>();
    private final EventClientService eventClientService;

    public EventService(EventClientService eventClientService) {
        this.eventClientService = eventClientService;
    }

    public Event createEvent(Event event) {
        DateFormat dateFormat = new SimpleDateFormat("MM/dd/yyyy hh:mm");
      /*  try{
        if(dateFormat.parse(event.getStartDate()).getSeconds() > dateFormat.parse(event.getEndDate()).getSeconds()){
            throw new IllegalArgumentException("Start date must be before end date");
        }}
        catch (ParseException e){
            throw new IllegalArgumentException(e.toString());
        }*/
        CreateEventRequest request = CreateEventRequest.newBuilder().setAvailablePlaces(event.getAvailablePlaces())
                .setCafeOwner(event.getCafeOwnerId().toString()).setEntertainer(event.getEntertainerId().toString())
                .setStartDate(event.getStartDate()).setEndDate(event.getEndDate()).setName(event.getName())
                .setDescription(event.getDescription()).build();
        GetEventResponse response = eventClientService.createEvent(request);
        Event e = new Event(){
            {
                setId(UUID.fromString(response.getId()));
                setName(response.getName());
                setDescription(response.getDescription());
                setEntertainerId(UUID.fromString(response.getEntertainer()));
                setStartDate(response.getStartDate());
                setEndDate(response.getEndDate());
                setAvailablePlaces(response.getAvailablePlaces());
                setCafeOwnerId(UUID.fromString(response.getCafeOwner()));
                setStatus(response.getState());
            }
        };

        return e;
        }

    public Event acceptState(UUID id){
        GetEventResponse response = eventClientService.acceptEvent(GetRequest.newBuilder().setId(id.toString()).build());
        Event e = new Event(){
            {
                setId(UUID.fromString(response.getId()));
                setName(response.getName());
                setDescription(response.getDescription());
                setEntertainerId(UUID.fromString(response.getEntertainer()));
                setStartDate(response.getStartDate());
                setEndDate(response.getEndDate());
                setAvailablePlaces(response.getAvailablePlaces());
                setCafeOwnerId(UUID.fromString(response.getCafeOwner()));
                 setStatus(response.getState());
            }
        };
        return e;
    }
    public Event refuseEvent(UUID id){
        GetEventResponse response = eventClientService.refuseEvent(GetRequest.newBuilder().setId(id.toString()).build());
        Event e = new Event(){
            {
                setId(UUID.fromString(response.getId()));
                setName(response.getName());
                setDescription(response.getDescription());
                setEntertainerId(UUID.fromString(response.getEntertainer()));
                setStartDate(response.getStartDate());
                setEndDate(response.getEndDate());
                setAvailablePlaces(response.getAvailablePlaces());
                setCafeOwnerId(UUID.fromString(response.getCafeOwner()));
                setStatus(response.getState());
            }
        };
        return e;
    }
    public Event reverseState(UUID id){
        GetEventResponse response = eventClientService.reverseState(GetRequest.newBuilder().setId(id.toString()).build());
        Event e = new Event(){
            {
                setId(UUID.fromString(response.getId()));
                setName(response.getName());
                setDescription(response.getDescription());
                setEntertainerId(UUID.fromString(response.getEntertainer()));
                setStartDate(response.getStartDate());
                setEndDate(response.getEndDate());
                setAvailablePlaces(response.getAvailablePlaces());
                setCafeOwnerId(UUID.fromString(response.getCafeOwner()));
                setStatus(response.getState());
            }
        };
        return e;
    }
    public ArrayList<EventDto> getEventByUserId(UUID id) throws ParseException {
        GetRequest request = GetRequest.newBuilder().setId(id.toString()).build();
        GetEventsByUserResponse response = eventClientService.getEventsByUserId(request);
        ArrayList<EventDto> events = new ArrayList<>();
        SimpleDateFormat parser = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS'Z'");
        for (GetEventResponse e : response.getEventsList()) {
            EventDto event = new EventDto() {
                {
                    setId(UUID.fromString(e.getId()));
                    setName(e.getName());
                    setDescription(e.getDescription());
                    setEntertainerId(UUID.fromString(e.getEntertainerId()));
                    setStartDate(e.getStartDate());
                    setEndDate(e.getEndDate());
                    setAvailablePlaces(e.getAvailablePlaces());
                    setCafeOwnerId(UUID.fromString(e.getCafeOwnerId()));
                    setStatus(e.getState());
                    setCafeOwnerName(e.getCafeOwner());
                    setEntertainerName(e.getEntertainer());
                }
            };
            events.add(event);
        }
        return events;
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

    public Optional<EventDto> getEventById(UUID id) {
        GetRequest request = GetRequest.newBuilder().setId(id.toString()).build();
        GetEventResponse response = eventClientService.getEventById(request);
        EventDto event = new EventDto() {
            {
                setId(UUID.fromString(response.getId()));
                setName(response.getName());
                setDescription(response.getDescription());
                setEntertainerId(UUID.fromString(response.getEntertainerId()));
                setStartDate(response.getStartDate());
                setEndDate(response.getEndDate());
                setAvailablePlaces(response.getAvailablePlaces());
                setCafeOwnerId(UUID.fromString(response.getCafeOwnerId()));
                setStatus(response.getState());
                setCafeOwnerName(response.getCafeOwner());
                setEntertainerName(response.getEntertainer());
            }
        };
        return Optional.of(event);
    }

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
                UUID.fromString(event.getEntertainerId()),
                UUID.fromString(event.getCafeOwnerId()),
                event.getStartDate(),
                event.getEndDate(),
                event.getState(),
                event.getAvailablePlaces()
        );
    }
}
