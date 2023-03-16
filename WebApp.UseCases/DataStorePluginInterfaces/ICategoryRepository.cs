using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebApp.UseCases.DataStorePluginInterfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();

        void AddCategory (Category category);

        void UpdateCategory (Category category);

        Category GetCategoryById(int categoryId);

        void DeleteCategory (int categoryId);

        public IEnumerable<Category> Search(string name);
    }
}
