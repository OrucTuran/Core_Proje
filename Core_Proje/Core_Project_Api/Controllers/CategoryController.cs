using Core_Project_Api.DAL.ApiContext;
using Core_Project_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public Context context = new Context();

        [HttpGet]
        public IActionResult GetCagegoryList()
        {
            return Ok(context.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetID(int id)
        {
            var value = context.Categories.Find(id);

            if (value.Equals(null))
                return NotFound();
            return Ok(value);

        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            context.Add(p);
            context.SaveChanges();
            return Created("", p);
        }
        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            var value = context.Categories.Find(id);
            if (value.Equals(null))
                return NotFound();
            else
            {
                context.Remove(value);
                context.SaveChanges();
                return NoContent();
            }
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category p)
        {
            var value = context.Find<Category>(p.CategoryID);
            if (value.Equals(null))
                return NotFound();
            else
            {
                value.CategoryName = p.CategoryName;
                context.Update(value);
                context.SaveChanges();
                return Ok(value);
            }
        }
    }

}
