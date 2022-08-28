using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Data.Entity
{
    public class PlanItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PlanItem_ID")]
        public Nullable<int> ID { get; set; }
        public string Text { get; set; }
        public PlanItemType Type { get; set; }
    }

    public enum PlanItemType
    {
        GroceryList,
        Kitchen
    }
}