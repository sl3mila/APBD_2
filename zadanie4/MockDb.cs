using System.Drawing;

namespace zadanie4;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; } //kategoria
    public double Mass { get; set; }
    public string FurrColor { get; set; }
}

public class Visit
{
    public DateTime DateofVisit { get; set; }
    public Animal VisitingAnimal { get; set; }
    public string VisitDescription { get; set; }
    public double PriceOfVisit { get; set; }
}

public interface IMockDb
{
    //animmals
    public ICollection<Animal> GetAllAnimals();
    public Animal? GetAnimalById(int id);
    public void AddAnimal(Animal animal);
    public void EditAnimal(int id, string newName, double newMass, string newFurrColor);
    public void DeleteAnimal(Animal animal);

    //visits
    public void AddVisit(Visit visit);
    public ICollection<Visit> GetVisitsOf(Animal animal);
}

public class MockDb : IMockDb
{
    private ICollection<Animal> _animals;
    private ICollection<Visit> _visits;

    public MockDb()
    {
        _animals = new List<Animal>
        {
            new Animal()
            {
                Id = 1,
                Name = "Pimpek",
                Species = "Dog",
                Mass = 6.5,
                FurrColor = "White"
            },
            new Animal()
            {
                Id = 2,
                Name = "Dasy",
                Species = "Cat",
                Mass = 3.6,
                FurrColor = "Grey"
            }
        };

        _visits = new List<Visit>()
        {
            new Visit()
            {
                DateofVisit = new DateTime(2024, 04, 13),
                VisitingAnimal = GetAnimalById(1),
                VisitDescription = "bla bla bla",
                PriceOfVisit = 200.99
            }
        };
    }

    public ICollection<Animal> GetAllAnimals()
    {
        return _animals;
    }

    public Animal? GetAnimalById(int id)
    {
        return _animals.FirstOrDefault(a => a.Id == id);
    }

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public void EditAnimal(int id, string newName, double newMass, string newFurrColor)
    {
        _animals.FirstOrDefault(a => a.Id == id).Name = newName;
        _animals.FirstOrDefault(a => a.Id == id).Mass = newMass;
        _animals.FirstOrDefault(a => a.Id == id).FurrColor = newFurrColor;
    }

    public void DeleteAnimal(Animal animal)
    {
        _animals.Remove(animal);
    }

    public void AddVisit(Visit visit)
    {
        _visits.Add(visit);
    }

    public ICollection<Visit> GetVisitsOf(Animal animal)
    {
        var visitsForAnimal = _visits.Where(visit => visit.VisitingAnimal == animal).ToList();
        
        return visitsForAnimal;
    }
}