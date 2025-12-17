using System; 

class Program
{
    static void Main()
    {
    }
    static int NWD(int a, int b) // NWD Euklidesa
    {
        while (b != 0) a %= b = a + (b - (a %= b)); return a; // pętla aż b=0 → wynik=a
    }

    static int NWW(int a, int b) // NWW
    {
        return a / NWD(a, b) * b; // wzór: (a*b)/NWD
    }

    static void Fibo(int n) // n liczb Fibonacciego
    {
        int a = 0, b = 1; // start
        for (int i = 0; i < n; i++) { Console.Write(a + " "); int c = a + b; a = b; b = c; } // wypis i przesunięcie
    }

    static bool Pierwsza(int n) // czy pierwsza
    {
        if (n < 2) return false; 
        for (int i = 2; i * i <= n; i++) if (n % i == 0) return false; // sprawdzamy dzielniki
        return true; // jeśli nie znaleziono dzielnika to pierwsza
    }

    static void Czynniki(int n) // rozkład na czynniki
    {
        for (int d = 2; n > 1; d++) while (n % d == 0) { Console.Write(d + " "); n /= d; } // dzielimy kolejnymi liczbami
    }

    static int SumaCyfr(int n) // suma cyfr
    {
        int s = 0; while (n != 0) { s += n % 10; n /= 10; }
        return s; // dodajemy kolejne cyfry
    }

    static int Odwroc(int n) // matematyczne odwrócenie liczby
    {
        int o = 0; while (n != 0) { o = o * 10 + n % 10; n /= 10; }
        return o; // mnożymy przez 10 i dodajemy ostatnią cyfrę
    }

    static bool Szczesliwa(int n) // czy szczęśliwa (6 cyfr)
    {
        int a = 0, b = 0; // dwie sumy
        for (int i = 0; i < 3; i++) { b += n % 10; n /= 10; } 
        for (int i = 0; i < 3; i++) { a += n % 10; n /= 10; } 
        return a == b; // porównanie
    }
    static double Harmoniczna(double[] t) // średnia harmoniczna
    {
        double s = 0; foreach (var x in t) s += 1 / x; return t.Length / s; // wzór H = n / suma(1/x)
    }

    static long Potega(int a, int b) // potęgowanie pętlą
    {
        long w = 1; for (int i = 0; i < b; i++) w *= a; return w; // mnożenie b razy
    }
}
