using System.Runtime.CompilerServices;

namespace KonteneryApp;

public class KontenerChlodniczy : Kontener
{
    private string rodzajProduktu;
    private double temperatura;
    
    public override string GetNumerSeryjny()
    {
        return "KON-C-" + numerSeryjny;
    }

    public KontenerChlodniczy(int numerSeryjny, double wysokosc, double wagaWlasna, double glebokosc,
        double maxLad, string rodzajProdukt, double temperatura) 
        : base(numerSeryjny,  wysokosc, wagaWlasna, glebokosc, maxLad)
    {
        this.rodzajProduktu = rodzajProdukt;
        this.temperatura = temperatura;
    }

    public void Info()
    {
        base.Info();
        Console.WriteLine("Rodzaj przeworzonego produktu: " + rodzajProduktu +
                          "\nTemperatura: " + temperatura);
    }

    public void Zaladuj(double ladunek, Produkt produkt)
    {
        if (czyOdpowiedniTyp_Temperatura(produkt))
        {
            if (ladunek <= maxLad)
            {
                masa += ladunek;
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
        if (rodzajProduktu != produkt.GetNazwa() || 
            temperatura < produkt.GetTemperatura() )
        {
            return false;
        }
        return true;
    }
}