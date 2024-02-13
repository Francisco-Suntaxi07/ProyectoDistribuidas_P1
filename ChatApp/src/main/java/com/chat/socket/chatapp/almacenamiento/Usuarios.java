package com.chat.socket.chatapp.almacenamiento;

import java.util.HashSet;
import java.util.Set;

public class Usuarios {
    private static Usuarios instance;
    private Set<String> usuarios;

    private Usuarios() {
        usuarios = new HashSet<>();
    }

    public static synchronized Usuarios getInstance() {
        if (instance == null) {
            instance = new Usuarios();
        }
        return instance;
    }

    public Set<String> getUsuarios() {
        return usuarios;
    }

    //se debe controlar que el nombre de cada usuario es unico
    public void setUsuarios(String nombreUsuario) throws Exception {
        if (usuarios.contains(nombreUsuario)) {
            throw new Exception("Este nombre de usuario ya existe: " + nombreUsuario);
        }
        usuarios.add(nombreUsuario);
    }
}
