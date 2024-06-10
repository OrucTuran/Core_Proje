using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Portfolio List";
            ViewBag.v2 = "Portfolios";
            ViewBag.v3 = "Portfolio List";
            var values = portfolioManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.v1 = "Add Portfolios";
            ViewBag.v2 = "Portfolios";
            ViewBag.v3 = "Add Portfolios";
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            portfolioManager.TAdd(portfolio);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteSkill(int id)
        {
            var values = portfolioManager.GetByID(id);
            portfolioManager.TDelete(values);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.v1 = "Portfolio Update";
            ViewBag.v2 = "Portfolio";
            ViewBag.v3 = "Portfolio Update";
            var values = portfolioManager.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSkill(Portfolio portfolio)
        {
            portfolioManager.TUpdate(portfolio);
            return RedirectToAction(nameof(Index));
        }
    }
}
