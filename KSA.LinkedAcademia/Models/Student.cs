using System;
using System.Collections.Generic;

namespace KSA.LinkedAcademia.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? UniversityId { get; set; }
        public int? ClassId { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }

        public University University { get; set; }
    }
}
