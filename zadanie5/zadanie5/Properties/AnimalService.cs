using zadanie5.Repositories;

namespace zadanie5.Properties;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals();
    int CreateAnimal(Animal newAnimal);
    int EditAnimal(int idAnimal, Animal animal);
    int DeleteAnimal(int idAnimal);
}

public class AnimalService : IAnimalsService
{

    private readonly IAnimalsRepository _animalsRepository;

    public AnimalService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }
    
    public IEnumerable<Animal> GetAnimals()
    {
        
        var data = _animalsRepository.GetAnimals();
        
        return data;
    }

    public int CreateAnimal(Animal newAnimal)
    {
        
        return _animalsRepository.CrateAnimal(newAnimal);
    }

    public int EditAnimal(int idAnimal, Animal animal)
    {
        
        return _animalsRepository.EditAnimal(idAnimal, animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        
        return _animalsRepository.DeleteAnimal(idAnimal);
    }
}