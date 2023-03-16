using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model;
using WebApp.UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;

        public CategoryInMemoryRepository() 
        {
            // Default value
            categories= new List<Category>()
            {
                new Category{ Id = 1, Name = "Đồ uống", Description = "Đồ uống" },
                new Category{ Id = 2, Name = "Thức ăn", Description = "Thức ăn" },
                new Category{ Id = 3, Name = "Đồ lưu niệm", Description = "Đồ lưu niệm" },
            };
        }

        public IEnumerable<Category> GetCategories() 
        {
            return categories;
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (categories != null && categories.Count > 0)
            {
                var maxId = categories.Max(x => x.Id);
                category.Id = maxId + 1;
            }
            else
            {
                category.Id = 1;
            }
            categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.Id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            return categories.FirstOrDefault(x => x.Id == categoryId);

        }

        public void DeleteCategory (int categoryId)
        {
            categories?.Remove(GetCategoryById(categoryId));
        }

        public IEnumerable<Category> Search(string name)
        {
            //if (string.IsNullOrWhiteSpace(category))
            //    return db.Categories.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            //else
            return categories.Where(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
               
        }
    }
}
