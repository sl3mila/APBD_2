namespace KonteneryApp;

public class KontenerNaPlyny : Kontener, IHazardNotifier
{
    private bool niebezpieczny;
    public override string GetNumerSeryjny()
    {
        return "KON-L-" + numerSeryjny;
    }

    public void Niebezpiecznie()
    {
        Console.WriteLine("Niebezpieczna sytuacją w kontenarze o numerze: " + GetNumerSeryjny());
    }

    public KontenerNaPlyny(int numerSeryjny, double wysokosc, double wagaWlasna, double glebokosc,
        double maxLad, bool niebezpieczny)
        : base(numerSeryjny,  wysokosc, wagaWlasna, glebokosc, maxLad)
    {
        this.niebezpieczny = niebezpieczny;
    }
    
    public void Info()
    {
        base.Info();
        Console.WriteLine("Ładunek jest niebezpieczny: " + niebezpieczny);
    }

    public void Zaladuj(double ladunek)
    {
        if (niebezpieczny)
        {
            if (maxLad * 0.5 < ladunek)
            {
                Niebezpiecznie();
            }
        }
        else
        {
            if (maxLad * 0.9 < ladunek)
            {
                Niebezpiecznie();
            }
            else
            {
                base.Zaladuj(ladunek);
            }
        }
    }
}