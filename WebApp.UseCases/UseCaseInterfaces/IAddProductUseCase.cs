using WebApp.Model;

namespace WebApp.UseCases.UseCaseInterfaces
{
    public interface IAddProductUseCase
    {
        void Execute(Product product);
    }
}