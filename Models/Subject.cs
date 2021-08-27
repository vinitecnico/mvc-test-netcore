using System;
using System.Collections.Generic;

namespace MvcTest.Models
{
     public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public virtual Course Course { get; set; }

    }
}