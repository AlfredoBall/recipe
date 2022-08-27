    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace Recipe.Data.Entity;
    
    public class Instruction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Instruction_ID")]
        public Nullable<int> ID { get; set; }
        public int Order { get; set; }
        public string Text { get; set;}
    }