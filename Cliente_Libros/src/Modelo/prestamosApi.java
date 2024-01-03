package Modelo;

import Controlador.controladorApi;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.security.KeyManagementException;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;
import java.security.cert.X509Certificate;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Random;
import java.util.UUID;
import javax.net.ssl.HttpsURLConnection;
import javax.net.ssl.SSLContext;
import javax.net.ssl.TrustManager;
import javax.net.ssl.X509TrustManager;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class prestamosApi extends apiBase {

    private controladorApi controladorApi;

    public JSONArray obtenerPrestamosPorIdCliente(String idCliente) {
        String respuestaJson = realizarConexion(obtenerUrlApi());

        JSONArray prestamosCliente = new JSONArray();

        try {
            JSONArray todosLosPrestamos = new JSONArray(respuestaJson);
            for (int i = 0; i < todosLosPrestamos.length(); i++) {
                JSONObject prestamo = todosLosPrestamos.getJSONObject(i);
                if (prestamo.getString("id_cliente").equals(idCliente)) {
                    prestamosCliente.put(prestamo);
                }
            }
        } catch (JSONException e) {
            System.out.println("Error al procesar la respuesta JSON de préstamos: " + e.getMessage());
        }

        return prestamosCliente;
    }

    public void realizarPrestamo(String idLibro, String idCliente, Date fechaDevolucion) {
        quitarCertificados();
        // Realizar solicitud POST
        String postUrl = "https://localhost:5001/api/loan/save";
        String idPrestamo = "P" + System.currentTimeMillis() + UUID.randomUUID().toString().substring(9);
        idPrestamo = idPrestamo.substring(0, Math.min(idPrestamo.length(), 8));
        Date fechaPrestamo = new Date();

        double precioPrestamo = Math.round((2.0 + new Random().nextDouble() * 3.0) * 10.0) / 10.0;

        // Formatear la fecha como "yyyy-MM-dd"
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
        String fechaPrestamoFormateada = dateFormat.format(fechaPrestamo);
        String fechaDevolucionFormateada = dateFormat.format(fechaDevolucion);

        // Construir el cuerpo de la solicitud con los datos recibidos como parámetros
        String cuerpoSolicitud = "{\"id_prestamo\":\"" + idPrestamo + "\",\"id_libro\":\"" + idLibro + "\",\"id_cliente\":\"" + idCliente + "\",\"fecha_prestamo\":\"" + fechaPrestamoFormateada + "\", \"fecha_devolucion\":\"" + fechaDevolucionFormateada + "\", \"precio_prestamo\":\"" + precioPrestamo + "\", \"multa_prestamo\":0.0, \"observaciones_prestamo\":\"Sin observaciones\"}";

        try {

            // Crear la conexión HTTP
            URL url = new URL(postUrl);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();

            // Configurar la conexión para el método POST
            connection.setRequestMethod("POST");
            connection.setRequestProperty("Content-Type", "application/json");
            connection.setDoOutput(true);

            // Escribir el cuerpo de la solicitud en el flujo de salida
            try (OutputStream os = connection.getOutputStream()) {
                byte[] input = cuerpoSolicitud.getBytes("utf-8");
                os.write(input, 0, input.length);
            }

            // Obtener la respuesta
            int responseCode = connection.getResponseCode();
            if (responseCode == HttpURLConnection.HTTP_OK) {
                decrementarCantidadLibro(idLibro);
                System.out.println("Préstamo realizado con éxito.");
            } else {
                System.out.println("Error al realizar el préstamo. Código de respuesta: " + responseCode);

                try (BufferedReader br = new BufferedReader(new InputStreamReader(connection.getErrorStream()))) {
                    String line;
                    StringBuilder response = new StringBuilder();
                    while ((line = br.readLine()) != null) {
                        response.append(line);
                    }
                    System.out.println("Respuesta del servidor: " + response.toString());
                }
            }

        } catch (IOException e) {
            System.err.println("Error al realizar la solicitud: " + e.getMessage());
            throw new RuntimeException("Error al realizar la solicitud", e);
        }
    }

    private void decrementarCantidadLibro(String idLibro) {
        controladorApi controladorAp = new controladorApi();
        controladorAp.decrementarCantidadLibro(idLibro);
    }

    @Override
    protected String obtenerUrlApi() {
        return "https://localhost:5001/api/loan/all";
    }

    public void quitarCertificados() {
        TrustManager[] trustAllCerts = new TrustManager[]{new X509TrustManager() {
            @Override
            public X509Certificate[] getAcceptedIssuers() {
                return null;
            }

            @Override
            public void checkClientTrusted(X509Certificate[] certs, String authType) {
            }

            @Override
            public void checkServerTrusted(X509Certificate[] certs, String authType) {
            }
        }};

        try {
            SSLContext sc = SSLContext.getInstance("SSL");
            sc.init(null, trustAllCerts, new SecureRandom());
            HttpsURLConnection.setDefaultSSLSocketFactory(sc.getSocketFactory());
        } catch (KeyManagementException | NoSuchAlgorithmException e) {
            e.printStackTrace();
        }
    }

}
