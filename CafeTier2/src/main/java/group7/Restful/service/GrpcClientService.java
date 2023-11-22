//package group7.Restful.service;
//
//import group7.protobuf.EventRequest;
//import group7.protobuf.EventResponse;
//import group7.protobuf.EventServiceGrpc;
//import io.grpc.ManagedChannel;
//import io.grpc.ManagedChannelBuilder;
//import org.springframework.stereotype.Service;
//
//@Service
//public class GrpcClientService {
//
//    private final ManagedChannel channel;
//    private final EventServiceGrpc.EventServiceBlockingStub stub;
//
//    public GrpcClientService() {
//        String host = "localhost"; // Specify the host
//        int port = 9090;           // Specify the port
//
//        this.channel = ManagedChannelBuilder.forAddress(host, port)
//                .usePlaintext()
//                .build();
//        this.stub = EventServiceGrpc.newBlockingStub(channel);
//    }
//
//    public EventResponse createEvent(EventRequest request) {
//        return stub.createEvent(request);
//    }
//
//    public void shutdown() {
//        channel.shutdown();
//    }
//}