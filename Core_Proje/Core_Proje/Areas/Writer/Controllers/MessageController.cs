using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> ReceiverMessage(string p)
        {
            WriterUser values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            List<WriterMessage> messageList = writerMessageManager.GetListReceiverMessages(p);
            return View(messageList);
        }
        public async Task<IActionResult> SenderMessage(string p)
        {
            WriterUser values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            List<WriterMessage> messageList = writerMessageManager.GetListSenderMessages(p);
            return View(messageList);
        }
        public IActionResult MessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetByID(id);
            return View(writerMessage);
        }
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetByID(id);
            return View(writerMessage);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            WriterUser values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            Context c = new Context();
            var userNameSurname = c.Users.Where(x => x.Email.Equals(p.Receiver)).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = userNameSurname;
            writerMessageManager.TAdd(p);
            return RedirectToAction(nameof(SenderMessage), "Message");
        }
    }
}
