package group7.Grpc.Controller;

import group7.Grpc.service.BookEventRequestService;
import group7.Restful.entity.Booking;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

public class BookRequestController {
    private final static Logger LOG = LoggerFactory.getLogger(EventRequestController.class);
    private final BookEventRequestService bookEventService;
    public BookRequestController(BookEventRequestService bookEventService) {
        this.bookEventService = bookEventService;
    }

    @PostMapping("/bookings/")
    public String bookEvent(@RequestBody Booking book) {
        LOG.info("Received request to book event with id: {}", book.getId());
        return bookEventService.bookEvent(book);
    }
}
