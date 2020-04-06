using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSA.LinkedAcademia.Models
{
    public class JoinViewModel
    {
        public List<Chat> Chats { set; get; }
        public List<Student> Students { set; get; }
        public List<FileStorage> FileStorages { set; get; }
        public int CreatorId { set; get; }
    }
}
