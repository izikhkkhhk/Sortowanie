using System;
using System.Collections.Generic;

namespace ListaUczniow
{
    class Uczen
    {
        public string Imie { get; set; }
        public int Wiek { get; set; }
        public int Wzrost { get; set; }
        public Uczen(string imie, int wiek, int wzrost)
        {
            Imie = imie;
            Wiek = wiek;
            Wzrost = wzrost;
        }
        public override string ToString()
        {
            return $"Imię: {Imie}, Wiek: {Wiek}, Wzrost: {Wzrost} cm";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Uczen> uczniowie = new List<Uczen>();
            string opcja;
            do
            {
                Console.WriteLine("\nMENU:");
                Console.WriteLine("1. Dodaj nowego ucznia");
                Console.WriteLine("2. Wyświetl listę uczniów (posortowaną po wzroście)");
                Console.WriteLine("3. Wyjście");
                Console.Write("Wybierz opcję: ");
                opcja = Console.ReadLine();

                switch (opcja)
                {
                    case "1":
                        DodajUcznia(uczniowie);
                        break;
                    case "2":
                        WyswietlUczniow(uczniowie);
                        break;
                    case "3":
                        Console.WriteLine("Zamykanie programu...");
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                        break;
                }

            } while (opcja != "3");
        }
        static void DodajUcznia(List<Uczen> uczniowie)
        {
            Console.Write("Podaj imię ucznia: ");
            string imie = Console.ReadLine();

            Console.Write("Podaj wiek ucznia: ");
            if (!int.TryParse(Console.ReadLine(), out int wiek))
            {
                Console.WriteLine("Nieprawidłowy wiek. Uczeń nie został dodany.");
                return;
            }
            Console.Write("Podaj wzrost ucznia (w cm): ");
            if (!int.TryParse(Console.ReadLine(), out int wzrost))
            {
                Console.WriteLine("Nieprawidłowy wzrost. Uczeń nie został dodany.");
                return;
            }
            uczniowie.Add(new Uczen(imie, wiek, wzrost));
            Console.WriteLine("Uczeń został dodany pomyślnie.");
        }
        static void WyswietlUczniow(List<Uczen> uczniowie)
        {
            if (uczniowie.Count == 0)
            {
                Console.WriteLine("Lista uczniów jest pusta.");
                return;
            }

            // Sortowanie bąbelkowe
            for (int i = 0; i < uczniowie.Count - 1; i++)
            {
                for (int j = 0; j < uczniowie.Count - i - 1; j++)
                {
                    if (uczniowie[j].Wzrost > uczniowie[j + 1].Wzrost)
                    {
                        // Zamiana miejscami
                        var temp = uczniowie[j];
                        uczniowie[j] = uczniowie[j + 1];
                        uczniowie[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\nLista uczniów (posortowana po wzroście):");
            foreach (var uczen in uczniowie)
            {
                Console.WriteLine(uczen);
            }
        }
    }
}
