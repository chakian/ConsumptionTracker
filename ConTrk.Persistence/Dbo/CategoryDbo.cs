using SQLite;

namespace ConTrk.Persistence
{
    [Table("category")]
    public class CategoryDbo
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("parent_id")]
        public int? ParentId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("unit_name")]
        public string UnitName { get; set; }
    }
}
