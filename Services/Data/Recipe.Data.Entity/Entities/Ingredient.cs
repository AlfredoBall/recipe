    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace Recipe.Data.Entity;
    
    public class Ingredient
    {
        public Ingredient(){}

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Ingredient_ID")]
        public int ID { get; set; }
        public string Text { get; set; }
    }