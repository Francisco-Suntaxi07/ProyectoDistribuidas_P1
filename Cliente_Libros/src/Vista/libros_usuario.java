package Vista;

import Controlador.controladorApi;
import Controlador.controladorVistas;
import java.awt.Component;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JTable;

import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableCellRenderer;
import javax.swing.table.TableColumnModel;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class libros_usuario extends javax.swing.JFrame {

    private DefaultTableModel modeloTabla = null;
    private String idTemp;
    private controladorVistas controlador;

    public libros_usuario() {
        initComponents();
        
        this.setLocationRelativeTo(null);
        txtGUsuario.setBorder(null);
        modeloTabla = new DefaultTableModel();
        modeloTabla.addColumn("ID_Prestamo");
        modeloTabla.addColumn("Titulo");
        modeloTabla.addColumn("Precio");
        modeloTabla.addColumn("Multa");
        modeloTabla.addColumn("Fecha_Préstamo");
        modeloTabla.addColumn("Fecha_Devolución");

        tblLibros.setModel(modeloTabla);
       
    }
    private void resizeColumnWidth(JTable table) {
        final TableColumnModel columnModel = table.getColumnModel();
        for (int column = 0; column < table.getColumnCount(); column++) {
            int width = 15; // Ancho mínimo de la columna
            for (int row = 0; row < table.getRowCount(); row++) {
                TableCellRenderer renderer = table.getCellRenderer(row, column);
                Component comp = table.prepareRenderer(renderer, row, column);
                width = Math.max(comp.getPreferredSize().width + 1, width);
            }
            columnModel.getColumn(column).setPreferredWidth(width);
        }
    }

    public void mostrarIdUsuario(String idCliente) {
        idTemp = idCliente;
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        txtGUsuario = new javax.swing.JTextField();
        jLabel1 = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        tblLibros = new javax.swing.JTable();
        btnLibros = new javax.swing.JButton();
        btnActualizar = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        txtGUsuario.setEditable(false);
        txtGUsuario.setFont(new java.awt.Font("PMingLiU-ExtB", 2, 18)); // NOI18N
        txtGUsuario.setHorizontalAlignment(javax.swing.JTextField.CENTER);
        txtGUsuario.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtGUsuarioActionPerformed(evt);
            }
        });

        jLabel1.setText("Aqui tienes una lista de los libros que rentaste ");

        tblLibros.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            },
            new String [] {
                "Title 1", "Title 2", "Title 3", "Title 4"
            }
        ));
        jScrollPane1.setViewportView(tblLibros);

        btnLibros.setText("Busqueda y Prestamos de Libros");
        btnLibros.setActionCommand("");
        btnLibros.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnLibrosActionPerformed(evt);
            }
        });

        btnActualizar.setText("Actualizar");
        btnActualizar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnActualizarActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 602, Short.MAX_VALUE)
                    .addComponent(txtGUsuario, javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                        .addComponent(jLabel1, javax.swing.GroupLayout.PREFERRED_SIZE, 264, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(btnActualizar)
                        .addGap(14, 14, 14)))
                .addContainerGap())
            .addGroup(layout.createSequentialGroup()
                .addGap(196, 196, 196)
                .addComponent(btnLibros)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(txtGUsuario, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel1)
                    .addComponent(btnActualizar))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 249, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addComponent(btnLibros)
                .addContainerGap(11, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void txtGUsuarioActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtGUsuarioActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_txtGUsuarioActionPerformed

    private void btnLibrosActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnLibrosActionPerformed

        try {
            controlador.setIdCliente(idTemp);
            controlador.mostrarVistaBusquedas();
            dispose();
        } catch (JSONException ex) {
            Logger.getLogger(libros_usuario.class.getName()).log(Level.SEVERE, null, ex);
        }


    }//GEN-LAST:event_btnLibrosActionPerformed

    private void btnActualizarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnActualizarActionPerformed


        // Configurar el ajuste automático del ancho de las columnas después de que se carguen los datos
        tblLibros.addComponentListener(new ComponentAdapter() {
            @Override
            public void componentResized(ComponentEvent e) {
                resizeColumnWidth(tblLibros);
            }
        });
        
        controladorApi controladorPres = new controladorApi();

        //Creacion de array de prestamos y jalar datos
        JSONArray prestamosCliente;
        prestamosCliente = controladorPres.obtenerPrestamos(idTemp);

        // Limpiar la tabla antes de agregar nuevos datos
        modeloTabla.setRowCount(0);

        //Poner datos en la tabla
        for (int i = 0; i < prestamosCliente.length(); i++) {
            try {
                JSONObject prestamo = prestamosCliente.getJSONObject(i);

                // Obtener el título del libro
                String idLibro = prestamo.getString("id_libro");
                String tituloLibro = controladorPres.obtenerTituloLibro(idLibro);

                // Agregar cada fila a la tabla
                modeloTabla.addRow(new Object[]{
                    prestamo.getString("id_prestamo"),
                    tituloLibro,
                    obtenerValorComoString(prestamo, "precio_prestamo"),
                    obtenerValorComoString(prestamo, "multa_prestamo"),
                    prestamo.getString("fecha_prestamo"),
                    prestamo.getString("fecha_devolucion"),});
            } catch (JSONException e) {
            }
        }
    }//GEN-LAST:event_btnActualizarActionPerformed

    public void mostrarNombreUsuario(String nombreUsuario) {

        txtGUsuario.setText("Bienvenido " + nombreUsuario); // Mostrar el nombre de usuario en el campo de texto
    }

    private String obtenerValorComoString(JSONObject objeto, String clave) throws JSONException {
        return objeto.isNull(clave) ? "" : String.valueOf(objeto.get(clave));
    }

    public void setControlador(controladorVistas controlador) {
        this.controlador = controlador;
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(libros_usuario.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(libros_usuario.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(libros_usuario.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(libros_usuario.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new libros_usuario().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnActualizar;
    private javax.swing.JButton btnLibros;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTable tblLibros;
    private javax.swing.JTextField txtGUsuario;
    // End of variables declaration//GEN-END:variables
}
