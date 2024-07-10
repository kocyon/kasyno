using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace kasyno
{
    internal class Program
    {
        class Guy
        {
            public string Name;
            public int Cash;

            public void WriteMyInfo()
            {
                Console.WriteLine(Name + " ma " + Cash + " zł.");
            }

            public int GiveCash(int amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine(Name + " mówi: " + amount + " nie jest poprawną kwotą.");
                    return 0;
                }
                if (amount > Cash)
                {
                    Console.WriteLine(Name + " mówi: " + "nie mam wystarczających środków, aby dać ci " + amount + " zł.");
                    return 0;
                }
                Cash -= amount;
                return amount;
            }

            public void ReceiveCash(int amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine(Name + " mówi: " + "nie przyjmę " + amount + " zł.");
                }
                else
                {
                    Cash += amount;
                }
            }
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            double odds = 0.75;
            Guy player = new Guy() {Cash = 100, Name = "Gracz"};
            Console.WriteLine("Witamy w kasynie. Prawdopodobieństwo przegranej: " + odds);

            while (player.Cash > 0)
            {
                player.WriteMyInfo();
                Console.Write("Stawiana kwota: ");
                string howMuch = Console.ReadLine();
                if (int.TryParse(howMuch, out int amount))
                {
                    int pot = player.GiveCash(amount) * 2;
                    if (pot > 0)
                    {
                        rnd.NextDouble();
                        if (rnd.NextDouble() > odds)
                        {
                            Console.WriteLine("Wygrałeś " + pot + " zł");
                            player.ReceiveCash(pot);
                        }
                        else
                        {
                            Console.WriteLine("Niestety przegrałeś.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wpisz poprawną kwotę.");
                }

            }
            Console.WriteLine("Kasyno zawsze wygrywa.");
            Console.ReadKey();
        }
    }
}
