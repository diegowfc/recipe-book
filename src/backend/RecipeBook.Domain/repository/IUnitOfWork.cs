namespace RecipeBook.Domain.repository;

public interface IUnitOfWork
{
    Task Commit();
}
