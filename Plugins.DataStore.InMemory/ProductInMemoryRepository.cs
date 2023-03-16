using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model;
using WebApp.UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;
        public ProductInMemoryRepository() 
        {
            // Default value
            products = new List<Product>()
            {
                new Product{ ProductId = 1, CategoryId = 1, Name = "Trà Lipton", Quantity = 100, Price = 50000 },
                new Product{ ProductId = 2, CategoryId = 2, Name = "Chân gà xả tắc", Quantity = 50, Price = 100000 },
                new Product{ ProductId = 3, CategoryId = 3, Name = "Móc khóa Hust", Quantity = 100, Price = 20000 },
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (products != null && products.Count > 0)
            {
                var maxId = products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }
            products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductById(product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
            }
        }
        public Product GetProductById(int productId)
        {
            return products.FirstOrDefault(x => x.ProductId == productId);
        }
        public void DeleteProduct(int productId)
        {
            //products?.Remove(GetProductById(productId));
            var productToDelete = GetProductById(productId);
            if (productToDelete != null) products.Remove(productToDelete);
        }
        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return products.Where(x => x.CategoryId == categoryId);
        }
        public IEnumerable<Product> Search(string name)
        {
            //if (string.IsNullOrWhiteSpace(category))
            //    return db.Categories.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            //else
            return products.Where(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));

        }
    }
}
