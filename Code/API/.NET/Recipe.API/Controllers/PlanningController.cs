using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipe.API.Data;

namespace Recipe.API.Controllers;

[ApiController]
[Route("api/planning")]
public class PlanningController : ControllerBase
{
    // private readonly RecipeContext _context;

    // public PlanningController(Recipe.API.Data.RecipeContext context)
    // {
    //     _context = context;
    // }

    // [HttpGet]
    // [Route("groceryList")]
    // public IEnumerable<Recipe.API.Data.Ingredient> GetGroceryList()
    // {
    //     return _context.Planning.Where(planItem => planItem.Type == PlanItemType.GroceryList).Select(planItem => new Ingredient{
    //         Text = planItem.Text
    //     }).ToList();
    // }

    // [HttpGet]
    // [Route("kitchen")]
    // public IEnumerable<Recipe.API.Data.Ingredient> GetKitchen()
    // {
    //     return _context.Planning.Where(planItem => planItem.Type == PlanItemType.Kitchen).Select(planItem => new Ingredient{
    //         Text = planItem.Text
    //     }).ToList();
    // }

    // // TODO Refactor
    // [HttpPost]
    // public Recipe.API.Data.Recipe Post(Recipe.API.Data.Recipe recipe)
    // {
    //     var existingRecipe = _context.Recipes.Where(r => r.Title == recipe.Title).SingleOrDefault();

    //     if (existingRecipe != null)
    //     {
    //         _context.Remove(existingRecipe);

    //         _context.SaveChanges();
    //     }
        
    //     recipe.ID = null;
    //     _context.Recipes.Add(recipe);

    //     _context.SaveChanges();

    //     return recipe;
    // }
}