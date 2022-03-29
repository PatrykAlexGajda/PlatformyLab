using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Student
    {
        public int ID { set; get; }
        public string name { set; get; }
        public float avg { set; get; }

        public override string ToString()
        {
            return ID + ": " + name + ": " + avg.ToString();
        }
    }
}