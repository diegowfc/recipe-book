using RecipeBook.Domain.model;

namespace RecipeBook.Domain.repository;

public interface IUserWriteRepository
{
    Task Save(User user);
}
