using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSA.LinkedAcademia.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Email { set; get; }
        public string Fname { set; get; }
        public string Lname { set; get; }
        public University university { set; get; }
        public bool IsTeacher { set; get; }
    }
}
