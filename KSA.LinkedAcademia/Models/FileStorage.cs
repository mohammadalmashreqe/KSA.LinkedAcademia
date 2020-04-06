using System;
using System.Collections.Generic;

namespace KSA.LinkedAcademia.Models
{
    public partial class FileStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int? ClassId { get; set; }
        public int? StudentId { get; set; }

        public Class Class { get; set; }
        public Student Student { get; set; }
    }
}
