package com.chat.socket.chatapp.model;

public class MensajeModel {
    private String mensaje;
    private String desdeRegistro;

    public String getMensaje() {
        return mensaje;
    }

    public void setMensaje(String mensaje) {
        this.mensaje = mensaje;
    }

    public String getDesdeRegistro() {
        return desdeRegistro;
    }

    public void setDesdeRegistro(String desdeRegistro) {
        this.desdeRegistro = desdeRegistro;
    }

    @Override
    public String toString() {
        return "MensajeModel{" +
                "mensaje='" + mensaje + '\'' +
                ", desdeRegistro='" + desdeRegistro + '\'' +
                '}';
    }
}
