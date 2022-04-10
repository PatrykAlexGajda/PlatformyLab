using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Data.Entity;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Currency currency = new Currency();
        public List<Student> students = new List<Student>();
        public Dictionary<string, float> dictCurr = new Dictionary<string, float>();
        public Dictionary<string, float> testDict = new Dictionary<string, float>();
        //public University context;

        public Form1()
        {
            InitializeComponent();
            //context = new University();
            //context.Students.Add(new Student { name = "Adam", avg = 4.0f });
            //context.Students.Add(new Student { name = "Czarek", avg = 5.0f });
            //context.Students.Add(new Student { name = "Pajac", avg = 2.0f });
            //context.SaveChanges();

            //foreach (Student s in context.Students)
            //    listBox1.Items.Add(s.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var json = GetCurrencyAsync();
            dictCurr = currency.rates;
        }

        private async Task<string> GetCurrencyAsync()
        {
            string call = "https://openexchangerates.org/api/historical/2013-02-16.json?app_id=b2c2808e40714b4b9eae3dd6a3e4f630";
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(call);
            currency = JsonConvert.DeserializeObject<Currency>(response);
            return response;
        }

        public string DictToString(Dictionary<string, float> dict)
        {
            string toString = "";
            foreach (string key in dict.Keys)
            {
                toString += key + "=" + dict[key];
            }
            return toString;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            listBox1.Items.Add(dictCurr["ANG"].ToString());
        }
    }
}