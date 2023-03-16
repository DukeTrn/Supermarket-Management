using WebApp.Model;

namespace WebApp.UseCases.UseCaseInterfaces
{
    public interface IGetProductByIdUseCase
    {
        Product Execute(int productId);
    }
}