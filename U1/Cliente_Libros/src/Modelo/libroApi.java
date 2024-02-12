package Modelo;

import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class libroApi extends apiBase {

    public String obtenerTituloLibroPorId(String idLibro) {
        String respuestaJson = realizarConexion(obtenerUrlApi());

        String nombreLibro = "";
        try {
            JSONArray libros = new JSONArray(respuestaJson);
            for (int i = 0; i < libros.length(); i++) {
                JSONObject libro = libros.getJSONObject(i);
                if (libro.getString("id_libro").equals(idLibro)) {
                    // Se encontró el libro, obtener su nombre
                    nombreLibro = libro.getString("titulo_libro");
                    break;
                }
            }
        } catch (JSONException e) {
            System.out.println("Error al procesar la respuesta JSON: " + e.getMessage());
        }

        return nombreLibro;
    }

    public JSONArray obtenerTodosLosLibros() {
        String respuestaJson = realizarConexion(obtenerUrlApi());
        try {
            return new JSONArray(respuestaJson);
        } catch (JSONException e) {
            System.out.println("Error al procesar la respuesta JSON: " + e.getMessage());
            return new JSONArray();
        }
    }

    public boolean existeLibro(String idLibro) throws JSONException {
        JSONArray libros = obtenerTodosLosLibros();

        for (int i = 0; i < libros.length(); i++) {
            JSONObject libro = libros.getJSONObject(i);
            if (libro.getString("id_libro").equals(idLibro)) {
                return true; // El libro existe
            }
        }

        return false; // El libro no existe
    }

    public JSONObject obtenerLibroPorId(String idLibro) throws JSONException {
    // Obtener la información del libro por ID
    JSONArray libros = obtenerTodosLosLibros();

    for (int i = 0; i < libros.length(); i++) {
        JSONObject libro = libros.getJSONObject(i);
        if (libro.getString("id_libro").equals(idLibro)) {
            return libro;
        }
    }

    return null; // El libro no fue encontrado
}

public void decrementarCantidadLibro(String idLibro) throws JSONException {
    // Obtener la información del libro por ID
    JSONObject libro = obtenerLibroPorId(idLibro);

    // Verificar si el libro existe
    if (libro != null) {
        // Obtener la cantidad actual
        int cantidadActual = libro.getInt("cantidad_libro");

        // Verificar que la cantidad sea mayor que cero antes de decrementar
        if (cantidadActual > 0) {
            // Decrementar la cantidad
            cantidadActual--;

            // Actualizar la cantidad en el objeto JSON
            libro.put("cantidad_libro", cantidadActual);

            // Enviar la actualización a la API
            enviarActualizacion(libro);
        } else {
            System.out.println("Error: La cantidad de libros es 0, no se puede decrementar más.");
        }
    } else {
        System.out.println("Error: El libro con ID " + idLibro + " no existe.");
    }
}

    private void enviarActualizacion(JSONObject libro) {
        try {
            // Construir la URL de actualización (ajusta la URL según tu API)
            String updateUrl = "https://localhost:44324/api/Libros/" + libro.getString("id_libro");

            // Crear la conexión HTTP
            URL url = new URL(updateUrl);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();

            // Configurar la conexión para el método PUT
            connection.setRequestMethod("PUT");
            connection.setRequestProperty("Content-Type", "application/json");
            connection.setDoOutput(true);

            // Escribir el cuerpo de la solicitud en el flujo de salida
            try (OutputStream os = connection.getOutputStream()) {
                byte[] input = libro.toString().getBytes("utf-8");
                os.write(input, 0, input.length);
            }

            // Obtener la respuesta
            int responseCode = connection.getResponseCode();
            if (responseCode == HttpURLConnection.HTTP_OK) {
                System.out.println("Actualización del libro exitosa.");
            } else {
                System.out.println("Error al actualizar el libro. Código de respuesta: " + responseCode);
            }

        } catch (Exception e) {
            System.err.println("Error al enviar la actualización: " + e.getMessage());
        }
    }

    @Override
    protected String obtenerUrlApi() {
        return "https://localhost:44324/api/Libros";
    }

}
