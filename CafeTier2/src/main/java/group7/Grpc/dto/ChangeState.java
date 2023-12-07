package group7.Grpc.dto;

import lombok.Data;

import java.security.Guard;
import java.util.UUID;
@Data
public class ChangeState {
    private UUID id;
    private String state;

}
