package com.chat.socket.chatapp.controller;

import com.chat.socket.chatapp.almacenamiento.Usuarios;
import com.chat.socket.chatapp.model.MensajeModel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.messaging.handler.annotation.DestinationVariable;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.simp.SimpMessagingTemplate;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class MensajeController {

    @Autowired
    private SimpMessagingTemplate simpMessagingTemplate;

    @MessageMapping("/chat/{hacia}")
    public void enviarMensaje(@DestinationVariable String receptor, MensajeModel mensaje) {
        System.out.println("Envío de mensaje: " + mensaje + " hacia " + receptor);
        boolean usuarioExistente = Usuarios.getInstance().getUsuarios().contains(receptor);
        if (usuarioExistente) {
            simpMessagingTemplate.convertAndSend("/server/mensajes/" + receptor, mensaje);
        }
    }
}
