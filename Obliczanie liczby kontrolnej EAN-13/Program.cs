using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obliczanie_liczby_kontrolnej_EAN_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int[] ean = new int[13];
            int[] multiplier = { 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3 };
            double sum;
            Console.WriteLine("Program weryfikujący liczbę kontrolną.");
            while (true)
            {
                //Zapis do postaci string
                Console.WriteLine("Podaj 13 cyfrowy nr. EAN :");
                input = Console.ReadLine();

                //Sprawdzenie poprawnej ilości znaków
                if (input.Length != 13)
                {
                    Console.WriteLine("Nr. EAN musi zawierać 13 cyfr!");
                    continue;
                }

                //Konwersja z typu string do tablicy int
                try
                {
                    int i = 0;
                    foreach (char c in input) 
                    {
                        ean[i] = int.Parse(c.ToString());
                        i++;
                    }

                }

                //Przy wyłapaniu błędnych znaków przerywa konwersje i ponawia pętle
                catch
                {
                    Console.WriteLine("Nr. EAN nie może zawierać liter!");
                    continue;
                }
                break;

            }
            //Przeliczenie sumy dwunastu pierwszych znaków, potem pomnożenie każdej liczby przemiennie przez 1 i 3
            sum = 0;
            for(int i=0;i<multiplier.Length; i++)
            {
                sum += ean[i] * multiplier[i];
            }
            int roundedNumber = (int)Math.Ceiling(sum / 10.0) * 10;

            //Sprawdzenie czy ostatnia liczba w podanym ciągu jest zgodna z wynikiem powyższego działania
            if ((roundedNumber - sum) == ean[12])
            {
                Console.WriteLine("\nPodany numer EAN jest prawidłowy.");
            }
            else
            {
                Console.WriteLine("\nPodany numer EAN nie jest poprawny.");
            }
        }
    }
}
