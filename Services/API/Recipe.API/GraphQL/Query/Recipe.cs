using Microsoft.EntityFrameworkCore;
using Recipe.Data.Entity;
using Recipe.Data;

namespace Recipe.API.GraphQL
{
    public class RecipeQuery
    {
        [UseDbContext(typeof(Context))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        [UseProjection]
        public IQueryable<Recipe.Data.Entity.Recipe> GetRecipes([ScopedService] Context context)
        {
            return context.Recipes;
        }
    }
}