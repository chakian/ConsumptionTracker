using System.Collections.Generic;

namespace ConTrk.Persistence
{
    public class CategoryRepository : RepositoryBase
    {
        public void InsertCategory()
        {
            var category = new CategoryDbo
            {
                ParentId=null,
                Name="Ekmek",
                UnitName= null
            };
            _db.Insert(category);
        }

        public List<CategoryDbo> GetList()
        {
            var categories = _db.Query<CategoryDbo>("SELECT * FROM category");

            return categories;
        }
    }
}
