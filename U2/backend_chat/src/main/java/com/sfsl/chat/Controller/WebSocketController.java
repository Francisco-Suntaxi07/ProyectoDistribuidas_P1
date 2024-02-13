package com.sfsl.chat.Controller;

import com.sfsl.chat.Model.MessageDto;
import org.springframework.messaging.handler.annotation.DestinationVariable;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.stereotype.Controller;

@Controller
public class WebSocketController {

    @MessageMapping("/chat/{roomId}")
    @SendTo("/topic/{roomId}")
    public MessageDto chat (@DestinationVariable String roomId, MessageDto message){
        System.out.println(message);
        return new MessageDto(message.getMessage(), message.getUser());
    }
}
