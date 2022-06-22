using System;
using Knapsack;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Zmienne pobierane z okien wpisywania aplikacji
            int seed = int.Parse(textBox3.Text);
            int n = int.Parse(textBox2.Text);
            int cap = int.Parse(textBox1.Text);

            List<Przedmiot> przedmioty = new List<Przedmiot>();
            Generator generator = new Generator(n, seed);
            Przedmiot przedmiot = new Przedmiot();
            Plecak plecak = new Plecak(cap);
            przedmioty = przedmiot.buduj(n, przedmiot, generator);
            przedmioty[0].sort(przedmioty);
            plecak.rabuj(plecak, przedmioty);

            // Wypisywanie w oknie pierwszym wybranych danych oraz calkowitej
            // wartosci przedmiotow skradzionych
            richTextBox1.Text = "Pojemnosc = " + cap + "\n";
            richTextBox1.Text += "Liczba Przedmiotów = " + n + "\n";
            richTextBox1.Text += "Seed = " + seed + "\n";
            richTextBox1.Text += "Skradziona wartosc: " + plecak.wartosc;

            // W dugim oknie wypisywana jest zawartosc plecaka
            // Wydruk zaczyna sie od dwoch linii informacyjnych 
            richTextBox2.Text = plecak.ToString();
        }
    }
}
