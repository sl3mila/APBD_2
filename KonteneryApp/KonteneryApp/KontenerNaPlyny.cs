namespace KonteneryApp;

public class KontenerNaPlyny(int numerSeryjny, double wysokosc, double wagaWlasna, double glebokosc,
    double maxLad, bool niebezpieczny) 
    : Kontener(numerSeryjny, wysokosc, wagaWlasna, glebokosc, maxLad), IHazardNotifier
{
    private bool Niebezpieczny = niebezpieczny;
    public override string GetNumerSeryjny()
    {
        return "KON-L-" + numerSeryjny;
    }

    public void Niebezpiecznie()
    {
        Console.WriteLine("Niebezpieczna sytuacją w kontenarze o numerze: " + GetNumerSeryjny());
    }
    
    public void Info()
    {
        base.Info();
        Console.WriteLine("Ładunek jest niebezpieczny: " + Niebezpieczny);
    }

    public void Zaladuj(double ladunek)
    {
        if (Niebezpieczny)
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