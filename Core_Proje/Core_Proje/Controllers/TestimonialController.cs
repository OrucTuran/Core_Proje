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
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var values = testimonialManager.TGetByID(id);
            testimonialManager.TDelete(values);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            var values = testimonialManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {
            testimonialManager.TUpdate(testimonial);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            testimonialManager.TAdd(testimonial);
            return RedirectToAction(nameof(Index));
        }
    }
}
