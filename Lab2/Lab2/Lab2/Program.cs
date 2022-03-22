using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("plik");
            students = JsonConvert.DeserializeObject<Lista<Student>>(json);
        }
    }
}
