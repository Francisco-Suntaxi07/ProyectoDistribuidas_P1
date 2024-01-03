package Controlador;

import Modelo.clienteApi;
import Modelo.libroApi;
import Modelo.prestamosApi;
import java.util.Date;
import java.util.List;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class controladorApi {

    private clienteApi clienteApi;
    private prestamosApi prestamosApi;
    private libroApi libroApi;

    public controladorApi() {
        this.clienteApi = new clienteApi();
        this.prestamosApi = new prestamosApi();
        this.libroApi = new libroApi();
    }

    public String obtenerNombreCliente(String idCliente) {
        try {
            return clienteApi.obtenerNombreClientePorID(idCliente);
        } catch (Exception e) {
            System.out.println("Error en obtener datos");
            return "";
        }
    }

    public JSONArray obtenerPrestamos(String idCliente) {
        try {
            return prestamosApi.obtenerPrestamosPorIdCliente(idCliente);
        } catch (Exception e) {
            System.out.println("Error en obtener datos");

        }
        return null;
    }

    public String obtenerTituloLibro(String idLibro) {
        try {
            return libroApi.obtenerTituloLibroPorId(idLibro);
        } catch (Exception e) {
            System.out.println("Error en obtener datos");

        }
        return null;
    }

    public JSONArray obtenerTodosLibros() {
        try {
            return libroApi.obtenerTodosLosLibros();
        } catch (Exception e) {
            System.out.println("Error en obtener datos");

        }
        return null;
    }

    public void realizarPrestamo(String idLibro, String idCliente, Date fechaDevolucion) throws JSONException {

        if (libroApi.existeLibro(idLibro)) {
            prestamosApi.realizarPrestamo(idLibro, idCliente, fechaDevolucion);
            System.out.println("Préstamo realizado con éxito.");
        } else {
            System.out.println("Error: El libro con ID " + idLibro + " no existe.");
        }
    }

    public boolean existeLibro(String idLibro) {
        try {
            return libroApi.existeLibro(idLibro);
        } catch (Exception e) {
            System.out.println("Error al verificar la existencia del libro: " + e.getMessage());
            return false;
        }
    }
    
   public JSONObject obtenerLibroPorId(String idLibro) {
        try {
            return libroApi.obtenerLibroPorId(idLibro);
        } catch (Exception e) {
            System.out.println("Error al obtener el libro por ID: " + e.getMessage());
            return null;
        }
    }
   
   public void decrementarCantidadLibro(String idLibro) {
        try {
            // Obtener la información del libro por ID
            JSONObject libro = libroApi.obtenerLibroPorId(idLibro);

            // Verificar si el libro existe
            if (libro != null) {
                // Decrementar la cantidad de libros
                libroApi.decrementarCantidadLibro(idLibro);
                System.out.println("Cantidad de libros decrementada con éxito.");
            } else {
                System.out.println("Error: El libro con ID " + idLibro + " no existe.");
            }
        } catch (JSONException e) {
            System.out.println("Error al decrementar la cantidad de libros: " + e.getMessage());
        }
    }
   
}

