using WebApp.Model;

namespace WebApp.UseCases.UseCaseInterfaces
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
        IEnumerable<Category> Search(string name);
    }
}