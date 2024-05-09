using System.Data;
using System.Data.SqlClient;
using kolokwium_1.DTO;

namespace kolokwium_1.Services;

public interface IService
{
    //metody klasy
    public Task<GetGroupDTO?> GetGroupDetailsByIdAsync(int id);
}

public class Service(IConfiguration configuration) : IService
{

    private async Task<SqlConnection> GetConnection()
    {
        var connection = new SqlConnection(configuration.GetConnectionString("Deafult"));
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        return connection;
    }

    public async Task<GetGroupDTO?> GetGroupDetailsByIdAsync(int id)
    { 
        await using var connection = await GetConnection();
        
        var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = """ """; //sql command in """ """
        
        command.Parameters.AddWithValue("@id", id); //parametry do zmiany
        var reader = await command.ExecuteReaderAsync();
        
        if (!reader.HasRows) return null;
        await reader.ReadAsync();
        
        while (await reader.ReadAsync())
        {
            //result.Students.Add(reader.GetInt32(2));
            
        }

        return /*result*/ null;
    }
    
    //metody 
}