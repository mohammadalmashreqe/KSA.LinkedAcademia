using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KSA.LinkedAcademia.Models
{
    public partial class University
    {
        public University()
        {
            Student = new HashSet<Student>();
        }

     
        public int Id { get; set; }
        [Display (Name ="University Name")]
        public string Name { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}
