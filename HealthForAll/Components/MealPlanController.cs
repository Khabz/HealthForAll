using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthForAll.Data;
using HealthForAll.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthForAll.Components
{
    [Route("api/[controller]")]
    public class MealPlanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealPlanController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var meals = _context.Meals.ToList();
            if(meals is null)
            {
                return NotFound();
            }
            return Ok(meals.Take(5));
        }
    }
}