package group7.Restful.service;

import group7.Grpc.service.BookEventService;
import group7.Restful.entity.Book;
import group7.Restful.entity.Event;
import group7.protobuf.BookEventRequest;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;


public class BookService {
    private final List<Book> bookings = new ArrayList();

    private Long idCounter = 1L;

    public BookService() {}

    public Book createBook(Book booking) {
        BookEventService bookEventService = new BookEventService();
        bookEventService.bookEvent(booking.getId().toString(),booking.getFirstname(), booking.getLastname(), booking.getSits().toString());
        this.bookings.add(booking);
        return booking;
    }

    public List<Book> getAllBookings() {
        return this.bookings;
    }

    public Optional<Book> getBookById(Long id) {
        return this.bookings.stream().filter((e) -> {
            return e.getId().equals(id);
        }).findFirst();
    }

    public Optional<Book> updateBooking(Long id, Book booking) {
        Optional<Book> existingBookingOpt = this.getBookById(id);
        if (existingBookingOpt.isPresent()) {
            Book existingBooking = (Book)existingBookingOpt.get();
            existingBooking.setFirstname(booking.getFirstname());
            existingBooking.setLastname(booking.getLastname());
            existingBooking.setSits(booking.getSits());
            return Optional.of(existingBooking);
        } else {
            return Optional.empty();
        }
    }

    public void deleteBooking(Long id) {
        this.bookings.removeIf((e) -> {
            return e.getId().equals(id);
        });
    }
}
