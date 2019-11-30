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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public MealPlanController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult RequestMealPlan()
        {
            return View();
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}