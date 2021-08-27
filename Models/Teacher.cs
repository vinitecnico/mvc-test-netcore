using System;
using System.Collections.Generic;

namespace MvcTest.Models
{
     public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Decimal Salary  { get; set; }

        public virtual Teacher Course { get; set; }

    }
}
