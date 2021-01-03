using System.Collections.Generic;

namespace ConTrk.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }

        public List<Category> Children { get; set; }

        public override string ToString() => Name;
    }
}
