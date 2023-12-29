using Microsoft.Data.SqlClient;
using PrestamoApi.Connection;
using PrestamoApi.Model;
using System.Data;

namespace PrestamoApi.DAO
{
    public class CustomerDao
    {
        DBConnection conn = new DBConnection();

        public async Task<List<CustomerModel>> findAllCustomers()
        {
            var customerList = new List<CustomerModel>();
            using (var sqlConnection = new SqlConnection(conn.connectionString()))
            {
                string sqlQuery = "select * from Cliente";
                using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    await sqlConnection.OpenAsync();
                    sqlCommand.CommandType = CommandType.Text;
                    using (var item = await sqlCommand.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var customerModel = new CustomerModel();

                            customerModel.id_cliente = (string)item["id_cliente"];
                            customerModel.nombre_cliente = (string)item["nombre_cliente"];
                            customerModel.direccion_cliente = (string)item["direccion_cliente"];
                            customerModel.telf_cliente = (string)item["telf_cliente"];
                            customerModel.email_cliente = (string)item["email_cliente"];
                            customerModel.edad_cliente = (int)item["edad_cliente"];

                            customerList.Add(customerModel);
                        }
                    }
                }
            }
            return customerList;
        }

        public async Task<CustomerModel> findCustomerById(string id)
        {
            var customerModel = new CustomerModel();
            using (var sqlConnection = new SqlConnection(conn.connectionString()))
            {
                string sqlQuery = "select * from Cliente " +
                          "WHERE id_cliente = @id_cliente";
                using (var sqlCommand = new SqlCommand(sqlQuery,sqlConnection))
                {
                    await sqlConnection.OpenAsync();
                    sqlCommand.CommandType = CommandType.Text;
                    // Parámetros
                    sqlCommand.Parameters.AddWithValue("@id_cliente", id);
                    using (var item = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {                          
                            customerModel.id_cliente = (string)item["id_cliente"];
                            customerModel.nombre_cliente = (string)item["nombre_cliente"];
                            customerModel.direccion_cliente = (string)item["direccion_cliente"];
                            customerModel.telf_cliente = (string)item["telf_cliente"];
                            customerModel.email_cliente = (string)item["email_cliente"];
                            customerModel.edad_cliente = (int)item["edad_cliente"];
                        }
                    }

                }
            }
            return customerModel;
        }

        public async Task saveCustomer(CustomerModel customerModel)
        {
            using (var sqlConnection = new SqlConnection(conn.connectionString()))
            {
                string sqlQuery = "INSERT INTO Cliente (id_cliente, nombre_cliente, direccion_cliente, telf_cliente, email_cliente, edad_cliente) " +
                          "VALUES (@id_cliente, @nombre_cliente, @direccion_cliente,@telf_cliente, @email_cliente, @edad_cliente)";
                using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    await sqlConnection.OpenAsync();
                    sqlCommand.CommandType = CommandType.Text;

                    // Parámetros
                    sqlCommand.Parameters.AddWithValue("@id_cliente", customerModel.id_cliente);
                    sqlCommand.Parameters.AddWithValue("@nombre_cliente", customerModel.nombre_cliente);
                    sqlCommand.Parameters.AddWithValue("@direccion_cliente", customerModel.direccion_cliente);
                    sqlCommand.Parameters.AddWithValue("@telf_cliente", customerModel.telf_cliente);
                    sqlCommand.Parameters.AddWithValue("@email_cliente",customerModel.email_cliente );
                    sqlCommand.Parameters.AddWithValue("@edad_cliente", customerModel.edad_cliente);

                    // Ejecutar la consulta
                    await sqlCommand.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task updateCustomerById(CustomerModel customerModel)
        {
            using (var sqlConnection = new SqlConnection(conn.connectionString()))
            {
                string sqlQuery = "UPDATE Cliente " +
                          "SET direccion_cliente = @direccion_cliente, " +
                          "    telf_cliente = @telf_cliente, " +
                          "    email_cliente = @email_cliente, " +
                          "    edad_cliente = @edad_cliente " +
                          "WHERE id_cliente = @id_cliente";
                using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    await sqlConnection.OpenAsync();
                    sqlCommand.CommandType = CommandType.Text;

                    // Parámetros
                    sqlCommand.Parameters.AddWithValue("@id_cliente", customerModel.id_cliente);
                    sqlCommand.Parameters.AddWithValue("@direccion_cliente", customerModel.direccion_cliente);
                    sqlCommand.Parameters.AddWithValue("@telf_cliente", customerModel.telf_cliente);
                    sqlCommand.Parameters.AddWithValue("@email_cliente", customerModel.email_cliente);
                    sqlCommand.Parameters.AddWithValue("@edad_cliente", customerModel.edad_cliente);

                    // Ejecutar la consulta
                    await sqlCommand.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task deleteCustomerById(String id)
        {
            using (var sqlConnection = new SqlConnection(conn.connectionString()))
            {
                string sqlQuery = "DELETE FROM Cliente " +
                          "WHERE id_cliente = @id_cliente";
                using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    await sqlConnection.OpenAsync();
                    sqlCommand.CommandType = CommandType.Text;

                    // Parámetros
                    sqlCommand.Parameters.AddWithValue("@id_cliente", id);

                    // Ejecutar la consulta
                    await sqlCommand.ExecuteNonQueryAsync();

                }
            }
        }

    }

}
