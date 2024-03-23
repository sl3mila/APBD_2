namespace KonteneryApp;

public class KontenerNaGaz(int numerSeryjny, double wysokosc, double wagaWlasna, double glebokosc, 
    double maxLad, double cisnienie) 
    : Kontener(numerSeryjny, wysokosc, wagaWlasna, glebokosc, maxLad), IHazardNotifier
{
    private double Cisnienie { get; } = cisnienie;
    
    public override string GetNumerSeryjny()
    {
        return "KON-G-" + numerSeryjny;
    }
    
    public void Info()
    {
        base.Info();
        Console.WriteLine("Cisnienie: " + Cisnienie);
    }

    public void Niebezpiecznie()
    {
        Console.WriteLine("Niebezpieczna sytuacją w kontenarze o numerze: " + GetNumerSeryjny());
    }
    
    public void Oproznienie()
    {
        Masa = Masa*0.05;
        Console.WriteLine("Kontener "+ GetNumerSeryjny() + " opróżniony");

    } 
}