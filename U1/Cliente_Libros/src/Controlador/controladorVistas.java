/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Controlador;

import Vista.busquedas;
import Vista.libros_usuario;
import Vista.usuario;
import org.json.JSONArray;
import org.json.JSONException;

/**
 *
 * @author ASUS GAMING
 */
public class controladorVistas {

    private String nombreUsuario;
    private String idCliente;
    private JSONArray libros;
    private String titulo;
    private static controladorVistas instancia;

    public void mostrarVistaUsuario() {
        usuario vistaUsuario = new usuario();
        vistaUsuario.setControlador(this); // Establecer la referencia al controlador
        vistaUsuario.setVisible(true);
    }

    public void mostrarVistaLibros() {
        libros_usuario vistaLibros = new libros_usuario();
        vistaLibros.setControlador(this);
        vistaLibros.mostrarIdUsuario(idCliente);
        vistaLibros.mostrarNombreUsuario(nombreUsuario); // Pasar el nombre de usuario a la vista de libros
        vistaLibros.setVisible(true);

    }

    public void mostrarVistaBusquedas() throws JSONException {
        busquedas vistaBusquedas = new busquedas();
        vistaBusquedas.mostrarIdUsuario(idCliente);
        vistaBusquedas.setControlador(this); // Establecer la referencia al controlador
        vistaBusquedas.mostrarTodosLosLibros();
        vistaBusquedas.filtrarLibros();
        vistaBusquedas.setVisible(true);

    }

    public void setNombreUsuario(String nombreUsuario) {
        this.nombreUsuario = nombreUsuario;
    }

    public void setIdCliente(String idCliente) {
        this.idCliente = idCliente;
    }


    public static void main(String[] args) {
        controladorVistas controlador = new controladorVistas();
        controlador.mostrarVistaUsuario();
    }

}
