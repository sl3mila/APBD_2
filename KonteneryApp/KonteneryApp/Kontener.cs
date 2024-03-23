namespace KonteneryApp;

public abstract class Kontener
{
    private protected int numerSeryjny;
    public abstract String GetNumerSeryjny();

    private protected double masa;
    private protected double wysokosc;
    private protected double wagaWlasna;
    private protected double glebokosc;
    private protected double maxLad;

    public double GetMasa;
    
    public Kontener(int numerSeryjny, double masa, double wysokosc, double wagaWlasna, double glebokosc, double maxLad)
    {
        this.numerSeryjny = numerSeryjny;
        this.masa = masa;
        this.wysokosc = wysokosc;
        this.wagaWlasna = wagaWlasna;
        this.glebokosc = glebokosc;
        this.maxLad = maxLad;
    }

    public void Oproznienie()
    {
        masa = 0;
    }

    public void Zaladuj(double ladunek)
    {
        if (ladunek <= maxLad)
        {
            masa += ladunek;
        }
        else
        {
            throw new Exception("OverfillException: za duży towar");    //zrobić swój
        }
    }
}