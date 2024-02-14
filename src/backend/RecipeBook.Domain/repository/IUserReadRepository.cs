namespace RecipeBook.Domain.repository;

public interface IUserReadRepository
{
    Task<bool> IsRegistered(string email);
}
