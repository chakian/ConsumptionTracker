using SQLite;
using System;

namespace ConTrk.Persistence
{
    [Table("consumption")]
    public class ConsumptionDbo : DboBase
    {
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("unit_count")]
        public decimal UnitCount { get; set; }
    }
}
