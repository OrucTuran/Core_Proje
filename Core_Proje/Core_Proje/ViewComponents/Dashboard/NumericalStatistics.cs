using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class NumericalStatistics : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.n1 = c.Portfolios.Count();
            ViewBag.n2 = c.Messages.Count();
            ViewBag.n3 = c.Services.Count();
            return View();
        }
    }
}
