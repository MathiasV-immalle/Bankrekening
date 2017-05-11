using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class Program
    {
        static void PrintMenu()
        {
            Melding("Kies een actie.");
            Console.WriteLine("Type 1 om een rekening te openen");
            Console.WriteLine("Type 2 om geld te storten");
            Console.WriteLine("Type 3 om geld af te halen");
            Console.WriteLine("Type 0 om het programma te verlaten");
        }

        static Dictionary<int, Action> acties = new Dictionary<int, Action>()
        {
            { 1, Keuze1 },
            { 2, Keuze2 },
            { 3, Keuze3 }
        };

        static Rekening rekening = new Rekening();
        static int bedrag;

        static void Foutmelding(string melding)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(melding);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Goedkeuring(string melding)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(melding);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Melding(string melding)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(melding);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Keuze1()
        {
            rekening.Saldo = 0;
            Console.WriteLine("Wat is uw voornaam?");
            rekening.Voornaam = Console.ReadLine();

            Console.WriteLine("Wat is uw achternaam?");
            rekening.Achternaam = Console.ReadLine();

            Console.WriteLine("Wat is uw leeftijd?");
            rekening.Leeftijd = Console.ReadLine();
            if (Convert.ToInt16(rekening.Leeftijd) < 18)
            {
                Foutmelding("U moet ten minste 18 jaar zijn om een rekening te kunnen openen.");
                PrintMenu();
            }
            else
            {
                Goedkeuring("De rekening is succesvol geopend.");
                PrintMenu();
            }
        }

        static void Keuze2()
        {
            Console.WriteLine("Welk bedrag wilt u storten? (Kommagetallen worden NIET aanvaard)");
            string x = Console.ReadLine();
            bedrag = Convert.ToInt32(x);
            rekening.Saldo += bedrag;
            Goedkeuring("U heeft het bedrag succesvol gestort.");
            PrintMenu();
        }
        static void Keuze3()
        {
            Console.WriteLine("Welk bedrag wilt u afhalen? (Kommagetallen worden NIET aanvaard)");
            string x = Console.ReadLine();
            bedrag = Convert.ToInt32(x);
            if (rekening.Saldo < bedrag)
            {
                Foutmelding("Er staat niet genoeg geld op uw rekening.");
                PrintMenu();
            }
            else
            {
                rekening.Saldo -= bedrag;
                Goedkeuring("U heeft het bedrag succesvol afgehaald.");
                PrintMenu();
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            PrintMenu();

            bool infinite = true;
            while (infinite)
            {
                int keuze = Convert.ToInt16(Console.ReadLine());
                switch (keuze)
                {
                    case 0:
                        infinite = false;
                        break;
                    default:
                        acties[keuze]();
                        break;
                }
            }
        }
    }
}
