using ConTrk.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConTrk.Business
{
    public class CategoryBusiness
    {
        public void CreateCategory() {
            CategoryRepository categoryRepository = new CategoryRepository();
            categoryRepository.InsertCategory();
        }

        public void UpdateCategory() { 
        }

        public void GetCategoryById(int id) { }

        public void GetCategoryList() {
            CategoryRepository categoryRepository = new CategoryRepository();
            var list = categoryRepository.GetList();
        }

        public void GetChildrenOfCategory(int id) { }

        public void GetParentsOfCategory(int id) { }
    }
}
