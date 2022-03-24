package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import networking.response.GameResponse;
import utility.Log;

/**
 * The RequestHeartbeat class is mainly used to release all pending responses
 * the client. Also used to keep the connection alive.
 */
public class RequestHeartbeat extends GameRequest {
    @Override
    public void parse() throws IOException {
        // Parsing is not necessary for this request
    }

    @Override
    public void doBusiness() throws Exception {
        for (GameResponse response : client.getUpdates()) {
            try {
                client.send(response);
            } catch (IOException ex) {
                Log.println_e(ex.getMessage());
            }
        }
    }
}
