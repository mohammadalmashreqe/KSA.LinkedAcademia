using System;
using System.Collections.Generic;

namespace KSA.LinkedAcademia.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassStudents = new HashSet<ClassStudents>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? UnivirsetyId { get; set; }
        public int? CreatorId { get; set; }

        public Student Creator { get; set; }
        public University Univirsety { get; set; }
        public ICollection<ClassStudents> ClassStudents { get; set; }
    }
}
