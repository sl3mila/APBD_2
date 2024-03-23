
namespace KonteneryApp;

public abstract class Kontener
{
    private protected int NumerSeryjny;
    public abstract string GetNumerSeryjny();

    public double Masa { get; set; }
    private protected double Wysokosc { get; }
    private protected double WagaWlasna { get; }
    private protected double Glebokosc { get; }
    private protected double MaxLad { get; }

    protected Kontener(int numerSeryjny, double wysokosc, double wagaWlasna, double glebokosc, double maxLad)
    {
        Masa = 0;
        NumerSeryjny = numerSeryjny;
        Wysokosc = wysokosc;
        WagaWlasna = wagaWlasna;
        Glebokosc = glebokosc;
        MaxLad = maxLad;
    }
    
    public void Info()
    {
        Console.WriteLine("Nunmer seryjny kontenera: " + GetNumerSeryjny() + 
                          "\nWysokosc: " + Wysokosc +
                          "\nWaga własna: " + WagaWlasna +
                          "\nGłębokość: " + Glebokosc +
                          "\nMaksymalny waga ładunku: " + MaxLad + 
                            "\nMasa ładunku: " + Masa);
    }

    public void Oproznienie()
    {
        Masa = 0;
        Console.WriteLine("Kontener "+ GetNumerSeryjny() + " opróżniony");

    }

    public void Zaladuj(double ladunek)
    {
        if (ladunek + Masa > MaxLad)
        {
            throw new OverfillException("Towar jest za duży");

        }
        
        Masa += ladunek;
        Console.WriteLine("Ladunek załadowany na: " + GetNumerSeryjny());
    }
    
}