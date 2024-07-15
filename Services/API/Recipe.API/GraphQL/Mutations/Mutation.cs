using Microsoft.EntityFrameworkCore;
using Recipe.Data;

namespace Recipe.API.GraphQL
{
    public class Mutation
    {
        // TODO Remove the ID
        [UseDbContext(typeof(Context))]
        [GraphQLName("AddRecipe")]
        public async Task<Recipe.Data.Entity.Recipe> AddRecipe([ScopedService] Context context, Recipe.Data.Entity.Recipe recipe)
        {
            var existingRecipe = context.Recipes.Where(r => r.Title == recipe.Title).SingleOrDefault();

            if (existingRecipe != null)
            {
                context.Remove(existingRecipe);

                await context.SaveChangesAsync();
            }

            recipe.ID = null;
            context.Recipes.Add(recipe);

            await context.SaveChangesAsync();

            return recipe;
        }
    }
}
