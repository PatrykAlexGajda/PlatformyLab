using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lab2
{
    public class University : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
    }
}