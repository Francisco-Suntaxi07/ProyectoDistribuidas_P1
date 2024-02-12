/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Vista;
import Modelo.prestamosApi;   
import Controlador.controladorApi;
import Controlador.controladorVistas;
import Modelo.prestamosApi;
import java.time.LocalDate;
import java.util.Date;
import org.json.JSONException;

/**
 *
 * @author ASUS GAMING
 */
public class vis {
    private static controladorApi control = new controladorApi();

    public static void main(String[] args) throws JSONException {

        control.realizarPrestamo("L007","1023456789",new Date(123, 3, 12));
    }
}