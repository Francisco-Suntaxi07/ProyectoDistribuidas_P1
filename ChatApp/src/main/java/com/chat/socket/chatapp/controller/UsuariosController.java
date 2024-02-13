package com.chat.socket.chatapp.controller;

import com.chat.socket.chatapp.almacenamiento.Usuarios;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import java.util.Set;

@RestController
public class UsuariosController {

    @GetMapping("/registro/{nombreUsuario}")
    public ResponseEntity<Void> registro(@PathVariable String nombreUsuario) {
        try {
            Usuarios.getInstance().setUsuarios(nombreUsuario);
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }
        return ResponseEntity.ok().build();
    }

    @GetMapping("/buscarUsuarios")
    public Set<String> buscarTodos() {
        return  Usuarios.getInstance().getUsuarios();
    }
}
