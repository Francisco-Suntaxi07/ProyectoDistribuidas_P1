package Modelo;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.security.KeyManagementException;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;
import java.security.cert.X509Certificate;
import javax.net.ssl.HttpsURLConnection;
import javax.net.ssl.SSLContext;
import javax.net.ssl.TrustManager;
import javax.net.ssl.X509TrustManager;

public abstract class apiBase {

    protected String realizarConexion(String apiUrl) {
        StringBuilder salida = new StringBuilder();
        quitarCertificados();

        try {
            URL url = new URL(apiUrl);
            HttpURLConnection conec_api = (HttpURLConnection) url.openConnection();
            conec_api.setRequestMethod("GET");
            conec_api.setRequestProperty("Accept", "application/json");

            if (conec_api.getResponseCode() == 200) {
                InputStreamReader entrada = new InputStreamReader(conec_api.getInputStream());
                BufferedReader lectura = new BufferedReader(entrada);

                String linea;
                while ((linea = lectura.readLine()) != null) {
                    salida.append(linea);
                }

                lectura.close();
            } else {
                System.out.println("No se puede conectar a la API. Código de respuesta: " + conec_api.getResponseCode());
            }
            conec_api.disconnect();
        } catch (IOException ex) {
            System.out.println("Error de la API: " + ex.getMessage());
        }
        return salida.toString();
    }
    

    private void quitarCertificados() {
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
        }
    }

    // Método abstracto para que las clases hijas proporcionen la URL específica de la API
    protected abstract String obtenerUrlApi();
}
