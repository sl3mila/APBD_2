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

    public async Task<GetGroupDTO?> GetGroupDetailsByIdAsync(int id)    //get
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
            //result.DatabaseKlass.Add(reader.GetInt32(2));
            
        }

        return /*result*/ null;
    }
    
    public async Task<bool> RemoveStudent(int id)   //delete
    {
        await using var connection = await GetConnection();
        await using var transaction = connection.BeginTransaction();

        try
        {
            var command1 = new SqlCommand();
            command1.Connection = connection;
            command1.CommandText = """
                                    DELETE FROM GroupAssignments
                                   WHERE Student_ID = @id;
                                   """; //sql command in

            command1.Parameters.AddWithValue("@id", id); //parametry do zmiany
            var reader = await command1.ExecuteReaderAsync();

            var command2 = new SqlCommand();
            command2.Connection = connection;
            command2.CommandText = """
                                   DELETE FROM Students
                                          WHERE ID = @id;
                                   """;

            command2.Transaction = (SqlTransaction)transaction;
            command2.Parameters.AddWithValue("@id", id);
            var affectedRows = await command2.ExecuteNonQueryAsync();

            await transaction.CommitAsync();

            return affectedRows != 0;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    
    //metody 
}