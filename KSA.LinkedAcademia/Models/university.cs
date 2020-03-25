using System;
using System.Collections.Generic;

namespace KSA.LinkedAcademia.Models
{
    public partial class University
    {
        public University()
        {
            Class = new HashSet<Class>();
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Class> Class { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
