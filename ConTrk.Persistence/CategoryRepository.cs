using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ConTrk.Persistence
{
    public class CategoryRepository : RepositoryBase
    {
        public override string GetTableName() => "category";

        public void InsertCategory(CategoryDbo category)
        {
            var all = GetAllCategories();
            if (all.Any(c => c.Name.ToUpperInvariant() == category.Name.ToUpperInvariant() && c.ParentId == category.ParentId && c.UnitName == category.UnitName))
            {
                throw new DuplicateNameException("Ayynen bu isimde bir kategori zaten var!");
            }

            Insert(category);
        }
        
        public List<CategoryDbo> GetAllCategories()
        {
            return GetAllAsList<CategoryDbo>();
        }
    }
}
