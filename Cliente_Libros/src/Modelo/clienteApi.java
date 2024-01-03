package Modelo;

import org.json.JSONArray;
import org.json.JSONObject;

import org.json.JSONException;

public class clienteApi extends apiBase{

    public String obtenerNombreClientePorID(String idCliente) {
        String respuestaJson = realizarConexion(obtenerUrlApi());

        // Lógica específica para procesar la respuesta JSON
        String nombreCliente = "";
        try {
            JSONArray clientes = new JSONArray(respuestaJson);
            for (int i = 0; i < clientes.length(); i++) {
                JSONObject cliente = clientes.getJSONObject(i);
                if (cliente.getString("id_cliente").equals(idCliente)) {
                    // Se encontró el cliente, obtener su nombre
                    nombreCliente = cliente.getString("nombre_cliente");
                    break;
                }
            }
        } catch (JSONException e) {
            System.out.println("Error al procesar la respuesta JSON: " + e.getMessage());
        }

        return nombreCliente;
    
    }

    @Override
    protected String obtenerUrlApi() {
      return "https://localhost:5001/api/customer/all";
    }


}
