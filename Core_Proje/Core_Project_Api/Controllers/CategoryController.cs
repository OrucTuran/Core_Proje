using Core_Project_Api.DAL.ApiContext;
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
    }

}
