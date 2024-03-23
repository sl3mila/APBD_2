namespace KonteneryApp;

public class Produkt
{
    private string nazwa;
    private double temperaturaDoPrzewozu;

    public Produkt(string nazwa, double temperaturaDoPrzewozu)
    {
        this.nazwa = nazwa;
        this.temperaturaDoPrzewozu = temperaturaDoPrzewozu;
    }

    public string GetNazwa()
    {
        return nazwa;
    }

    public double GetTemperatura()
    {
        return temperaturaDoPrzewozu;
    }
}