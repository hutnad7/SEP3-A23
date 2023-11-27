package group7.Restful.Controller;

import java.util.List;
import java.util.Optional;

import group7.Restful.entity.Book;
import group7.Restful.entity.Event;
import group7.Restful.service.BookService;
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
@RequestMapping({"/api/books"})
public class BookController {

    private final BookService bookService;

    @Autowired
    public BookController(BookService bookService){
        this.bookService = bookService;
    }

    @PostMapping
    public ResponseEntity<Book> createBook(@RequestBody Book book) {
        return ResponseEntity.ok(this.bookService.createBook(book));
    }

    @GetMapping({"/{id}"})
    public ResponseEntity<Book> getBookById(@PathVariable Long id) {
        Optional<Book> bookOpt = this.bookService.getBookById(id);
        return bookOpt.isPresent() ? ResponseEntity.ok((Book)bookOpt.get()) : ResponseEntity.notFound().build();
    }

    @GetMapping
    public ResponseEntity<List<Book>> getAllBooks() {
        return ResponseEntity.ok(this.bookService.getAllBookings());
    }

    @PutMapping({"/{id}"})
    public ResponseEntity<Book> updateBook(@PathVariable Long id, @RequestBody Book book) {
        Optional<Book> updatedEventOpt = this.bookService.updateBooking(id, book);
        return updatedEventOpt.isPresent() ? ResponseEntity.ok((Book)updatedEventOpt.get()) : ResponseEntity.notFound().build();
    }

    @DeleteMapping({"/{id}"})
    public ResponseEntity<Void> deleteBooking(@PathVariable Long id) {
        this.bookService.deleteBooking(id);
        return ResponseEntity.ok().build();
    }
}
