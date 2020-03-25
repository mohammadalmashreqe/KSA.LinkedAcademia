using System;
using System.Collections.Generic;

namespace KSA.LinkedAcademia.Models
{
    public partial class Student
    {
        public Student()
        {
            Class = new HashSet<Class>();
            ClassStudents = new HashSet<ClassStudents>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? UniversityId { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }

        public University University { get; set; }
        public ICollection<Class> Class { get; set; }
        public ICollection<ClassStudents> ClassStudents { get; set; }
    }
}
