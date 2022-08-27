using HotChocolate.Execution.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Recipe.API.GraphQL
{
    public static class Configuration
    {
        public static IRequestExecutorBuilder AddConfiguration(this IRequestExecutorBuilder builder)
        {
            return builder

            # region Recipe

            .AddObjectType<Recipe.Data.Entity.Recipe>(x => {
                x.Description("A Recipe");
                x.Ignore(d => d.ImageData);
                x.Field("monkey").Resolve(m => "monkey man");
            })
            .AddQueryType(x => {
                // This can be created like a controller
                x.Name("GetRecipes").Description("Gets the recipes");
                
                // More than one top level field can be defined here, as if it were a separate controller action

                x.Field("recipe")
                    .Description("Recipes")
                        .Argument("title", (t) => {
                    t.Type<NonNullType<StringType>>();
                })
                .Resolve((ctx, ct) => {
                    var title = ctx.ArgumentValue<string>("title");
                    return ctx.Service<Recipe.Data.Context>().Recipes
                        .Where(r => r.Title == title)
                        .Include(r => r.Instructions);
                });
            });
            # endregion
        }
    }
}