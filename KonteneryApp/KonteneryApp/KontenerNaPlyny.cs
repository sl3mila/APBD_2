namespace KonteneryApp;

public class KontenerNaPlyny : Kontener
{
    public override String GetNumerSeryjny()
    {
        return "KON-L-" + numerSeryjny;
    }

    public KontenerNaPlyny(int numerSeryjny, double masa, double wysokosc, double wagaWlasna, double glebokosc, double maxLad) 
        : base(numerSeryjny, masa, wysokosc, wagaWlasna, glebokosc, maxLad)
    {
        
    }
}