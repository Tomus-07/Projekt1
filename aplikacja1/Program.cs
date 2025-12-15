using System;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            // Menu 
            Console.WriteLine("\n1 PESEL 2 Palindrom 3 Sam/Spół, 4 Bez cyfr, 5 Zmiana liter");
            Console.WriteLine("6 Hasło, 7 Słowa, 8 Generator, 9 Prefix, 0 Wyjście z programu");
            Console.Write("Wybór: ");
            string w = Console.ReadLine();

            if (w == "0") break; // wyjście

            // PESEL
            if (w == "1")
            {
                string p = Console.ReadLine();

                // sprawdzenie 11 cyfr
                bool ok = p.Length == 11 && p.All(char.IsDigit);

                // wagi do sumy kontrolnej
                int[] g = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                int s = 0;

                // liczenie sumy
                for (int i = 0; i < 10; i++)
                    s += (p[i] - '0') * g[i];

                // sprawdzenie cyfr 
                ok = ok && ((10 - s % 10) % 10) == (p[10] - '0');

                if (!ok) { Console.WriteLine("Błędny"); continue; }

                // wyciąganie daty
                int r = int.Parse(p[..2]);
                int m = int.Parse(p[2..4]);
                int d = int.Parse(p[4..6]);

                // określenie wieku na podstawie miesiąca
                r += 1900 + (m / 20) * 100;
                m %= 20;

                // płeć 
                string plec = ((p[9] - '0') % 2 == 0) ? "K" : "M";

                Console.WriteLine($"{d:D2}-{m:D2}-{r}, {plec}");
            }

            // Palindrom
            else if (w == "2")
            {
                string t = Console.ReadLine().ToLower().Replace(" ", "");
                Console.WriteLine(t.SequenceEqual(t.Reverse()) ? "Palindrom" : "Nie");
            }

            // Samogłoski i spółgłoski 
            else if (w == "3")
            {
                string t = Console.ReadLine().ToLower();
                string sam = "aeiouyąęó";

                int s = t.Count(c => char.IsLetter(c) && sam.Contains(c));// samogłoski
                int sp = t.Count(c => char.IsLetter(c) && !sam.Contains(c));// spółgłoski

                Console.WriteLine($"Sam:{s} Spół:{sp}");
            }

            // Usunięcie cyfr
            else if (w == "4")
                Console.WriteLine(new string(Console.ReadLine().Where(c => !char.IsDigit(c)).ToArray()));

            //Zmień wielkość liter
            else if (w == "5")
            {
                string t = Console.ReadLine();
                // jesli wystapi litera, zmienia jej wartosc
                Console.WriteLine(new string(t.Select(c =>
                    char.IsLetter(c) ? (char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)) : c).ToArray()));
            }

            // Sprawdź hasło
            else if (w == "6")
            {
                string h = Console.ReadLine();
                bool ok = h.Length >= 8 && h.Any(char.IsDigit) && h.Any(char.IsUpper);
                Console.WriteLine(ok ? "OK" : "Złe");
            }

            // Liczba słów
            else if (w == "7")
                Console.WriteLine(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Length);

            // Generator haseł
            else if (w == "8")
            {
                int dl = int.Parse(Console.ReadLine()); //długość hasła
                string z = "";

                // Każda odpowiedź „t” dodaje grupę znaków
                if (Console.ReadLine() == "t") z += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";   // duże
                if (Console.ReadLine() == "t") z += "abcdefghijklmnopqrstuvwxyz";   // małe
                if (Console.ReadLine() == "t") z += "0123456789";                   // cyfry
                if (Console.ReadLine() == "t") z += "!@#$%^&*()_+-=[]{}<>?";        // spec.

                Random r = new();
                Console.WriteLine(new string(Enumerable.Range(0, dl).Select(_ => z[r.Next(z.Length)]).ToArray()));
            }

            // Wspólny prefix   
            else if (w == "9")
            {
                string a = Console.ReadLine(), b = Console.ReadLine();
                int i = 0;
                // dopóki litery sa takie same, zwieksz indeks
                while (i < a.Length && i < b.Length && a[i] == b[i]) i++;
                Console.WriteLine(a[..i]);
            }
        }
    }
}
