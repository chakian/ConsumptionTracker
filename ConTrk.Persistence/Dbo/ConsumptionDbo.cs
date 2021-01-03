using SQLite;

namespace ConTrk.Persistence
{
    [Table("consumption")]
    public class ConsumptionDbo
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("unit_count")]
        public decimal UnitCount { get; set; }
    }
}
