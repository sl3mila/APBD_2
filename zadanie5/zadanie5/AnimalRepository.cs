using System.Data.SqlClient;

namespace zadanie5.Repositories;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals();
    public int CrateAnimal(Animal animal);
    public int EditAnimal(int idAnimal, Animal animal);
    public int DeleteAnimal(int idAnimal);
}

public class AnimalRepository : IAnimalsRepository
{
    private IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Animal> GetAnimals()
    {
        using var con = new SqlConnection(_configuration["ConnectionString:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM Animal";    //todo dodać selecta - sql ORDER BY Order=@Order
        //cmd.Parameters.AddWithValue(@Order, order);

        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var animal = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Descriptiopn = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString()
            };
            animals.Add(animal);
        }
        
        //con.Close();
        
        return animals;
    }

    public int CrateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionString:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Animal(IdAnimal, Name, Descriptiopn, Category, Area) " +
                          "VALUES(@IdAnimal, @Name, @Descriptiopn, @Category, @Area)";
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Descriptiopn", animal.Descriptiopn);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int EditAnimal(int idAnimal, Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionString:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Animal(Name, Descriptiopn, Category, Area) " +
                          "VALUES(@IdAnimal, @Name, @Descriptiopn, @Category, @Area) " +
                          "WHERE IdAnimal == @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Descriptiopn", animal.Descriptiopn);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int DeleteAnimal(int idAnimal)
    {
        using var con = new SqlConnection(_configuration["ConnectionString:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animmal WHERE IdAnimal == @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
            
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}