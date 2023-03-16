using WebApp.Model;

namespace WebApp.UseCases.UseCaseInterfaces
{
    public interface IAddCategoryUseCase
    {
        void Execute(Category category);
    }
}