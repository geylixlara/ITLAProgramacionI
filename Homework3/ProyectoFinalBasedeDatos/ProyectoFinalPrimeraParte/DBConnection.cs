using Microsoft.Data.SqlClient;

public class DBConnection
{
    private readonly string connectionString =
        "Server=localhost\\SQLEXPRESS;Database=HotelDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}