using ConTrk.Business;
using ConTrk.Entities;
using System.Collections.ObjectModel;

namespace ConTrk.UI
{
    public class CategoryList : ObservableCollection<Category>
    {
        public CategoryList()
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            var list = categoryBusiness.GetCategoryList();
            foreach (var category in list)
            {
                Add(category);
            }
        }
    }
}
