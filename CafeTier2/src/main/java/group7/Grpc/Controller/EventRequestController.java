//package group7.Grpc.Controller;
//
//import group7.Grpc.service.EventRequestService;
//import group7.protobuf.EventRequest;
//import org.slf4j.Logger;
//import org.slf4j.LoggerFactory;
//import org.springframework.web.bind.annotation.GetMapping;
//import org.springframework.web.bind.annotation.PathVariable;
//import org.springframework.web.bind.annotation.RequestMapping;
//import org.springframework.web.bind.annotation.RestController;
//
//@RestController
//@RequestMapping("/grpc/api")
//public class EventRequestController {
//    private final static Logger LOG = LoggerFactory.getLogger(EventRequestController.class);
//    private EventRequestService eventRequestService;
//
//    public EventRequestController(EventRequestService eventRequestService) {
//        this.eventRequestService = eventRequestService;
//    }
//
//    @GetMapping("/events/{name}/{description}/{entertainer}/{cafeOwner}/{date}")
//    public String createEvent(@PathVariable("name")String name, @PathVariable("description")String description, @PathVariable("entertainer")String entertainer, @PathVariable("cafeOwner")String cafeOwner, @PathVariable("date")String date){
//        LOG.info("Received request to create event with name: {}", name);
//        EventRequest result = eventRequestService.createEvent(name, description, entertainer, cafeOwner, date);
//        if(result == null){
//            return "Event not found";
//        }
//        LOG.info(result.toString());
//        return eventRequestService.createEvent(name, description, entertainer, cafeOwner, date).toString();
//    }
//}
