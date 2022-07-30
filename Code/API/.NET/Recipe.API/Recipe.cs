using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.API.Data
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Recipe_ID")]
        public Nullable<int> ID { get; set; }
        public string Title { get; set; }
        public string? ImageData { get; set; }
        public IList<Instruction> Instructions { get; set; } = new List<Instruction>();
        public IList<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }

    public class Instruction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Instruction_ID")]
        public Nullable<int> ID { get; set; }
        public string Text { get; set;}
    }

    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Ingredient_ID")]
        public Nullable<int> ID { get; set; }
        public int Order { get; set; }
        public string Text { get; set;}
    }
}