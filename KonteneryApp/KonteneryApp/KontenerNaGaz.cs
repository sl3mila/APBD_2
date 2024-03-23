namespace KonteneryApp;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    private double cisnienie;
    
    public override string GetNumerSeryjny()
    {
        return "KON-G-" + numerSeryjny;
    }

    public KontenerNaGaz(int numerSeryjny, double wysokosc, double wagaWlasna, double glebokosc, 
        double maxLad, double cisnienie) 
        : base(numerSeryjny, wysokosc, wagaWlasna, glebokosc, maxLad)
    {
        this.cisnienie = cisnienie;
    }
    
    public void Info()
    {
        base.Info();
        Console.WriteLine("Cisnienie: " + cisnienie);
    }

    public void Niebezpiecznie()
    {
        Console.WriteLine("Niebezpieczna sytuacją w kontenarze o numerze: " + GetNumerSeryjny());
    }
    
    public void Oproznienie()
    {
        masa = masa*0.05;
        Console.WriteLine("Kontener "+ GetNumerSeryjny() + " opróżniony");

    } 
}