using Microsoft.Data.SqlClient;
using PrestamoApi.Connection;
using PrestamoApi.Model;
using System.Data;

namespace PrestamoApi.DAO
{
    public class LoanDao
    {
        DBConnection conn = new DBConnection();

        public async Task<List<LoanModel>> findAllLoans() 
        {
            var loansList = new List<LoanModel>();
            using (var sqlConnection = new SqlConnection(conn.connectionString()))
            {
                string sqlQuery = "select * from Prestamo";
                using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    await sqlConnection.OpenAsync();
                    sqlCommand.CommandType = CommandType.Text;
                    using (var item = await sqlCommand.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var loanModel = new LoanModel();
                            
                            loanModel.id_prestamo = (string)item["id_prestamo"];
                            loanModel.id_libro = (string)item["id_libro"];
                            loanModel.id_cliente = (string)item["id_cliente"];
                            loanModel.fecha_prestamo = ((DateTime)item["fecha_prestamo"]).Date;
                            loanModel.fecha_devolucion = ((DateTime)item["fecha_devolucion"]).Date;
                            loanModel.precio_prestamo = (decimal)item["precio_prestamo"];
                            loanModel.multa_prestamo = (decimal)item["multa_prestamo"];
                            loanModel.observaciones_prestamo = (string)item["observaciones_prestamo"];

                            loansList.Add(loanModel);
                        }
                    }
                }
            }
            return loansList;
        }

        public async Task<LoanModel> findLoanById(string id)
        {
            var loanModel = new LoanModel();
            using (var sqlConnection = new SqlConnection(conn.connectionString()))
            {
                string sqlQuery = "select * from Prestamo " +
                          "WHERE id_prestamo = @id_prestamo";
                using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    await sqlConnection.OpenAsync();
                    sqlCommand.CommandType = CommandType.Text;
                    // Parámetros
                    sqlCommand.Parameters.AddWithValue("@id_prestamo", id);
                    using (var item = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            loanModel.id_prestamo = (string)item["id_prestamo"];
                            loanModel.id_libro = (string)item["id_libro"];
                            loanModel.id_cliente = (string)item["id_cliente"];
                            loanModel.fecha_prestamo = ((DateTime)item["fecha_prestamo"]).Date;
                            loanModel.fecha_devolucion = ((DateTime)item["fecha_devolucion"]).Date;
                            loanModel.precio_prestamo = (decimal)item["precio_prestamo"];
                            loanModel.multa_prestamo = (decimal)item["multa_prestamo"];
                            loanModel.observaciones_prestamo = (string)item["observaciones_prestamo"];
                        }
                    }

                }
            }
            return loanModel;
        }

        public async Task saveLoan(LoanModel loanModel)
        {
            using (var sqlConnection = new SqlConnection(conn.connectionString()))
            {
                string sqlQuery = "INSERT INTO Prestamo (id_prestamo, id_libro, id_cliente, fecha_prestamo, fecha_devolucion, precio_prestamo, multa_prestamo, observaciones_prestamo)" +
                          "VALUES (@id_prestamo, @id_libro, @id_cliente, @fecha_prestamo, @fecha_devolucion, @precio_prestamo, @multa_prestamo, @observaciones_prestamo)";
                using (var sqlCommand = new SqlCommand(sqlQuery,sqlConnection))
                {
                    await sqlConnection.OpenAsync();
                    sqlCommand.CommandType = CommandType.Text;

                    // Parámetros
                    sqlCommand.Parameters.AddWithValue("@id_prestamo", loanModel.id_prestamo);
                    sqlCommand.Parameters.AddWithValue("@id_libro", loanModel.id_libro);
                    sqlCommand.Parameters.AddWithValue("@id_cliente", loanModel.id_cliente);
                    sqlCommand.Parameters.AddWithValue("@fecha_prestamo", loanModel.fecha_prestamo);
                    sqlCommand.Parameters.AddWithValue("@fecha_devolucion", loanModel.fecha_devolucion);
                    sqlCommand.Parameters.AddWithValue("@precio_prestamo", loanModel.precio_prestamo);
                    sqlCommand.Parameters.AddWithValue("@multa_prestamo", loanModel.multa_prestamo);
                    sqlCommand.Parameters.AddWithValue("@observaciones_prestamo", loanModel.observaciones_prestamo);

                    // Ejecutar la consulta
                    await sqlCommand.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task updateLoanById(LoanModel loanModel)
        {
            using (var sqlConnection = new SqlConnection(conn.connectionString()))
            {
                string sqlQuery = "UPDATE Prestamo " +
                          "SET fecha_devolucion = @fecha_devolucion, " +
                          "    precio_prestamo = @precio_prestamo, " +
                          "    multa_prestamo = @multa_prestamo, " +
                          "    observaciones_prestamo = @observaciones_prestamo " +
                          "WHERE id_prestamo = @id_prestamo";
                using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    await sqlConnection.OpenAsync();
                    sqlCommand.CommandType = CommandType.Text;

                    // Parámetros
                    sqlCommand.Parameters.AddWithValue("@id_prestamo", loanModel.id_prestamo);
                    sqlCommand.Parameters.AddWithValue("@fecha_devolucion", loanModel.fecha_devolucion);
                    sqlCommand.Parameters.AddWithValue("@precio_prestamo", loanModel.precio_prestamo);
                    sqlCommand.Parameters.AddWithValue("@multa_prestamo", loanModel.multa_prestamo);
                    sqlCommand.Parameters.AddWithValue("@observaciones_prestamo", loanModel.observaciones_prestamo);

                    // Ejecutar la consulta
                    await sqlCommand.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task deleteLoanById(String id)
        {
            using (var sqlConnection = new SqlConnection(conn.connectionString()))
            {
                string sqlQuery = "DELETE FROM Prestamo "+
                          "WHERE id_prestamo = @id_prestamo";
                using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    await sqlConnection.OpenAsync();
                    sqlCommand.CommandType = CommandType.Text;

                    // Parámetros
                    sqlCommand.Parameters.AddWithValue("@id_prestamo", id);

                    // Ejecutar la consulta
                    await sqlCommand.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
