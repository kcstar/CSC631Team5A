package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.ResponseLeave;
import core.NetworkManager;

public class RequestLeave extends GameRequest {
    private ResponseLeave responseLeave; // Responses

    public RequestLeave() {
        responses.add(responseLeave = new ResponseLeave());
    }

    @Override
    public void parse() throws IOException {
        // Parsing is not necessary for this request
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();

        responseLeave.setPlayer(player);
        NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseLeave);
    }
}