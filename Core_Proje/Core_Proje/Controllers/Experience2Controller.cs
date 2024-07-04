using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class Experience2Controller : Controller //ajax islemlerini yapacagimiz controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
        public IActionResult GetByID(int ExperienceID)
        {
            var values = experienceManager.TGetByID(ExperienceID);
            var findValues = JsonConvert.SerializeObject(values);
            return Json(findValues);
        }
        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetByID(id);
            experienceManager.TDelete(values);
            return NoContent();
        }
        [HttpPost]
        public IActionResult UpdateExperince([FromBody] Experience p)
        {
            if (p == null)
            {
                return BadRequest("Empty data was sent.");
            }

            var v = experienceManager.TGetByID(p.ExperienceID);
            if (v == null)
            {
                return NotFound($"Experience with ID {p.ExperienceID} not found.");
            }

            v.Name = p.Name;
            v.Date = p.Date;

            experienceManager.TUpdate(v);

            return Json(v);
        }
    }
}
