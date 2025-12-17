using System;

class Program
{
    static Random r = new Random(); // generator losowy

    static void Main()
    {
        Zad1(); // losowe liczby > średnia
        int[] t = { 1, 2, 3, 2, 1 };
        Console.WriteLine(Zad2(t)); // sprawdzanie symetrii
        int[] t2 = { 1, 2, 2, 3, 2, 2, 2 };
        Console.WriteLine(Zad3(t2)); // najczęstsza wartość
        int[] t3 = { 0, 1, 1, 1, 0, 1 };
        Console.WriteLine(Zad4(t3)); // najdłuższy ciąg jedynek
        int[] t4 = { 5, 10, 15, 2, 20 };
        Console.WriteLine(string.Join(" ", Zad5(t4))); // liczby >=10
        Zad6(); // ile liczb pierwszych z 50 losowych
        int[] A = { 1, 2, 3 }, B = { 4, 5, 6 };
        Console.WriteLine(string.Join(" ", Zad7(A, B))); // suma elementów
        Zad8(3); // suma przekątnych tablicy NxN
        int[,] m = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        Zad9(m); // suma i max w tablicy 2D
        int[] t5 = { 1, 2, 3, 2, 4, 5 };
        Console.WriteLine(Zad10(t5)); // liczba trójek rosnących
    }

    static void Zad1()
    {
        int[] t = new int[20]; int s = 0, c = 0; // tablica, suma i licznik
        for (int i = 0; i < 20; i++) { t[i] = r.Next(1, 101); s += t[i]; } // wypełnij losowo i sumuj
        double sr = s / 20.0; foreach (int x in t) if (x > sr) c++; // policz > średniej
        Console.WriteLine(c);
    }

    static bool Zad2(int[] t)
    {
        for (int i = 0; i < t.Length / 2; i++) if (t[i] != t[t.Length - 1 - i]) return false; // sprawdz symetrię
        return true;
    }

    static int Zad3(int[] t)
    {
        int best = t[0], max = 0;
        for (int i = 0; i < t.Length; i++)
        {
            int c = 0;
            for (int j = 0; j < t.Length; j++) if (t[j] == t[i]) c++; // zlicz wystąpienia
            if (c > max) { max = c; best = t[i]; } // aktualizuj najlepszą wartość
        }
        return best;
    }

    static int Zad4(int[] t)
    {
        int max = 0, a = 0;
        foreach (int x in t) { if (x == 1) a++; else a = 0; if (a > max) max = a; } // najdłuższy ciąg jedynek
        return max;
    }

    static int[] Zad5(int[] t)
    {
        int c = 0; foreach (int x in t) if (x >= 10) c++; // policz ile >=10
        int[] n = new int[c]; int i2 = 0; foreach (int x in t) if (x >= 10) n[i2++] = x; // kopiuj >=10
        return n;
    }

    static void Zad6()
    {
        int c = 0;
        for (int i = 0; i < 50; i++) if (Pierwsza(r.Next(1, 101))) c++; // losuj i sprawdzaj pierwsze
        Console.WriteLine(c);
    }

    static bool Pierwsza(int n) { if (n < 2) return false; for (int i = 2; i * i <= n; i++) if (n % i == 0) return false; return true; } // test pierwszości

    static int[] Zad7(int[] A, int[] B)
    {
        int[] C = new int[A.Length]; for (int i = 0; i < A.Length; i++) C[i] = A[i] + B[i]; // sumuj elementy
        return C;
    }

    static void Zad8(int N)
    {
        int[,] m = new int[N, N]; int s1 = 0, s2 = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++) m[i, j] = r.Next(1, 10); // wypełnij losowo
            s1 += m[i, i]; s2 += m[i, N - 1 - i]; // sumuj przekątne
        }
        Console.WriteLine($"{s1} {s2}");
    }

    static void Zad9(int[,] t)
    {
        int s = 0, max = t[0, 0];
        foreach (int x in t) { s += x; if (x > max) max = x; } // suma i max
        Console.WriteLine($"{s} {max}");
    }

    static int Zad10(int[] t)
    {
        int c = 0;
        for (int i = 0; i < t.Length - 2; i++) if (t[i] < t[i + 1] && t[i + 1] < t[i + 2]) c++; // trójki rosnące
        return c;
    }
}
