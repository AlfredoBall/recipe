using Microsoft.EntityFrameworkCore;
using Recipe.Data;

namespace Recipe.API.Resolvers
{
    public class RecipeResolver
    {
        public IQueryable<Recipe.Data.Entity.Recipe> GetRecipes([ScopedService] Context context)
        {
            return context.Recipes.Include(r => r.Ingredients);
        }

        public IQueryable<Recipe.Data.Entity.Ingredient> GetIngredients([ScopedService] Context context, [Parent]Recipe.Data.Entity.Recipe parent)
        {
            return context.Ingredients.Where(i => i.Recipe.ID == parent.ID);
        }
    }
}