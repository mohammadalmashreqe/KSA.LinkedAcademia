using System;
using System.Collections.Generic;

namespace KSA.LinkedAcademia.Models
{
    public partial class Chat
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int? ClassId { get; set; }
        public int? StudentId { get; set; }
        public DateTime? MessageDateTime { get; set; }
        public string SenderName { get; set; }
    }
}
