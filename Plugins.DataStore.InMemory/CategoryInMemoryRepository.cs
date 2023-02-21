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
                new Category{ Id = 1, Name = "Food", Description = "Food" },
                new Category{ Id = 2, Name = "Food", Description = "Food" },
                new Category{ Id = 3, Name = "Food", Description = "Food" },
            };
        }

        public IEnumerable<Category> GetCategories() 
        {
            return categories;
        }
    }
}
