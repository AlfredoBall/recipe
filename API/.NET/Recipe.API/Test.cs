using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Data
{
    public class Test
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Test_ID")]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}