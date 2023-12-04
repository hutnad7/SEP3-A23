package group7.Grpc.dto;

import com.google.inject.Guice;
import lombok.Data;

import java.security.Guard;
import java.util.UUID;
@Data
public class ChangeState {
    private UUID id;
    private String state;

}
