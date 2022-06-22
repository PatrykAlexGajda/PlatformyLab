using Microsoft.VisualStudio.TestTools.UnitTesting;
using Knapsack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testy
{
    [TestClass]
    public class UnitTest1
    {
        // Test sprawdza czy obiekt generator posiada liste o okreslonej
        // ilosci wartosci 
        [TestMethod]
        public void TestMethod1()
        {
            List<Przedmiot> przedmioty = new List<Przedmiot>();
            Generator generator = new Generator(20, 3);
            Assert.AreEqual(20, generator.weights.Count());
        }

        // Test sprawdza czy algorytm daje lepsze rezultaty niz
        // zabranie pierwszych przedmiotow z brzegu
        [TestMethod]
        public void TestMethod2()
        {
            int temp = 0;
            List<Przedmiot> przedmioty = new List<Przedmiot>();
            Generator generator = new Generator(20, 3);
            Przedmiot przedmiot = new Przedmiot();
            Plecak plecak = new Plecak(50);
            przedmioty = przedmiot.buduj(20, przedmiot, generator);
            przedmioty[0].sort(przedmioty);
            plecak.rabuj(plecak, przedmioty);
            for (int i = 0; i < plecak.skradzione.Count(); i++) 
            {
                temp += przedmioty[i].value;
            }
            if (plecak.wartosc < temp) Assert.Fail();
        }


        // Czy liczba wygenerowanych przedmiotow jest rowna liczbie zbudowanych
        // Czy funkcja buduj poprawnie dziala
        [TestMethod]
        public void TestMethod3()
        {
            List<Przedmiot> przedmioty = new List<Przedmiot>();
            Generator generator = new Generator(20, 3);
            Przedmiot przedmiot = new Przedmiot();
            przedmioty = przedmiot.buduj(20, przedmiot, generator);
            Assert.AreEqual(generator.weights.Count(), przedmioty.Count());
        }

        // Czy przedmiot wziety z puli jest rowny przedmiotowi wlasnie dodanemu do plecaka
        // Czy dodanie do plecak przebieglo pomyslnie
        [TestMethod]
        public void TestMethod4()
        {
            List<Przedmiot> przedmioty = new List<Przedmiot>();
            Generator generator = new Generator(20, 3);
            Przedmiot przedmiot = new Przedmiot();
            przedmioty = przedmiot.buduj(20, przedmiot, generator);
            Plecak plecak = new Plecak(10000);
            
            for(int i = 0; i < przedmioty.Count(); i++)
            {   
                plecak.doPlecaka(przedmioty[i]);
                Assert.AreEqual(przedmioty[i], plecak.skradzione[i]) ;
            }
        }
    }
}
