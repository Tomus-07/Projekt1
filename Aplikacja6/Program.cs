using System;
using System.Collections.Generic;
using System.Linq;

class Osoba
{
    public string Imie, Nazwisko;
    int wiek;
    public int Wiek { get => wiek; set { if (value >= 0 && value < 120) wiek = value; } }

    public Osoba(string i, string n, int w) { Imie = i; Nazwisko = n; Wiek = w; }
    public virtual void PrzedstawSie() =>
        Console.WriteLine($"Cześć, jestem {Imie} {Nazwisko}, mam {Wiek} lat.");
}

class Samochod
{
    public string Marka, Model; public int Rok;
    public Samochod(string m, string mo, int r) { Marka = m; Model = mo; Rok = r; }
    public void Opis() => Console.WriteLine($"{Marka} {Model} {Rok}");
}

class Prostokat
{
    public double S, W;
    public Prostokat(double s, double w) { S = s; W = w; }
    public double Pole() => S * W;
    public double Obwod() => 2 * (S + W);
}

class Pojazd { public int Predkosc; public virtual void Jedz() => Console.WriteLine($"Jadę {Predkosc} km/h"); }
class Rower : Pojazd { public override void Jedz() => Console.WriteLine($"Rower {Predkosc} km/h"); }
class Auto : Pojazd { public override void Jedz() => Console.WriteLine($"Auto {Predkosc} km/h"); }

static class Matematyka { public static int Dodaj(int a, int b) => a + b; }

class BankAccount
{
    decimal saldo;
    public void Wplac(decimal k) { if (k > 0) saldo += k; }
    public void Wyplac(decimal k) { if (k <= saldo) saldo -= k; }
    public void Pokaz() => Console.WriteLine($"Saldo: {saldo}");
}

class Ksiazka
{
    public string Tytul, Autor;
    public Ksiazka(string t, string a) { Tytul = t; Autor = a; }
    public Ksiazka(Ksiazka k) { Tytul = k.Tytul; Autor = k.Autor; } // kopia
}

class Uczen : Osoba
{
    public string Klasa; public int[] Oceny;
    public Uczen(string i, string n, int w, string k, int[] o) : base(i, n, w) { Klasa = k; Oceny = o; }
    public double Srednia() => Oceny.Average();
}

class Nauczyciel : Osoba
{
    public string Przedmiot;
    public Nauczyciel(string i, string n, int w, string p) : base(i, n, w) { Przedmiot = p; }
}

class Szkola
{
    public List<Uczen> U = new(); public List<Nauczyciel> N = new();
    public void Wypisz()
    {
        U.ForEach(x => x.PrzedstawSie());
        N.ForEach(x => x.PrzedstawSie());
    }
}

class Program
{
    static void Main()
    {
        // Osoby
        Osoba[] osoby = {
            new("Jan","Kowalski",25), new("Anna","Nowak",30),
            new("Piotr","Lis",20), new("Ola","Kot",22), new("Tomek","Wilk",40)
        };
        foreach (var o in osoby) o.PrzedstawSie();

        // Samochód
        new Samochod("BMW", "X5", 2020).Opis();

        // Prostokąt
        var p = new Prostokat(4, 5);
        Console.WriteLine(p.Pole() + " " + p.Obwod());

        // Pojazdy
        new Rower { Predkosc = 20 }.Jedz();
        new Auto { Predkosc = 100 }.Jedz();

        // Matematyka
        Console.WriteLine(Matematyka.Dodaj(2, 3));

        // Bank
        var b = new BankAccount(); b.Wplac(500); b.Wyplac(200); b.Pokaz();

        // Książka
        var k1 = new Ksiazka("Pan Tadeusz", "Mickiewicz");
        var k2 = new Ksiazka(k1);

        // Szkoła
        var s = new Szkola();
        s.U.Add(new Uczen("Adam", "Nowy", 16, "3A", new[] { 4, 5, 3 }));
        s.N.Add(new Nauczyciel("Ewa", "Polna", 40, "Matematyka"));
        s.Wypisz();
    }
}

