namespace ConTrk.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
    }
}
