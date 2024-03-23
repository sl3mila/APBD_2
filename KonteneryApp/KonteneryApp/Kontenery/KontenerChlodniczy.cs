using System.Runtime.CompilerServices;

namespace KonteneryApp;

public class KontenerChlodniczy(int numerSeryjny, double wysokosc, double wagaWlasna, double glebokosc,
    double maxLad, string rodzajProdukt, double temperatura)  
    : Kontener(numerSeryjny, wysokosc, wagaWlasna, glebokosc, maxLad)
{
    private string RodzajProduktu { get; } = rodzajProdukt;
    private double Temperatura { get; }= temperatura;
    
    public override string GetNumerSeryjny()
    {
        return "KON-C-" + numerSeryjny;
    }
    

    public void Info()
    {
        base.Info();
        Console.WriteLine("Rodzaj przeworzonego produktu: " + RodzajProduktu +
                          "\nTemperatura: " + Temperatura + "\n");
    }

    public void Zaladuj(double ladunek, Produkt produkt)
    {
        if (czyOdpowiedniTyp_Temperatura(produkt))
        {
            if (ladunek <= MaxLad)
            {
                Masa += ladunek;
                Console.WriteLine("Ladunek zaladowany na: "+ GetNumerSeryjny());

            }
            else
            {
                throw new OverfillException("Towar jest za duży"); //zrobić swój
            }
        }
    }
    
    private bool czyOdpowiedniTyp_Temperatura(Produkt produkt) //TODO
    {
        if (RodzajProduktu != produkt.GetNazwa() || 
            temperatura < produkt.GetTemperatura() )
        {
            return false;
        }
        return true;
    }
}