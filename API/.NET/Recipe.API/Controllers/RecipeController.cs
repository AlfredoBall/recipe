using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipe.API.Data;

namespace Recipe.API.Controllers;

[ApiController]
[Route("api/recipe")]
public class RecipeController : ControllerBase
{
    // private readonly RecipeContext _context;

    // public RecipeController(Recipe.API.Data.RecipeContext context)
    // {
    //     _context = context;
    // }

    // [HttpGet]
    // public IEnumerable<Recipe.API.Data.Recipe> Get()
    // {
    //     // TODO https://docs.microsoft.com/en-us/ef/core/querying/raw-sql
    //     return _context.Recipes.Include(recipe => recipe.Instructions).Include(recipe => recipe.Ingredients).ToArray();

    //     // return _context.Recipes.ToArray();
    //     // return Enumerable.Range(1, 5).Select(index => new Recipe.API.Data.Recipe
    //     // {
    //     //     ID = 12345,
    //     //     Title = "test title"
    //     // })
    //     // .ToArray();
    // }

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