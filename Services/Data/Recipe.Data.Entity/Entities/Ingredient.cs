    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace Recipe.Data.Entity;
    
    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Ingredient_ID")]
        public Nullable<int> ID { get; set; }
        public string Text { get; set; }
        public Recipe Recipe { get; set; }
    }