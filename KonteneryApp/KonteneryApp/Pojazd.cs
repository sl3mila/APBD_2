namespace KonteneryApp;

public abstract class Pojazd(int maxPredkosc, int maxIloscKontenerow, double maxWagaKontenerow)
{
    private protected int MaxPredkosc { get; } = maxPredkosc;
    private protected int MaxIloscKontenerow { get; } = maxIloscKontenerow;
    private protected double MaxWagaKontenerow { get; } = maxWagaKontenerow;
    
    private protected List<Kontener> Kontenery { get; set; } = [];
    private protected int IloscKontenerow { get; set; }= 0;
    private protected double Masa { get; set; }= 0;
    
    public void ZaladujNa(Kontener kontener)
    {
        if (Masa + kontener.Masa < maxWagaKontenerow && maxIloscKontenerow <= IloscKontenerow)
        {
            Kontenery[IloscKontenerow] = kontener;
            Masa += kontener.Masa;
            IloscKontenerow++;
            Console.WriteLine("Kontener "+ kontener.GetNumerSeryjny() + " zaladowany");
        }
    }

    public void UsunZ(Kontener kontener)
    {
        for (int i = 0; i <= IloscKontenerow; i++)
        {
            Kontenery.Remove(kontener);
            IloscKontenerow--;
            Console.WriteLine("Kontener "+ kontener.GetNumerSeryjny() + " usunięty");
        }
    }

    public void Zamien(string zmieniany, Kontener naZmiane)
    {
        for (int i = 0; i <= IloscKontenerow; i++)
        {
            if (zmieniany.Equals(Kontenery[i].GetNumerSeryjny()))
            {
                Kontenery[i] = naZmiane;
                Console.WriteLine("Kontener zmieniony");

            }
        }
    }

    public void naInnyPojazd(Kontener kontener, Pojazd naPojazd)
    {
        UsunZ(kontener);
        naPojazd.ZaladujNa(kontener);
        Console.WriteLine("Miejsce kontenera "+ kontener.GetNumerSeryjny() + " zmienione");

    }

    public void info()
    {
        Console.WriteLine("Maksymalna prędkość: " + maxPredkosc + 
                          "\nMaksymalna ilość kontenerów: " + maxIloscKontenerow +
                          "\nMaksymalna waga kontenerów: " + maxWagaKontenerow +
                          "\nObecna załądowana masa: " + Masa +
                          "\nZaładowane kontenery: ");
        for (int i = 0; i <= IloscKontenerow; i++)
        {
           Kontenery[i].Info();
        }
    }
}