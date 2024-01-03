/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Modelo;

import com.google.gson.annotations.SerializedName;
import java.util.Date;

/**
 *
 * @author ASUS GAMING
 */
public class modeloPrestamo {

    @SerializedName("id_prestamo")
    private String idPrestamo;

    @SerializedName("id_libro")
    private String idLibro;

    @SerializedName("id_cliente")
    private String idCliente;

    @SerializedName("fecha_prestamo")
    private Date fechaPrestamo;

    @SerializedName("fecha_devolucion")
    private Date fechaDevolucion;

    @SerializedName("precio_prestamo")
    private double precioPrestamo;

    @SerializedName("multa_prestamo")
    private double multaPrestamo;

    @SerializedName("observaciones_prestamo")
    private String observacionesPrestamo;

    // Constructor vacío necesario para Gson
    public modeloPrestamo() {
    }

    // Constructor con todos los campos
    public modeloPrestamo (String idPrestamo, String idLibro , String idCliente , Date fechaPrestamo , Date fechaDevolucion ,double precioPrestamo, double multaPrestamo, String observacionesPrestamo

    
        ) {
        this.idPrestamo = idPrestamo;
        this.idLibro = idLibro;
        this.idCliente = idCliente;
        this.fechaPrestamo = fechaPrestamo;
        this.fechaDevolucion = fechaDevolucion;
        this.precioPrestamo = precioPrestamo;
        this.multaPrestamo = multaPrestamo;
        this.observacionesPrestamo = observacionesPrestamo;
    }

    // Getters y Setters
    public String getIdPrestamo() {
        return idPrestamo;
    }

    public void setIdPrestamo(String idPrestamo) {
        this.idPrestamo = idPrestamo;
    }

    public String getIdLibro() {
        return idLibro;
    }

    public void setIdLibro(String idLibro) {
        this.idLibro = idLibro;
    }

    public String getIdCliente() {
        return idCliente;
    }

    public void setIdCliente(String idCliente) {
        this.idCliente = idCliente;
    }

    public Date getFechaPrestamo() {
        return fechaPrestamo;
    }

    public void setFechaPrestamo(Date fechaPrestamo) {
        this.fechaPrestamo = fechaPrestamo;
    }

    public Date getFechaDevolucion() {
        return fechaDevolucion;
    }

    public void setFechaDevolucion(Date fechaDevolucion) {
        this.fechaDevolucion = fechaDevolucion;
    }

    public double getPrecioPrestamo() {
        return precioPrestamo;
    }

    public void setPrecioPrestamo(double precioPrestamo) {
        this.precioPrestamo = precioPrestamo;
    }

    public double getMultaPrestamo() {
        return multaPrestamo;
    }

    public void setMultaPrestamo(double multaPrestamo) {
        this.multaPrestamo = multaPrestamo;
    }

    public String getObservacionesPrestamo() {
        return observacionesPrestamo;
    }

    public void setObservacionesPrestamo(String observacionesPrestamo) {
        this.observacionesPrestamo = observacionesPrestamo;
    }

    // Resto de la clase
    @Override
    public String toString() {
        return "Prestamo{"
                + "idPrestamo='" + idPrestamo + '\''
                + ", idLibro='" + idLibro + '\''
                + ", idCliente='" + idCliente + '\''
                + ", fechaPrestamo=" + fechaPrestamo
                + ", fechaDevolucion=" + fechaDevolucion
                + ", precioPrestamo=" + precioPrestamo
                + ", multaPrestamo=" + multaPrestamo
                + ", observacionesPrestamo='" + observacionesPrestamo + '\''
                + '}';
    }
}
