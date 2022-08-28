

namespace Recipe.API.GraphQL
{
    public class RecipeType : Recipe.Data.Entity.Recipe
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        new public virtual ICollection<Recipe.Data.Entity.Ingredient> Ingredients { get; set; } = new List<Recipe.Data.Entity.Ingredient>();

        new public virtual int ID { get; set; }
        new public virtual string Title { get { return base.Title; }  set {
            base.Title = value;
        }}
    }

}