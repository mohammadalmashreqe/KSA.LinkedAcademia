using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSA.LinkedAcademia.Models
{
    public class Class
    {
        public int Id { set; get; }
        public Student Creator { set; get; }

        public List<Student> Students { set; get;  }

    }
}
