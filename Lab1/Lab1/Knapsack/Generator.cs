using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    // Klasa opisujaca obiekt o polach weights i values bedacyh listami.
    // Na podstawie seeda generuje okreslone wartosci i z danych tego 
    // obiektu korzysta klasa odpowiedzialna za przedmioty mozliwe do
    // zrabowania
    public class Generator
    {
        public List<int> weights;
        public List<int> values;

        // Konstruktor generuje listy o danej dlugosci na bazie okreslonego seeda
        public Generator(int n, int seed)
        {
            weights = new List<int>();
            values = new List<int>();
            Random random = new Random(seed);
            for (int i = 0; i < n; i++)
            {
                weights.Add(random.Next(1, 40));
                values.Add(random.Next(1, 1000));
            } 
        }
    }
}