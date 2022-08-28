using HotChocolate.Execution.Configuration;
using Microsoft.EntityFrameworkCore;
using Recipe.API.Resolvers;

namespace Recipe.API.GraphQL
{
    public static class Configuration
    {
        public static IRequestExecutorBuilder AddConfiguration(this IRequestExecutorBuilder builder)
        {
            return builder

            # region Recipe
            
            

            .AddObjectType<Recipe.Data.Entity.Recipe>(x => {
                x.Field(r => r.Ingredients)
                // .UseDbContext<Recipe.Data.Context>()
                // .ResolveWith<RecipeResolver>(r => r.GetIngredients(default!, default!))
                .UseProjection().UseFiltering().UseSorting();


                // x.Description("A Recipe");
                // // x.Name("recipe");
                // x.Ignore(d => d.ImageData);
                // x.Field("monkey") .Resolve(m => "monkey man");
                // x.Field("recipe").Resolve(r => "blup blup");
            })
            // .TryAddTypeInterceptor<FilterCollectionTypeInterceptor>()
            // .AddQueryType<RecipeQuery>(x => {
            //     x.Field(c => c.)
            // })
            .AddQueryType(x => {
                // This can be created like a controller
                x.Name("GetRecipes").Description("Gets the recipes");
                
                // More than one top level field can be defined here, as if it were a separate controller action

                // x.Field("plan").Description("Plan Items")
                // .Resolve((ctx, ct) => {
                //     return ctx.Service<Recipe.Data.Context>().Planning;
                // });

                x.Field("recipe").Description("Recipes")
                //         .Argument("title", (t) => {
                //     t.Type<NonNullType<StringType>>();
                // })
                .Use(next => async context => {
                    await next(context);
                })
                .UseDbContext<Recipe.Data.Context>()
                .ResolveWith<RecipeResolver>(r => r.GetRecipes(default!))
                .UsePaging()
                .UseProjection()
                .UseFiltering()
                .UseSorting();

                // x.Field("ingredients").Description("Ingredients")
                // .UseDbContext<Recipe.Data.Context>()
                // .ResolveWith<RecipeResolver>(r => r.GetIngredients(default!, default!))
                // .UsePaging()
                // .UseProjection();
                // .Resolve((ctx, ct) => {
                //     using (var scope = ctx.Services.CreateScope())
                //     {
                //         return scope.ServiceProvider.GetRequiredService<Recipe.Data.Context>().Recipes
                //         .Include(r => r.Instructions)
                //         .Include(r => r.Ingredients);
                //     }
                //     // var title = ctx.ArgumentValue<string>("title");
                //     // return ctx.Service<Recipe.Data.Context>().Recipes
                //     //     .Include(r => r.Instructions)
                //     //     .Include(r => r.Ingredients);
                // });
            });
            # endregion
        }
    }
}