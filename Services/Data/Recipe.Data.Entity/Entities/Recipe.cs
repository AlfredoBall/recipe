using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Data.Entity
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Recipe_ID")]
        public Nullable<int> ID { get; set; }
        public string Title { get; set; }
        public string? ImageData { get; set; }

        public IList<Instruction> Instructions { get; set; } = new List<Instruction>();

        [UseFiltering]
        [UseSorting]
        public IList<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}