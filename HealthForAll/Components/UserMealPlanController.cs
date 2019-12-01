using HealthForAll.Data;
using HealthForAll.Models;
using HealthForAll.Models.RestModels.UserMealsRestModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthForAll.Components
{
    [Route("api/[controller]")]
    public class UserMealPlanController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserMealPlanController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUserMealRestModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is null)
                return BadRequest();
            if (ModelState.IsValid)
            {
                var meal = _context.Meals.Where(m => m.Id.Equals(model.MealId)).FirstOrDefault();
                if (meal is null)
                    return BadRequest();
                var domainModel = new UserMeal
                {
                    Id = Guid.NewGuid().ToString(),
                    FoodName = meal.FoodName,
                    Carbohydrate = meal.Carbohydrate,
                    Liqids = meal.Liqids,
                    Protein = meal.Protein,
                    Fibre = meal.Fibre,
                    Energy = meal.Energy,
                    Category = meal.Category,
                    Price = meal.Price,
                    Budget = model.BudgetAmount,
                    Dependaents = model.Dependents,
                    MealDate = model.MealDate,
                    User = user
                };
                _context.Add(domainModel);
                await _context.SaveChangesAsync();
                domainModel.User = null;
                return Ok(domainModel);
            }
            return BadRequest();
        }
    }
}
