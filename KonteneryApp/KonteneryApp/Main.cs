// See https://aka.ms/new-console-template for more information

using KonteneryApp;

Produkt banany = new Produkt("Bananas", 13.3);
Produkt czekolada = new Produkt("Chocolate", 18);
Produkt ryba = new Produkt("Fish", 2);
Produkt mięso = new Produkt("Meat", -15);
Produkt lody = new Produkt("Ice cream", -18);
Produkt mrozonaPizza = new Produkt("Frozen pizza", -30);
Produkt ser = new Produkt("Cheese", 7.2);
Produkt kielbasa = new Produkt("Sausages", 5);
Produkt maslo = new Produkt("Butter", 20.5);
Produkt jaja = new Produkt("Eggs", 19);

Statek statek1 = new Statek(100, 2, 1000);
Statek statek2 = new Statek(200, 1, 100);

KontenerNaPlyny kPlyny = new KontenerNaPlyny(012, 300, 500, 10000, 700, true);
KontenerNaGaz kGaz = new KontenerNaGaz(040, 310, 600, 10000,64, 1000);
KontenerChlodniczy kChlodniczy = new KontenerChlodniczy(124, 285, 300, 11000, 1000, "Eggs", 20);

try
{
    kPlyny.Zaladuj(600);
    //kPlyny.Zaladuj(300);
    kPlyny.Oproznienie();
    kPlyny.Zaladuj(600);

    kGaz.Zaladuj(60);
    //kGaz.Zaladuj(50);
    kGaz.Oproznienie();
    kGaz.Zaladuj(64);

    //kChlodniczy.Zaladuj(900, jaja);

    kChlodniczy.Zaladuj(200, jaja);
    kChlodniczy.Oproznienie();
    kChlodniczy.Zaladuj(900, maslo);
    kChlodniczy.Zaladuj(900, jaja);
}
catch (OverfillException e)
{
    Console.WriteLine(e.Message);
}

kChlodniczy.Info();
kGaz.Info();
kPlyny.Info();

statek1.ZaladujNa(kPlyny);
statek1.ZaladujNa(kGaz);
statek1.ZaladujNa(kChlodniczy);
statek1.Zamien("KON-L-012", kChlodniczy);

statek1.naInnyPojazd(kChlodniczy, statek2);

statek1.info();
statek2.info();
