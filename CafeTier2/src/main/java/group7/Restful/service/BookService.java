package group7.Restful.service;

import group7.Grpc.service.EventClientService;
import group7.Restful.entity.Booking;
import group7.protobuf.BookEventRequest;
import group7.protobuf.BookEventResponse;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

@Service
public class BookService {
    private final List<Booking> bookings = new ArrayList();

    private final EventClientService eventClientService;
    private Long idCounter = 1L;

    public BookService(EventClientService eventClientService) {
        this.eventClientService = eventClientService;
    }

    public Booking createBook(Booking booking) {
        BookEventRequest request = BookEventRequest.newBuilder().setUserId(booking.getUserId().toString()).setEventId(booking.getEventId().toString()).setDate(booking.getCreationDate()).setNumerOfPeople(booking.getNumberOfPeople()).build();

        BookEventResponse response = eventClientService.bookEvent(request);
        Booking b = new Booking(UUID.fromString(response.getUserId()),UUID.fromString(response.getEventId()),response.getDate(),response.getNumerOfPeople());
        return booking;
    }

    public List<Booking> getAllBookings() {
        return this.bookings;
    }

  /*  public Optional<Booking> getBookById(Long id) {
        return this.bookings.stream().filter((e) -> {
            return e.getId().equals(id);
        }).findFirst();
    }*/

  /*  public Optional<Booking> updateBooking(Long id, Booking booking) {
        Optional<Booking> existingBookingOpt = this.getBookById(id);
        if (existingBookingOpt.isPresent()) {
            Booking existingBooking = (Booking)existingBookingOpt.get();
            existingBooking.setFirstname(booking.getFirstname());
            existingBooking.setLastname(booking.getLastname());
            existingBooking.setSits(booking.getSits());
            return Optional.of(existingBooking);
        } else {
            return Optional.empty();
        }
    }*/

   /* public void deleteBooking(Long id) {
        this.bookings.removeIf((e) -> {
            return e.getId().equals(id);
        });
    }*/
}
