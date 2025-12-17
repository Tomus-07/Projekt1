using System;

class Program
{
    static Random r = new Random();

    static void Main()
    {
        int[] losowe = LosoweTab(10, 1, 50); // tablica 10 losowych liczb od 1 do 50
        Console.WriteLine("Losowe: " + string.Join(", ", losowe));

        Console.WriteLine("Rok 2024 przestępny? " + (Przestepny(2024) ? "Tak" : "Nie"));
        Console.WriteLine("Liczba cyfr 12345: " + LiczbaCyfr(12345));

        int[] t = { 1, 2, 3, 4, 5, 6 };
        Console.WriteLine("Suma parzystych: " + SumaParzystych(t));

        Console.WriteLine("220 i 284 amicable? " + (Amicable(220, 284) ? "Tak" : "Nie"));
    }

    // losowa tablica
    static int[] LosoweTab(int n, int min, int max)
    {
        int[] t = new int[n];
        for (int i = 0; i < n; i++) t[i] = r.Next(min, max + 1);
        return t;
    }

    // rok przestępny
    static bool Przestepny(int rok) => (rok % 4 == 0 && rok % 100 != 0) || (rok % 400 == 0);

    // liczba cyfr
    static int LiczbaCyfr(int n)
    {
        if (n == 0) return 1;
        int c = 0;
        n = Math.Abs(n);
        while (n > 0) { n /= 10; c++; }
        return c;
    }

    // suma parzystych elementów tablicy
    static int SumaParzystych(int[] t)
    {
        int s = 0;
        foreach (int x in t) if (x % 2 == 0) s += x;
        return s;
    }

    // liczby zaprzyjaźnione
    static bool Amicable(int a, int b)
    {
        int suma1 = 0, suma2 = 0;
        for (int i = 1; i < a; i++) if (a % i == 0) suma1 += i;
        for (int i = 1; i < b; i++) if (b % i == 0) suma2 += i;
        return suma1 == b && suma2 == a;
    }
}
