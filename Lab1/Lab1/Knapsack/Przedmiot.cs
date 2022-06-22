using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    // Klasa opisujaca obiekt pojedynczego przedmiot ktory ma w sobie
    // zapisana wage, wartosc oraz stosunek wartosci do wagi
    public class Przedmiot
    {
        public int weight;
        public int value;
        public double ratio;
        public Przedmiot() 
        {
            weight = 0;
            value = 0;
            ratio = 0;
        }

        // Funkcja przypisuje przedmiotowi odpowiednie trzy wartosci
        // na podstawie konkretnego indeksu w obiekcie generator
        public Przedmiot SetValues(int index, Generator generator)
        {
            Przedmiot val = new Przedmiot();
            val.weight = generator.weights[index];
            val.value = generator.values[index];
            if (val.weight == 0)
            {
                Console.WriteLine("Error: dividing by zero.");
            }
            else 
            {
                val.ratio = (double)val.value / (double)val.weight;
                val.ratio = Math.Round(val.ratio, 3);
            }
            return val;
        }
        
        // Przeciazenie funkcji toString w celu wypisywania wszystkich
        // informacji jednego przedmiotu
        public override string ToString()
        {
            string str = "Weight: ";
            str = str + string.Join(" ", weight);
            str = str + " Value: ";
            str = str + string.Join(" ", value);
            str = str + " Ratio: ";
            str = str + string.Join(" ", ratio);
            return str;
        }

        // Sortowanie listy przedmiotow po ich stosunku wartosci do wagi
        public void sort(List<Przedmiot> przedmioty) 
        {
            var enum1 = from przedmiot in przedmioty
                        orderby przedmiot.ratio descending
                        select przedmiot;

            int i = 0;
            foreach (var e in enum1){
                przedmioty[i] = e;
                i++;
            }
        }

        // Buduje liste przedmiotow na podstawie danego generatora
        public List<Przedmiot> buduj(int n, Przedmiot przedmiot, Generator generator) 
        {
            List<Przedmiot> newList = new List<Przedmiot>();

            for (int i = 0; i < n; i++) 
            {
                newList.Add(przedmiot.SetValues(i, generator));
            }

            return newList;
        }
    }
}