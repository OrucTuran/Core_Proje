﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Skill List";
            ViewBag.v2 = "Skills";
            ViewBag.v3 = "Skill List";
            var values = skillManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "Add Skills";
            ViewBag.v2 = "Skills";
            ViewBag.v3 = "Add Skills";
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteSkill(int id)
        {
            var values = skillManager.TGetByID(id);
            skillManager.TDelete(values);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.v1 = "Skill Update";
            ViewBag.v2 = "Skills";
            ViewBag.v3 = "Skill Update";
            var values = skillManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction(nameof(Index));
        }
    }
}