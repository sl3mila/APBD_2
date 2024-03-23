namespace KonteneryApp;

public abstract class Pojazd
{
    private protected int maxPredkosc;
    private protected int maxIloscKontenerow;
    private protected double maxWagaKontenerow;
    
    private protected Kontener[] kontenery;
    private protected int iloscKontenerow = 0;
    private protected double masa = 0;
    
    protected Pojazd(int maxPredkosc, int maxIloscKontenerow, double maxWagaKontenerow)
    {
        this.maxPredkosc = maxPredkosc;
        this.maxIloscKontenerow = maxIloscKontenerow;
        this.maxWagaKontenerow = maxWagaKontenerow;
        ListaKontenerow();
    }

    private protected void ListaKontenerow()
    {
        kontenery = new Kontener[maxIloscKontenerow];
    }
    
    public void ZaladujNa(Kontener kontener)
    {
        if (masa < maxWagaKontenerow && maxIloscKontenerow < iloscKontenerow)
        {
            kontenery[iloscKontenerow] = kontener;
            masa += kontener.GetMasa;
            iloscKontenerow++;
            Console.WriteLine("Kontener "+ kontener.GetNumerSeryjny() + " zaladowany");
        }
    }

    public void UsunZ(Kontener kontener)
    {
        for (int i = 0; i <= iloscKontenerow; i++)
        {
            if (kontener.GetNumerSeryjny().Equals(kontenery[i].GetNumerSeryjny()))
            {
                for (int j = i+1; j < iloscKontenerow; j++)
                {
                    kontenery[i] = kontenery[j];
                    masa -= kontenery[i].GetMasa;
                }
                kontenery[iloscKontenerow] = null;
                iloscKontenerow--;
                Console.WriteLine("Kontener "+ kontener.GetNumerSeryjny() + " usunięty");

            }
        }
    }

    public void Zamien(string zmieniany, Kontener naZmiane)
    {
        for (int i = 0; i <= iloscKontenerow; i++)
        {
            if (zmieniany.Equals(kontenery[i].GetNumerSeryjny()))
            {
                kontenery[i] = naZmiane;
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
                          "\nObecna załądowana masa: " + masa +
                          "\nZaładowane kontenery: ");
        for (int i = 0; i <= iloscKontenerow; i++)
        {
           kontenery[i].Info();
        }
    }
}