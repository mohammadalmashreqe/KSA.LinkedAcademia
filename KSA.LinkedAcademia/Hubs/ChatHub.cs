using KSA.LinkedAcademia.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSA.LinkedAcademia.Hubs
{



    public class ChatHub : Hub
    {
        private readonly KSALinkedAcademiaContext _context;

        public ChatHub(KSALinkedAcademiaContext kSALinkedAcademiaContext)
        {
            _context = kSALinkedAcademiaContext;

        }
        public async Task SendMessage(int classID, string message, int studentId, string studentname)
        {
            Chat chat = new Chat
            {
                ClassId = classID,
                StudentId = studentId,
                Message = message,
                MessageDateTime = DateTime.Now,
                SenderName=studentname

            };
            _context.Add(chat);
            _context.SaveChanges();
            await Clients.All.SendAsync("ReceiveMessage", classID, message,studentname);
        }
    }
}
