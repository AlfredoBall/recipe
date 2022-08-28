using Microsoft.EntityFrameworkCore;
using Recipe.Data;

namespace Recipe.API.Resolvers
{
    public class RecipeResolver
    {
        public IQueryable<Recipe.Data.Entity.Recipe> GetRecipes([ScopedService] Context context)
        {
            var yar = context.Recipes.Include(r => r.Ingredients).ToList();
            return context.Recipes.Include(r => r.Ingredients).ToList().AsQueryable();
        }

        public IQueryable<Recipe.Data.Entity.Ingredient> GetIngredients([ScopedService] Context context, [Parent]Recipe.Data.Entity.Recipe parent)
        {
            return context.Ingredients;
        }
    }
}