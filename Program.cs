using System;
using System.Collections.Generic;

class Program
{
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"Articolo: {Name}, Prezzo: {Price:C}";
        }
    }

    static List<Item> cart = new List<Item>();

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n1. Aggiungi un articolo al carrello");
            Console.WriteLine("2. Visualizza articoli nel carrello");
            Console.WriteLine("3. Calcola totale");
            Console.WriteLine("4. Esci");
            Console.Write("Scegli un'opzione: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddItem();
                    break;
                case "2":
                    ShowCart();
                    break;
                case "3":
                    CalculateTotal();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Arrivederci!");
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }
    }

    static void AddItem()
    {
        Console.Write("Inserisci il nome dell'articolo: ");
        string name = Console.ReadLine();

        Console.Write("Inserisci il prezzo dell'articolo: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            cart.Add(new Item(name, price));
            Console.WriteLine($"Articolo '{name}' aggiunto con successo.");
        }
        else
        {
            Console.WriteLine("Prezzo non valido.");
        }
    }

    static void ShowCart()
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("Il carrello è vuoto.");
        }
        else
        {
            Console.WriteLine("\nArticoli nel carrello:");
            foreach (var item in cart)
            {
                Console.WriteLine(item);
            }
        }
    }

    static void CalculateTotal()
    {
        decimal total = 0;
        foreach (var item in cart)
        {
            total += item.Price;
        }
        Console.WriteLine($"Totale del carrello: {total:C}");
    }
}
