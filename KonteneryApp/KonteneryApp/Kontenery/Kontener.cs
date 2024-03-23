
namespace KonteneryApp;

public abstract class Kontener(int numerSeryjny, double wysokosc, double wagaWlasna, double glebokosc, double maxLad)
{
    private protected int numerSeryjny = numerSeryjny;
    public abstract string GetNumerSeryjny();

    public double Masa { get; set; } = 0;
    private protected double Wysokosc { get; } = wysokosc;
    private protected double WagaWlasna { get; } = wagaWlasna;
    private protected double Glebokosc { get; } = glebokosc;
    private protected double MaxLad { get; } = maxLad;

    public void Info()
    {
        Console.WriteLine("Nunmer seryjny kontenera: " + GetNumerSeryjny() + 
                          "\nWysokosc: " + Wysokosc +
                          "\nWaga własna: " + WagaWlasna +
                          "\nGłębokość: " + Glebokosc +
                          "\nMaksymalny waga ładunku: " + MaxLad + 
                            "\nMasa ładunku: " + Masa );
    }

    public void Oproznienie()
    {
        Masa = 0;
        Console.WriteLine("Kontener "+ GetNumerSeryjny() + " opróżniony");

    }

    public void Zaladuj(double ladunek)
    {
        if (ladunek + Masa > maxLad)
        {
            throw new OverfillException("Towar jest za duży");

        }
        Masa += ladunek;
        Console.WriteLine("Ladunek załadowany na: "+ GetNumerSeryjny());
    }
}