using System;
using System.Collections.Generic;

namespace KSA.LinkedAcademia.Models
{
    public partial class ClassStudents
    {
        public int Id { get; set; }
        public int? ClassId { get; set; }
        public int? StudentId { get; set; }

        public Class Class { get; set; }
        public Student Student { get; set; }
    }
}
