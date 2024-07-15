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
        [UseFiltering]
        [UseSorting]
        [GraphQLName("GetRecipes")]
        public IQueryable<Recipe.Data.Entity.Recipe> GetRecipes([ScopedService] Context context)
        {
            var yar = context.Recipes.Include(r => r.Ingredients).ToList();
            return yar.AsQueryable();
        }
    }
}