namespace KonteneryApp;

public abstract class Kontener
{
    private protected int numerSeryjny;
    public abstract string GetNumerSeryjny();

    private protected double masa = 0;
    private protected double wysokosc;
    private protected double wagaWlasna;
    private protected double glebokosc;
    private protected double maxLad;

    public double GetMasa;
    
    public Kontener(int numerSeryjny, double wysokosc, double wagaWlasna, double glebokosc, double maxLad)
    {
        this.numerSeryjny = numerSeryjny;
        this.wysokosc = wysokosc;
        this.wagaWlasna = wagaWlasna;
        this.glebokosc = glebokosc;
        this.maxLad = maxLad;
    }

    public void Info()
    {
        Console.WriteLine("Nunmer seryjny kontenera: " + GetNumerSeryjny() + 
                          "\nWysokosc: " + wysokosc +
                          "\nWaga własna: " + wagaWlasna +
                          "\nGłębokość: " + glebokosc +
                          "\nMaksymalny waga ładunku: " + maxLad);
    }

    public void Oproznienie()
    {
        masa = 0;
        Console.WriteLine("Kontener "+ GetNumerSeryjny() + " opróżniony");

    }

    public void Zaladuj(double ladunek)
    {
        if (ladunek + masa <= maxLad)
        {
            masa += ladunek;
            Console.WriteLine("Ladunek załadowany na: "+ GetNumerSeryjny());

        }
        else
        {
            throw new OverfillException("Towar jest za duży");    //zrobić swój
        }
    }
}