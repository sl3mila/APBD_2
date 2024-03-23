namespace KonteneryApp;

public abstract class Pojazd(int maxPredkosc, int maxIloscKontenerow, double maxWagaKontenerow)
{
    private protected int MaxPredkosc { get; } = maxPredkosc;
    private protected int MaxIloscKontenerow { get; } = maxIloscKontenerow;
    private protected double MaxWagaKontenerow { get; } = maxWagaKontenerow;

    public List<Kontener> Kontenery { get; set; } = [];
    public double Masa { get; set; } = 0;
    
    public void ZaladujNa(Kontener kontener)
    {
        if (!( Kontenery.Sum(c => c.Masa) + kontener.Masa < maxWagaKontenerow))
        {
            Console.WriteLine("Za duża masa aby załadować");
            return;
        } 
        if (maxIloscKontenerow <= Kontenery.Count)
        {
            Console.WriteLine("Pojazd pełny");
            return;
        }
        Kontenery.Add(kontener);
        //Masa += kontener.Masa;
        //IloscKontenerow++;
        Console.WriteLine("Kontener "+ kontener.GetNumerSeryjny() + " zaladowany");
    }

    public void UsunZ(Kontener kontener)
    {
            Kontenery.Remove(kontener);
            //IloscKontenerow--;
            Console.WriteLine("Kontener "+ kontener.GetNumerSeryjny() + " usunięty");
    }

    public void Zamien(string zmieniany, Kontener naZmiane)
    {
        for (int i = 0; i < Kontenery.Count; i++)
        {
            if (zmieniany.Equals(Kontenery[i].GetNumerSeryjny()))
            {
                Kontenery.Remove(Kontenery[i]);
                Kontenery.Add(naZmiane);
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
        Console.WriteLine("Maksymalna prędkość: " + MaxPredkosc + 
                          "\nMaksymalna ilość kontenerów: " + MaxIloscKontenerow +
                          "\nMaksymalna waga kontenerów: " + MaxWagaKontenerow +
                          "\nObecna załądowana masa: " + Kontenery.Sum(c => c.Masa) +
                          "\nIlość kontenerów: " + Kontenery.Count + "\n");
    }
}