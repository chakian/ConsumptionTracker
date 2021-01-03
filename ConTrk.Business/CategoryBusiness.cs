using ConTrk.Entities;
using ConTrk.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConTrk.Business
{
    public class CategoryBusiness
    {
        public void CreateCategory()
        {
            //CategoryRepository categoryRepository = new CategoryRepository();
            //categoryRepository.InsertCategory();
        }

        public void UpdateCategory()
        {
        }

        public void GetCategoryById(int id) { }

        public List<Category> GetCategoryList()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var list = categoryRepository.GetAllCategories();

            List<Category> categories = GetHierarchicalCategoryList(list, 0);

            return categories;
        }

        private List<Category> GetHierarchicalCategoryList(List<CategoryDbo> categoryDbos, int parentId)
        {
            List<Category> categories = new List<Category>();

            List<CategoryDbo> currentLevelDbos;
            if(parentId == 0)
            {
                currentLevelDbos = categoryDbos.Where(q => q.ParentId == null).ToList();
            }
            else
            {
                currentLevelDbos = categoryDbos.Where(q => q.ParentId == parentId).ToList();
            }

            foreach (var categoryDbo in currentLevelDbos)
            {
                categories.Add(new Category()
                {
                    Id = categoryDbo.Id,
                    Name = categoryDbo.Name,
                    ParentId = categoryDbo.ParentId,
                    UnitName = categoryDbo.UnitName,
                    Children = GetHierarchicalCategoryList(categoryDbos, categoryDbo.Id)
                });
            }

            return categories;
        }

        public void GetChildrenOfCategory(int id) { }

        public void GetParentsOfCategory(int id) { }
    }
}
