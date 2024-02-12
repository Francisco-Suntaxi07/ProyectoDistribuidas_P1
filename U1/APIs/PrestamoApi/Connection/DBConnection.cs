namespace PrestamoApi.Connection
{
    public class DBConnection
    {
        private string _connectionString = string.Empty;
        public DBConnection()
        {
            var builderConnection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _connectionString = builderConnection.GetSection("ConnectionStrings:conexionBiblioteca").Value;
        }

        public string connectionString()
        { 
            return _connectionString; 
        }
    }
}
