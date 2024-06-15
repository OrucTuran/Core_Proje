using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.a1 = c.Skills.Count();
            ViewBag.a2 = c.Messages.Where(x => x.Status == false).Count();
            ViewBag.a3 = c.Messages.Where(x => x.Status == true).Count();
            ViewBag.a4 = c.Experiences.Count();
            return View();
        }
    }
}
