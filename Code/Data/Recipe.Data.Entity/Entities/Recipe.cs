using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Recipe.Data.Entity
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Recipe_ID")]
        public Nullable<int> ID { get; set; }
        public string Title { get; set; }
        public string? ImageData { get; set; }
        public ICollection<Instruction> Instructions { get; set; } = new List<Instruction>();
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}