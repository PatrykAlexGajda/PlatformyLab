using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{   
    // Klasa Plecak zawiera liste elementow typu przedmiot oraz pole capacity, oraz wartosc bedace typu int
    public class Plecak
    {
        public List<Przedmiot> skradzione = new List<Przedmiot>();
        public int capacity;
        public int wartosc;
        
        public Plecak(int cap) 
        {
            capacity = cap;
            wartosc = 0;
        }

        // Funkcja dodajaca do plecaka "skarb", bedacy obiektem typu Przedmiot
        // Wewnatrz funkcji jest sprawdzane czy mamy jeszcze miejsce w plecaku
        public void doPlecaka(Przedmiot skarb) 
        {
            if (capacity - skarb.weight < 0)
            {
                Console.WriteLine("Brak miejsca w plecaku.");
            }
            else
            {
                skradzione.Add(skarb);
                capacity -= skarb.weight;
                wartosc += skarb.value;
            }
        }

        // Funkcja rabuj posiada 2 argumenty: plecak typu Plecak oraz liste przedmiotow typu Przedmiot
        // Petla wykonuje sie n - krotnie, gdzie n jest rowne liczbie przedmiotow w puli. Przedmioty sa dodawane tak dlugo jak jest miejsce
        public void rabuj(Plecak plecak, List<Przedmiot> przedmioty) 
        {
            int j = 0;
            while (j < przedmioty.Count())
            {
                plecak.doPlecaka(przedmioty[j]);
                j++;
            }
        }


        /*public void wyswietlZawartosc(Plecak plecak) 
        {
            for (int k = 0; k < plecak.skradzione.Count(); k++)
            {
                Console.WriteLine(plecak.skradzione[k]);
            }
        }
        */

        // Przeciazenie funkcji toString w celu wypisania informacji o wszystkich 
        // zrabowanych przedmiotach
        public override string ToString()
        {   
            string str = "Zawartość plecaka:\n";
            str += "Waga\t Wartosc\t Stosunek\n";
            for (int i = 0; i < skradzione.Count(); i++) 
            {
                str += skradzione[i].weight.ToString() + "\t";
                str += skradzione[i].value.ToString() + "\t";
                str += skradzione[i].ratio.ToString() + "\n";
            }
            return str;
        }
    }
}