using System.Data;
using System.Data.SqlClient;
using kolokwium_1.DTO;

namespace kolokwium_1.Services;

public interface IService
{
    //metody klasy
    public Task<GetGenreDTO?> GetGenresByIdAsync(int idBook);
    public Task<bool> AddBook(string title, List<int> gen);
}

public class DBService : IService
{

    private IConfiguration _configuration;

    public DBService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private async Task<SqlConnection> GetConnection()
    {
        
        var connection = new SqlConnection(_configuration.GetConnectionString("Deafult"));
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        return connection;
    }

    public async Task<GetGenreDTO?> GetGenresByIdAsync(int idBook)    //get
    { 
        await using var connection = await GetConnection();
        
        var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = """
                                SELECT Genres.Nam 
                                FROM Genres g LEFT JOIN Books_genres bg 
                                    on g.PK = bg.FK_genre 
                                    left join Books b
                                    on b.PK = bg.FK_book
                                    WHERE b.PK = @id
                                """;
        
        command.Parameters.AddWithValue("@id", idBook); //parametry do zmiany
        var reader = await command.ExecuteReaderAsync();
        
        if (!reader.HasRows) return null;
        await reader.ReadAsync();
        

        var result = new GetGenreDTO(
            reader.GetInt32(0),
            !await reader.IsDBNullAsync(1) ? new List<int> {reader.GetInt32(1)} : new List<int>()
        );
        
        while (await reader.ReadAsync())
        {
            result.Genre.Add(reader.GetInt32(2));
        }

        return result;
    }
    
    public async Task<bool> AddBook(string title, List<int> gen)   //insert
    {
        await using var connection = await GetConnection();
        await using var transaction = connection.BeginTransaction();

        try
        {
            var command1 = new SqlCommand();
            command1.Connection = connection;
            command1.CommandText = """
                                    INSERT INTO Books (PK, Title)
                                   VALUES ($pk, $title);
                                   """; //sql command in

            command1.Parameters.AddWithValue("@pk", Book.idCount); //parametry do zmiany
            command1.Parameters.AddWithValue("@title", title);
            await command1.ExecuteReaderAsync();
            
            var command2 = new SqlCommand();
            command2.Connection = connection;
            command2.CommandText = """
                                   INSERT INTO Books_genres (FK_book, FK_genre)
                                   VALUES ($fk_book, $fk_genre)
                                   """;
            if (gen.Count != 0)
            {
                foreach (var g in gen)
                {
                    command2.Transaction = (SqlTransaction)transaction;
                    command2.Parameters.AddWithValue("@fk_book", Book.idCount);
                    command2.Parameters.AddWithValue("@fk_genre", g);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    command2.Transaction = (SqlTransaction)transaction;
                    command2.Parameters.AddWithValue("@fk_book", Book.idCount);
                    command2.Parameters.AddWithValue("@fk_genre", null);
                }
            }

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
}