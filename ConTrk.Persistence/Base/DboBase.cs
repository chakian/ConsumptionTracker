using SQLite;

namespace ConTrk.Persistence
{
    public class DboBase
    {
        public DboBase() { }
        
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
    }
}
