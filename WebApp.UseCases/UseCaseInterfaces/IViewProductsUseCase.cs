using WebApp.Model;

namespace WebApp.UseCases.UseCaseInterfaces
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute();
        IEnumerable<Product> Search(string name);
    }
}