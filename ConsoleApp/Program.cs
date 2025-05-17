using System;

class Program
{
    static bool[,] seats = new bool[5, 5];

    static void DisplaySeats()
    {
        Console.WriteLine("\nDostępne miejsca (O = wolne, X = zajęte):");
        for (int row = 0; row < 5; row++)
        {
            Console.Write((char)('A' + row) + " ");
            for (int seat = 0; seat < 5; seat++)
            {
                Console.Write(seats[row, seat] ? "X " : "O ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.WriteLine("Witamy w systemie rezerwacji biletów!\n");

        DisplaySeats();

        Console.Write("\nPodaj swoje imię: ");
        string name = Console.ReadLine();

        Console.Write("Wybierz rząd (A-E): ");
        char rowChar = char.ToUpper(Console.ReadKey().KeyChar);
        Console.Write("\nWybierz miejsce (1-5): ");
        int seatNumber;
        if (!int.TryParse(Console.ReadLine(), out seatNumber))
        {
            Console.WriteLine("Nieprawidłowy numer miejsca.");
            return;
        }

        int row = rowChar - 'A';
        int seat = seatNumber - 1;

        if (row >= 0 && row < 5 && seat >= 0 && seat < 5)
        {
            if (!seats[row, seat])
            {
                seats[row, seat] = true;
                Console.WriteLine($"\nBilet zarezerwowany dla {name} na miejsce {rowChar}{seat + 1}.");
            }
            else
            {
                Console.WriteLine("\nTo miejsce jest już zajęte.");
            }
        }
        else
        {
            Console.WriteLine("\nNieprawidłowe dane.");
        }

        DisplaySeats();
    }
}